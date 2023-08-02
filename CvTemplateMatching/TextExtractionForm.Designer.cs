namespace CvTemplateMatching
{
    partial class TextExtractionForm
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
            btnImage = new Button();
            pcbImage = new PictureBox();
            btnExtractText = new Button();
            tbResult = new TextBox();
            lblResult = new Label();
            btnEmguExtract = new Button();
            btnDownload = new Button();
            label1 = new Label();
            lblTimeOccupy = new Label();
            btnCheckGameState = new Button();
            ((System.ComponentModel.ISupportInitialize)pcbImage).BeginInit();
            SuspendLayout();
            // 
            // btnImage
            // 
            btnImage.Location = new System.Drawing.Point(14, 15);
            btnImage.Name = "btnImage";
            btnImage.Size = new System.Drawing.Size(94, 29);
            btnImage.TabIndex = 0;
            btnImage.Text = "Open";
            btnImage.UseVisualStyleBackColor = true;
            btnImage.Click += btnImage_Click;
            // 
            // pcbImage
            // 
            pcbImage.Location = new System.Drawing.Point(211, 15);
            pcbImage.Name = "pcbImage";
            pcbImage.Size = new System.Drawing.Size(562, 325);
            pcbImage.TabIndex = 1;
            pcbImage.TabStop = false;
            // 
            // btnExtractText
            // 
            btnExtractText.Location = new System.Drawing.Point(14, 64);
            btnExtractText.Name = "btnExtractText";
            btnExtractText.Size = new System.Drawing.Size(94, 29);
            btnExtractText.TabIndex = 2;
            btnExtractText.Text = "Extract";
            btnExtractText.UseVisualStyleBackColor = true;
            btnExtractText.Click += btnExtractText_Click;
            // 
            // tbResult
            // 
            tbResult.Location = new System.Drawing.Point(14, 400);
            tbResult.Multiline = true;
            tbResult.Name = "tbResult";
            tbResult.ScrollBars = ScrollBars.Vertical;
            tbResult.Size = new System.Drawing.Size(771, 117);
            tbResult.TabIndex = 3;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new System.Drawing.Point(18, 368);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(49, 20);
            lblResult.TabIndex = 4;
            lblResult.Text = "Result";
            // 
            // btnEmguExtract
            // 
            btnEmguExtract.Location = new System.Drawing.Point(14, 111);
            btnEmguExtract.Name = "btnEmguExtract";
            btnEmguExtract.Size = new System.Drawing.Size(133, 29);
            btnEmguExtract.TabIndex = 5;
            btnEmguExtract.Text = "EmguCV Extract";
            btnEmguExtract.UseVisualStyleBackColor = true;
            btnEmguExtract.Click += btnEmguExtract_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new System.Drawing.Point(11, 215);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new System.Drawing.Size(94, 29);
            btnDownload.TabIndex = 6;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 265);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 20);
            label1.TabIndex = 7;
            label1.Text = "Time occupy";
            // 
            // lblTimeOccupy
            // 
            lblTimeOccupy.AutoSize = true;
            lblTimeOccupy.Location = new System.Drawing.Point(14, 297);
            lblTimeOccupy.Name = "lblTimeOccupy";
            lblTimeOccupy.Size = new System.Drawing.Size(63, 20);
            lblTimeOccupy.TabIndex = 8;
            lblTimeOccupy.Text = "00:00:00";
            // 
            // btnCheckGameState
            // 
            btnCheckGameState.Location = new System.Drawing.Point(15, 163);
            btnCheckGameState.Name = "btnCheckGameState";
            btnCheckGameState.Size = new System.Drawing.Size(94, 29);
            btnCheckGameState.TabIndex = 9;
            btnCheckGameState.Text = "Game State";
            btnCheckGameState.UseVisualStyleBackColor = true;
            btnCheckGameState.Click += btnCheckGameState_Click;
            // 
            // TextExtractionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(797, 529);
            Controls.Add(btnCheckGameState);
            Controls.Add(lblTimeOccupy);
            Controls.Add(label1);
            Controls.Add(btnDownload);
            Controls.Add(btnEmguExtract);
            Controls.Add(lblResult);
            Controls.Add(tbResult);
            Controls.Add(btnExtractText);
            Controls.Add(pcbImage);
            Controls.Add(btnImage);
            Name = "TextExtractionForm";
            Text = "TextExtractionForm";
            ((System.ComponentModel.ISupportInitialize)pcbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImage;
        private PictureBox pcbImage;
        private Button btnExtractText;
        private TextBox tbResult;
        private Label lblResult;
        private Button btnEmguExtract;
        private Button btnDownload;
        private Label label1;
        private Label lblTimeOccupy;
        private Button btnCheckGameState;
    }
}