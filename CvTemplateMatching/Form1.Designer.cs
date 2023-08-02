namespace CvTemplateMatching
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
            btnMatching = new Button();
            lbTimeOccupancy = new Label();
            cbGames = new ComboBox();
            btnScreenshoot = new Button();
            lblScreenshootName = new Label();
            lblResult = new Label();
            btnMatchingAll = new Button();
            SuspendLayout();
            // 
            // btnMatching
            // 
            btnMatching.Location = new System.Drawing.Point(12, 104);
            btnMatching.Name = "btnMatching";
            btnMatching.Size = new System.Drawing.Size(94, 29);
            btnMatching.TabIndex = 1;
            btnMatching.Text = "Matching";
            btnMatching.UseVisualStyleBackColor = true;
            btnMatching.Click += btnMatching_Click;
            // 
            // lbTimeOccupancy
            // 
            lbTimeOccupancy.AutoSize = true;
            lbTimeOccupancy.Location = new System.Drawing.Point(12, 152);
            lbTimeOccupancy.Name = "lbTimeOccupancy";
            lbTimeOccupancy.Size = new System.Drawing.Size(72, 20);
            lbTimeOccupancy.TabIndex = 2;
            lbTimeOccupancy.Text = "Occupied";
            // 
            // cbGames
            // 
            cbGames.FormattingEnabled = true;
            cbGames.Location = new System.Drawing.Point(12, 61);
            cbGames.Name = "cbGames";
            cbGames.Size = new System.Drawing.Size(234, 28);
            cbGames.TabIndex = 4;
            // 
            // btnScreenshoot
            // 
            btnScreenshoot.Location = new System.Drawing.Point(12, 12);
            btnScreenshoot.Name = "btnScreenshoot";
            btnScreenshoot.Size = new System.Drawing.Size(111, 29);
            btnScreenshoot.TabIndex = 5;
            btnScreenshoot.Text = "Screenshoot";
            btnScreenshoot.UseVisualStyleBackColor = true;
            btnScreenshoot.Click += btnScreenshoot_Click;
            // 
            // lblScreenshootName
            // 
            lblScreenshootName.AutoSize = true;
            lblScreenshootName.Location = new System.Drawing.Point(279, 16);
            lblScreenshootName.Name = "lblScreenshootName";
            lblScreenshootName.Size = new System.Drawing.Size(133, 20);
            lblScreenshootName.TabIndex = 6;
            lblScreenshootName.Text = "Take a screenshoot";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new System.Drawing.Point(12, 182);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(49, 20);
            lblResult.TabIndex = 7;
            lblResult.Text = "Result";
            // 
            // btnMatchingAll
            // 
            btnMatchingAll.Location = new System.Drawing.Point(112, 104);
            btnMatchingAll.Name = "btnMatchingAll";
            btnMatchingAll.Size = new System.Drawing.Size(121, 29);
            btnMatchingAll.TabIndex = 8;
            btnMatchingAll.Text = "Matching All";
            btnMatchingAll.UseVisualStyleBackColor = true;
            btnMatchingAll.Click += btnMatchingAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(456, 238);
            Controls.Add(btnMatchingAll);
            Controls.Add(lblResult);
            Controls.Add(lblScreenshootName);
            Controls.Add(btnScreenshoot);
            Controls.Add(cbGames);
            Controls.Add(lbTimeOccupancy);
            Controls.Add(btnMatching);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnMatching;
        private Label lbTimeOccupancy;
        private ComboBox cbGames;
        private Button btnScreenshoot;
        private Label lblScreenshootName;
        private Label lblResult;
        private Button btnMatchingAll;
    }
}