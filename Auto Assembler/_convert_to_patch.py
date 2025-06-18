# pip3 install psutil
# py -3.12 _convert_to_patch.py Achievements.CEA > _patch.cs
import re
import psutil
from ctypes import *

# Регулярное выражение для парсинга строк
pattern = re.compile(r'^([0-9A-Fa-f]{8}):.*//\s*(\w+)\s*\((\d+)\)$', re.IGNORECASE)

def parse_file(filename):
    entries = []
    with open(filename, 'r') as f:
        for line in f:
            line = line.strip()
            match = pattern.match(line)
            if match:
                addr_str, name, count_str = match.groups()
                address = int(addr_str, 16)
                count = int(count_str)
                entries.append((address, name, count))
    return entries

def get_process_pid(process_name):
    for proc in psutil.process_iter(['pid', 'name']):
        if proc.info['name'].lower() == process_name.lower():
            return proc.info['pid']
    return None

def read_process_memory(pid, address, size):
    PROCESS_VM_READ = 0x0010
    process_handle = windll.kernel32.OpenProcess(PROCESS_VM_READ, False, pid)
    if not process_handle:
        return None
    
    buffer = (c_byte * size)()
    bytes_read = c_ulong(0)
    success = windll.kernel32.ReadProcessMemory(
        process_handle,
        address,
        buffer,
        size,
        byref(bytes_read)
    )
    windll.kernel32.CloseHandle(process_handle)
    
    if success and bytes_read.value == size:
        return bytearray(buffer)
    else:
        return None

def main():
    import sys
    if len(sys.argv) < 2:
        print("Использование: script.py <имя_файла>")
        return
    
    filename = sys.argv[1]
    entries = parse_file(filename)
    if not entries:
        print("Не найдено подходящих строк в файле.")
        return
    
    pid = get_process_pid('taz.exe')
    if not pid:
        print("Процесс taz.exe не найден.")
        return
    
    for address, name, count in entries:
        data = read_process_memory(pid, address, count)
        if data is None:
            print(f"Ошибка чтения {count} байт по адресу 0x{address:08X}")
            continue
        
        offset = address - 0x00400000
        bytes_str = ", ".join([f"0x{b:02X}" for b in data])
        print(f"file.Position = 0x{offset:X};\nbyte[] {name} = {{ {bytes_str} }};\nfile.Write({name}, 0, {name}.Length);\n")

if __name__ == "__main__":
    main()