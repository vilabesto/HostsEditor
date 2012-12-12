using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HostsChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Search for remote hosts file then pressing on button "Connect" and read data from it
        private void button1_Click(object sender, EventArgs e)
        {
            hostsFileText.Text = hostsChanger.Reader();
        }

        //create URL
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hostsChanger.setUrl("\\\\" + textBox1.Text + "\\c$\\Windows\\System32\\drivers\\etc\\hosts");
        }

        //Save text from main form to temp file
        private void hostsFileText_TextChanged(object sender, EventArgs e)
        {
            hostsChanger.setHostsFile(hostsFileText.Text);
        }

        //Save text from temp file to remote hosts file
        private void saveButton_Click(object sender, EventArgs e)
        {
            hostsChanger.Writer();
        }

        //Search for remote hosts file then pressing Enter button and read data from it
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                hostsFileText.Text = hostsChanger.Reader();
            }
        }

        //Save then press Ctrl + S key
        private void hostsFileText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                hostsChanger.Writer();
            }
        }

        //Button - About
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
        
        //Create form "About"
        public class Form2 : Form
        {
            public Form2()
            {
                Text = "About";

                Label label1 = new Label();
                label1.AutoSize = true;
                label1.Text = "ddd";
                label1.Visible = true;
            }
        }
    }
}
