using DAO_Pattern;

namespace Equips
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dwConnection = new ComboBox();
            btnConnect = new Button();
            lblInformation = new Label();
            SuspendLayout();
            // 
            // dwConnection
            // 
            dwConnection.BackColor = SystemColors.ActiveBorder;
            dwConnection.DisplayMember = "0";
            dwConnection.DropDownStyle = ComboBoxStyle.DropDownList;
            dwConnection.FormattingEnabled = true;
            dwConnection.Location = new Point(12, 12);
            dwConnection.Name = "dwConnection";
            dwConnection.Size = new Size(167, 23);
            dwConnection.Sorted = true;
            dwConnection.TabIndex = 0;
            dwConnection.ValueMember = "0";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 68);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(167, 23);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Start Connection";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblInformation
            // 
            lblInformation.AutoSize = true;
            lblInformation.ForeColor = Color.Red;
            lblInformation.Location = new Point(15, 43);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(164, 15);
            lblInformation.TabIndex = 2;
            lblInformation.Text = "Select one type of connection";
            lblInformation.TextAlign = ContentAlignment.MiddleCenter;
            lblInformation.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(191, 107);
            Controls.Add(lblInformation);
            Controls.Add(btnConnect);
            Controls.Add(dwConnection);
            MaximumSize = new Size(207, 146);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DB Select";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox dwConnection;
        private Button btnConnect;
        private Label lblInformation;
    }
}