namespace FS80H.Scanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Fingerprint = new PictureBox();
            btn_Start_Capture = new Button();
            btn_Complete_Capture = new Button();
            btn_Download = new Button();
            label1 = new Label();
            txtLogs = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Fingerprint).BeginInit();
            SuspendLayout();
            // 
            // Fingerprint
            // 
            Fingerprint.Location = new Point(12, 12);
            Fingerprint.Name = "Fingerprint";
            Fingerprint.Size = new Size(345, 493);
            Fingerprint.TabIndex = 0;
            Fingerprint.TabStop = false;
            // 
            // btn_Start_Capture
            // 
            btn_Start_Capture.BackColor = Color.FromArgb(255, 255, 128);
            btn_Start_Capture.Location = new Point(10, 511);
            btn_Start_Capture.Name = "btn_Start_Capture";
            btn_Start_Capture.Size = new Size(119, 56);
            btn_Start_Capture.TabIndex = 2;
            btn_Start_Capture.Text = "Start Capture";
            btn_Start_Capture.UseVisualStyleBackColor = false;
            btn_Start_Capture.Click += btn_Start_Capture_Click;
            // 
            // btn_Complete_Capture
            // 
            btn_Complete_Capture.BackColor = Color.FromArgb(128, 255, 128);
            btn_Complete_Capture.Location = new Point(135, 511);
            btn_Complete_Capture.Name = "btn_Complete_Capture";
            btn_Complete_Capture.Size = new Size(119, 56);
            btn_Complete_Capture.TabIndex = 3;
            btn_Complete_Capture.Text = "Capture Image";
            btn_Complete_Capture.UseVisualStyleBackColor = false;
            btn_Complete_Capture.Click += btn_Complete_Capture_Click;
            // 
            // btn_Download
            // 
            btn_Download.BackColor = Color.FromArgb(255, 128, 128);
            btn_Download.Location = new Point(260, 511);
            btn_Download.Name = "btn_Download";
            btn_Download.Size = new Size(99, 56);
            btn_Download.TabIndex = 4;
            btn_Download.Text = "Download";
            btn_Download.UseVisualStyleBackColor = false;
            btn_Download.Click += btn_Download_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(377, 27);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(381, 12);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(372, 493);
            txtLogs.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 575);
            Controls.Add(txtLogs);
            Controls.Add(label1);
            Controls.Add(btn_Download);
            Controls.Add(btn_Complete_Capture);
            Controls.Add(btn_Start_Capture);
            Controls.Add(Fingerprint);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)Fingerprint).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Fingerprint;
        private Button btn_Start_Capture;
        private Button btn_Complete_Capture;
        private Button btn_Download;
        private Label label1;
        private TextBox txtLogs;
    }
}
