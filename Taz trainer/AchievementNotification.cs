// MilkGames was here!
// Enjoy a pretty amazing achievement notification!
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Taz_trainer.Properties;
using Taz_trainer;

/// <summary>
/// Specifies the visual style of the achievement notification.
/// </summary>
public enum AchievementStyle
{
    Zoo,
    City,
    West,
    Tazland,
    Challenge,
    Hardcore
}

/// <summary>
/// Represents a customizable achievement notification window that appears and disappears with animation.
/// It supports different visual styles and queues multiple achievements.
/// </summary>
public class AchievementNotificationForm : Form
{
    // Window style constants
    private const int WS_EX_NOACTIVATE = 0x08000000; // Form doesn't activate when shown

    // Controls
    private PictureBox achievementIconPb;
    private Label titleLabel;
    private Label descriptionLabel;
    private System.Windows.Forms.Timer animationTimer;
    private System.Windows.Forms.Timer displayDurationTimer;

    // Animation parameters
    private int targetY;        // The Y-coordinate where the notification settles.
    private int currentY;       // The current Y-coordinate during animation.
    private int startY;         // The initial Y-coordinate (off-screen).
    private double currentOpacity; // The current opacity level during animation.

    private const int ANIMATION_STEP_Y = 16;    // Pixels to move per animation tick for Y-axis.
    private const double OPACITY_STEP = 0.08;   // Amount to change opacity per animation tick.
    private const int DISPLAY_DURATION_MS = 5000; // Duration the notification stays fully visible.

    // Sound and style
    private SoundPlayer soundPlayer;
    private AchievementStyle currentStyle;

    // Rounded corners and appearance
    private int cornerRadius = 25; // Radius for rounded corners.
    private const int OUTLINE_BORDER_WIDTH = 8; // Width of the black outline.
    private const int GLOW_EFFECT_WIDTH = 12; // Width of the glow effect pen for specific styles.

    // --- Static members for queueing achievements ---
    private static Queue<AchievementData> achievementQueue = new Queue<AchievementData>();
    private static bool isNotificationShowing = false; // Flag to indicate if a notification is currently active.
    private static readonly object queueLock = new object(); // Thread synchronization for queue access.

    /// <summary>
    /// A private struct to hold the data for an achievement to be displayed or queued.
    /// </summary>
    private struct AchievementData
    {
        public string Title;
        public string Description;
        public Image Icon;
        public AchievementStyle Style;
    }
    // --- End of static members for queueing ---

    /// <summary>
    /// Initializes a new instance of the <see cref="AchievementNotificationForm"/> class.
    /// Sets up components, form properties, and prepares for display.
    /// </summary>
    public AchievementNotificationForm()
    {
        this.DoubleBuffered = true; // Enables double buffering to reduce flicker during custom painting.
        InitializeComponents();
        SetupForm();
    }

    /// <summary>
    /// Initializes the visual components (PictureBox, Labels, Timers) of the form.
    /// </summary>
    private void InitializeComponents()
    {
        this.achievementIconPb = new PictureBox();
        this.titleLabel = new Label();
        this.descriptionLabel = new Label();
        this.animationTimer = new System.Windows.Forms.Timer();
        this.displayDurationTimer = new System.Windows.Forms.Timer();

        // Achievement Icon PictureBox
        this.achievementIconPb.Location = new Point(20, 20);
        this.achievementIconPb.Size = new Size(70, 70);
        this.achievementIconPb.SizeMode = PictureBoxSizeMode.StretchImage;
        this.achievementIconPb.BackColor = Color.Transparent; // Important for custom background to show through.

        // Title Label
        this.titleLabel.Location = new Point(100, 13);
        this.titleLabel.Size = new Size(400, 25);
        this.titleLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        this.titleLabel.ForeColor = Color.White;
        this.titleLabel.BackColor = Color.Transparent; // Shows form's custom background.
        this.titleLabel.TextAlign = ContentAlignment.MiddleLeft;

        // Description Label
        this.descriptionLabel.Location = new Point(100, 43); // Positioned below the title.
        this.descriptionLabel.Size = new Size(280, 60);
        this.descriptionLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        this.descriptionLabel.ForeColor = Color.Gainsboro;
        this.descriptionLabel.BackColor = Color.Transparent; // Shows form's custom background.
        this.descriptionLabel.TextAlign = ContentAlignment.TopLeft;


        // Animation Timer (for slide-in/out and fade-in/out effects)
        this.animationTimer.Interval = 15; // Aims for approximately 66 FPS.
        this.animationTimer.Tick += AnimationTimer_Tick;

        // Display Duration Timer (determines how long the notification stays fully visible)
        this.displayDurationTimer.Interval = DISPLAY_DURATION_MS;
        this.displayDurationTimer.Tick += DisplayDurationTimer_Tick;

        this.Controls.Add(this.achievementIconPb);
        this.Controls.Add(this.titleLabel);
        this.Controls.Add(this.descriptionLabel);
    }

