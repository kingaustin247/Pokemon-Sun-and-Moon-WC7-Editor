namespace PokemonSunMoonRNGTool
{
    partial class ParentsEntry
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
            this.LB_Parents = new System.Windows.Forms.ListBox();
            this.SetPre = new System.Windows.Forms.Button();
            this.SetPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Parents
            // 
            this.LB_Parents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Parents.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Parents.FormattingEnabled = true;
            this.LB_Parents.ItemHeight = 14;
            this.LB_Parents.Location = new System.Drawing.Point(12, 12);
            this.LB_Parents.Name = "LB_Parents";
            this.LB_Parents.Size = new System.Drawing.Size(260, 298);
            this.LB_Parents.TabIndex = 0;
            // 
            // SetPre
            // 
            this.SetPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SetPre.Location = new System.Drawing.Point(12, 326);
            this.SetPre.Name = "SetPre";
            this.SetPre.Size = new System.Drawing.Size(75, 23);
            this.SetPre.TabIndex = 1;
            this.SetPre.Text = "♂親にする";
            this.SetPre.UseVisualStyleBackColor = true;
            this.SetPre.Click += new System.EventHandler(this.SetPre_Click);
            // 
            // SetPost
            // 
            this.SetPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SetPost.Location = new System.Drawing.Point(93, 326);
            this.SetPost.Name = "SetPost";
            this.SetPost.Size = new System.Drawing.Size(75, 23);
            this.SetPost.TabIndex = 2;
            this.SetPost.Text = "♀親にする";
            this.SetPost.UseVisualStyleBackColor = true;
            this.SetPost.Click += new System.EventHandler(this.SetPost_Click);
            // 
            // ParentsEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.SetPost);
            this.Controls.Add(this.SetPre);
            this.Controls.Add(this.LB_Parents);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "ParentsEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ParentsEntry";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Parents;
        private System.Windows.Forms.Button SetPre;
        private System.Windows.Forms.Button SetPost;
    }
}