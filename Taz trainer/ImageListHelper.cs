// Сгенерировано с помощью DeepSeek LLM
// Формирование изображений с эффектом размытия, обесцвечивания и затенения
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class ImageListHelper
{
    /// <summary>
    /// Типы эффектов для преобразования изображений
    /// </summary>
    public enum ImageEffect
    {
        /// <summary> Обесцвечивание (чёрно-белое) </summary>
        Grayscale,

        /// <summary> Затенение (затемнение) </summary>
        Shading,

        /// <summary> Комбинация обесцвечивания и затенения </summary>
        GrayscaleShading
    }

    /// <summary>
    /// Применяет выбранный эффект к изображению
    /// </summary>
    private static Bitmap ApplyImageEffect(Image original, ImageEffect effect, float shadingFactor = 0.6f)
    {
        Bitmap resultImage = new Bitmap(original.Width, original.Height);

        using (Graphics g = Graphics.FromImage(resultImage))
        using (ImageAttributes attributes = new ImageAttributes())
        {
            ColorMatrix colorMatrix;

            // Заменяем switch expression на классический switch
            switch (effect)
            {
                case ImageEffect.Grayscale:
                    colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0,      0,      0,      1, 0 },
                        new float[] { 0,      0,      0,      0, 1 }
                    });
                    break;

                case ImageEffect.Shading:
                    colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[] { shadingFactor, 0, 0, 0, 0 },
                        new float[] { 0, shadingFactor, 0, 0, 0 },
                        new float[] { 0, 0, shadingFactor, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });
                    break;

                case ImageEffect.GrayscaleShading:
                    colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[] { 0.299f * shadingFactor, 0.299f * shadingFactor, 0.299f * shadingFactor, 0, 0 },
                        new float[] { 0.587f * shadingFactor, 0.587f * shadingFactor, 0.587f * shadingFactor, 0, 0 },
                        new float[] { 0.114f * shadingFactor, 0.114f * shadingFactor, 0.114f * shadingFactor, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });
                    break;

                default:
                    colorMatrix = new ColorMatrix(); // Без изменений
                    break;
            }

            attributes.SetColorMatrix(colorMatrix);

            // Рисуем изображение с применением матрицы преобразования
            g.DrawImage(
                original,
                new Rectangle(0, 0, original.Width, original.Height),
                0, 0, original.Width, original.Height,
                GraphicsUnit.Pixel,
                attributes
            );
        }
        return resultImage;
    }

    /// <summary>
    /// Применяет размытие по Гауссу к изображению
    /// </summary>
    private static Bitmap ApplyGaussianBlur(Image image, int radius = 3)
    {
        if (radius < 1) radius = 1;
        if (radius > 10) radius = 10;

        using (Bitmap temp = new Bitmap(image))
        {
            // Блокируем биты изображения для прямого доступа к памяти
            Rectangle rect = new Rectangle(0, 0, temp.Width, temp.Height);
            BitmapData data = temp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bytes = Math.Abs(data.Stride) * data.Height;
            byte[] buffer = new byte[bytes];

            // Копируем данные пикселей в буфер
            Marshal.Copy(data.Scan0, buffer, 0, bytes);

            // Применяем размытие
            GaussianBlur(buffer, data.Width, data.Height, data.Stride, radius);

            // Копируем модифицированные данные обратно
            Marshal.Copy(buffer, 0, data.Scan0, bytes);
            temp.UnlockBits(data);

            return new Bitmap(temp);
        }
    }

    /// <summary>
    /// Реализация размытия по Гауссу с использованием свёртки
    /// </summary>
    private static void GaussianBlur(byte[] buffer, int width, int height, int stride, int radius)
    {
        // Создаём ядро Гаусса
        int kernelSize = radius * 2 + 1;
        double[] kernel = CreateGaussianKernel(kernelSize, radius / 3.0);

        byte[] result = new byte[buffer.Length];
        int pixelSize = 4; // 32bpp ARGB

        // Горизонтальный проход
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                double r = 0, g = 0, b = 0, a = 0;
                double weightSum = 0;

                for (int i = -radius; i <= radius; i++)
                {
                    int offsetX = x + i;
                    if (offsetX < 0 || offsetX >= width) continue;

                    int index = y * stride + offsetX * pixelSize;
                    double weight = kernel[i + radius];

                    b += buffer[index] * weight;
                    g += buffer[index + 1] * weight;
                    r += buffer[index + 2] * weight;
                    a += buffer[index + 3] * weight;
                    weightSum += weight;
                }

                int resultIndex = y * stride + x * pixelSize;
                result[resultIndex] = (byte)(b / weightSum);
                result[resultIndex + 1] = (byte)(g / weightSum);
                result[resultIndex + 2] = (byte)(r / weightSum);
                result[resultIndex + 3] = (byte)(a / weightSum);
            }
        }

        // Вертикальный проход
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                double r = 0, g = 0, b = 0, a = 0;
                double weightSum = 0;

                for (int i = -radius; i <= radius; i++)
                {
                    int offsetY = y + i;
                    if (offsetY < 0 || offsetY >= height) continue;

                    int index = offsetY * stride + x * pixelSize;
                    double weight = kernel[i + radius];

                    b += result[index] * weight;
                    g += result[index + 1] * weight;
                    r += result[index + 2] * weight;
                    a += result[index + 3] * weight;
                    weightSum += weight;
                }

                int bufferIndex = y * stride + x * pixelSize;
                buffer[bufferIndex] = (byte)(b / weightSum);
                buffer[bufferIndex + 1] = (byte)(g / weightSum);
                buffer[bufferIndex + 2] = (byte)(r / weightSum);
                buffer[bufferIndex + 3] = (byte)(a / weightSum);
            }
        }
    }

    /// <summary>
    /// Создаёт ядро Гаусса для эффекта размытия
    /// </summary>
    private static double[] CreateGaussianKernel(int size, double sigma)
    {
        double[] kernel = new double[size];
        double sum = 0;
        int half = size / 2;

        for (int i = 0; i < size; i++)
        {
            double x = i - half;
            kernel[i] = Math.Exp(-(x * x) / (2 * sigma * sigma));
            sum += kernel[i];
        }

        // Нормализуем ядро
        for (int i = 0; i < size; i++)
        {
            kernel[i] /= sum;
        }

        return kernel;
    }

    /// <summary>
    /// Добавляет обработанные версии изображений в ImageList
    /// </summary>
    public static void AddProcessedVersionsToImageList(
        ImageList imageList,
        ImageEffect effect = ImageEffect.Grayscale,
        float shadingFactor = 0.6f,
        int blurRadius = 0)
    {
        // Корректировка параметров
        shadingFactor = Math.Max(0.1f, Math.Min(1.0f, shadingFactor));
        blurRadius = Math.Max(0, Math.Min(10, blurRadius));

        // Собираем ключи оригинальных изображений
        var originalKeys = new List<string>();
        for (int i = 0; i < imageList.Images.Count; i++)
        {
            string key = imageList.Images.Keys[i];
            if (string.IsNullOrEmpty(key)) continue;
            originalKeys.Add(key);
        }

        // Создаём обработанные версии
        foreach (string key in originalKeys)
        {
            string processedKey = key.Replace(".png", "_lock.png");
            if (imageList.Images.ContainsKey(processedKey)) continue;

            Image original = imageList.Images[key];

            // Применяем основной эффект
            Bitmap processedImage = ApplyImageEffect(original, effect, shadingFactor);

            // Применяем размытие если нужно
            if (blurRadius > 0)
            {
                Bitmap blurred = ApplyGaussianBlur(processedImage, blurRadius);
                processedImage.Dispose();
                processedImage = blurred;
            }

            imageList.Images.Add(processedKey, processedImage);
        }
    }
}