    /// <summary>
    /// Sets up the form's initial properties, such as border style, transparency, size, and position.
    /// Also defines the rounded region of the form.
    /// </summary>
    private void SetupForm()
    {
        this.FormBorderStyle = FormBorderStyle.None; // No standard window border or title bar.
        this.ShowInTaskbar = false; // The form will not appear in the Windows taskbar.
        this.TopMost = true;        // The form will stay on top of all other windows.
        this.StartPosition = FormStartPosition.Manual; // Position will be set manually.
        this.Opacity = 0;           // Starts fully transparent for the fade-in animation.

        // Form dimensions
        this.Width = 500;
        this.Height = 110;

        // Set a specific, unlikely color as BackColor and make it the TransparencyKey.
        // Areas of the form with this BackColor will be rendered transparent.
        // Our OnPaint method will draw over this entirely for the visible parts of the notification.
        this.BackColor = Color.Magenta;
        this.TransparencyKey = Color.Magenta;

        // Calculate starting position (centered horizontally, off-screen at the top).
        this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        this.startY = -this.Height - 10; // Positioned just above the visible screen area.
        this.currentY = this.startY;
        this.Top = this.currentY;
        this.targetY = 20; // Target Y position on screen (indent from the top).

        // Set the rounded region for the form. This is done once as the form size is fixed.
        using (GraphicsPath path = CreateRoundedRectanglePath(this.ClientRectangle, cornerRadius))
        {
            this.Region = new Region(path); // Defines the visible, non-rectangular shape of the form.
        }
    }

