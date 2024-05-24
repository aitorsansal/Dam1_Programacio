using DAO_Pattern;
using System.Diagnostics;
using System.Text;
namespace Equips
{
    public partial class frmMain : Form
    {
        private IDAO<Team> dao;
        public frmMain() :this(DataSource.XML){}

        public frmMain(DataSource ds)
        {
            dao = DAOTeamFactory<Team>.CreateDAOTeamInstance(ds);
            InitializeComponent();
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
                Team t = dao.GetValue(txtABV.Text);
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
                    lblInformation.Visible = true;
                    lblInformation.Text = @"No existeix l'equip sol·licitat";
                    ReHideInformation(2);
                }
            }
            else if (dgvEquips.GetCellCount(DataGridViewElementStates.Selected) <= 1)
            {
                if (dgvEquips.CurrentRow is null)
                {
                    lblInformation.Visible = true;
                    lblInformation.Text = @"Abreviació entrada incorrecte";
                    ReHideInformation(2);
                }
                else
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
                lblInformation.Visible = true;
                lblInformation.Text = @"Abreviació entrada incorrecte";
                ReHideInformation(2);
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
                lblInformation.Visible = true;
                lblInformation.Text = @"La informació del nou equip no és completa";
                ReHideInformation(2);
            }
            else
            {
                Team t = new Team(txtABV.Text, txtNom.Text, Convert.ToInt32(txtPressupost.Text), txtImageLink.Text);
                if (dao.GetAll().Contains(t))
                {
                    lblInformation.Visible = true;
                    lblInformation.Text = $@"L'equip amb l'abreviació {txtABV.Text} ja existeix";
                    ReHideInformation(2);
                }
                else
                {
                    dao.Save(t);
                    btnLoadAllTeams_Click(sender, e);
                }
            }
        }

        private async Task ReHideInformation(int s)
        {
            await Task.Delay(s * 1000);
            lblInformation.Visible = false;
        }


        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (dao.Delete(txtABV.Text))
            {
                lblInformation.Visible = true;
                lblInformation.Text = $@"Equip eliminat correctament";
                btnLoadAllTeams_Click(sender, e);
                Neteja();
            }
            else
            {
                lblInformation.Visible = true;
                lblInformation.Text = $@"L'equip no s'ha pogut eliminar";
            }
            ReHideInformation(2);
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
                    while (line is not null)
                    {
                        var sp = line.Split(",");
                        if (sp.Length <= 1)
                        {
                            sp = line.Split(";");
                        }
                        try
                        {
                            if (sp.Length != 4) throw new Exception("Wrong csv file splitting.");
                            while (sp[3][^1] == ';')
                                sp[3] = sp[3].Remove(sp[3].Length - 2, 1);
                            Team t = new Team(sp[1], sp[0], Convert.ToInt32(sp[2]), sp[3]);
                            dao.Save(t);
                        }
                        catch (Exception exception)
                        {
                            lblInformation.Text = exception.Message + "\n" + line;
                            lblInformation.Visible = true;
                            ReHideInformation(5);

                            throw;
                        }
                        line = sr.ReadLine();
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
    }
}
