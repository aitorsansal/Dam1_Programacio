using DAO_Pattern;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Pituivan.CoroutineSystem;
using static Pituivan.CoroutineSystem.Coroutine;

namespace Equips
{
    public partial class frmMain : Form
    {
        private IDAO<Team> dao;
        public frmMain() :this(DataSource.XML){}
        private Task? lblActive;

        public frmMain(DataSource ds)
        {
            dao = DAOTeamFactory<Team>.CreateDAOTeamInstance(ds);
            InitializeComponent();
            Text += $@" Connected with {ds}";
            lblActive = null;
        }

        private void Neteja()
        {
            txtABV.Text = "";
            txtNom.Text = "";
            txtPressupost.Text = "";
            imgLog.Image = null;
            txtImageLink.Text = "";
            btnModifyTeam.Enabled = false;
            btnDeleteTeam.Enabled = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void imgLog_Click(object sender, EventArgs e)
        {

        }

        private void txtABV_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtABV.Text))
            {
                LoadSelectedTeams(dao.GetAll().Where(x => x.Avb.Contains(txtABV.Text)).ToList());
            }
            else
                btnLoadAllTeams_Click(sender, e);
        }

        private void txtABV_Enter(object sender, EventArgs e)
        {
            Neteja();
        }

        private void bntGetTeam_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtABV.Text) && txtABV.Text.Length == 3)
            {
                Team? t = dao.GetValue(txtABV.Text);
                if (t is not null)
                {
                    txtNom.Text = t.Name;
                    txtPressupost.Text = Convert.ToString(t.Budget);
                    imgLog.ImageLocation = t.LogoLink;
                    imgLog.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtImageLink.Text = t.LogoLink;
                    btnModifyTeam.Enabled = true;
                    btnDeleteTeam.Enabled = true;
                }
                else
                {
                    if(lblActive is null || lblActive.IsCompleted)
                        lblActive.Dispose();
                    lblActive = ShowAndHideInformationLabel(2, @"No existeix l'equip sol·licitat");
                }
            }
            else if (dgvEquips.GetCellCount(DataGridViewElementStates.Selected) <= 1)
            {
                if (dgvEquips.CurrentRow is not null)
                {
                    Team t = dao.GetValue(Convert.ToString(dgvEquips.CurrentRow.Cells[0].FormattedValue));
                    txtABV.Text = t.Avb;
                    txtNom.Text = t.Name;
                    txtPressupost.Text = Convert.ToString(t.Budget);
                    imgLog.ImageLocation = t.LogoLink;
                    imgLog.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtImageLink.Text = t.LogoLink;
                    btnModifyTeam.Enabled = true;
                    btnDeleteTeam.Enabled = true;
                }
            }
            else
            {
                if (lblActive is not null && lblActive.IsCompleted)
                    lblActive.Dispose();
                lblActive = ShowAndHideInformationLabel(2, @"Abreviació entrada incorrecte");
            }
        }

        private void btnLoadAllTeams_Click(object sender, EventArgs e)
        {
            LoadSelectedTeams(dao.GetAll().ToList());
        }

        private void LoadSelectedTeams(List<Team> l)
        {
            dgvEquips.DataSource = l;
            dgvEquips.AutoResizeColumns();
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtABV.Text) ||
                string.IsNullOrEmpty(txtNom.Text) ||
                string.IsNullOrEmpty(txtPressupost.Text) ||
                string.IsNullOrEmpty(txtImageLink.Text))
            {
                if (lblActive is not null && lblActive.IsCompleted)
                    lblActive.Dispose();
                lblActive = ShowAndHideInformationLabel(2, @"La informació del nou equip no és completa");
            }
            else
            {
                if (txtABV.Text.Length != 3)
                {
                    if (lblActive is not null || !lblActive.IsCompleted)
                        lblActive.Dispose();;
                    lblActive = ShowAndHideInformationLabel(2, @"L'abreviació hauria de tenir exactament 3 caràcters");
                }
                Team t = new Team(txtABV.Text, txtNom.Text, Convert.ToInt32(txtPressupost.Text), txtImageLink.Text);
                if (dao.GetAll().Contains(t))
                {
                    if (lblActive is not null && lblActive.IsCompleted)
                        lblActive.Dispose();
                    lblActive = ShowAndHideInformationLabel(2, $@"L'equip amb l'abreviació {txtABV.Text} ja existeix");
                }
                else
                { 
                    dao.Save(t);
                    btnLoadAllTeams_Click(sender, e);
                }
            }
        }


        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (dao.Delete(txtABV.Text))
            {
                if (lblActive is not null && lblActive.IsCompleted)
                    lblActive.Dispose();
                lblActive = ShowAndHideInformationLabel(2, "Equip eliminat correctament");
                btnLoadAllTeams_Click(sender, e);
                Neteja();
            }
            else
            {
                if (lblActive is not null && lblActive.IsCompleted)
                    lblActive.Dispose();
                lblActive = ShowAndHideInformationLabel(2, "L'equip no s'ha pogut eliminar");
            }
        }

        private void btnModifyTeam_Click(object sender, EventArgs e)
        {
            Team t = new Team(txtABV.Text, txtNom.Text, Convert.ToInt32(txtPressupost.Text), txtImageLink.Text);
            dao.Update(txtABV.Text, t);
        }

        private void mnuOpenExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt;*.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    sr.ReadLine();
                    string? line = sr.ReadLine();
                    try
                    {
                        while (line is not null)
                        {
                            var sp = line.Split(",");
                            if (sp.Length <= 1)
                            {
                                sp = line.Split(";");
                            }

                            if (sp.Length != 4) throw new Exception("Wrong csv file splitting.");
                            while (sp[3][^1] == ';')
                                sp[3] = sp[3].Remove(sp[3].Length - 2, 1);
                            Team t = new(sp[1], sp[0], Convert.ToInt32(sp[2]), sp[3]);
                            dao.Save(t);
                            line = sr.ReadLine();
                        }
                    }
                    catch (Exception exception)
                    {
                        if (lblActive is not null && lblActive.IsCompleted)
                            lblActive.Dispose();
                        lblActive = ShowAndHideInformationLabel(5, exception.Message + "\n" + line);
                    }
                }
                btnLoadAllTeams_Click(sender, e);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            foreach (var team in dao.GetAll())
            {
                dao.Delete(team.Avb);
            }

            btnLoadAllTeams_Click(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Neteja();
        }

        private async Task? ShowAndHideInformationLabel(int s, string msg)
        {
            lblInformation.Text = msg;
            lblInformation.Visible = true;
            await Task.Delay(s * 1000);
            lblInformation.Visible = false;
            lblActive = null;
        }

    }
}
