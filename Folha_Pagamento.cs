using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaFolhaPagto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcula_Click(object sender, EventArgs e)
        {
            
            if (txtNomFunc.Text == "")
            {
                MessageBox.Show("PREENCHA CORRETAMENTE O CAMPO NOME");
                txtNomFunc.Focus();
            }
            else
            {
                if (txtHorTra.Text == "")
                {
                    MessageBox.Show("PREENCHA CORRETAMENTE O CAMPO HORAS");
                    txtHorTra.Focus();
                }
                else{
                    if(txtValor.Text=="")
                    {
                        MessageBox.Show("PREENCHA CORRETAMENTE O CAMPO VALOR");
                        txtValor.Focus();
                    }
                    else{
                        if(txtDepen.Text=="")
                        {
                            MessageBox.Show("PREENCHA CORRETAMENTE O CAMPO DEPENDENTES");
                            txtDepen.Focus();
                        }
                        else
                        {

                            double x = double.Parse(txtHorTra.Text);
                            double y = double.Parse(txtValor.Text);
                            txtSalBruto.Text = Taxas.salario(x, y).ToString("###,###,##0.00");
                            double salBruto = double.Parse(txtSalBruto.Text);
                            txtInss.Text = Taxas.calculaINSS(salBruto).ToString("###,###,##0.00");
                            double dependente = double.Parse(txtDepen.Text);
                            double Inss = double.Parse(txtInss.Text);
                            txtImpRen.Text = Taxas.CalculaIR(Inss, salBruto, dependente).ToString("###,###,##0.00");
                            double IR = double.Parse(txtImpRen.Text);
                            txtSalLiq.Text = (salBruto - Inss - IR).ToString("###,###,##0.00");

                        }
                    }
                }
               
            }

            
        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            if (txtNomFunc.Text != "" || txtHorTra.Text != "" || txtValor.Text != "" || txtDepen.Text != "" || txtSalBruto.Text != "" || txtInss.Text != "" || txtImpRen.Text != "" || txtSalLiq.Text != "")
            {
                txtNomFunc.Text = "";
                txtHorTra.Text = "";
                txtValor.Text = "";
                txtDepen.Text = "";
                txtSalBruto.Text = "";
                txtInss.Text = "";
                txtImpRen.Text = "";
                txtSalLiq.Text = "";
                txtNomFunc.Focus();
            }
        }

        private void txtNomFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtHorTra.Focus();
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar == ',')
                e.KeyChar = (char)0;
        }
        private void txtHorTra_KeyPress(object sender, KeyPressEventArgs e)
        {
         if (e.KeyChar == (char)13)
               txtValor.Focus();
         if (e.KeyChar == ',')
             e.KeyChar = virgula.soumavirgula(txtHorTra.Text);
         e.KeyChar = virgula.consisteNum(e.KeyChar);
            
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtDepen.Focus();
            if (e.KeyChar == ',')
                e.KeyChar = virgula.soumavirgula(txtValor.Text);
            e.KeyChar = virgula.consisteNum(e.KeyChar);
            
        }
       
        private void txtDepen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 &&  txtNomFunc.Text != "" && txtHorTra.Text != "" && txtValor.Text != "" && txtDepen.Text != "")
            {
                int x = int.Parse(txtHorTra.Text);
                double y = double.Parse(txtValor.Text);
                txtSalBruto.Text = Taxas.salario(x, y).ToString("###,###,##0.00");
                double salBruto = double.Parse(txtSalBruto.Text);
                txtInss.Text = Taxas.calculaINSS(salBruto).ToString("###,###,##0.00");
                double dependente = double.Parse(txtDepen.Text);
                double Inss = double.Parse(txtInss.Text);
                txtImpRen.Text = Taxas.CalculaIR(Inss, salBruto, dependente).ToString("###,###,##0.00");
                double IR = double.Parse(txtImpRen.Text);
                txtSalLiq.Text = (salBruto - Inss - IR).ToString("###,###,##0.00");
            }
            e.KeyChar = virgula.consisteNum(e.KeyChar);
            int i = txtDepen.Text.IndexOf(',');
            if(e.KeyChar==',')
            {
                e.KeyChar=(char)0;
                MessageBox.Show("Apenas numeros inteiros");
            }
        }

        private void btnFim_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você quer mesmo sair?", "Sair", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                txtNomFunc.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSalBruto.Enabled = false;
            txtInss.Enabled = false;
            txtImpRen.Enabled = false;
            txtSalLiq.Enabled = false;
        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfaFolhaPagto
{
    class Taxas
    {
        public static double salario(double x, double y)
        {
            return x * y;
        }

        public static double calculaINSS(double salBruto)
        {
         

            if (salBruto <= 965.7) return (salBruto * 0.08);
            else if (salBruto <= 1609.45) return (salBruto * 0.09);
            else if (salBruto <= 3218.90) return (salBruto * 0.11);
            else return (354.08);

        }
        public static double CalculaIR(double Inss,double salBruto, double dependente)
        {
            if (salBruto <= 1434.59) return (0);
            else if (salBruto <= 2150 && salBruto >= 1434.60) return ((salBruto - Inss - (dependente * 144.20)) * 0.08) - 107.59;
            else if (salBruto <= 2866.70 && salBruto >= 2150.01) return ((salBruto - Inss - (dependente * 144.20)) * 0.15) - 268.84;
            else if (salBruto <= 3582 && salBruto >= 2866.71) return ((salBruto - Inss - (dependente * 144.20)) * 0.225) - 483.84;
            else
            {
                return ((salBruto - Inss - (dependente * 144.20)) * 0.275) - 662.94;
            }

           
      
        }
        

    }
    
    // essa página tbm é chamada pelo progrma principal
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfaFolhaPagto
{
    class virgula
    {
        public static char soumavirgula(string texto)
        {
            int i;
            i = texto.IndexOf(',');
            if (i >= 0)
            {
                return ((char)0);
            }
            else
                return (',');
        }
        public static char consisteNum(char c)
        {
            if (((c < '0') || (c > '9')) && c != ',' && c != (char)8)
                c = (char)0;
            return (c);
        }

       
    }
}
}
