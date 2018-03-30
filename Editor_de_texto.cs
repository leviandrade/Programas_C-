using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaSenha_Levi
{
    public partial class frmEditor : Form
    {
        public frmEditor()
        {
            InitializeComponent();
        }
        private void rdPreto_CheckedChanged(object sender, EventArgs e)
        {
            txt1.ForeColor = Color.Black;
        }
        private void rdVermelho_CheckedChanged(object sender, EventArgs e)
        {
            txt1.ForeColor = Color.Red;
        }

        private void rdVerde_CheckedChanged(object sender, EventArgs e)
        {
            txt1.ForeColor = Color.Green;
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNegrito.Checked && !chkSublinhado.Checked)
                txt1.Font = new Font(txt1.Font, FontStyle.Bold);
            if (chkNegrito.Checked && chkSublinhado.Checked)
                txt1.Font = new Font(txt1.Font, FontStyle.Bold | FontStyle.Underline);
            if (!chkNegrito.Checked && !chkSublinhado.Checked)
                txt1.Font = new Font(txt1.Font, FontStyle.Regular);
            if (!chkNegrito.Checked && chkSublinhado.Checked)
                txt1.Font = new Font(txt1.Font, FontStyle.Underline);
        }

        private void chkSublinhado_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkNegrito.Checked && !chkSublinhado.Checked)
                    txt1.Font = new Font(txt1.Font, FontStyle.Bold);
                if (chkNegrito.Checked && chkSublinhado.Checked)
                    txt1.Font = new Font(txt1.Font, FontStyle.Bold | FontStyle.Underline);
                if (!chkNegrito.Checked && !chkSublinhado.Checked)
                    txt1.Font = new Font(txt1.Font, FontStyle.Regular);
                if (!chkNegrito.Checked && chkSublinhado.Checked)
                    txt1.Font = new Font(txt1.Font, FontStyle.Underline);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            rdPreto.Select();
            chkNegrito.Checked = false;
            chkSublinhado.Checked = false;
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            rdPreto.Checked = true;
            txt1.Focus();
            
        }

    }
}
