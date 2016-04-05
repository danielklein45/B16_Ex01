namespace FacebookSmartView
{
    partial class FormLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoader));
            this.pcBoxLoading = new System.Windows.Forms.PictureBox();
            this.lblLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // pcBoxLoading
            // 
            this.pcBoxLoading.Location = new System.Drawing.Point(12, 12);
            this.pcBoxLoading.Name = "pcBoxLoading";
            this.pcBoxLoading.Size = new System.Drawing.Size(132, 123);
            this.pcBoxLoading.TabIndex = 0;
            this.pcBoxLoading.TabStop = false;
            this.pcBoxLoading.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.ImageLoadingComplete);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(10, 144);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(134, 16);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Loading information...";
            // 
            // FormLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 169);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.pcBoxLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            ((System.ComponentModel.ISupportInitialize)(this.pcBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcBoxLoading;
        private System.Windows.Forms.Label lblLoading;
    }
}