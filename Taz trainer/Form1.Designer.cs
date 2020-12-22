namespace Taz_trainer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkIcons = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusField = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.invisibility = new System.Windows.Forms.CheckBox();
            this.superBelchCan = new System.Windows.Forms.CheckBox();
            this.superJump = new System.Windows.Forms.CheckBox();
            this.freezeLevelTimer = new System.Windows.Forms.CheckBox();
            this.savePos = new System.Windows.Forms.CheckBox();
            this.flyMode = new System.Windows.Forms.CheckBox();
            this.pictureTaz = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.disallowJump = new System.Windows.Forms.CheckBox();
            this.drawDistance = new System.Windows.Forms.CheckBox();
            this.debugMenu = new System.Windows.Forms.CheckBox();
            this.smoothLight = new System.Windows.Forms.CheckBox();
            this.loadPos = new System.Windows.Forms.CheckBox();
            this.gameSpeed = new System.Windows.Forms.CheckBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.trainerTab = new System.Windows.Forms.TabPage();
            this.patcherTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.nativeOptions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.gameFolder = new System.Windows.Forms.Button();
            this.buttonIcons = new System.Windows.Forms.ImageList(this.components);
            this.controls = new System.Windows.Forms.Button();
            this.audio = new System.Windows.Forms.Button();
            this.video = new System.Windows.Forms.Button();
            this.launcher = new System.Windows.Forms.Button();
            this.videoOptions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.changeResolution = new System.Windows.Forms.CheckBox();
            this.aspectRatio = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.aspect2 = new System.Windows.Forms.TextBox();
            this.aspect1 = new System.Windows.Forms.TextBox();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.height = new System.Windows.Forms.TextBox();
            this.width = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.windowed = new System.Windows.Forms.CheckBox();
            this.loadOptions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.language = new System.Windows.Forms.Label();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.noCD = new System.Windows.Forms.CheckBox();
            this.warningBanner = new System.Windows.Forms.CheckBox();
            this.disableDrawDistance = new System.Windows.Forms.CheckBox();
            this.disableVideos = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.play = new System.Windows.Forms.Button();
            this.patch = new System.Windows.Forms.Button();
            this.restore = new System.Windows.Forms.Button();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.infoText = new System.Windows.Forms.Label();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.gitHub = new System.Windows.Forms.Button();
            this.trainerSound = new System.Windows.Forms.CheckBox();
            this.tabsIcons = new System.Windows.Forms.ImageList(this.components);
            this.dbgMenuOff = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTaz)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            this.tabs.SuspendLayout();
            this.trainerTab.SuspendLayout();
            this.patcherTab.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.nativeOptions.SuspendLayout();
            this.tableLayoutPanel25.SuspendLayout();
            this.videoOptions.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            this.tableLayoutPanel29.SuspendLayout();
            this.loadOptions.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkIcons
            // 
            this.checkIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("checkIcons.ImageStream")));
            this.checkIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.checkIcons.Images.SetKeyName(0, "spookyeyes.png");
            this.checkIcons.Images.SetKeyName(1, "comicbomb.png");
            this.checkIcons.Images.SetKeyName(2, "beachball.png");
            this.checkIcons.Images.SetKeyName(3, "clock.png");
            this.checkIcons.Images.SetKeyName(4, "bombbit2.png");
            this.checkIcons.Images.SetKeyName(5, "eyeball.png");
            this.checkIcons.Images.SetKeyName(6, "baubleyellow.png");
            this.checkIcons.Images.SetKeyName(7, "bowlingball.png");
            this.checkIcons.Images.SetKeyName(8, "cloud.png");
            this.checkIcons.Images.SetKeyName(9, "speedsign.png");
            this.checkIcons.Images.SetKeyName(10, "flag.png");
            this.checkIcons.Images.SetKeyName(11, "flagexit.png");
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusField});
            this.statusStrip.Location = new System.Drawing.Point(0, 335);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(680, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            // 
            // statusField
            // 
            this.statusField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusField.Name = "statusField";
            this.statusField.Size = new System.Drawing.Size(137, 17);
            this.statusField.Text = "Welcome to Taz Hacked!";
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 3;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.pictureTaz, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel13, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(672, 290);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.invisibility, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.superBelchCan, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.superJump, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.freezeLevelTimer, 0, 3);
            this.tableLayoutPanel12.Controls.Add(this.savePos, 0, 5);
            this.tableLayoutPanel12.Controls.Add(this.flyMode, 0, 4);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 6;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(253, 290);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // invisibility
            // 
            this.invisibility.Appearance = System.Windows.Forms.Appearance.Button;
            this.invisibility.AutoSize = true;
            this.invisibility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invisibility.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.invisibility.ImageIndex = 0;
            this.invisibility.ImageList = this.checkIcons;
            this.invisibility.Location = new System.Drawing.Point(1, 1);
            this.invisibility.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.invisibility.Name = "invisibility";
            this.invisibility.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.invisibility.Size = new System.Drawing.Size(251, 47);
            this.invisibility.TabIndex = 1;
            this.invisibility.Text = "      F1 - Invisibility";
            this.invisibility.UseVisualStyleBackColor = false;
            this.invisibility.CheckedChanged += new System.EventHandler(this.invisibility_CheckedChanged);
            // 
            // superBelchCan
            // 
            this.superBelchCan.Appearance = System.Windows.Forms.Appearance.Button;
            this.superBelchCan.AutoSize = true;
            this.superBelchCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superBelchCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.superBelchCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.superBelchCan.ImageIndex = 1;
            this.superBelchCan.ImageList = this.checkIcons;
            this.superBelchCan.Location = new System.Drawing.Point(1, 49);
            this.superBelchCan.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.superBelchCan.Name = "superBelchCan";
            this.superBelchCan.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.superBelchCan.Size = new System.Drawing.Size(251, 47);
            this.superBelchCan.TabIndex = 2;
            this.superBelchCan.Text = "      F2 - Always burp";
            this.superBelchCan.UseVisualStyleBackColor = false;
            this.superBelchCan.CheckedChanged += new System.EventHandler(this.superBelchCan_CheckedChanged);
            // 
            // superJump
            // 
            this.superJump.Appearance = System.Windows.Forms.Appearance.Button;
            this.superJump.AutoSize = true;
            this.superJump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.superJump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.superJump.ImageIndex = 2;
            this.superJump.ImageList = this.checkIcons;
            this.superJump.Location = new System.Drawing.Point(1, 97);
            this.superJump.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.superJump.Name = "superJump";
            this.superJump.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.superJump.Size = new System.Drawing.Size(251, 47);
            this.superJump.TabIndex = 3;
            this.superJump.Text = "      F3 - Super jump";
            this.superJump.UseVisualStyleBackColor = false;
            this.superJump.CheckedChanged += new System.EventHandler(this.superJump_CheckedChanged);
            // 
            // freezeLevelTimer
            // 
            this.freezeLevelTimer.Appearance = System.Windows.Forms.Appearance.Button;
            this.freezeLevelTimer.AutoSize = true;
            this.freezeLevelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freezeLevelTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.freezeLevelTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.freezeLevelTimer.ImageIndex = 3;
            this.freezeLevelTimer.ImageList = this.checkIcons;
            this.freezeLevelTimer.Location = new System.Drawing.Point(1, 145);
            this.freezeLevelTimer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.freezeLevelTimer.Name = "freezeLevelTimer";
            this.freezeLevelTimer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.freezeLevelTimer.Size = new System.Drawing.Size(251, 47);
            this.freezeLevelTimer.TabIndex = 4;
            this.freezeLevelTimer.Text = "      F4 - Freeze timers";
            this.freezeLevelTimer.UseVisualStyleBackColor = false;
            this.freezeLevelTimer.CheckedChanged += new System.EventHandler(this.freezeLevelTimer_CheckedChanged);
            // 
            // savePos
            // 
            this.savePos.Appearance = System.Windows.Forms.Appearance.Button;
            this.savePos.AutoSize = true;
            this.savePos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savePos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.savePos.ImageIndex = 10;
            this.savePos.ImageList = this.checkIcons;
            this.savePos.Location = new System.Drawing.Point(1, 241);
            this.savePos.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.savePos.Name = "savePos";
            this.savePos.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.savePos.Size = new System.Drawing.Size(251, 49);
            this.savePos.TabIndex = 11;
            this.savePos.Text = "      Num1 - Save position";
            this.savePos.UseVisualStyleBackColor = false;
            // 
            // flyMode
            // 
            this.flyMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.flyMode.AutoSize = true;
            this.flyMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flyMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flyMode.ImageIndex = 8;
            this.flyMode.ImageList = this.checkIcons;
            this.flyMode.Location = new System.Drawing.Point(1, 193);
            this.flyMode.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.flyMode.Name = "flyMode";
            this.flyMode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flyMode.Size = new System.Drawing.Size(251, 47);
            this.flyMode.TabIndex = 9;
            this.flyMode.Text = "      Num5 - Fly mode";
            this.flyMode.UseVisualStyleBackColor = false;
            this.flyMode.CheckedChanged += new System.EventHandler(this.flyMode_CheckedChanged);
            // 
            // pictureTaz
            // 
            this.pictureTaz.Image = ((System.Drawing.Image)(resources.GetObject("pictureTaz.Image")));
            this.pictureTaz.Location = new System.Drawing.Point(506, 0);
            this.pictureTaz.Margin = new System.Windows.Forms.Padding(0);
            this.pictureTaz.Name = "pictureTaz";
            this.pictureTaz.Size = new System.Drawing.Size(165, 290);
            this.pictureTaz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureTaz.TabIndex = 1;
            this.pictureTaz.TabStop = false;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Controls.Add(this.disallowJump, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.drawDistance, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.debugMenu, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.smoothLight, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.loadPos, 0, 5);
            this.tableLayoutPanel13.Controls.Add(this.gameSpeed, 0, 4);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel13.Location = new System.Drawing.Point(253, 0);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 6;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(253, 290);
            this.tableLayoutPanel13.TabIndex = 1;
            // 
            // disallowJump
            // 
            this.disallowJump.Appearance = System.Windows.Forms.Appearance.Button;
            this.disallowJump.AutoSize = true;
            this.disallowJump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disallowJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disallowJump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.disallowJump.ImageIndex = 7;
            this.disallowJump.ImageList = this.checkIcons;
            this.disallowJump.Location = new System.Drawing.Point(1, 145);
            this.disallowJump.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.disallowJump.Name = "disallowJump";
            this.disallowJump.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.disallowJump.Size = new System.Drawing.Size(251, 47);
            this.disallowJump.TabIndex = 8;
            this.disallowJump.Text = "      F8 - Disallow jump";
            this.disallowJump.UseVisualStyleBackColor = false;
            this.disallowJump.CheckedChanged += new System.EventHandler(this.disallowJump_CheckedChanged);
            // 
            // drawDistance
            // 
            this.drawDistance.Appearance = System.Windows.Forms.Appearance.Button;
            this.drawDistance.AutoSize = true;
            this.drawDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawDistance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drawDistance.ImageIndex = 5;
            this.drawDistance.ImageList = this.checkIcons;
            this.drawDistance.Location = new System.Drawing.Point(1, 49);
            this.drawDistance.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.drawDistance.Name = "drawDistance";
            this.drawDistance.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.drawDistance.Size = new System.Drawing.Size(251, 47);
            this.drawDistance.TabIndex = 6;
            this.drawDistance.Text = "      F6 - Draw distance";
            this.drawDistance.UseVisualStyleBackColor = false;
            this.drawDistance.CheckedChanged += new System.EventHandler(this.drawDistance_CheckedChanged);
            // 
            // debugMenu
            // 
            this.debugMenu.Appearance = System.Windows.Forms.Appearance.Button;
            this.debugMenu.AutoSize = true;
            this.debugMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.debugMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.debugMenu.ImageIndex = 4;
            this.debugMenu.ImageList = this.checkIcons;
            this.debugMenu.Location = new System.Drawing.Point(1, 1);
            this.debugMenu.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.debugMenu.Name = "debugMenu";
            this.debugMenu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.debugMenu.Size = new System.Drawing.Size(251, 47);
            this.debugMenu.TabIndex = 5;
            this.debugMenu.Text = "      F5 - Debug menu";
            this.debugMenu.UseVisualStyleBackColor = false;
            this.debugMenu.CheckedChanged += new System.EventHandler(this.debugMenu_CheckedChanged);
            // 
            // smoothLight
            // 
            this.smoothLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.smoothLight.AutoSize = true;
            this.smoothLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smoothLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.smoothLight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smoothLight.ImageIndex = 6;
            this.smoothLight.ImageList = this.checkIcons;
            this.smoothLight.Location = new System.Drawing.Point(1, 97);
            this.smoothLight.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.smoothLight.Name = "smoothLight";
            this.smoothLight.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.smoothLight.Size = new System.Drawing.Size(251, 47);
            this.smoothLight.TabIndex = 7;
            this.smoothLight.Text = "      F7 - Smooth lighting";
            this.smoothLight.UseVisualStyleBackColor = false;
            this.smoothLight.CheckedChanged += new System.EventHandler(this.smoothLight_CheckedChanged);
            // 
            // loadPos
            // 
            this.loadPos.Appearance = System.Windows.Forms.Appearance.Button;
            this.loadPos.AutoSize = true;
            this.loadPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadPos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadPos.ImageIndex = 11;
            this.loadPos.ImageList = this.checkIcons;
            this.loadPos.Location = new System.Drawing.Point(1, 241);
            this.loadPos.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.loadPos.Name = "loadPos";
            this.loadPos.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.loadPos.Size = new System.Drawing.Size(251, 49);
            this.loadPos.TabIndex = 12;
            this.loadPos.Text = "      Num3 - Load position";
            this.loadPos.UseVisualStyleBackColor = false;
            // 
            // gameSpeed
            // 
            this.gameSpeed.Appearance = System.Windows.Forms.Appearance.Button;
            this.gameSpeed.AutoSize = true;
            this.gameSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gameSpeed.ImageIndex = 9;
            this.gameSpeed.ImageList = this.checkIcons;
            this.gameSpeed.Location = new System.Drawing.Point(1, 193);
            this.gameSpeed.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gameSpeed.Name = "gameSpeed";
            this.gameSpeed.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.gameSpeed.Size = new System.Drawing.Size(251, 47);
            this.gameSpeed.TabIndex = 10;
            this.gameSpeed.Text = "      -/= - Game speed";
            this.gameSpeed.UseVisualStyleBackColor = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.trainerTab);
            this.tabs.Controls.Add(this.patcherTab);
            this.tabs.Controls.Add(this.infoTab);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabs.ImageList = this.tabsIcons;
            this.tabs.ItemSize = new System.Drawing.Size(223, 37);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(0);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(0, 0);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(680, 335);
            this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabs.TabIndex = 0;
            this.tabs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabs_DrawItem);
            // 
            // trainerTab
            // 
            this.trainerTab.Controls.Add(this.tableLayoutPanel11);
            this.trainerTab.ImageIndex = 0;
            this.trainerTab.Location = new System.Drawing.Point(4, 41);
            this.trainerTab.Margin = new System.Windows.Forms.Padding(0);
            this.trainerTab.Name = "trainerTab";
            this.trainerTab.Size = new System.Drawing.Size(672, 290);
            this.trainerTab.TabIndex = 0;
            this.trainerTab.Text = "Trainer";
            // 
            // patcherTab
            // 
            this.patcherTab.Controls.Add(this.tableLayoutPanel21);
            this.patcherTab.ImageIndex = 1;
            this.patcherTab.Location = new System.Drawing.Point(4, 41);
            this.patcherTab.Margin = new System.Windows.Forms.Padding(0);
            this.patcherTab.Name = "patcherTab";
            this.patcherTab.Size = new System.Drawing.Size(672, 290);
            this.patcherTab.TabIndex = 1;
            this.patcherTab.Text = "Patcher";
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.ColumnCount = 1;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Controls.Add(this.tableLayoutPanel22, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.tableLayoutPanel26, 0, 1);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel21.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 2;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(672, 290);
            this.tableLayoutPanel21.TabIndex = 7;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 3;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.Controls.Add(this.nativeOptions, 2, 0);
            this.tableLayoutPanel22.Controls.Add(this.videoOptions, 1, 0);
            this.tableLayoutPanel22.Controls.Add(this.loadOptions, 0, 0);
            this.tableLayoutPanel22.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel22.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 1;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(672, 248);
            this.tableLayoutPanel22.TabIndex = 2;
            // 
            // nativeOptions
            // 
            this.nativeOptions.BackColor = System.Drawing.Color.Transparent;
            this.nativeOptions.Controls.Add(this.tableLayoutPanel25);
            this.nativeOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nativeOptions.Location = new System.Drawing.Point(449, 0);
            this.nativeOptions.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.nativeOptions.Name = "nativeOptions";
            this.nativeOptions.Padding = new System.Windows.Forms.Padding(2);
            this.nativeOptions.Size = new System.Drawing.Size(222, 248);
            this.nativeOptions.TabIndex = 4;
            this.nativeOptions.TabStop = false;
            this.nativeOptions.Text = "Native options";
            // 
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.ColumnCount = 1;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.Controls.Add(this.gameFolder, 0, 4);
            this.tableLayoutPanel25.Controls.Add(this.controls, 0, 3);
            this.tableLayoutPanel25.Controls.Add(this.audio, 0, 2);
            this.tableLayoutPanel25.Controls.Add(this.video, 0, 1);
            this.tableLayoutPanel25.Controls.Add(this.launcher, 0, 0);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(2, 29);
            this.tableLayoutPanel25.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 5;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel25.Size = new System.Drawing.Size(218, 217);
            this.tableLayoutPanel25.TabIndex = 19;
            // 
            // gameFolder
            // 
            this.gameFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gameFolder.ImageIndex = 7;
            this.gameFolder.ImageList = this.buttonIcons;
            this.gameFolder.Location = new System.Drawing.Point(1, 173);
            this.gameFolder.Margin = new System.Windows.Forms.Padding(1);
            this.gameFolder.Name = "gameFolder";
            this.gameFolder.Size = new System.Drawing.Size(216, 43);
            this.gameFolder.TabIndex = 23;
            this.gameFolder.Text = "Game folder";
            this.gameFolder.UseVisualStyleBackColor = false;
            this.gameFolder.Click += new System.EventHandler(this.gameFolder_Click);
            // 
            // buttonIcons
            // 
            this.buttonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonIcons.ImageStream")));
            this.buttonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.buttonIcons.Images.SetKeyName(0, "checkpoint.png");
            this.buttonIcons.Images.SetKeyName(1, "swirl.png");
            this.buttonIcons.Images.SetKeyName(2, "rubixcube.png");
            this.buttonIcons.Images.SetKeyName(3, "spanner.png");
            this.buttonIcons.Images.SetKeyName(4, "static.png");
            this.buttonIcons.Images.SetKeyName(5, "quaver.png");
            this.buttonIcons.Images.SetKeyName(6, "icon_pause.png");
            this.buttonIcons.Images.SetKeyName(7, "destructibles.png");
            this.buttonIcons.Images.SetKeyName(8, "tazwanted.png");
            // 
            // controls
            // 
            this.controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.controls.ImageIndex = 6;
            this.controls.ImageList = this.buttonIcons;
            this.controls.Location = new System.Drawing.Point(1, 130);
            this.controls.Margin = new System.Windows.Forms.Padding(1);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(216, 41);
            this.controls.TabIndex = 22;
            this.controls.Text = "Controls";
            this.controls.UseVisualStyleBackColor = false;
            this.controls.Click += new System.EventHandler(this.controls_Click);
            // 
            // audio
            // 
            this.audio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.audio.ImageIndex = 5;
            this.audio.ImageList = this.buttonIcons;
            this.audio.Location = new System.Drawing.Point(1, 87);
            this.audio.Margin = new System.Windows.Forms.Padding(1);
            this.audio.Name = "audio";
            this.audio.Size = new System.Drawing.Size(216, 41);
            this.audio.TabIndex = 21;
            this.audio.Text = "Audio";
            this.audio.UseVisualStyleBackColor = false;
            this.audio.Click += new System.EventHandler(this.audio_Click);
            // 
            // video
            // 
            this.video.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.video.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.video.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.video.ImageIndex = 4;
            this.video.ImageList = this.buttonIcons;
            this.video.Location = new System.Drawing.Point(1, 44);
            this.video.Margin = new System.Windows.Forms.Padding(1);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(216, 41);
            this.video.TabIndex = 20;
            this.video.Text = "Video";
            this.video.UseVisualStyleBackColor = false;
            this.video.Click += new System.EventHandler(this.video_Click);
            // 
            // launcher
            // 
            this.launcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launcher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcher.ImageIndex = 3;
            this.launcher.ImageList = this.buttonIcons;
            this.launcher.Location = new System.Drawing.Point(1, 1);
            this.launcher.Margin = new System.Windows.Forms.Padding(1);
            this.launcher.Name = "launcher";
            this.launcher.Size = new System.Drawing.Size(216, 41);
            this.launcher.TabIndex = 19;
            this.launcher.Text = "Launcher";
            this.launcher.UseVisualStyleBackColor = false;
            this.launcher.Click += new System.EventHandler(this.button1_Click);
            // 
            // videoOptions
            // 
            this.videoOptions.BackColor = System.Drawing.Color.Transparent;
            this.videoOptions.Controls.Add(this.tableLayoutPanel24);
            this.videoOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoOptions.Location = new System.Drawing.Point(225, 0);
            this.videoOptions.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.videoOptions.Name = "videoOptions";
            this.videoOptions.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.videoOptions.Size = new System.Drawing.Size(222, 248);
            this.videoOptions.TabIndex = 3;
            this.videoOptions.TabStop = false;
            this.videoOptions.Text = "Video options";
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.ColumnCount = 1;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel24.Controls.Add(this.changeResolution, 0, 2);
            this.tableLayoutPanel24.Controls.Add(this.aspectRatio, 0, 0);
            this.tableLayoutPanel24.Controls.Add(this.tableLayoutPanel28, 0, 1);
            this.tableLayoutPanel24.Controls.Add(this.tableLayoutPanel29, 0, 3);
            this.tableLayoutPanel24.Controls.Add(this.windowed, 0, 4);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(2, 27);
            this.tableLayoutPanel24.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 5;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel24.Size = new System.Drawing.Size(218, 221);
            this.tableLayoutPanel24.TabIndex = 19;
            // 
            // changeResolution
            // 
            this.changeResolution.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.changeResolution.AutoSize = true;
            this.changeResolution.Checked = true;
            this.changeResolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeResolution.Location = new System.Drawing.Point(3, 95);
            this.changeResolution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeResolution.Name = "changeResolution";
            this.changeResolution.Size = new System.Drawing.Size(122, 30);
            this.changeResolution.TabIndex = 11;
            this.changeResolution.Text = "Resolution:";
            this.changeResolution.UseVisualStyleBackColor = false;
            this.changeResolution.CheckedChanged += new System.EventHandler(this.changeResolution_CheckedChanged);
            // 
            // aspectRatio
            // 
            this.aspectRatio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aspectRatio.AutoSize = true;
            this.aspectRatio.Checked = true;
            this.aspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aspectRatio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aspectRatio.Location = new System.Drawing.Point(3, 7);
            this.aspectRatio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aspectRatio.Name = "aspectRatio";
            this.aspectRatio.Size = new System.Drawing.Size(141, 30);
            this.aspectRatio.TabIndex = 7;
            this.aspectRatio.Text = "Aspect ratio:";
            this.aspectRatio.UseVisualStyleBackColor = false;
            this.aspectRatio.CheckedChanged += new System.EventHandler(this.aspectRatio_CheckedChanged);
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.ColumnCount = 3;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel28.Controls.Add(this.aspect2, 2, 0);
            this.tableLayoutPanel28.Controls.Add(this.aspect1, 0, 0);
            this.tableLayoutPanel28.Controls.Add(this.pointsLabel, 1, 0);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel28.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 1;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(218, 44);
            this.tableLayoutPanel28.TabIndex = 11;
            // 
            // aspect2
            // 
            this.aspect2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aspect2.Location = new System.Drawing.Point(70, 5);
            this.aspect2.Margin = new System.Windows.Forms.Padding(0);
            this.aspect2.Name = "aspect2";
            this.aspect2.Size = new System.Drawing.Size(45, 34);
            this.aspect2.TabIndex = 10;
            // 
            // aspect1
            // 
            this.aspect1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aspect1.Location = new System.Drawing.Point(0, 5);
            this.aspect1.Margin = new System.Windows.Forms.Padding(0);
            this.aspect1.Name = "aspect1";
            this.aspect1.Size = new System.Drawing.Size(45, 34);
            this.aspect1.TabIndex = 8;
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(48, 9);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(18, 26);
            this.pointsLabel.TabIndex = 9;
            this.pointsLabel.Text = ":";
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.ColumnCount = 3;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel29.Controls.Add(this.height, 2, 0);
            this.tableLayoutPanel29.Controls.Add(this.width, 0, 0);
            this.tableLayoutPanel29.Controls.Add(this.xLabel, 1, 0);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(0, 132);
            this.tableLayoutPanel29.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 1;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(218, 44);
            this.tableLayoutPanel29.TabIndex = 11;
            // 
            // height
            // 
            this.height.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.height.Location = new System.Drawing.Point(95, 5);
            this.height.Margin = new System.Windows.Forms.Padding(0);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(70, 34);
            this.height.TabIndex = 14;
            this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
            // 
            // width
            // 
            this.width.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.width.Location = new System.Drawing.Point(0, 5);
            this.width.Margin = new System.Windows.Forms.Padding(0);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(70, 34);
            this.width.TabIndex = 12;
            this.width.TextChanged += new System.EventHandler(this.width_TextChanged);
            // 
            // xLabel
            // 
            this.xLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(73, 9);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(19, 26);
            this.xLabel.TabIndex = 13;
            this.xLabel.Text = "x";
            // 
            // windowed
            // 
            this.windowed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.windowed.AutoSize = true;
            this.windowed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowed.Location = new System.Drawing.Point(3, 183);
            this.windowed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.windowed.Name = "windowed";
            this.windowed.Size = new System.Drawing.Size(169, 30);
            this.windowed.TabIndex = 15;
            this.windowed.Text = "Windowed mode";
            this.windowed.UseVisualStyleBackColor = false;
            this.windowed.CheckedChanged += new System.EventHandler(this.windowed_CheckedChanged);
            // 
            // loadOptions
            // 
            this.loadOptions.BackColor = System.Drawing.Color.Transparent;
            this.loadOptions.Controls.Add(this.tableLayoutPanel23);
            this.loadOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadOptions.Location = new System.Drawing.Point(1, 0);
            this.loadOptions.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.loadOptions.Name = "loadOptions";
            this.loadOptions.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loadOptions.Size = new System.Drawing.Size(222, 248);
            this.loadOptions.TabIndex = 2;
            this.loadOptions.TabStop = false;
            this.loadOptions.Text = "Load options";
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 1;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel23.Controls.Add(this.tableLayoutPanel27, 0, 4);
            this.tableLayoutPanel23.Controls.Add(this.noCD, 0, 0);
            this.tableLayoutPanel23.Controls.Add(this.warningBanner, 0, 3);
            this.tableLayoutPanel23.Controls.Add(this.disableDrawDistance, 0, 1);
            this.tableLayoutPanel23.Controls.Add(this.disableVideos, 0, 2);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(2, 27);
            this.tableLayoutPanel23.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 5;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(218, 221);
            this.tableLayoutPanel23.TabIndex = 19;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.Controls.Add(this.language, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.langComboBox, 1, 0);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(0, 176);
            this.tableLayoutPanel27.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(218, 45);
            this.tableLayoutPanel27.TabIndex = 12;
            // 
            // language
            // 
            this.language.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.language.AutoSize = true;
            this.language.Location = new System.Drawing.Point(3, 9);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(98, 26);
            this.language.TabIndex = 0;
            this.language.Text = "Language:";
            // 
            // langComboBox
            // 
            this.langComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.langComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.langComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.langComboBox.Items.AddRange(new object[] {
            "English",
            "French",
            "German",
            "Italian",
            "Spanish"});
            this.langComboBox.Location = new System.Drawing.Point(112, 5);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(103, 34);
            this.langComboBox.TabIndex = 23;
            // 
            // noCD
            // 
            this.noCD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.noCD.AutoSize = true;
            this.noCD.Checked = true;
            this.noCD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noCD.Location = new System.Drawing.Point(3, 7);
            this.noCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.noCD.Name = "noCD";
            this.noCD.Size = new System.Drawing.Size(132, 30);
            this.noCD.TabIndex = 2;
            this.noCD.Text = "NoCD patch";
            this.noCD.UseVisualStyleBackColor = false;
            // 
            // warningBanner
            // 
            this.warningBanner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.warningBanner.AutoSize = true;
            this.warningBanner.Checked = true;
            this.warningBanner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.warningBanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warningBanner.Location = new System.Drawing.Point(3, 139);
            this.warningBanner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.warningBanner.Name = "warningBanner";
            this.warningBanner.Size = new System.Drawing.Size(192, 30);
            this.warningBanner.TabIndex = 4;
            this.warningBanner.Text = "No warning banner";
            this.warningBanner.UseVisualStyleBackColor = false;
            // 
            // disableDrawDistance
            // 
            this.disableDrawDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.disableDrawDistance.AutoSize = true;
            this.disableDrawDistance.Checked = true;
            this.disableDrawDistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableDrawDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableDrawDistance.Location = new System.Drawing.Point(3, 51);
            this.disableDrawDistance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disableDrawDistance.Name = "disableDrawDistance";
            this.disableDrawDistance.Size = new System.Drawing.Size(145, 30);
            this.disableDrawDistance.TabIndex = 5;
            this.disableDrawDistance.Text = "No draw limit";
            this.disableDrawDistance.UseVisualStyleBackColor = false;
            // 
            // disableVideos
            // 
            this.disableVideos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.disableVideos.AutoSize = true;
            this.disableVideos.Checked = true;
            this.disableVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableVideos.Location = new System.Drawing.Point(3, 95);
            this.disableVideos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disableVideos.Name = "disableVideos";
            this.disableVideos.Size = new System.Drawing.Size(191, 30);
            this.disableVideos.TabIndex = 3;
            this.disableVideos.Text = "Disable logo videos";
            this.disableVideos.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.ColumnCount = 3;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel26.Controls.Add(this.play, 2, 0);
            this.tableLayoutPanel26.Controls.Add(this.patch, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.restore, 1, 0);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(0, 248);
            this.tableLayoutPanel26.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 1;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(672, 42);
            this.tableLayoutPanel26.TabIndex = 11;
            // 
            // play
            // 
            this.play.Dock = System.Windows.Forms.DockStyle.Fill;
            this.play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.play.ImageIndex = 8;
            this.play.ImageList = this.buttonIcons;
            this.play.Location = new System.Drawing.Point(449, 1);
            this.play.Margin = new System.Windows.Forms.Padding(1);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(222, 40);
            this.play.TabIndex = 32;
            this.play.Text = "Play";
            this.play.UseVisualStyleBackColor = false;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // patch
            // 
            this.patch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patch.ImageIndex = 0;
            this.patch.ImageList = this.buttonIcons;
            this.patch.Location = new System.Drawing.Point(1, 1);
            this.patch.Margin = new System.Windows.Forms.Padding(1);
            this.patch.Name = "patch";
            this.patch.Size = new System.Drawing.Size(222, 40);
            this.patch.TabIndex = 30;
            this.patch.Text = "Patch";
            this.patch.UseVisualStyleBackColor = false;
            this.patch.Click += new System.EventHandler(this.patch_Click);
            // 
            // restore
            // 
            this.restore.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.restore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restore.ImageIndex = 1;
            this.restore.ImageList = this.buttonIcons;
            this.restore.Location = new System.Drawing.Point(225, 1);
            this.restore.Margin = new System.Windows.Forms.Padding(1);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(222, 40);
            this.restore.TabIndex = 31;
            this.restore.Text = "Restore";
            this.restore.UseVisualStyleBackColor = false;
            this.restore.Click += new System.EventHandler(this.restore_Click);
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.tableLayoutPanel31);
            this.infoTab.ImageIndex = 2;
            this.infoTab.Location = new System.Drawing.Point(4, 41);
            this.infoTab.Margin = new System.Windows.Forms.Padding(0);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(672, 290);
            this.infoTab.TabIndex = 2;
            this.infoTab.Text = "Info";
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 1;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel31.Controls.Add(this.infoText, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.tableLayoutPanel32, 0, 1);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel31.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 2;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(672, 290);
            this.tableLayoutPanel31.TabIndex = 0;
            // 
            // infoText
            // 
            this.infoText.AutoSize = true;
            this.infoText.Location = new System.Drawing.Point(0, 0);
            this.infoText.Margin = new System.Windows.Forms.Padding(0);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(663, 156);
            this.infoText.TabIndex = 1;
            this.infoText.Text = resources.GetString("infoText.Text");
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.ColumnCount = 3;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel32.Controls.Add(this.gitHub, 2, 0);
            this.tableLayoutPanel32.Controls.Add(this.trainerSound, 0, 0);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(0, 248);
            this.tableLayoutPanel32.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 1;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(672, 42);
            this.tableLayoutPanel32.TabIndex = 2;
            // 
            // gitHub
            // 
            this.gitHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gitHub.ImageIndex = 2;
            this.gitHub.ImageList = this.buttonIcons;
            this.gitHub.Location = new System.Drawing.Point(449, 1);
            this.gitHub.Margin = new System.Windows.Forms.Padding(1);
            this.gitHub.Name = "gitHub";
            this.gitHub.Size = new System.Drawing.Size(222, 40);
            this.gitHub.TabIndex = 3;
            this.gitHub.Text = "Source code";
            this.gitHub.UseVisualStyleBackColor = false;
            this.gitHub.Click += new System.EventHandler(this.gitHub_Click);
            // 
            // trainerSound
            // 
            this.trainerSound.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainerSound.AutoSize = true;
            this.trainerSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainerSound.Location = new System.Drawing.Point(1, 6);
            this.trainerSound.Margin = new System.Windows.Forms.Padding(1);
            this.trainerSound.Name = "trainerSound";
            this.trainerSound.Size = new System.Drawing.Size(195, 30);
            this.trainerSound.TabIndex = 2;
            this.trainerSound.Text = "Sound notifications";
            this.trainerSound.UseVisualStyleBackColor = true;
            // 
            // tabsIcons
            // 
            this.tabsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabsIcons.ImageStream")));
            this.tabsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.tabsIcons.Images.SetKeyName(0, "dollar.png");
            this.tabsIcons.Images.SetKeyName(1, "screw.png");
            this.tabsIcons.Images.SetKeyName(2, "caution.png");
            // 
            // dbgMenuOff
            // 
            this.dbgMenuOff.Tick += new System.EventHandler(this.dbgMenuOff_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(680, 357);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.statusStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taz Wanted trainer and patcher v1.1";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTaz)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.trainerTab.ResumeLayout(false);
            this.patcherTab.ResumeLayout(false);
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel22.ResumeLayout(false);
            this.nativeOptions.ResumeLayout(false);
            this.tableLayoutPanel25.ResumeLayout(false);
            this.videoOptions.ResumeLayout(false);
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel28.PerformLayout();
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            this.loadOptions.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tableLayoutPanel26.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel31.PerformLayout();
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel32.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox drawDistance;
        public System.Windows.Forms.ToolStripStatusLabel statusField;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.CheckBox superBelchCan;
        private System.Windows.Forms.CheckBox flyMode;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox smoothLight;
        private System.Windows.Forms.CheckBox invisibility;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.PictureBox pictureTaz;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage trainerTab;
        private System.Windows.Forms.TabPage patcherTab;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        private System.Windows.Forms.Button gitHub;
        private System.Windows.Forms.CheckBox freezeLevelTimer;
        private System.Windows.Forms.CheckBox debugMenu;
        private System.Windows.Forms.Timer dbgMenuOff;
        private System.Windows.Forms.ImageList tabsIcons;
        private System.Windows.Forms.ImageList checkIcons;
        private System.Windows.Forms.CheckBox superJump;
        private System.Windows.Forms.CheckBox gameSpeed;
        private System.Windows.Forms.ImageList buttonIcons;
        private System.Windows.Forms.CheckBox trainerSound;
        private System.Windows.Forms.CheckBox disallowJump;
        private System.Windows.Forms.CheckBox savePos;
        private System.Windows.Forms.CheckBox loadPos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.Button restore;
        private System.Windows.Forms.CheckBox disableVideos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.TextBox aspect2;
        private System.Windows.Forms.TextBox aspect1;
        private System.Windows.Forms.CheckBox aspectRatio;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.CheckBox changeResolution;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.CheckBox windowed;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.CheckBox warningBanner;
        private System.Windows.Forms.CheckBox disableDrawDistance;
        private System.Windows.Forms.Button patch;
        private System.Windows.Forms.GroupBox loadOptions;
        private System.Windows.Forms.CheckBox noCD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.GroupBox nativeOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel25;
        private System.Windows.Forms.GroupBox videoOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.Label language;
        private System.Windows.Forms.Button controls;
        private System.Windows.Forms.Button audio;
        private System.Windows.Forms.Button video;
        private System.Windows.Forms.Button launcher;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.Button gameFolder;
    }
}

