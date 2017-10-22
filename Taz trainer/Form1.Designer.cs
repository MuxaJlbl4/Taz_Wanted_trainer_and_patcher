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
            this.drawDistance = new System.Windows.Forms.CheckBox();
            this.checkIcons = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusField = new System.Windows.Forms.ToolStripStatusLabel();
            this.superBelchCan = new System.Windows.Forms.CheckBox();
            this.flyMode = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.smoothLight = new System.Windows.Forms.CheckBox();
            this.invisibility = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1Trainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2Trainer = new System.Windows.Forms.TableLayoutPanel();
            this.freezeLevelTimer = new System.Windows.Forms.CheckBox();
            this.debugMenu = new System.Windows.Forms.CheckBox();
            this.superJump = new System.Windows.Forms.CheckBox();
            this.gameSpeed = new System.Windows.Forms.CheckBox();
            this.pictureTaz = new System.Windows.Forms.PictureBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.trainerTab = new System.Windows.Forms.TabPage();
            this.patcherTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1Patcher = new System.Windows.Forms.TableLayoutPanel();
            this.trainerTitle = new System.Windows.Forms.Label();
            this.disableVideos = new System.Windows.Forms.CheckBox();
            this.disableDrawDistance = new System.Windows.Forms.CheckBox();
            this.noCD = new System.Windows.Forms.CheckBox();
            this.d3d8to9 = new System.Windows.Forms.CheckBox();
            this.warningBanner = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4Patcher = new System.Windows.Forms.TableLayoutPanel();
            this.patch = new System.Windows.Forms.Button();
            this.buttonIcons = new System.Windows.Forms.ImageList(this.components);
            this.restore = new System.Windows.Forms.Button();
            this.restoreBackup = new System.Windows.Forms.Button();
            this.tableLayoutPanel3Patcher = new System.Windows.Forms.TableLayoutPanel();
            this.aspect2 = new System.Windows.Forms.TextBox();
            this.aspect1 = new System.Windows.Forms.TextBox();
            this.aspectRatio = new System.Windows.Forms.CheckBox();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2Patcher = new System.Windows.Forms.TableLayoutPanel();
            this.changeResolution = new System.Windows.Forms.CheckBox();
            this.height = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.windowed = new System.Windows.Forms.CheckBox();
            this.width = new System.Windows.Forms.TextBox();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1Info = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2Info = new System.Windows.Forms.TableLayoutPanel();
            this.gitHub = new System.Windows.Forms.Button();
            this.res = new System.Windows.Forms.Button();
            this.d3d = new System.Windows.Forms.Button();
            this.infoText = new System.Windows.Forms.Label();
            this.tabsIcons = new System.Windows.Forms.ImageList(this.components);
            this.dbgMenuOff = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1Trainer.SuspendLayout();
            this.tableLayoutPanel2Trainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTaz)).BeginInit();
            this.tabs.SuspendLayout();
            this.trainerTab.SuspendLayout();
            this.patcherTab.SuspendLayout();
            this.tableLayoutPanel1Patcher.SuspendLayout();
            this.tableLayoutPanel4Patcher.SuspendLayout();
            this.tableLayoutPanel3Patcher.SuspendLayout();
            this.tableLayoutPanel2Patcher.SuspendLayout();
            this.infoTab.SuspendLayout();
            this.tableLayoutPanel1Info.SuspendLayout();
            this.tableLayoutPanel2Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawDistance
            // 
            this.drawDistance.Appearance = System.Windows.Forms.Appearance.Button;
            this.drawDistance.AutoSize = true;
            this.drawDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawDistance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drawDistance.ImageIndex = 4;
            this.drawDistance.ImageList = this.checkIcons;
            this.drawDistance.Location = new System.Drawing.Point(1, 133);
            this.drawDistance.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.drawDistance.Name = "drawDistance";
            this.drawDistance.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.drawDistance.Size = new System.Drawing.Size(293, 32);
            this.drawDistance.TabIndex = 1;
            this.drawDistance.Text = "       F5 - Infinity draw distance";
            this.drawDistance.UseVisualStyleBackColor = true;
            this.drawDistance.CheckedChanged += new System.EventHandler(this.drawDistance_CheckedChanged);
            // 
            // checkIcons
            // 
            this.checkIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("checkIcons.ImageStream")));
            this.checkIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.checkIcons.Images.SetKeyName(0, "invis.png");
            this.checkIcons.Images.SetKeyName(1, "burp.png");
            this.checkIcons.Images.SetKeyName(2, "jump.png");
            this.checkIcons.Images.SetKeyName(3, "time.png");
            this.checkIcons.Images.SetKeyName(4, "draw.png");
            this.checkIcons.Images.SetKeyName(5, "light.png");
            this.checkIcons.Images.SetKeyName(6, "debug.png");
            this.checkIcons.Images.SetKeyName(7, "fly.png");
            this.checkIcons.Images.SetKeyName(8, "speed.png");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusField});
            this.statusStrip.Location = new System.Drawing.Point(0, 333);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(468, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            // 
            // statusField
            // 
            this.statusField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusField.Name = "statusField";
            this.statusField.Size = new System.Drawing.Size(137, 17);
            this.statusField.Text = "Welcome to Taz Hacked!";
            // 
            // superBelchCan
            // 
            this.superBelchCan.Appearance = System.Windows.Forms.Appearance.Button;
            this.superBelchCan.AutoSize = true;
            this.superBelchCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superBelchCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.superBelchCan.ImageIndex = 1;
            this.superBelchCan.ImageList = this.checkIcons;
            this.superBelchCan.Location = new System.Drawing.Point(1, 34);
            this.superBelchCan.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.superBelchCan.Name = "superBelchCan";
            this.superBelchCan.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.superBelchCan.Size = new System.Drawing.Size(293, 32);
            this.superBelchCan.TabIndex = 1;
            this.superBelchCan.Text = "       F2 - Super burp can";
            this.superBelchCan.UseVisualStyleBackColor = true;
            this.superBelchCan.CheckedChanged += new System.EventHandler(this.superBelchCan_CheckedChanged);
            // 
            // flyMode
            // 
            this.flyMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.flyMode.AutoSize = true;
            this.flyMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flyMode.ImageIndex = 7;
            this.flyMode.ImageList = this.checkIcons;
            this.flyMode.Location = new System.Drawing.Point(1, 232);
            this.flyMode.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.flyMode.Name = "flyMode";
            this.flyMode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flyMode.Size = new System.Drawing.Size(293, 32);
            this.flyMode.TabIndex = 1;
            this.flyMode.Text = "       Num5/NumPad keys - Fly mode";
            this.flyMode.UseVisualStyleBackColor = true;
            this.flyMode.CheckedChanged += new System.EventHandler(this.flyMode_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // smoothLight
            // 
            this.smoothLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.smoothLight.AutoSize = true;
            this.smoothLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smoothLight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smoothLight.ImageIndex = 5;
            this.smoothLight.ImageList = this.checkIcons;
            this.smoothLight.Location = new System.Drawing.Point(1, 166);
            this.smoothLight.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.smoothLight.Name = "smoothLight";
            this.smoothLight.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.smoothLight.Size = new System.Drawing.Size(293, 32);
            this.smoothLight.TabIndex = 1;
            this.smoothLight.Text = "       F6 - Smooth lighting";
            this.smoothLight.UseVisualStyleBackColor = true;
            this.smoothLight.CheckedChanged += new System.EventHandler(this.smoothLight_CheckedChanged);
            // 
            // invisibility
            // 
            this.invisibility.Appearance = System.Windows.Forms.Appearance.Button;
            this.invisibility.AutoSize = true;
            this.invisibility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invisibility.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.invisibility.ImageIndex = 0;
            this.invisibility.ImageList = this.checkIcons;
            this.invisibility.Location = new System.Drawing.Point(1, 1);
            this.invisibility.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.invisibility.Name = "invisibility";
            this.invisibility.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.invisibility.Size = new System.Drawing.Size(293, 32);
            this.invisibility.TabIndex = 1;
            this.invisibility.Text = "       F1 - Invisibility";
            this.invisibility.UseVisualStyleBackColor = true;
            this.invisibility.CheckedChanged += new System.EventHandler(this.invisibility_CheckedChanged);
            // 
            // tableLayoutPanel1Trainer
            // 
            this.tableLayoutPanel1Trainer.ColumnCount = 2;
            this.tableLayoutPanel1Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Trainer.Controls.Add(this.tableLayoutPanel2Trainer, 1, 0);
            this.tableLayoutPanel1Trainer.Controls.Add(this.pictureTaz, 0, 0);
            this.tableLayoutPanel1Trainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1Trainer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1Trainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1Trainer.Name = "tableLayoutPanel1Trainer";
            this.tableLayoutPanel1Trainer.RowCount = 1;
            this.tableLayoutPanel1Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Trainer.Size = new System.Drawing.Size(460, 298);
            this.tableLayoutPanel1Trainer.TabIndex = 7;
            // 
            // tableLayoutPanel2Trainer
            // 
            this.tableLayoutPanel2Trainer.ColumnCount = 1;
            this.tableLayoutPanel2Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Trainer.Controls.Add(this.superBelchCan, 0, 1);
            this.tableLayoutPanel2Trainer.Controls.Add(this.invisibility, 0, 0);
            this.tableLayoutPanel2Trainer.Controls.Add(this.smoothLight, 0, 5);
            this.tableLayoutPanel2Trainer.Controls.Add(this.drawDistance, 0, 4);
            this.tableLayoutPanel2Trainer.Controls.Add(this.freezeLevelTimer, 0, 3);
            this.tableLayoutPanel2Trainer.Controls.Add(this.debugMenu, 0, 6);
            this.tableLayoutPanel2Trainer.Controls.Add(this.flyMode, 0, 7);
            this.tableLayoutPanel2Trainer.Controls.Add(this.superJump, 0, 2);
            this.tableLayoutPanel2Trainer.Controls.Add(this.gameSpeed, 0, 8);
            this.tableLayoutPanel2Trainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2Trainer.Location = new System.Drawing.Point(165, 0);
            this.tableLayoutPanel2Trainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2Trainer.Name = "tableLayoutPanel2Trainer";
            this.tableLayoutPanel2Trainer.RowCount = 10;
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Trainer.Size = new System.Drawing.Size(295, 298);
            this.tableLayoutPanel2Trainer.TabIndex = 0;
            // 
            // freezeLevelTimer
            // 
            this.freezeLevelTimer.Appearance = System.Windows.Forms.Appearance.Button;
            this.freezeLevelTimer.AutoSize = true;
            this.freezeLevelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freezeLevelTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.freezeLevelTimer.ImageIndex = 3;
            this.freezeLevelTimer.ImageList = this.checkIcons;
            this.freezeLevelTimer.Location = new System.Drawing.Point(1, 100);
            this.freezeLevelTimer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.freezeLevelTimer.Name = "freezeLevelTimer";
            this.freezeLevelTimer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.freezeLevelTimer.Size = new System.Drawing.Size(293, 32);
            this.freezeLevelTimer.TabIndex = 8;
            this.freezeLevelTimer.Text = "       F4 - Freeze level timer";
            this.freezeLevelTimer.UseVisualStyleBackColor = true;
            this.freezeLevelTimer.CheckedChanged += new System.EventHandler(this.freezeLevelTimer_CheckedChanged);
            // 
            // debugMenu
            // 
            this.debugMenu.Appearance = System.Windows.Forms.Appearance.Button;
            this.debugMenu.AutoSize = true;
            this.debugMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.debugMenu.ImageIndex = 6;
            this.debugMenu.ImageList = this.checkIcons;
            this.debugMenu.Location = new System.Drawing.Point(1, 199);
            this.debugMenu.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.debugMenu.Name = "debugMenu";
            this.debugMenu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.debugMenu.Size = new System.Drawing.Size(293, 32);
            this.debugMenu.TabIndex = 1;
            this.debugMenu.Text = "       F7 - Debug menu";
            this.debugMenu.UseVisualStyleBackColor = true;
            this.debugMenu.CheckedChanged += new System.EventHandler(this.debugMenu_CheckedChanged);
            // 
            // superJump
            // 
            this.superJump.Appearance = System.Windows.Forms.Appearance.Button;
            this.superJump.AutoSize = true;
            this.superJump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superJump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.superJump.ImageIndex = 2;
            this.superJump.ImageList = this.checkIcons;
            this.superJump.Location = new System.Drawing.Point(1, 67);
            this.superJump.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.superJump.Name = "superJump";
            this.superJump.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.superJump.Size = new System.Drawing.Size(293, 32);
            this.superJump.TabIndex = 1;
            this.superJump.Text = "       F3 - Super jump";
            this.superJump.UseVisualStyleBackColor = true;
            this.superJump.CheckedChanged += new System.EventHandler(this.superJump_CheckedChanged);
            // 
            // gameSpeed
            // 
            this.gameSpeed.Appearance = System.Windows.Forms.Appearance.Button;
            this.gameSpeed.AutoSize = true;
            this.gameSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gameSpeed.ImageIndex = 8;
            this.gameSpeed.ImageList = this.checkIcons;
            this.gameSpeed.Location = new System.Drawing.Point(1, 265);
            this.gameSpeed.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gameSpeed.Name = "gameSpeed";
            this.gameSpeed.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.gameSpeed.Size = new System.Drawing.Size(293, 32);
            this.gameSpeed.TabIndex = 1;
            this.gameSpeed.Text = "       -/= - Change game speed";
            this.gameSpeed.UseVisualStyleBackColor = true;
            // 
            // pictureTaz
            // 
            this.pictureTaz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureTaz.Image = global::Taz_trainer.Properties.Resources.TAZ;
            this.pictureTaz.Location = new System.Drawing.Point(0, 0);
            this.pictureTaz.Margin = new System.Windows.Forms.Padding(0);
            this.pictureTaz.Name = "pictureTaz";
            this.pictureTaz.Size = new System.Drawing.Size(165, 298);
            this.pictureTaz.TabIndex = 1;
            this.pictureTaz.TabStop = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.trainerTab);
            this.tabs.Controls.Add(this.patcherTab);
            this.tabs.Controls.Add(this.infoTab);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabs.ImageList = this.tabsIcons;
            this.tabs.ItemSize = new System.Drawing.Size(155, 27);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(0);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(0, 0);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(468, 333);
            this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabs.TabIndex = 8;
            // 
            // trainerTab
            // 
            this.trainerTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.trainerTab.Controls.Add(this.tableLayoutPanel1Trainer);
            this.trainerTab.ImageIndex = 0;
            this.trainerTab.Location = new System.Drawing.Point(4, 31);
            this.trainerTab.Margin = new System.Windows.Forms.Padding(0);
            this.trainerTab.Name = "trainerTab";
            this.trainerTab.Size = new System.Drawing.Size(460, 298);
            this.trainerTab.TabIndex = 0;
            this.trainerTab.Text = "Trainer";
            this.trainerTab.UseVisualStyleBackColor = true;
            // 
            // patcherTab
            // 
            this.patcherTab.Controls.Add(this.tableLayoutPanel1Patcher);
            this.patcherTab.ImageIndex = 1;
            this.patcherTab.Location = new System.Drawing.Point(4, 31);
            this.patcherTab.Margin = new System.Windows.Forms.Padding(0);
            this.patcherTab.Name = "patcherTab";
            this.patcherTab.Size = new System.Drawing.Size(460, 298);
            this.patcherTab.TabIndex = 1;
            this.patcherTab.Text = "Patcher";
            this.patcherTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1Patcher
            // 
            this.tableLayoutPanel1Patcher.ColumnCount = 1;
            this.tableLayoutPanel1Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Patcher.Controls.Add(this.trainerTitle, 0, 0);
            this.tableLayoutPanel1Patcher.Controls.Add(this.disableVideos, 0, 3);
            this.tableLayoutPanel1Patcher.Controls.Add(this.disableDrawDistance, 0, 2);
            this.tableLayoutPanel1Patcher.Controls.Add(this.noCD, 0, 1);
            this.tableLayoutPanel1Patcher.Controls.Add(this.d3d8to9, 0, 5);
            this.tableLayoutPanel1Patcher.Controls.Add(this.warningBanner, 0, 4);
            this.tableLayoutPanel1Patcher.Controls.Add(this.tableLayoutPanel4Patcher, 0, 8);
            this.tableLayoutPanel1Patcher.Controls.Add(this.tableLayoutPanel3Patcher, 0, 7);
            this.tableLayoutPanel1Patcher.Controls.Add(this.tableLayoutPanel2Patcher, 0, 6);
            this.tableLayoutPanel1Patcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1Patcher.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1Patcher.Name = "tableLayoutPanel1Patcher";
            this.tableLayoutPanel1Patcher.RowCount = 9;
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Patcher.Size = new System.Drawing.Size(460, 298);
            this.tableLayoutPanel1Patcher.TabIndex = 4;
            // 
            // trainerTitle
            // 
            this.trainerTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainerTitle.AutoSize = true;
            this.trainerTitle.Location = new System.Drawing.Point(3, 5);
            this.trainerTitle.Name = "trainerTitle";
            this.trainerTitle.Size = new System.Drawing.Size(195, 23);
            this.trainerTitle.TabIndex = 5;
            this.trainerTitle.Text = "Choose options for patch:";
            // 
            // disableVideos
            // 
            this.disableVideos.AutoSize = true;
            this.disableVideos.Checked = true;
            this.disableVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableVideos.Location = new System.Drawing.Point(1, 100);
            this.disableVideos.Margin = new System.Windows.Forms.Padding(1);
            this.disableVideos.Name = "disableVideos";
            this.disableVideos.Size = new System.Drawing.Size(168, 27);
            this.disableVideos.TabIndex = 2;
            this.disableVideos.Text = "Disable logo videos";
            this.disableVideos.UseVisualStyleBackColor = true;
            // 
            // disableDrawDistance
            // 
            this.disableDrawDistance.AutoSize = true;
            this.disableDrawDistance.Checked = true;
            this.disableDrawDistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableDrawDistance.Location = new System.Drawing.Point(1, 67);
            this.disableDrawDistance.Margin = new System.Windows.Forms.Padding(1);
            this.disableDrawDistance.Name = "disableDrawDistance";
            this.disableDrawDistance.Size = new System.Drawing.Size(190, 27);
            this.disableDrawDistance.TabIndex = 2;
            this.disableDrawDistance.Text = "Disable draw distance";
            this.disableDrawDistance.UseVisualStyleBackColor = true;
            // 
            // noCD
            // 
            this.noCD.AutoSize = true;
            this.noCD.Checked = true;
            this.noCD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noCD.Location = new System.Drawing.Point(1, 34);
            this.noCD.Margin = new System.Windows.Forms.Padding(1);
            this.noCD.Name = "noCD";
            this.noCD.Size = new System.Drawing.Size(117, 27);
            this.noCD.TabIndex = 2;
            this.noCD.Text = "NoCD patch";
            this.noCD.UseVisualStyleBackColor = true;
            // 
            // d3d8to9
            // 
            this.d3d8to9.AutoSize = true;
            this.d3d8to9.Checked = true;
            this.d3d8to9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.d3d8to9.Location = new System.Drawing.Point(1, 166);
            this.d3d8to9.Margin = new System.Windows.Forms.Padding(1);
            this.d3d8to9.Name = "d3d8to9";
            this.d3d8to9.Size = new System.Drawing.Size(235, 27);
            this.d3d8to9.TabIndex = 2;
            this.d3d8to9.Text = "Convert DirectX 8 API to 9";
            this.d3d8to9.UseVisualStyleBackColor = true;
            // 
            // warningBanner
            // 
            this.warningBanner.AutoSize = true;
            this.warningBanner.Checked = true;
            this.warningBanner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.warningBanner.Location = new System.Drawing.Point(1, 133);
            this.warningBanner.Margin = new System.Windows.Forms.Padding(1);
            this.warningBanner.Name = "warningBanner";
            this.warningBanner.Size = new System.Drawing.Size(200, 27);
            this.warningBanner.TabIndex = 2;
            this.warningBanner.Text = "Disable warning banner";
            this.warningBanner.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4Patcher
            // 
            this.tableLayoutPanel4Patcher.ColumnCount = 3;
            this.tableLayoutPanel4Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4Patcher.Controls.Add(this.patch, 0, 0);
            this.tableLayoutPanel4Patcher.Controls.Add(this.restore, 2, 0);
            this.tableLayoutPanel4Patcher.Controls.Add(this.restoreBackup, 1, 0);
            this.tableLayoutPanel4Patcher.Location = new System.Drawing.Point(0, 265);
            this.tableLayoutPanel4Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4Patcher.Name = "tableLayoutPanel4Patcher";
            this.tableLayoutPanel4Patcher.RowCount = 1;
            this.tableLayoutPanel4Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4Patcher.Size = new System.Drawing.Size(460, 33);
            this.tableLayoutPanel4Patcher.TabIndex = 6;
            // 
            // patch
            // 
            this.patch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patch.ImageIndex = 0;
            this.patch.ImageList = this.buttonIcons;
            this.patch.Location = new System.Drawing.Point(1, 1);
            this.patch.Margin = new System.Windows.Forms.Padding(1);
            this.patch.Name = "patch";
            this.patch.Size = new System.Drawing.Size(151, 31);
            this.patch.TabIndex = 3;
            this.patch.Text = "Patch!";
            this.patch.UseVisualStyleBackColor = true;
            this.patch.Click += new System.EventHandler(this.patch_Click);
            // 
            // buttonIcons
            // 
            this.buttonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonIcons.ImageStream")));
            this.buttonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.buttonIcons.Images.SetKeyName(0, "bonus.png");
            this.buttonIcons.Images.SetKeyName(1, "restoreexe.png");
            this.buttonIcons.Images.SetKeyName(2, "restoreall.png");
            this.buttonIcons.Images.SetKeyName(3, "github.png");
            this.buttonIcons.Images.SetKeyName(4, "d3d.png");
            this.buttonIcons.Images.SetKeyName(5, "music.png");
            // 
            // restore
            // 
            this.restore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restore.ImageIndex = 2;
            this.restore.ImageList = this.buttonIcons;
            this.restore.Location = new System.Drawing.Point(307, 1);
            this.restore.Margin = new System.Windows.Forms.Padding(1);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(152, 31);
            this.restore.TabIndex = 3;
            this.restore.Text = "Restore all";
            this.restore.UseVisualStyleBackColor = true;
            this.restore.Click += new System.EventHandler(this.restore_Click);
            // 
            // restoreBackup
            // 
            this.restoreBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restoreBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restoreBackup.ImageIndex = 1;
            this.restoreBackup.ImageList = this.buttonIcons;
            this.restoreBackup.Location = new System.Drawing.Point(154, 1);
            this.restoreBackup.Margin = new System.Windows.Forms.Padding(1);
            this.restoreBackup.Name = "restoreBackup";
            this.restoreBackup.Size = new System.Drawing.Size(151, 31);
            this.restoreBackup.TabIndex = 3;
            this.restoreBackup.Text = "Restore exe";
            this.restoreBackup.UseVisualStyleBackColor = true;
            this.restoreBackup.Click += new System.EventHandler(this.restoreBackup_Click);
            // 
            // tableLayoutPanel3Patcher
            // 
            this.tableLayoutPanel3Patcher.ColumnCount = 5;
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3Patcher.Controls.Add(this.aspect2, 3, 0);
            this.tableLayoutPanel3Patcher.Controls.Add(this.aspect1, 1, 0);
            this.tableLayoutPanel3Patcher.Controls.Add(this.aspectRatio, 0, 0);
            this.tableLayoutPanel3Patcher.Controls.Add(this.pointsLabel, 2, 0);
            this.tableLayoutPanel3Patcher.Location = new System.Drawing.Point(0, 231);
            this.tableLayoutPanel3Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3Patcher.Name = "tableLayoutPanel3Patcher";
            this.tableLayoutPanel3Patcher.RowCount = 1;
            this.tableLayoutPanel3Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3Patcher.Size = new System.Drawing.Size(460, 30);
            this.tableLayoutPanel3Patcher.TabIndex = 5;
            // 
            // aspect2
            // 
            this.aspect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aspect2.Location = new System.Drawing.Point(235, 0);
            this.aspect2.Margin = new System.Windows.Forms.Padding(0);
            this.aspect2.Name = "aspect2";
            this.aspect2.Size = new System.Drawing.Size(35, 30);
            this.aspect2.TabIndex = 6;
            // 
            // aspect1
            // 
            this.aspect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aspect1.Location = new System.Drawing.Point(180, 0);
            this.aspect1.Margin = new System.Windows.Forms.Padding(0);
            this.aspect1.Name = "aspect1";
            this.aspect1.Size = new System.Drawing.Size(35, 30);
            this.aspect1.TabIndex = 4;
            // 
            // aspectRatio
            // 
            this.aspectRatio.AutoSize = true;
            this.aspectRatio.Checked = true;
            this.aspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aspectRatio.Location = new System.Drawing.Point(1, 1);
            this.aspectRatio.Margin = new System.Windows.Forms.Padding(1);
            this.aspectRatio.Name = "aspectRatio";
            this.aspectRatio.Size = new System.Drawing.Size(172, 27);
            this.aspectRatio.TabIndex = 2;
            this.aspectRatio.Text = "Change aspect ratio";
            this.aspectRatio.UseVisualStyleBackColor = true;
            this.aspectRatio.CheckedChanged += new System.EventHandler(this.aspectRatio_CheckedChanged);
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(218, 3);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(14, 23);
            this.pointsLabel.TabIndex = 5;
            this.pointsLabel.Text = ":";
            // 
            // tableLayoutPanel2Patcher
            // 
            this.tableLayoutPanel2Patcher.ColumnCount = 6;
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Patcher.Controls.Add(this.changeResolution, 0, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.height, 3, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.xLabel, 2, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.windowed, 5, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.width, 1, 0);
            this.tableLayoutPanel2Patcher.Location = new System.Drawing.Point(0, 198);
            this.tableLayoutPanel2Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2Patcher.Name = "tableLayoutPanel2Patcher";
            this.tableLayoutPanel2Patcher.RowCount = 1;
            this.tableLayoutPanel2Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Patcher.Size = new System.Drawing.Size(460, 30);
            this.tableLayoutPanel2Patcher.TabIndex = 4;
            // 
            // changeResolution
            // 
            this.changeResolution.AutoSize = true;
            this.changeResolution.Checked = true;
            this.changeResolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeResolution.Location = new System.Drawing.Point(1, 1);
            this.changeResolution.Margin = new System.Windows.Forms.Padding(1);
            this.changeResolution.Name = "changeResolution";
            this.changeResolution.Size = new System.Drawing.Size(156, 27);
            this.changeResolution.TabIndex = 2;
            this.changeResolution.Text = "Change resolution";
            this.changeResolution.UseVisualStyleBackColor = true;
            this.changeResolution.CheckedChanged += new System.EventHandler(this.changeResolution_CheckedChanged);
            // 
            // height
            // 
            this.height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.height.Location = new System.Drawing.Point(264, 0);
            this.height.Margin = new System.Windows.Forms.Padding(0);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(60, 30);
            this.height.TabIndex = 3;
            // 
            // xLabel
            // 
            this.xLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(243, 3);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(18, 23);
            this.xLabel.TabIndex = 5;
            this.xLabel.Text = "x";
            // 
            // windowed
            // 
            this.windowed.AutoSize = true;
            this.windowed.Location = new System.Drawing.Point(347, 4);
            this.windowed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.windowed.Name = "windowed";
            this.windowed.Size = new System.Drawing.Size(104, 22);
            this.windowed.TabIndex = 2;
            this.windowed.Text = "Windowed";
            this.windowed.UseVisualStyleBackColor = true;
            this.windowed.CheckedChanged += new System.EventHandler(this.windowed_CheckedChanged);
            // 
            // width
            // 
            this.width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.width.Location = new System.Drawing.Point(180, 0);
            this.width.Margin = new System.Windows.Forms.Padding(0);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(60, 30);
            this.width.TabIndex = 4;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.tableLayoutPanel1Info);
            this.infoTab.ImageIndex = 2;
            this.infoTab.Location = new System.Drawing.Point(4, 31);
            this.infoTab.Margin = new System.Windows.Forms.Padding(0);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(460, 298);
            this.infoTab.TabIndex = 2;
            this.infoTab.Text = "Info";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1Info
            // 
            this.tableLayoutPanel1Info.ColumnCount = 1;
            this.tableLayoutPanel1Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Info.Controls.Add(this.tableLayoutPanel2Info, 0, 1);
            this.tableLayoutPanel1Info.Controls.Add(this.infoText, 0, 0);
            this.tableLayoutPanel1Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1Info.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1Info.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1Info.Name = "tableLayoutPanel1Info";
            this.tableLayoutPanel1Info.RowCount = 2;
            this.tableLayoutPanel1Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1Info.Size = new System.Drawing.Size(460, 298);
            this.tableLayoutPanel1Info.TabIndex = 0;
            // 
            // tableLayoutPanel2Info
            // 
            this.tableLayoutPanel2Info.ColumnCount = 3;
            this.tableLayoutPanel2Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2Info.Controls.Add(this.gitHub, 0, 0);
            this.tableLayoutPanel2Info.Controls.Add(this.res, 2, 0);
            this.tableLayoutPanel2Info.Controls.Add(this.d3d, 1, 0);
            this.tableLayoutPanel2Info.Location = new System.Drawing.Point(0, 265);
            this.tableLayoutPanel2Info.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2Info.Name = "tableLayoutPanel2Info";
            this.tableLayoutPanel2Info.RowCount = 1;
            this.tableLayoutPanel2Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Info.Size = new System.Drawing.Size(460, 33);
            this.tableLayoutPanel2Info.TabIndex = 7;
            // 
            // gitHub
            // 
            this.gitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gitHub.ImageIndex = 3;
            this.gitHub.ImageList = this.buttonIcons;
            this.gitHub.Location = new System.Drawing.Point(1, 1);
            this.gitHub.Margin = new System.Windows.Forms.Padding(1);
            this.gitHub.Name = "gitHub";
            this.gitHub.Size = new System.Drawing.Size(151, 31);
            this.gitHub.TabIndex = 3;
            this.gitHub.Text = "Source code";
            this.gitHub.UseVisualStyleBackColor = true;
            this.gitHub.Click += new System.EventHandler(this.gitHub_Click);
            // 
            // res
            // 
            this.res.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.res.ImageIndex = 5;
            this.res.ImageList = this.buttonIcons;
            this.res.Location = new System.Drawing.Point(307, 1);
            this.res.Margin = new System.Windows.Forms.Padding(1);
            this.res.Name = "res";
            this.res.Size = new System.Drawing.Size(151, 31);
            this.res.TabIndex = 3;
            this.res.Text = "Extras";
            this.res.UseVisualStyleBackColor = true;
            this.res.Click += new System.EventHandler(this.res_Click);
            // 
            // d3d
            // 
            this.d3d.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.d3d.ImageIndex = 4;
            this.d3d.ImageList = this.buttonIcons;
            this.d3d.Location = new System.Drawing.Point(154, 1);
            this.d3d.Margin = new System.Windows.Forms.Padding(1);
            this.d3d.Name = "d3d";
            this.d3d.Size = new System.Drawing.Size(151, 31);
            this.d3d.TabIndex = 3;
            this.d3d.Text = "D3D8to9";
            this.d3d.UseVisualStyleBackColor = true;
            this.d3d.Click += new System.EventHandler(this.d3d_Click);
            // 
            // infoText
            // 
            this.infoText.AutoSize = true;
            this.infoText.Location = new System.Drawing.Point(0, 0);
            this.infoText.Margin = new System.Windows.Forms.Padding(0);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(456, 230);
            this.infoText.TabIndex = 8;
            this.infoText.Text = resources.GetString("infoText.Text");
            // 
            // tabsIcons
            // 
            this.tabsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabsIcons.ImageStream")));
            this.tabsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.tabsIcons.Images.SetKeyName(0, "trainer.png");
            this.tabsIcons.Images.SetKeyName(1, "patcher.png");
            this.tabsIcons.Images.SetKeyName(2, "info.png");
            // 
            // dbgMenuOff
            // 
            this.dbgMenuOff.Tick += new System.EventHandler(this.dbgMenuOff_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(468, 355);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.statusStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.tableLayoutPanel1Trainer.ResumeLayout(false);
            this.tableLayoutPanel2Trainer.ResumeLayout(false);
            this.tableLayoutPanel2Trainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTaz)).EndInit();
            this.tabs.ResumeLayout(false);
            this.trainerTab.ResumeLayout(false);
            this.patcherTab.ResumeLayout(false);
            this.tableLayoutPanel1Patcher.ResumeLayout(false);
            this.tableLayoutPanel1Patcher.PerformLayout();
            this.tableLayoutPanel4Patcher.ResumeLayout(false);
            this.tableLayoutPanel3Patcher.ResumeLayout(false);
            this.tableLayoutPanel3Patcher.PerformLayout();
            this.tableLayoutPanel2Patcher.ResumeLayout(false);
            this.tableLayoutPanel2Patcher.PerformLayout();
            this.infoTab.ResumeLayout(false);
            this.tableLayoutPanel1Info.ResumeLayout(false);
            this.tableLayoutPanel1Info.PerformLayout();
            this.tableLayoutPanel2Info.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1Trainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2Trainer;
        private System.Windows.Forms.PictureBox pictureTaz;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage trainerTab;
        private System.Windows.Forms.TabPage patcherTab;
        private System.Windows.Forms.CheckBox noCD;
        private System.Windows.Forms.Button restore;
        private System.Windows.Forms.Button patch;
        private System.Windows.Forms.CheckBox disableDrawDistance;
        private System.Windows.Forms.CheckBox disableVideos;
        private System.Windows.Forms.CheckBox aspectRatio;
        private System.Windows.Forms.CheckBox changeResolution;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1Patcher;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2Patcher;
        private System.Windows.Forms.CheckBox windowed;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3Patcher;
        private System.Windows.Forms.TextBox aspect2;
        private System.Windows.Forms.TextBox aspect1;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4Patcher;
        private System.Windows.Forms.Label trainerTitle;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1Info;
        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2Info;
        private System.Windows.Forms.Button gitHub;
        private System.Windows.Forms.Button restoreBackup;
        private System.Windows.Forms.CheckBox freezeLevelTimer;
        private System.Windows.Forms.CheckBox debugMenu;
        private System.Windows.Forms.Timer dbgMenuOff;
        private System.Windows.Forms.CheckBox warningBanner;
        private System.Windows.Forms.ImageList tabsIcons;
        private System.Windows.Forms.ImageList checkIcons;
        private System.Windows.Forms.CheckBox superJump;
        private System.Windows.Forms.CheckBox gameSpeed;
        private System.Windows.Forms.Button res;
        private System.Windows.Forms.ImageList buttonIcons;
        private System.Windows.Forms.Button d3d;
        private System.Windows.Forms.CheckBox d3d8to9;
    }
}

