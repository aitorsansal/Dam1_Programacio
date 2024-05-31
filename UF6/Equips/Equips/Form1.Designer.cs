namespace Equips
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuOpenExplorerToolStripMenuItem = new ToolStripMenuItem();
            totalEquipsToolStripMenuItem = new ToolStripMenuItem();
            promigDelsPressupostosToolStripMenuItem = new ToolStripMenuItem();
            btnGetTeam = new Button();
            lblAbreviatura = new Label();
            lblNom = new Label();
            lblPressupost = new Label();
            imgLog = new PictureBox();
            txtABV = new TextBox();
            txtNom = new TextBox();
            txtPressupost = new TextBox();
            dgvEquips = new DataGridView();
            btnGetSingleTeam = new Button();
            btnLoadAllTeams = new Button();
            txtImageLink = new TextBox();
            lblTeamImage = new Label();
            btnCreateTeam = new Button();
            btnDeleteTeam = new Button();
            btnModifyTeam = new Button();
            lblInformation = new Label();
            btnDeleteAll = new Button();
            btnClear = new Button();
            label1 = new Label();
            label2 = new Label();
            txtTotalEquips = new TextBox();
            txtPromigPresup = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgLog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquips).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuOpenExplorerToolStripMenuItem, totalEquipsToolStripMenuItem, promigDelsPressupostosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(1081, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuOpenExplorerToolStripMenuItem
            // 
            mnuOpenExplorerToolStripMenuItem.Name = "mnuOpenExplorerToolStripMenuItem";
            mnuOpenExplorerToolStripMenuItem.Size = new Size(94, 22);
            mnuOpenExplorerToolStripMenuItem.Text = "Open Explorer";
            mnuOpenExplorerToolStripMenuItem.Click += mnuOpenExplorerToolStripMenuItem_Click;
            // 
            // totalEquipsToolStripMenuItem
            // 
            totalEquipsToolStripMenuItem.Name = "totalEquipsToolStripMenuItem";
            totalEquipsToolStripMenuItem.Size = new Size(82, 22);
            totalEquipsToolStripMenuItem.Text = "Total Equips";
            totalEquipsToolStripMenuItem.Click += totalEquipsToolStripMenuItem_Click;
            // 
            // promigDelsPressupostosToolStripMenuItem
            // 
            promigDelsPressupostosToolStripMenuItem.Name = "promigDelsPressupostosToolStripMenuItem";
            promigDelsPressupostosToolStripMenuItem.Size = new Size(155, 22);
            promigDelsPressupostosToolStripMenuItem.Text = "Promig Dels Pressupostos";
            promigDelsPressupostosToolStripMenuItem.Click += promigDelsPressupostosToolStripMenuItem_Click;
            // 
            // btnGetTeam
            // 
            btnGetTeam.Location = new Point(1200, 215);
            btnGetTeam.Name = "btnGetTeam";
            btnGetTeam.Size = new Size(120, 30);
            btnGetTeam.TabIndex = 4;
            // 
            // lblAbreviatura
            // 
            lblAbreviatura.AutoSize = true;
            lblAbreviatura.Location = new Point(655, 35);
            lblAbreviatura.Margin = new Padding(2, 0, 2, 0);
            lblAbreviatura.Name = "lblAbreviatura";
            lblAbreviatura.Size = new Size(90, 15);
            lblAbreviatura.TabIndex = 1;
            lblAbreviatura.Text = "ABREVIATURA : ";
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(655, 68);
            lblNom.Margin = new Padding(2, 0, 2, 0);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(39, 15);
            lblNom.TabIndex = 2;
            lblNom.Text = "NOM:";
            // 
            // lblPressupost
            // 
            lblPressupost.AutoSize = true;
            lblPressupost.Location = new Point(655, 97);
            lblPressupost.Margin = new Padding(2, 0, 2, 0);
            lblPressupost.Name = "lblPressupost";
            lblPressupost.Size = new Size(78, 15);
            lblPressupost.TabIndex = 3;
            lblPressupost.Text = "PRESSUPOST:";
            // 
            // imgLog
            // 
            imgLog.Location = new Point(655, 274);
            imgLog.Margin = new Padding(2);
            imgLog.Name = "imgLog";
            imgLog.Size = new Size(380, 380);
            imgLog.TabIndex = 5;
            imgLog.TabStop = false;
            imgLog.Click += imgLog_Click;
            // 
            // txtABV
            // 
            txtABV.Location = new Point(782, 35);
            txtABV.Margin = new Padding(2);
            txtABV.Name = "txtABV";
            txtABV.Size = new Size(200, 23);
            txtABV.TabIndex = 6;
            txtABV.TextChanged += txtABV_TextChanged;
            txtABV.Enter += txtABV_Enter;
            // 
            // txtNom
            // 
            txtNom.Location = new Point(782, 65);
            txtNom.Margin = new Padding(2);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(200, 23);
            txtNom.TabIndex = 7;
            // 
            // txtPressupost
            // 
            txtPressupost.Location = new Point(782, 97);
            txtPressupost.Margin = new Padding(2);
            txtPressupost.Name = "txtPressupost";
            txtPressupost.Size = new Size(200, 23);
            txtPressupost.TabIndex = 8;
            // 
            // dgvEquips
            // 
            dgvEquips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquips.Location = new Point(21, 35);
            dgvEquips.Margin = new Padding(2);
            dgvEquips.Name = "dgvEquips";
            dgvEquips.RowHeadersWidth = 62;
            dgvEquips.Size = new Size(581, 436);
            dgvEquips.TabIndex = 8;
            // 
            // btnGetSingleTeam
            // 
            btnGetSingleTeam.Location = new Point(698, 171);
            btnGetSingleTeam.Name = "btnGetSingleTeam";
            btnGetSingleTeam.Size = new Size(133, 31);
            btnGetSingleTeam.TabIndex = 9;
            btnGetSingleTeam.Text = "Obtenir un equip";
            btnGetSingleTeam.UseVisualStyleBackColor = true;
            btnGetSingleTeam.Click += bntGetTeam_Click;
            // 
            // btnLoadAllTeams
            // 
            btnLoadAllTeams.Location = new Point(460, 476);
            btnLoadAllTeams.Name = "btnLoadAllTeams";
            btnLoadAllTeams.Size = new Size(142, 34);
            btnLoadAllTeams.TabIndex = 10;
            btnLoadAllTeams.Text = "Carrega tots els equips";
            btnLoadAllTeams.UseVisualStyleBackColor = true;
            btnLoadAllTeams.Click += btnLoadAllTeams_Click;
            // 
            // txtImageLink
            // 
            txtImageLink.Location = new Point(782, 130);
            txtImageLink.Margin = new Padding(2);
            txtImageLink.Name = "txtImageLink";
            txtImageLink.Size = new Size(200, 23);
            txtImageLink.TabIndex = 12;
            // 
            // lblTeamImage
            // 
            lblTeamImage.AutoSize = true;
            lblTeamImage.Location = new Point(655, 130);
            lblTeamImage.Margin = new Padding(2, 0, 2, 0);
            lblTeamImage.Name = "lblTeamImage";
            lblTeamImage.Size = new Size(74, 15);
            lblTeamImage.TabIndex = 11;
            lblTeamImage.Text = "IMAGE LINK:";
            // 
            // btnCreateTeam
            // 
            btnCreateTeam.Location = new Point(698, 208);
            btnCreateTeam.Name = "btnCreateTeam";
            btnCreateTeam.RightToLeft = RightToLeft.Yes;
            btnCreateTeam.Size = new Size(133, 31);
            btnCreateTeam.TabIndex = 13;
            btnCreateTeam.Text = "Crear equip";
            btnCreateTeam.UseVisualStyleBackColor = true;
            btnCreateTeam.Click += btnCreateTeam_Click;
            // 
            // btnDeleteTeam
            // 
            btnDeleteTeam.Enabled = false;
            btnDeleteTeam.Location = new Point(863, 208);
            btnDeleteTeam.Name = "btnDeleteTeam";
            btnDeleteTeam.Size = new Size(133, 31);
            btnDeleteTeam.TabIndex = 14;
            btnDeleteTeam.Text = "Eliminar equip";
            btnDeleteTeam.UseVisualStyleBackColor = true;
            btnDeleteTeam.Click += btnDeleteTeam_Click;
            // 
            // btnModifyTeam
            // 
            btnModifyTeam.Enabled = false;
            btnModifyTeam.Location = new Point(863, 171);
            btnModifyTeam.Name = "btnModifyTeam";
            btnModifyTeam.Size = new Size(133, 31);
            btnModifyTeam.TabIndex = 15;
            btnModifyTeam.Text = "Modificar equip";
            btnModifyTeam.UseVisualStyleBackColor = true;
            btnModifyTeam.Click += btnModifyTeam_Click;
            // 
            // lblInformation
            // 
            lblInformation.AutoSize = true;
            lblInformation.Font = new Font("Segoe UI", 11F);
            lblInformation.Location = new Point(655, 242);
            lblInformation.MaximumSize = new Size(400, 0);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(340, 20);
            lblInformation.TabIndex = 16;
            lblInformation.Text = "The team that you are trying to find does not exist";
            lblInformation.Visible = false;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(21, 478);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(142, 34);
            btnDeleteAll.TabIndex = 17;
            btnDeleteAll.Text = "Elimina tots els equips";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(987, 35);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(69, 23);
            btnClear.TabIndex = 18;
            btnClear.Text = "Neteja";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(210, 554);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 19;
            label1.Text = "TOTAL EQUIPS:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 589);
            label2.Name = "label2";
            label2.Size = new Size(169, 15);
            label2.TabIndex = 20;
            label2.Text = "PROMIG DELS PRESSUPOSTOS:";
            // 
            // txtTotalEquips
            // 
            txtTotalEquips.Location = new Point(300, 551);
            txtTotalEquips.Name = "txtTotalEquips";
            txtTotalEquips.Size = new Size(100, 23);
            txtTotalEquips.TabIndex = 21;
            // 
            // txtPromigPresup
            // 
            txtPromigPresup.Location = new Point(301, 586);
            txtPromigPresup.Name = "txtPromigPresup";
            txtPromigPresup.Size = new Size(100, 23);
            txtPromigPresup.TabIndex = 22;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1081, 667);
            Controls.Add(txtPromigPresup);
            Controls.Add(txtTotalEquips);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteAll);
            Controls.Add(lblInformation);
            Controls.Add(btnModifyTeam);
            Controls.Add(btnDeleteTeam);
            Controls.Add(btnCreateTeam);
            Controls.Add(txtImageLink);
            Controls.Add(lblTeamImage);
            Controls.Add(btnLoadAllTeams);
            Controls.Add(btnGetSingleTeam);
            Controls.Add(dgvEquips);
            Controls.Add(txtPressupost);
            Controls.Add(txtNom);
            Controls.Add(txtABV);
            Controls.Add(imgLog);
            Controls.Add(lblPressupost);
            Controls.Add(lblNom);
            Controls.Add(lblAbreviatura);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "APP EQUIPS";
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgLog).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquips).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Button btnGetTeam;
        private Label lblAbreviatura;
        private Label lblNom;
        private Label lblPressupost;
        private PictureBox imgLog;
        private TextBox txtABV;
        private TextBox txtNom;
        private TextBox txtPressupost;
        private DataGridView dgvEquips;
        private Button btnGetSingleTeam;
        private Button btnLoadAllTeams;
        private TextBox txtImageLink;
        private Label lblTeamImage;
        private Button btnCreateTeam;
        private Button btnDeleteTeam;
        private Button btnModifyTeam;
        private Label lblInformation;
        private ToolStripMenuItem mnuOpenExplorerToolStripMenuItem;
        private Button btnDeleteAll;
        private Button btnClear;
        private Label label1;
        private Label label2;
        private TextBox txtTotalEquips;
        private TextBox txtPromigPresup;
        private ToolStripMenuItem totalEquipsToolStripMenuItem;
        private ToolStripMenuItem promigDelsPressupostosToolStripMenuItem;
    }
}
