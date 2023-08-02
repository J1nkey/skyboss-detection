namespace CvTemplateMatching
{
    partial class TestEmguExtractTextSpeedForm
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
            btnImageSelected = new Button();
            btnExtractText = new Button();
            tbSearchText = new TextBox();
            lblImageSelected = new Label();
            lblResult = new Label();
            lblTimeOccupy = new Label();
            SuspendLayout();
            // 
            // btnImageSelected
            // 
            btnImageSelected.Location = new System.Drawing.Point(12, 21);
            btnImageSelected.Name = "btnImageSelected";
            btnImageSelected.Size = new System.Drawing.Size(94, 29);
            btnImageSelected.TabIndex = 0;
            btnImageSelected.Text = "Select";
            btnImageSelected.UseVisualStyleBackColor = true;
            btnImageSelected.Click += btnImageSelected_Click;
            // 
            // btnExtractText
            // 
            btnExtractText.Location = new System.Drawing.Point(12, 165);
            btnExtractText.Name = "btnExtractText";
            btnExtractText.Size = new System.Drawing.Size(94, 29);
            btnExtractText.TabIndex = 1;
            btnExtractText.Text = "Extract";
            btnExtractText.UseVisualStyleBackColor = true;
            btnExtractText.Click += btnExtractText_Click;
            // 
            // tbSearchText
            // 
            tbSearchText.Location = new System.Drawing.Point(12, 68);
            tbSearchText.Multiline = true;
            tbSearchText.Name = "tbSearchText";
            tbSearchText.ScrollBars = ScrollBars.Vertical;
            tbSearchText.Size = new System.Drawing.Size(767, 75);
            tbSearchText.TabIndex = 2;
            // 
            // lblImageSelected
            // 
            lblImageSelected.AutoSize = true;
            lblImageSelected.Location = new System.Drawing.Point(185, 25);
            lblImageSelected.Name = "lblImageSelected";
            lblImageSelected.Size = new System.Drawing.Size(104, 20);
            lblImageSelected.TabIndex = 3;
            lblImageSelected.Text = "Select image...";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new System.Drawing.Point(12, 215);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(43, 20);
            lblResult.TabIndex = 4;
            lblResult.Text = "State";
            // 
            // lblTimeOccupy
            // 
            lblTimeOccupy.AutoSize = true;
            lblTimeOccupy.Location = new System.Drawing.Point(12, 249);
            lblTimeOccupy.Name = "lblTimeOccupy";
            lblTimeOccupy.Size = new System.Drawing.Size(45, 20);
            lblTimeOccupy.TabIndex = 5;
            lblTimeOccupy.Text = "Time:";
            // 
            // TestEmguExtractTextSpeedForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 295);
            Controls.Add(lblTimeOccupy);
            Controls.Add(lblResult);
            Controls.Add(lblImageSelected);
            Controls.Add(tbSearchText);
            Controls.Add(btnExtractText);
            Controls.Add(btnImageSelected);
            Name = "TestEmguExtractTextSpeedForm";
            Text = "TestEmguExtractTextSpeedForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImageSelected;
        private Button btnExtractText;
        private TextBox tbSearchText;
        private Label lblImageSelected;
        private Label lblResult;
        private Label lblTimeOccupy;
    }
}