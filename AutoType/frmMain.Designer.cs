namespace AutoType
{
    partial class frmMain
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
            this.btnType = new System.Windows.Forms.Button();
            this.lblDelayInfo = new System.Windows.Forms.Label();
            this.tbKeys = new System.Windows.Forms.RichTextBox();
            this.lblAbout = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnType
            // 
            this.btnType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnType.Location = new System.Drawing.Point(369, 385);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(75, 23);
            this.btnType.TabIndex = 0;
            this.btnType.Text = "Type";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // lblDelayInfo
            // 
            this.lblDelayInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelayInfo.AutoSize = true;
            this.lblDelayInfo.Location = new System.Drawing.Point(12, 390);
            this.lblDelayInfo.Name = "lblDelayInfo";
            this.lblDelayInfo.Size = new System.Drawing.Size(166, 13);
            this.lblDelayInfo.TabIndex = 2;
            this.lblDelayInfo.Text = "Auto typing starts after 5 Seconds";
            // 
            // tbKeys
            // 
            this.tbKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeys.BackColor = System.Drawing.Color.Black;
            this.tbKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbKeys.Font = new System.Drawing.Font("Courier New", 12F);
            this.tbKeys.ForeColor = System.Drawing.Color.White;
            this.tbKeys.Location = new System.Drawing.Point(12, 12);
            this.tbKeys.Name = "tbKeys";
            this.tbKeys.Size = new System.Drawing.Size(432, 367);
            this.tbKeys.TabIndex = 3;
            this.tbKeys.Text = "";
            this.tbKeys.TextChanged += new System.EventHandler(this.tbKeys_TextChanged);
            this.tbKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKeys_KeyDown);
            // 
            // lblAbout
            // 
            this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbout.AutoSize = true;
            this.lblAbout.LinkColor = System.Drawing.Color.Blue;
            this.lblAbout.Location = new System.Drawing.Point(328, 390);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(35, 13);
            this.lblAbout.TabIndex = 4;
            this.lblAbout.TabStop = true;
            this.lblAbout.Text = "About";
            this.lblAbout.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAbout_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 420);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.tbKeys);
            this.Controls.Add(this.lblDelayInfo);
            this.Controls.Add(this.btnType);
            this.Name = "frmMain";
            this.Text = "Auto Typer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Label lblDelayInfo;
        private System.Windows.Forms.RichTextBox tbKeys;
        private System.Windows.Forms.LinkLabel lblAbout;
    }
}