    /// <summary>
    /// Overrides the form's CreateParams property to apply custom window styles (WS_EX_).
    /// </summary>
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= WS_EX_NOACTIVATE; // Prevents the form from stealing focus when shown.
            cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT - for click-through, why not?
            return cp;
        }
    }

    /// <summary>
    /// Handles the custom painting of the form's background, border, and glow effects.
    /// This method is called whenever the form needs to be redrawn.
    /// </summary>
    /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data and Graphics object.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
        // base.OnPaint(e) is not called at the beginning because we are fully custom-painting the background.
        // It will be called later to allow child controls to paint themselves.

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Ensures smooth lines and curves for drawing.

        // Create the main path for drawing the form's shape (the Region is already set).
        // Using ClientRectangle ensures the path is relative to the drawable area of the form.
        using (GraphicsPath drawPath = CreateRoundedRectanglePath(this.ClientRectangle, cornerRadius))
        {
            Color backgroundColor;
            Color glowColor = Color.Transparent;
            bool hasGlow = false;

            // Determine background color and glow effect based on the current achievement style.
            switch (currentStyle)
            {
                case AchievementStyle.Zoo:
                    backgroundColor = Color.Green;
                    break;
                case AchievementStyle.City:
                    backgroundColor = Color.SteelBlue;
                    break;
                case AchievementStyle.West:
                    backgroundColor = Color.Peru; // Sand-like color.
                    break;
                case AchievementStyle.Tazland:
                    backgroundColor = Color.DarkGreen;
                    break;
                case AchievementStyle.Challenge:
                    backgroundColor = Color.DimGray;
                    glowColor = Color.DeepSkyBlue;
                    hasGlow = true;
                    break;
                case AchievementStyle.Hardcore:
                    backgroundColor = Color.Firebrick; // Essentially just red.
                    glowColor = Color.Gold;
                    hasGlow = true;
                    break;
                default: // Just for a compiler.
                    backgroundColor = Color.Gray;
                    break;
            }

            // Fill the background of the notification using the determined color.
            using (SolidBrush backBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillPath(backBrush, drawPath);
            }

            // Draw the "glow" effect for Challenge and Hardcore styles.
            // This is rendered as a thicker, semi-transparent line along the existing path.
            if (hasGlow)
            {
                using (Pen glowPen = new Pen(glowColor, GLOW_EFFECT_WIDTH))
                {
                    glowPen.LineJoin = LineJoin.Round; // Provides smoother joins for thick lines.
                    e.Graphics.DrawPath(glowPen, drawPath);
                }
            }

            // Draw the main black outline around the window.
            using (Pen outlinePen = new Pen(Color.Black, OUTLINE_BORDER_WIDTH))
            {
                outlinePen.LineJoin = LineJoin.Round; // Smoother corners for the outline.
                e.Graphics.DrawPath(outlinePen, drawPath);
            }
        }

        // Call base.OnPaint(e) AFTER custom background drawing has completed.
        // This allows child controls (Labels, PictureBox) to paint themselves
        // on top of our custom-drawn background.
        base.OnPaint(e);

        // Draw the icon border for specific styles (Challenge, Hardcore).
        // This is drawn on top of the PictureBox (if it was painted by base.OnPaint).
        if (currentStyle == AchievementStyle.Challenge || currentStyle == AchievementStyle.Hardcore)
        {
            Color iconBorderColor = (currentStyle == AchievementStyle.Challenge) ? Color.DeepSkyBlue : Color.Gold;
            using (Pen pen = new Pen(iconBorderColor, 2)) // 2px border for the icon.
            {
                Rectangle iconRect = achievementIconPb.Bounds; // Bounds are relative to the form.
                iconRect.Inflate(1, 1); // Makes the border slightly larger than the icon itself.
                e.Graphics.DrawRectangle(pen, iconRect);
            }
        }
    }

    /// <summary>
    /// Creates a <see cref="GraphicsPath"/> object representing a rectangle with rounded corners.
    /// </summary>
    /// <param name="bounds">The <see cref="Rectangle"/> defining the bounds of the shape.</param>
    /// <param name="radius">The radius of the corners. If too large, it will be adjusted.</param>
    /// <returns>A <see cref="GraphicsPath"/> for the rounded rectangle.</returns>
    private static GraphicsPath CreateRoundedRectanglePath(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        if (radius <= 0) // If no radius, return a simple rectangle.
        {
            path.AddRectangle(bounds);
            return path;
        }

        // Ensure the diameter for arcs is not larger than the rectangle's dimensions.
        int diameter = radius * 2;
        diameter = Math.Min(diameter, Math.Min(bounds.Width, bounds.Height));
        radius = diameter / 2; // Recalculate radius based on adjusted diameter.

        if (radius <= 0) // If bounds are too small for any rounding after adjustment.
        {
            path.AddRectangle(bounds);
            return path;
        }

        // Define the arcs for the rounded corners.
        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top-left corner
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top-right corner
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right corner
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left corner
        path.CloseFigure(); // Connects the last arc to the first, completing the shape.
        return path;
    }

    /// <summary>
    /// Shows an achievement notification with the specified details and style.
    /// If a notification is already being shown, the new achievement is added to a queue.
    /// </summary>
    /// <param name="title">The title of the achievement.</param>
    /// <param name="description">The description of the achievement.</param>
    /// <param name="icon">The <see cref="Image"/> for the achievement. A default icon will be used if null.</param>
    /// <param name="style">The <see cref="AchievementStyle"/> determining the visual appearance.</param>
    public static void ShowAchievement(string title, string description, Image icon, AchievementStyle style)
    {
        AchievementData data = new AchievementData
        {
            Title = title,
            Description = description,
            Icon = icon,
            Style = style
        };

        lock (queueLock) // Ensure thread-safe access to the queue and showing flag.
        {
            // Check if a notification is already showing or if a form instance still exists (defensive check).
            if (isNotificationShowing || Application.OpenForms.OfType<AchievementNotificationForm>().Any())
            {
                achievementQueue.Enqueue(data); // Add to queue if one is active.
            }
            else
            {
                isNotificationShowing = true; // Mark that a notification is now being processed.
                DisplayAchievement(data);     // Display immediately.
            }
        }
    }

    /// <summary>
    /// Creates, configures, and displays the achievement notification form with the given data.
    /// This method is called internally when it's confirmed safe to show a new notification.
    /// </summary>
    /// <param name="data">The <see cref="AchievementData"/> to display.</param>
    private static void DisplayAchievement(AchievementData data)
    {
        AchievementNotificationForm achievementForm = new AchievementNotificationForm();

        achievementForm.titleLabel.Text = data.Title;
        achievementForm.descriptionLabel.Text = data.Description;
        // Use a default achievement icon from resources if no specific icon is provided.
        achievementForm.achievementIconPb.Image = data.Icon ?? Resources.defaultAchievement;
        achievementForm.currentStyle = data.Style;

        /*
        Stream soundStream = Resources.achievement;

        try
        {
            if (soundStream != null)
            {
                achievementForm.soundPlayer = new SoundPlayer(soundStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading sound for achievement style {data.Style}: {ex.Message}");
            achievementForm.soundPlayer = null; // Ensure player is null if sound loading fails.
        }
        */

        // Subscribe to the FormClosed event to handle cleanup and process the next item in the queue.
        achievementForm.FormClosed += AchievementForm_FormClosed;

        // Force the form to redraw with the new style settings before it's shown.
        achievementForm.Refresh();
        // Show the form. This must be called to create the window handle before starting animations.
        achievementForm.Show();
        achievementForm.StartAnimationIn(); // Begin the appearance animation.
    }

    /// <summary>
    /// Handles the <see cref="Form.FormClosed"/> event of an achievement notification.
    /// This method manages the achievement queue, displaying the next notification if available.
    /// </summary>
    /// <param name="sender">The source of the event (the closed form).</param>
    /// <param name="e">A <see cref="FormClosedEventArgs"/> that contains the event data.</param>
    private static void AchievementForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        // Unsubscribe from the event to prevent memory leaks from static event handlers.
        if (sender is AchievementNotificationForm form)
        {
            form.FormClosed -= AchievementForm_FormClosed;
        }

        lock (queueLock) // Ensure thread-safe access to the queue.
        {
            isNotificationShowing = false; // Mark that the current notification is no longer active.
            if (achievementQueue.Count > 0) // Check if there are more achievements in the queue.
            {
                AchievementData nextData = achievementQueue.Dequeue(); // Get the next achievement.
                isNotificationShowing = true; // Mark that a new notification is being processed.
                DisplayAchievement(nextData); // Display the next achievement.
            }
        }
    }

    /// <summary>
    /// Starts the animation for the notification appearing on screen (sliding in and fading in).
    /// </summary>
    private void StartAnimationIn()
    {
        // Reset position and opacity for appearance.
        this.currentY = this.startY;
        this.Top = this.currentY;
        this.currentOpacity = 0.0;
        this.Opacity = this.currentOpacity;

        //soundPlayer?.Play(); // Play the achievement sound, if loaded.

        this.animationTimer.Tag = "in"; // Set state for the animation timer to "in" (appearing).
        this.animationTimer.Start();
    }

    /// <summary>
    /// Starts the animation for the notification disappearing from screen (sliding out and fading out).
    /// </summary>
    private void StartAnimationOut()
    {
        this.animationTimer.Tag = "out"; // Set state for the animation timer to "out" (disappearing).
        this.animationTimer.Start();
    }

    /// <summary>
    /// Handles the <see cref="System.Windows.Forms.Timer.Tick"/> event of the animation timer.
    /// This method updates the form's position and opacity to create animation effects.
    /// </summary>
    /// <param name="sender">The source of the event (the animation timer).</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        if (this.animationTimer.Tag.ToString() == "in") // Process "appearing" animation.
        {
            bool moved = false;
            if (currentY < targetY) // Move down into view.
            {
                currentY += ANIMATION_STEP_Y;
                if (currentY > targetY) currentY = targetY; // Don't overshoot.
                this.Top = currentY;
                moved = true;
            }

            bool opacityChanged = false;
            if (currentOpacity < 1.0) // Fade in.
            {
                currentOpacity += OPACITY_STEP;
                if (currentOpacity > 1.0) currentOpacity = 1.0; // Cap at full opacity.
                this.Opacity = currentOpacity;
                opacityChanged = true;
            }

            if (!moved && !opacityChanged) // If both position and opacity have reached their targets.
            {
                animationTimer.Stop();
                displayDurationTimer.Start(); // Start timer to hold notification on screen.
            }
        }
        else // Process "disappearing" animation (Tag == "out").
        {
            bool moved = false;
            if (currentY > startY) // Move up towards the off-screen position.
            {
                currentY -= ANIMATION_STEP_Y;
                if (currentY < startY) currentY = startY; // Don't overshoot.
                this.Top = currentY;
                moved = true;
            }

            bool opacityChanged = false;
            if (currentOpacity > 0.0) // Fade out.
            {
                currentOpacity -= OPACITY_STEP;
                if (currentOpacity < 0.0) currentOpacity = 0.0; // Cap at full transparency.
                this.Opacity = currentOpacity;
                opacityChanged = true;
            }

            if (!moved && !opacityChanged) // If both position and opacity have reached their targets.
            {
                animationTimer.Stop();
                this.Close(); // Close the form. This will trigger the FormClosed event for queue management.
            }
        }
    }

    /// <summary>
    /// Handles the <see cref="System.Windows.Forms.Timer.Tick"/> event of the display duration timer.
    /// This method starts the disappearing animation once the notification has been visible for the set duration.
    /// </summary>
    /// <param name="sender">The source of the event (the display duration timer).</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    private void DisplayDurationTimer_Tick(object sender, EventArgs e)
    {
        displayDurationTimer.Stop();
        StartAnimationOut(); // Begin the disappearing animation.
    }

    /// <summary>
    /// Immediately stops all animations and closes the form.
    /// This can be used for an abrupt dismissal if needed by external logic.
    /// Closing the form will also trigger the standard queue processing.
    /// </summary>
    public void ForceClose()
    {
        animationTimer?.Stop();
        displayDurationTimer?.Stop();

        // Ensure the form is not already disposed before trying to close it.
        if (!this.IsDisposed && this.IsHandleCreated)
        {
            // Using BeginInvoke to ensure Close is called on the UI thread
            // if ForceClose might be called from a non-UI thread.
            // If always called from UI thread, direct this.Close() is fine.
            this.BeginInvoke(new MethodInvoker(this.Close));
        }
    }

    /// <summary>
    /// Cleans up any resources being used by the form, particularly managed resources like timers and sound players.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dispose of managed resources.
            animationTimer?.Dispose();
            displayDurationTimer?.Dispose();
            //soundPlayer?.Dispose(); // Disposes the SoundPlayer and releases the sound file.
            achievementIconPb?.Dispose();
            titleLabel?.Dispose();
            descriptionLabel?.Dispose();
            // The Region object associated with the form is disposed automatically when the form is disposed.
        }
        base.Dispose(disposing);
    }
}