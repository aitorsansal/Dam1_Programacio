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
            SuspendLayout();
            // 
            // dwConnection
            // 
            dwConnection.BackColor = SystemColors.Menu;
            dwConnection.DropDownStyle = ComboBoxStyle.DropDownList;
            dwConnection.FormattingEnabled = true;
            dwConnection.Items.AddRange(new object[] { DataSource.MySQL, DataSource.XML });
            dwConnection.Location = new Point(150, 82);
            dwConnection.Name = "dwConnection";
            dwConnection.Size = new Size(131, 23);
            dwConnection.Sorted = true;
            dwConnection.TabIndex = 0;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(150, 138);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(131, 23);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Start Connection";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(462, 261);
            Controls.Add(btnConnect);
            Controls.Add(dwConnection);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox dwConnection;
        private Button btnConnect;
    }
}