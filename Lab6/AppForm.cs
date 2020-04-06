using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab6
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();

            renderListViewItems();
        }

        private Person getSelectedPerson()
        {
            return Person.getPersonByIndex(listView1.FocusedItem.Index);
        }
        private void showPersonData_Click(object sender, System.EventArgs e)
        {
            Person person = getSelectedPerson();

            string message = "";
            message += "Name: " + person._name;
            message += "\nLast Name: " + person._lastName;
            message += "\nCity: " + person._city;
            message += "\nAge: " + person._age.ToString();

            string caption = "Circle properties";
            
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            
            MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void renderListViewItems()
        {
            listView1.Items.Clear();
            foreach (Person person in Person.getAllPeopleList())
            {
                ListViewItem itm = new ListViewItem(new string[] { person._name, person._lastName });
                listView1.Items.Add(itm);
            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPersonData_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = getSelectedPerson();

            AddOrEditPersonForm aoepf = new AddOrEditPersonForm(person);
            aoepf.ShowDialog(this);

            if (aoepf.DialogResult == DialogResult.OK)
            {
                Person updatedPerson = aoepf.getPerson();
                Person.updatePerson(updatedPerson, listView1.FocusedItem.Index);
            }

            aoepf.Dispose();
            renderListViewItems();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrEditPersonForm aoepf = new AddOrEditPersonForm();
            aoepf.ShowDialog(this);

            if (aoepf.DialogResult == DialogResult.OK)
            {
                Person newPerson = aoepf.getPerson();
                Person.addNewPerson(newPerson);
            }

            aoepf.Dispose();
            renderListViewItems();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person.removePerson(listView1.FocusedItem.Index);
            renderListViewItems();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Items[0].Visible = true;
                contextMenuStrip1.Items[1].Visible = true;
                contextMenuStrip1.Items[2].Visible = true;
                contextMenuStrip1.Items[3].Visible = false;
            }
            else
            {
                contextMenuStrip1.Items[0].Visible = false;
                contextMenuStrip1.Items[1].Visible = false;
                contextMenuStrip1.Items[2].Visible = false;
                contextMenuStrip1.Items[3].Visible = true;
            }
        }
    }
}
