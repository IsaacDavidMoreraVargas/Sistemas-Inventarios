using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_DE_INVENTARIOS
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }
        string data;
        private void InputBox_Load(object sender, EventArgs e)
        {
            this.Text = "INTRODUCE LA APROXIMACION A BUSCAR";
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            data = textBox1.Text;
            data += "?";
            data += "ACCEPT";
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            data = textBox1.Text;
            data += "?";
            data += "CANCEL";
            this.Close();
        }

        public string getOrder()
        {
            return data;
        }

        
    }
}
