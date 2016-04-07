namespace FacebookSmartView
{
    partial class FormPostFilterSettings
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
            this.buttonCreateGroup = new System.Windows.Forms.Button();
            this.buttonDeleteGroup = new System.Windows.Forms.Button();
            this.buttonSaveAndClose = new System.Windows.Forms.Button();
            this.checkedListBoxFilterGroups = new System.Windows.Forms.CheckedListBox();
            this.buttonEditGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateGroup
            // 
            this.buttonCreateGroup.Location = new System.Drawing.Point(204, 12);
            this.buttonCreateGroup.Name = "buttonCreateGroup";
            this.buttonCreateGroup.Size = new System.Drawing.Size(147, 39);
            this.buttonCreateGroup.TabIndex = 0;
            this.buttonCreateGroup.Text = "Create Group Filter";
            this.buttonCreateGroup.UseVisualStyleBackColor = true;
            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateNewGroup_Click);
            // 
            // buttonDeleteGroup
            // 
            this.buttonDeleteGroup.Location = new System.Drawing.Point(204, 102);
            this.buttonDeleteGroup.Name = "buttonDeleteGroup";
            this.buttonDeleteGroup.Size = new System.Drawing.Size(147, 39);
            this.buttonDeleteGroup.TabIndex = 1;
            this.buttonDeleteGroup.Text = "Delete Group Filter";
            this.buttonDeleteGroup.UseVisualStyleBackColor = true;
            this.buttonDeleteGroup.Click += new System.EventHandler(this.buttonDeleteGroup_Click);
            // 
            // buttonSaveAndClose
            // 
            this.buttonSaveAndClose.Location = new System.Drawing.Point(247, 222);
            this.buttonSaveAndClose.Name = "buttonSaveAndClose";
            this.buttonSaveAndClose.Size = new System.Drawing.Size(104, 28);
            this.buttonSaveAndClose.TabIndex = 2;
            this.buttonSaveAndClose.Text = "Save And Close";
            this.buttonSaveAndClose.UseVisualStyleBackColor = true;
            this.buttonSaveAndClose.Click += new System.EventHandler(this.buttonSaveAndClose_Click);
            // 
            // checkedListBoxFilterGroups
            // 
            this.checkedListBoxFilterGroups.FormattingEnabled = true;
            this.checkedListBoxFilterGroups.Location = new System.Drawing.Point(2, 13);
            this.checkedListBoxFilterGroups.Name = "checkedListBoxFilterGroups";
            this.checkedListBoxFilterGroups.Size = new System.Drawing.Size(196, 199);
            this.checkedListBoxFilterGroups.TabIndex = 3;
            // 
            // buttonEditGroup
            // 
            this.buttonEditGroup.Location = new System.Drawing.Point(204, 57);
            this.buttonEditGroup.Name = "buttonEditGroup";
            this.buttonEditGroup.Size = new System.Drawing.Size(147, 39);
            this.buttonEditGroup.TabIndex = 4;
            this.buttonEditGroup.Text = "Edit Group Filter";
            this.buttonEditGroup.UseVisualStyleBackColor = true;
            this.buttonEditGroup.Click += new System.EventHandler(this.buttonEditGroup_Click);
            // 
            // PostFilterSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.buttonEditGroup);
            this.Controls.Add(this.checkedListBoxFilterGroups);
            this.Controls.Add(this.buttonSaveAndClose);
            this.Controls.Add(this.buttonDeleteGroup);
            this.Controls.Add(this.buttonCreateGroup);
            this.Name = "PostFilterSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateGroup;
        private System.Windows.Forms.Button buttonDeleteGroup;
        private System.Windows.Forms.Button buttonSaveAndClose;
        private System.Windows.Forms.CheckedListBox checkedListBoxFilterGroups;
        private System.Windows.Forms.Button buttonEditGroup;
    }
}