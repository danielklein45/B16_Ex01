using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    public partial class PostFilterSettingsForm : Form
    {
        public PostFilter PostFilter { get; set; }

        public PostFilterSettingsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadGroups();
        }

        private void loadGroups()
        {
            foreach (FilterGroup group in PostFilter.FilterGroups)
            {
                checkedListBoxFilterGroups.Items.Add(group);
            }
        }

        private void buttonCreateNewGroup_Click(object sender, EventArgs e)
        {
            FilterGroup newGroup = new FilterGroup();
            FilterGroupForm filterGroupDialog = new FilterGroupForm();

            filterGroupDialog.GroupFilter = newGroup;
            filterGroupDialog.ShowDialog();

            if (newGroup.Name != null)
            {
                PostFilter.AddGroup(newGroup);
                checkedListBoxFilterGroups.Items.Add(newGroup);
            }
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            FilterGroup filterGroup = (FilterGroup)checkedListBoxFilterGroups.SelectedItem;

            if (filterGroup != null)
            {
                FilterGroupForm filterGroupDialog = new FilterGroupForm();

                filterGroupDialog.GroupFilter = filterGroup;
                filterGroupDialog.ShowDialog();

                filterGroup.Name = filterGroupDialog.GroupFilter.Name;
            }
            else
            {
                displayNoGroupSelectedMessage();
            }
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            FilterGroup filterGroup = (FilterGroup)checkedListBoxFilterGroups.SelectedItem;

            if (filterGroup != null)
            {
                PostFilter.RemoveGroup(filterGroup);
                checkedListBoxFilterGroups.Items.Remove(filterGroup);
            }
            else
            {
                displayNoGroupSelectedMessage();
            }
        }

        private void displayNoGroupSelectedMessage()
        {
            MessageBox.Show("At least one group must be selected");
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
