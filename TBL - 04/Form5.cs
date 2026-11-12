using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema
{
    public class Form5 : Form
    {
        public Form5()
        {
            this.Text = "Tela de Relatórios";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label();
            lbl.Text = "Cadastro de Relatórios";
            lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbl.AutoSize = true;
            lbl.Location = new Point(30, 30);

            this.Controls.Add(lbl);
        }
    }
}
