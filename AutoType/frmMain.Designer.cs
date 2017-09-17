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
            this.tbKeys = new System.Windows.Forms.TextBox();
            this.lblDelayInfo = new System.Windows.Forms.Label();
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
            // tbKeys
            // 
            this.tbKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeys.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKeys.Location = new System.Drawing.Point(12, 12);
            this.tbKeys.Multiline = true;
            this.tbKeys.Name = "tbKeys";
            this.tbKeys.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbKeys.Size = new System.Drawing.Size(432, 367);
            this.tbKeys.TabIndex = 1;
            this.tbKeys.WordWrap = false;
            this.tbKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKeys_KeyDown);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 420);
            this.Controls.Add(this.lblDelayInfo);
            this.Controls.Add(this.tbKeys);
            this.Controls.Add(this.btnType);
            this.Name = "frmMain";
            this.Text = "Auto Typer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.TextBox tbKeys;
        private System.Windows.Forms.Label lblDelayInfo;
    }
}

