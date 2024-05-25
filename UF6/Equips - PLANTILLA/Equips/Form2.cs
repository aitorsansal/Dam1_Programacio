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
using Pituivan.CoroutineSystem;
using static Pituivan.CoroutineSystem.Coroutine;

namespace Equips
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            foreach (var ds in Enum.GetValuesAsUnderlyingType<DataSource>())
            {
                dwConnection.Items.Add((DataSource)ds);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (dwConnection.SelectedItem is not null)
            {
                frmMain main = new frmMain((DataSource)dwConnection.SelectedItem);
                Hide();
                main.Show();
            }
            else
            {
                lblInformation.Visible = true;
                StartCoroutine(SetRedText());
                //SetTextRed();
            }
        }


        IEnumerator SetRedText()
        {
            lblInformation.ForeColor = Color.Red;
            yield return new WaitForTime(seconds: .1f);
            lblInformation.ForeColor = Color.Black;
        }
        async Task SetTextRed()
        {
            lblInformation.ForeColor = Color.Red;
            await Task.Delay(150);
            lblInformation.ForeColor = Color.Black;;
        }
    }
}
