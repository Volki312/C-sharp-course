using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab6
{
    public partial class AddOrEditPersonForm : Form
    {
        public AddOrEditPersonForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        public AddOrEditPersonForm(Person person) : this()
        {
            textBox1.Text = person._name;
            textBox2.Text = person._lastName;
            textBox3.Text = person._age.ToString();
            comboBox1.SelectedItem = person._city;
        }

        public void validateInput()
        {
            try
            {
                int age = Int16.Parse(textBox1.Text);
                if ((age <= 0 || age > 120) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text)) button1.Enabled = false;
                else button1.Enabled = true;
            }
            catch
            {
                button1.Enabled = false;
            }
        }

        public Person getPerson()
        {
            Person person = new Person(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt16(textBox3.Text));   
            return person;
        }

        private void inputChanged(object sender, EventArgs e)
        {
            try
            {
                int age = Int16.Parse(textBox3.Text);
                if (age <= 0 || age > 120 || textBox1.Text.Length < 3 || textBox2.Text.Length < 3) button1.Enabled = false;
                else button1.Enabled = true;
            }
            catch
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
