using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextMenuManager
{
    public partial class KeyEdit : Form
    {
        public KeyEdit()
        {
            InitializeComponent();
        }

        private void KeyEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;
        }
    }
}
