using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO_Pattern;

namespace Equips
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (dwConnection.SelectedItem is not null)
            {
                frmMain main = new frmMain((DataSource)dwConnection.SelectedItem);
                main.Show();
                Hide();
            }
        }
    }
}
