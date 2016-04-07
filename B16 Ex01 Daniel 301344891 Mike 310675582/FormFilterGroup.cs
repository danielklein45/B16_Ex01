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
    public partial class FormFilterGroup : Form
    {

        public FilterGroup GroupFilter { get; set; }
        public FormFilterGroup()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxGroupName.Text = GroupFilter.Name;

            foreach (FilterItem item in GroupFilter)
            {
                checkedListFilterItems.Items.Add(item);
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {   
            if (!string.IsNullOrEmpty(textBoxFilterItem.Text))
            {
                FilterItem newItem = new FilterItem(textBoxFilterItem.Text);
                GroupFilter.AddItem(newItem);
                checkedListFilterItems.Items.Add(newItem);

                textBoxFilterItem.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Item Cannot be Empty");
            }    
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            string groupName = textBoxGroupName.Text;
            
            if (!string.IsNullOrEmpty(groupName))
            {
                GroupFilter.Name = groupName;
                this.Close();
            }
            else
            {
                MessageBox.Show("Group Name Cannot be Empty");
            }
        }

        private void buttonRemoveItems_Click(object sender, EventArgs e)
        {
            FilterItem filterItem = (FilterItem)checkedListFilterItems.SelectedItem;

            if (filterItem != null)
            {
                GroupFilter.RemoveItem(filterItem);
                checkedListFilterItems.Items.Remove(filterItem);
            }
            else
            {
                MessageBox.Show("At least one item must be selected");
            }
        }
    }
}
