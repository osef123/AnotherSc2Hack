using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Another_SC2_Hack.Classes;
using System.Windows.Forms;

namespace Another_SC2_Hack.Forms
{
    public partial class Warning_Builder : Form
    {
        private string _myStuff = string.Empty;
        public Warning_Builder(string str)
        {
            _myStuff = str;
            InitializeComponent();
        }

        private void Warning_Builder_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
