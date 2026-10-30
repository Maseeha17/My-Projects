namespace GameScriptManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbFull;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RichTextBox rtbFullScript;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrentLine;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.btnLoad = new System.Windows.Forms.Button();
            this.rtbFullScript = new System.Windows.Forms.RichTextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrentLine = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();

            this.SuspendLayout();


            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                18F,
                System.Drawing.FontStyle.Bold);

            this.lblTitle.Location = new System.Drawing.Point(280, 20);
            this.lblTitle.Text = "GAME SCRIPT MANAGER";


            // Full Script Radio Button
            this.rbFull.AutoSize = true;
            this.rbFull.Location = new System.Drawing.Point(60, 80);
            this.rbFull.Text = "Full Script";
            this.rbFull.CheckedChanged += new System.EventHandler(this.rbFull_CheckedChanged);


            // Single Line Radio Button
            this.rbSingle.AutoSize = true;
            this.rbSingle.Location = new System.Drawing.Point(180, 80);
            this.rbSingle.Text = "One Line";
            this.rbSingle.CheckedChanged += new System.EventHandler(this.rbSingle_CheckedChanged);


            // Load Button
            this.btnLoad.Location = new System.Drawing.Point(730, 75);
            this.btnLoad.Size = new System.Drawing.Size(140, 40);
            this.btnLoad.Text = "Load Story";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);


            // Full Story Display
            this.rtbFullScript.Location = new System.Drawing.Point(40, 130);
            this.rtbFullScript.Size = new System.Drawing.Size(840, 230);
            this.rtbFullScript.ReadOnly = true;


            // Current Story Label
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblCurrent.Location = new System.Drawing.Point(40, 380);
            this.lblCurrent.Text = "Current Story Line";


            // Current Story TextBox
            this.txtCurrentLine.Location = new System.Drawing.Point(40, 410);
            this.txtCurrentLine.Multiline = true;
            this.txtCurrentLine.ReadOnly = true;
            this.txtCurrentLine.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtCurrentLine.Size =
                new System.Drawing.Size(840, 90);


            // Previous Button
            this.btnPrevious.Location =
                new System.Drawing.Point(240, 530);

            this.btnPrevious.Size =
                new System.Drawing.Size(140, 45);

            this.btnPrevious.Text = "Previous";

            this.btnPrevious.Click +=
                new System.EventHandler(this.btnPrevious_Click);



            // Next Button
            this.btnNext.Location =
                new System.Drawing.Point(520, 530);

            this.btnNext.Size =
                new System.Drawing.Size(140, 45);

            this.btnNext.Text = "Next";

            this.btnNext.Click +=
                new System.EventHandler(this.btnNext_Click);



            // Form
            this.ClientSize =
                new System.Drawing.Size(920, 620);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rbFull);
            this.Controls.Add(this.rbSingle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rtbFullScript);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrentLine);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Game Script Manager";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}