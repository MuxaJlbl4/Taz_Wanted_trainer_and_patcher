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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusField = new System.Windows.Forms.ToolStripStatusLabel();
            this.numericJump = new System.Windows.Forms.NumericUpDown();
            this.jumpLabel = new System.Windows.Forms.Label();
            this.numericSpeed = new System.Windows.Forms.NumericUpDown();
            this.speedLabel = new System.Windows.Forms.Label();
            this.superBelchCan = new System.Windows.Forms.CheckBox();
            this.flyMode = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.smoothLight = new System.Windows.Forms.CheckBox();
            this.invisibility = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1Trainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2Trainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4Trainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3Trainer = new System.Windows.Forms.TableLayoutPanel();
            this.freezeLevelTimer = new System.Windows.Forms.CheckBox();
            this.pictureTaz = new System.Windows.Forms.PictureBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.trainerTab = new System.Windows.Forms.TabPage();
            this.patcherTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1Patcher = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4Patcher = new System.Windows.Forms.TableLayoutPanel();
            this.patch = new System.Windows.Forms.Button();
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
            this.trainerTitle = new System.Windows.Forms.Label();
            this.disableVideos = new System.Windows.Forms.CheckBox();
            this.disableDrawDistance = new System.Windows.Forms.CheckBox();
            this.noCD = new System.Windows.Forms.CheckBox();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1Info = new System.Windows.Forms.TableLayoutPanel();
            this.infoText = new System.Windows.Forms.Label();
            this.tableLayoutPanel2Info = new System.Windows.Forms.TableLayoutPanel();
            this.gitHub = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericJump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).BeginInit();
            this.tableLayoutPanel1Trainer.SuspendLayout();
            this.tableLayoutPanel2Trainer.SuspendLayout();
            this.tableLayoutPanel4Trainer.SuspendLayout();
            this.tableLayoutPanel3Trainer.SuspendLayout();
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
            this.drawDistance.AutoSize = true;
            this.drawDistance.Location = new System.Drawing.Point(3, 124);
            this.drawDistance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drawDistance.Name = "drawDistance";
            this.drawDistance.Size = new System.Drawing.Size(195, 22);
            this.drawDistance.TabIndex = 1;
            this.drawDistance.Text = "Infinity draw distance (F5)";
            this.drawDistance.UseVisualStyleBackColor = true;
            this.drawDistance.CheckedChanged += new System.EventHandler(this.drawDistance_CheckedChanged);
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
            // numericJump
            // 
            this.numericJump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericJump.Location = new System.Drawing.Point(1, 1);
            this.numericJump.Margin = new System.Windows.Forms.Padding(1);
            this.numericJump.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericJump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericJump.Name = "numericJump";
            this.numericJump.Size = new System.Drawing.Size(48, 26);
            this.numericJump.TabIndex = 3;
            this.numericJump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericJump.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericJump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericJump.ValueChanged += new System.EventHandler(this.numericJump_ValueChanged);
            // 
            // jumpLabel
            // 
            this.jumpLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.jumpLabel.AutoSize = true;
            this.jumpLabel.Location = new System.Drawing.Point(53, 6);
            this.jumpLabel.Name = "jumpLabel";
            this.jumpLabel.Size = new System.Drawing.Size(170, 18);
            this.jumpLabel.TabIndex = 4;
            this.jumpLabel.Text = "x jump force (Num+/Num-)";
            // 
            // numericSpeed
            // 
            this.numericSpeed.DecimalPlaces = 1;
            this.numericSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericSpeed.Location = new System.Drawing.Point(1, 1);
            this.numericSpeed.Margin = new System.Windows.Forms.Padding(1);
            this.numericSpeed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericSpeed.Name = "numericSpeed";
            this.numericSpeed.Size = new System.Drawing.Size(48, 26);
            this.numericSpeed.TabIndex = 5;
            this.numericSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSpeed.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSpeed.ValueChanged += new System.EventHandler(this.numericSpeed_ValueChanged);
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(53, 6);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(171, 18);
            this.speedLabel.TabIndex = 4;
            this.speedLabel.Text = "x game speed (PgUp/PgDn)";
            // 
            // superBelchCan
            // 
            this.superBelchCan.AutoSize = true;
            this.superBelchCan.Location = new System.Drawing.Point(3, 34);
            this.superBelchCan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superBelchCan.Name = "superBelchCan";
            this.superBelchCan.Size = new System.Drawing.Size(150, 22);
            this.superBelchCan.TabIndex = 1;
            this.superBelchCan.Text = "Super burp can (F2)";
            this.superBelchCan.UseVisualStyleBackColor = true;
            this.superBelchCan.CheckedChanged += new System.EventHandler(this.superBelchCan_CheckedChanged);
            // 
            // flyMode
            // 
            this.flyMode.AutoSize = true;
            this.flyMode.Location = new System.Drawing.Point(3, 64);
            this.flyMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flyMode.Name = "flyMode";
            this.flyMode.Size = new System.Drawing.Size(261, 22);
            this.flyMode.TabIndex = 1;
            this.flyMode.Text = "Fly mode (F3/Num5 and NumPad keys)";
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
            this.smoothLight.AutoSize = true;
            this.smoothLight.Location = new System.Drawing.Point(3, 154);
            this.smoothLight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.smoothLight.Name = "smoothLight";
            this.smoothLight.Size = new System.Drawing.Size(150, 22);
            this.smoothLight.TabIndex = 1;
            this.smoothLight.Text = "Smooth lighting (F6)";
            this.smoothLight.UseVisualStyleBackColor = true;
            this.smoothLight.CheckedChanged += new System.EventHandler(this.smoothLight_CheckedChanged);
            // 
            // invisibility
            // 
            this.invisibility.AutoSize = true;
            this.invisibility.Location = new System.Drawing.Point(3, 4);
            this.invisibility.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.invisibility.Name = "invisibility";
            this.invisibility.Size = new System.Drawing.Size(121, 22);
            this.invisibility.TabIndex = 1;
            this.invisibility.Text = "Invisibility (F1)";
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
            this.tableLayoutPanel1Trainer.Size = new System.Drawing.Size(460, 302);
            this.tableLayoutPanel1Trainer.TabIndex = 7;
            // 
            // tableLayoutPanel2Trainer
            // 
            this.tableLayoutPanel2Trainer.ColumnCount = 1;
            this.tableLayoutPanel2Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Trainer.Controls.Add(this.superBelchCan, 0, 1);
            this.tableLayoutPanel2Trainer.Controls.Add(this.invisibility, 0, 0);
            this.tableLayoutPanel2Trainer.Controls.Add(this.flyMode, 0, 2);
            this.tableLayoutPanel2Trainer.Controls.Add(this.tableLayoutPanel4Trainer, 0, 7);
            this.tableLayoutPanel2Trainer.Controls.Add(this.tableLayoutPanel3Trainer, 0, 6);
            this.tableLayoutPanel2Trainer.Controls.Add(this.smoothLight, 0, 5);
            this.tableLayoutPanel2Trainer.Controls.Add(this.drawDistance, 0, 4);
            this.tableLayoutPanel2Trainer.Controls.Add(this.freezeLevelTimer, 0, 3);
            this.tableLayoutPanel2Trainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2Trainer.Location = new System.Drawing.Point(165, 0);
            this.tableLayoutPanel2Trainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2Trainer.Name = "tableLayoutPanel2Trainer";
            this.tableLayoutPanel2Trainer.RowCount = 9;
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2Trainer.Size = new System.Drawing.Size(295, 302);
            this.tableLayoutPanel2Trainer.TabIndex = 0;
            // 
            // tableLayoutPanel4Trainer
            // 
            this.tableLayoutPanel4Trainer.ColumnCount = 2;
            this.tableLayoutPanel4Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel4Trainer.Controls.Add(this.numericSpeed, 0, 0);
            this.tableLayoutPanel4Trainer.Controls.Add(this.speedLabel, 1, 0);
            this.tableLayoutPanel4Trainer.Location = new System.Drawing.Point(0, 210);
            this.tableLayoutPanel4Trainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4Trainer.Name = "tableLayoutPanel4Trainer";
            this.tableLayoutPanel4Trainer.RowCount = 1;
            this.tableLayoutPanel4Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4Trainer.Size = new System.Drawing.Size(295, 30);
            this.tableLayoutPanel4Trainer.TabIndex = 7;
            // 
            // tableLayoutPanel3Trainer
            // 
            this.tableLayoutPanel3Trainer.ColumnCount = 2;
            this.tableLayoutPanel3Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3Trainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel3Trainer.Controls.Add(this.jumpLabel, 1, 0);
            this.tableLayoutPanel3Trainer.Controls.Add(this.numericJump, 0, 0);
            this.tableLayoutPanel3Trainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3Trainer.Location = new System.Drawing.Point(0, 180);
            this.tableLayoutPanel3Trainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3Trainer.Name = "tableLayoutPanel3Trainer";
            this.tableLayoutPanel3Trainer.RowCount = 1;
            this.tableLayoutPanel3Trainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3Trainer.Size = new System.Drawing.Size(295, 30);
            this.tableLayoutPanel3Trainer.TabIndex = 6;
            // 
            // freezeLevelTimer
            // 
            this.freezeLevelTimer.AutoSize = true;
            this.freezeLevelTimer.Location = new System.Drawing.Point(3, 94);
            this.freezeLevelTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.freezeLevelTimer.Name = "freezeLevelTimer";
            this.freezeLevelTimer.Size = new System.Drawing.Size(166, 22);
            this.freezeLevelTimer.TabIndex = 8;
            this.freezeLevelTimer.Text = "Freeze level timer (F4)";
            this.freezeLevelTimer.UseVisualStyleBackColor = true;
            this.freezeLevelTimer.CheckedChanged += new System.EventHandler(this.freezeLevelTimer_CheckedChanged);
            // 
            // pictureTaz
            // 
            this.pictureTaz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureTaz.Image = global::Taz_trainer.Properties.Resources.TAZ;
            this.pictureTaz.Location = new System.Drawing.Point(0, 0);
            this.pictureTaz.Margin = new System.Windows.Forms.Padding(0);
            this.pictureTaz.Name = "pictureTaz";
            this.pictureTaz.Size = new System.Drawing.Size(165, 302);
            this.pictureTaz.TabIndex = 1;
            this.pictureTaz.TabStop = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.trainerTab);
            this.tabs.Controls.Add(this.patcherTab);
            this.tabs.Controls.Add(this.infoTab);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(0);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(0, 0);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(468, 333);
            this.tabs.TabIndex = 8;
            // 
            // trainerTab
            // 
            this.trainerTab.Controls.Add(this.tableLayoutPanel1Trainer);
            this.trainerTab.Location = new System.Drawing.Point(4, 27);
            this.trainerTab.Margin = new System.Windows.Forms.Padding(0);
            this.trainerTab.Name = "trainerTab";
            this.trainerTab.Size = new System.Drawing.Size(460, 302);
            this.trainerTab.TabIndex = 0;
            this.trainerTab.Text = "Trainer";
            this.trainerTab.UseVisualStyleBackColor = true;
            // 
            // patcherTab
            // 
            this.patcherTab.Controls.Add(this.tableLayoutPanel1Patcher);
            this.patcherTab.Location = new System.Drawing.Point(4, 22);
            this.patcherTab.Margin = new System.Windows.Forms.Padding(0);
            this.patcherTab.Name = "patcherTab";
            this.patcherTab.Size = new System.Drawing.Size(460, 307);
            this.patcherTab.TabIndex = 1;
            this.patcherTab.Text = "Patcher";
            this.patcherTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1Patcher
            // 
            this.tableLayoutPanel1Patcher.ColumnCount = 1;
            this.tableLayoutPanel1Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Patcher.Controls.Add(this.tableLayoutPanel4Patcher, 0, 7);
            this.tableLayoutPanel1Patcher.Controls.Add(this.tableLayoutPanel3Patcher, 0, 5);
            this.tableLayoutPanel1Patcher.Controls.Add(this.tableLayoutPanel2Patcher, 0, 4);
            this.tableLayoutPanel1Patcher.Controls.Add(this.trainerTitle, 0, 0);
            this.tableLayoutPanel1Patcher.Controls.Add(this.disableVideos, 0, 3);
            this.tableLayoutPanel1Patcher.Controls.Add(this.disableDrawDistance, 0, 2);
            this.tableLayoutPanel1Patcher.Controls.Add(this.noCD, 0, 1);
            this.tableLayoutPanel1Patcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1Patcher.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1Patcher.Name = "tableLayoutPanel1Patcher";
            this.tableLayoutPanel1Patcher.RowCount = 8;
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1Patcher.Size = new System.Drawing.Size(460, 307);
            this.tableLayoutPanel1Patcher.TabIndex = 4;
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
            this.tableLayoutPanel4Patcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4Patcher.Location = new System.Drawing.Point(0, 267);
            this.tableLayoutPanel4Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4Patcher.Name = "tableLayoutPanel4Patcher";
            this.tableLayoutPanel4Patcher.RowCount = 1;
            this.tableLayoutPanel4Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4Patcher.Size = new System.Drawing.Size(460, 40);
            this.tableLayoutPanel4Patcher.TabIndex = 6;
            // 
            // patch
            // 
            this.patch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patch.Location = new System.Drawing.Point(3, 3);
            this.patch.Name = "patch";
            this.patch.Size = new System.Drawing.Size(147, 34);
            this.patch.TabIndex = 3;
            this.patch.Text = "Patch!";
            this.patch.UseVisualStyleBackColor = true;
            this.patch.Click += new System.EventHandler(this.patch_Click);
            // 
            // restore
            // 
            this.restore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restore.Location = new System.Drawing.Point(309, 3);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(148, 34);
            this.restore.TabIndex = 3;
            this.restore.Text = "Restore to original";
            this.restore.UseVisualStyleBackColor = true;
            this.restore.Click += new System.EventHandler(this.restore_Click);
            // 
            // restoreBackup
            // 
            this.restoreBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restoreBackup.Location = new System.Drawing.Point(156, 3);
            this.restoreBackup.Name = "restoreBackup";
            this.restoreBackup.Size = new System.Drawing.Size(147, 34);
            this.restoreBackup.TabIndex = 3;
            this.restoreBackup.Text = "Restore from backup";
            this.restoreBackup.UseVisualStyleBackColor = true;
            this.restoreBackup.Click += new System.EventHandler(this.restoreBackup_Click);
            // 
            // tableLayoutPanel3Patcher
            // 
            this.tableLayoutPanel3Patcher.ColumnCount = 5;
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3Patcher.Controls.Add(this.aspect2, 3, 0);
            this.tableLayoutPanel3Patcher.Controls.Add(this.aspect1, 1, 0);
            this.tableLayoutPanel3Patcher.Controls.Add(this.aspectRatio, 0, 0);
            this.tableLayoutPanel3Patcher.Controls.Add(this.pointsLabel, 2, 0);
            this.tableLayoutPanel3Patcher.Location = new System.Drawing.Point(0, 150);
            this.tableLayoutPanel3Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3Patcher.Name = "tableLayoutPanel3Patcher";
            this.tableLayoutPanel3Patcher.RowCount = 1;
            this.tableLayoutPanel3Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3Patcher.Size = new System.Drawing.Size(413, 30);
            this.tableLayoutPanel3Patcher.TabIndex = 5;
            // 
            // aspect2
            // 
            this.aspect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aspect2.Location = new System.Drawing.Point(208, 3);
            this.aspect2.Name = "aspect2";
            this.aspect2.Size = new System.Drawing.Size(29, 26);
            this.aspect2.TabIndex = 6;
            // 
            // aspect1
            // 
            this.aspect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aspect1.Location = new System.Drawing.Point(158, 3);
            this.aspect1.Name = "aspect1";
            this.aspect1.Size = new System.Drawing.Size(29, 26);
            this.aspect1.TabIndex = 4;
            // 
            // aspectRatio
            // 
            this.aspectRatio.AutoSize = true;
            this.aspectRatio.Checked = true;
            this.aspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aspectRatio.Location = new System.Drawing.Point(3, 4);
            this.aspectRatio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aspectRatio.Name = "aspectRatio";
            this.aspectRatio.Size = new System.Drawing.Size(146, 22);
            this.aspectRatio.TabIndex = 2;
            this.aspectRatio.Text = "Change aspect ratio";
            this.aspectRatio.UseVisualStyleBackColor = true;
            this.aspectRatio.CheckedChanged += new System.EventHandler(this.aspectRatio_CheckedChanged);
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(193, 6);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(9, 18);
            this.pointsLabel.TabIndex = 5;
            this.pointsLabel.Text = ":";
            // 
            // tableLayoutPanel2Patcher
            // 
            this.tableLayoutPanel2Patcher.ColumnCount = 6;
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2Patcher.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Patcher.Controls.Add(this.changeResolution, 0, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.height, 3, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.xLabel, 2, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.windowed, 5, 0);
            this.tableLayoutPanel2Patcher.Controls.Add(this.width, 1, 0);
            this.tableLayoutPanel2Patcher.Location = new System.Drawing.Point(0, 120);
            this.tableLayoutPanel2Patcher.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2Patcher.Name = "tableLayoutPanel2Patcher";
            this.tableLayoutPanel2Patcher.RowCount = 1;
            this.tableLayoutPanel2Patcher.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Patcher.Size = new System.Drawing.Size(413, 30);
            this.tableLayoutPanel2Patcher.TabIndex = 4;
            // 
            // changeResolution
            // 
            this.changeResolution.AutoSize = true;
            this.changeResolution.Checked = true;
            this.changeResolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeResolution.Location = new System.Drawing.Point(3, 4);
            this.changeResolution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeResolution.Name = "changeResolution";
            this.changeResolution.Size = new System.Drawing.Size(134, 22);
            this.changeResolution.TabIndex = 2;
            this.changeResolution.Text = "Change resolution";
            this.changeResolution.UseVisualStyleBackColor = true;
            this.changeResolution.CheckedChanged += new System.EventHandler(this.changeResolution_CheckedChanged);
            // 
            // height
            // 
            this.height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.height.Location = new System.Drawing.Point(238, 3);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(54, 26);
            this.height.TabIndex = 3;
            // 
            // xLabel
            // 
            this.xLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(218, 6);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 18);
            this.xLabel.TabIndex = 5;
            this.xLabel.Text = "x";
            // 
            // windowed
            // 
            this.windowed.AutoSize = true;
            this.windowed.Location = new System.Drawing.Point(318, 4);
            this.windowed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.windowed.Name = "windowed";
            this.windowed.Size = new System.Drawing.Size(91, 22);
            this.windowed.TabIndex = 2;
            this.windowed.Text = "Windowed";
            this.windowed.UseVisualStyleBackColor = true;
            this.windowed.CheckedChanged += new System.EventHandler(this.windowed_CheckedChanged);
            // 
            // width
            // 
            this.width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.width.Location = new System.Drawing.Point(158, 3);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(54, 26);
            this.width.TabIndex = 4;
            // 
            // trainerTitle
            // 
            this.trainerTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trainerTitle.AutoSize = true;
            this.trainerTitle.Location = new System.Drawing.Point(3, 6);
            this.trainerTitle.Name = "trainerTitle";
            this.trainerTitle.Size = new System.Drawing.Size(162, 18);
            this.trainerTitle.TabIndex = 5;
            this.trainerTitle.Text = "Choose options for patch:";
            // 
            // disableVideos
            // 
            this.disableVideos.AutoSize = true;
            this.disableVideos.Checked = true;
            this.disableVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableVideos.Location = new System.Drawing.Point(3, 94);
            this.disableVideos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disableVideos.Name = "disableVideos";
            this.disableVideos.Size = new System.Drawing.Size(143, 22);
            this.disableVideos.TabIndex = 2;
            this.disableVideos.Text = "Disable logo videos";
            this.disableVideos.UseVisualStyleBackColor = true;
            // 
            // disableDrawDistance
            // 
            this.disableDrawDistance.AutoSize = true;
            this.disableDrawDistance.Checked = true;
            this.disableDrawDistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableDrawDistance.Location = new System.Drawing.Point(3, 64);
            this.disableDrawDistance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disableDrawDistance.Name = "disableDrawDistance";
            this.disableDrawDistance.Size = new System.Drawing.Size(162, 22);
            this.disableDrawDistance.TabIndex = 2;
            this.disableDrawDistance.Text = "Disable draw distance";
            this.disableDrawDistance.UseVisualStyleBackColor = true;
            // 
            // noCD
            // 
            this.noCD.AutoSize = true;
            this.noCD.Checked = true;
            this.noCD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noCD.Location = new System.Drawing.Point(3, 34);
            this.noCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.noCD.Name = "noCD";
            this.noCD.Size = new System.Drawing.Size(98, 22);
            this.noCD.TabIndex = 2;
            this.noCD.Text = "NoCD patch";
            this.noCD.UseVisualStyleBackColor = true;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.tableLayoutPanel1Info);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(460, 307);
            this.infoTab.TabIndex = 2;
            this.infoTab.Text = "Info";
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1Info
            // 
            this.tableLayoutPanel1Info.ColumnCount = 1;
            this.tableLayoutPanel1Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Info.Controls.Add(this.infoText, 0, 0);
            this.tableLayoutPanel1Info.Controls.Add(this.tableLayoutPanel2Info, 0, 1);
            this.tableLayoutPanel1Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1Info.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1Info.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1Info.Name = "tableLayoutPanel1Info";
            this.tableLayoutPanel1Info.RowCount = 2;
            this.tableLayoutPanel1Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1Info.Size = new System.Drawing.Size(454, 301);
            this.tableLayoutPanel1Info.TabIndex = 0;
            // 
            // infoText
            // 
            this.infoText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.infoText.AutoSize = true;
            this.infoText.Location = new System.Drawing.Point(32, 67);
            this.infoText.Margin = new System.Windows.Forms.Padding(0);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(390, 126);
            this.infoText.TabIndex = 8;
            this.infoText.Text = resources.GetString("infoText.Text");
            this.infoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2Info
            // 
            this.tableLayoutPanel2Info.ColumnCount = 3;
            this.tableLayoutPanel2Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2Info.Controls.Add(this.gitHub, 1, 0);
            this.tableLayoutPanel2Info.Location = new System.Drawing.Point(0, 261);
            this.tableLayoutPanel2Info.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2Info.Name = "tableLayoutPanel2Info";
            this.tableLayoutPanel2Info.RowCount = 1;
            this.tableLayoutPanel2Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2Info.Size = new System.Drawing.Size(454, 40);
            this.tableLayoutPanel2Info.TabIndex = 7;
            // 
            // gitHub
            // 
            this.gitHub.Location = new System.Drawing.Point(154, 3);
            this.gitHub.Name = "gitHub";
            this.gitHub.Size = new System.Drawing.Size(145, 34);
            this.gitHub.TabIndex = 3;
            this.gitHub.Text = "GitHub page";
            this.gitHub.UseVisualStyleBackColor = true;
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
            this.Text = "Taz Wanted trainer and patcher v1.0";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericJump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).EndInit();
            this.tableLayoutPanel1Trainer.ResumeLayout(false);
            this.tableLayoutPanel2Trainer.ResumeLayout(false);
            this.tableLayoutPanel2Trainer.PerformLayout();
            this.tableLayoutPanel4Trainer.ResumeLayout(false);
            this.tableLayoutPanel4Trainer.PerformLayout();
            this.tableLayoutPanel3Trainer.ResumeLayout(false);
            this.tableLayoutPanel3Trainer.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown numericJump;
        private System.Windows.Forms.Label jumpLabel;
        public System.Windows.Forms.ToolStripStatusLabel statusField;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.NumericUpDown numericSpeed;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.CheckBox superBelchCan;
        private System.Windows.Forms.CheckBox flyMode;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox smoothLight;
        private System.Windows.Forms.CheckBox invisibility;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1Trainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2Trainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4Trainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3Trainer;
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
    }
}

