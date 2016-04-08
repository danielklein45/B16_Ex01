namespace FacebookSmartView
{
    partial class FormFilterGroup
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
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.textBoxFilterItem = new System.Windows.Forms.TextBox();
            this.labelFilterItem = new System.Windows.Forms.Label();
            this.checkedListFilterItems = new System.Windows.Forms.CheckedListBox();
            this.buttonRemoveItems = new System.Windows.Forms.Button();
            this.buttonSaveAndClose = new System.Windows.Forms.Button();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(214, 59);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(97, 23);
            this.buttonAddItem.TabIndex = 0;
            this.buttonAddItem.Text = "Add New Item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // textBoxFilterItem
            // 
            this.textBoxFilterItem.Location = new System.Drawing.Point(17, 62);
            this.textBoxFilterItem.Name = "textBoxFilterItem";
            this.textBoxFilterItem.Size = new System.Drawing.Size(184, 20);
            this.textBoxFilterItem.TabIndex = 1;
            // 
            // labelFilterItem
            // 
            this.labelFilterItem.AutoSize = true;
            this.labelFilterItem.Location = new System.Drawing.Point(15, 43);
            this.labelFilterItem.Name = "labelFilterItem";
            this.labelFilterItem.Size = new System.Drawing.Size(32, 13);
            this.labelFilterItem.TabIndex = 2;
            this.labelFilterItem.Text = "Filter:";
            // 
            // checkedListFilterItems
            // 
            this.checkedListFilterItems.FormattingEnabled = true;
            this.checkedListFilterItems.Location = new System.Drawing.Point(17, 88);
            this.checkedListFilterItems.Name = "checkedListFilterItems";
            this.checkedListFilterItems.Size = new System.Drawing.Size(294, 124);
            this.checkedListFilterItems.TabIndex = 3;
            // 
            // buttonRemoveItems
            // 
            this.buttonRemoveItems.Location = new System.Drawing.Point(17, 229);
            this.buttonRemoveItems.Name = "buttonRemoveItems";
            this.buttonRemoveItems.Size = new System.Drawing.Size(120, 23);
            this.buttonRemoveItems.TabIndex = 4;
            this.buttonRemoveItems.Text = "Delete Items";
            this.buttonRemoveItems.UseVisualStyleBackColor = true;
            this.buttonRemoveItems.Click += new System.EventHandler(this.buttonRemoveItems_Click);
            // 
            // buttonSaveAndClose
            // 
            this.buttonSaveAndClose.Location = new System.Drawing.Point(17, 258);
            this.buttonSaveAndClose.Name = "buttonSaveAndClose";
            this.buttonSaveAndClose.Size = new System.Drawing.Size(120, 23);
            this.buttonSaveAndClose.TabIndex = 5;
            this.buttonSaveAndClose.Text = "Save And Close";
            this.buttonSaveAndClose.UseVisualStyleBackColor = true;
            this.buttonSaveAndClose.Click += new System.EventHandler(this.buttonSaveAndClose_Click);
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Location = new System.Drawing.Point(15, 12);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(38, 13);
            this.labelGroupName.TabIndex = 6;
            this.labelGroupName.Text = "Name:";
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Location = new System.Drawing.Point(56, 9);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(145, 20);
            this.textBoxGroupName.TabIndex = 7;
            // 
            // FormFilterGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 295);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.labelGroupName);
            this.Controls.Add(this.buttonSaveAndClose);
            this.Controls.Add(this.buttonRemoveItems);
            this.Controls.Add(this.checkedListFilterItems);
            this.Controls.Add(this.labelFilterItem);
            this.Controls.Add(this.textBoxFilterItem);
            this.Controls.Add(this.buttonAddItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormFilterGroup";
            this.Text = "Edit Filter Group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.TextBox textBoxFilterItem;
        private System.Windows.Forms.Label labelFilterItem;
        private System.Windows.Forms.CheckedListBox checkedListFilterItems;
        private System.Windows.Forms.Button buttonRemoveItems;
        private System.Windows.Forms.Button buttonSaveAndClose;
        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.TextBox textBoxGroupName;
    }
}