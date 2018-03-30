#Calculadora simples com uma série de verificações 
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Levi_lblcalculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            soma();
            
        }
        void soma(){

            float valorN1, valorN2, resultado;
            valorN1 = 0;
            valorN2 = 0;
            try
            {
                valorN1 = float.Parse(txtN1.Text);
                valorN2 = float.Parse(txtN2.Text);
                resultado = valorN1 + valorN2;
                lblResult.Text = resultado.ToString();
            }
            catch(Exception caught)
            {
                lblResult.Text = "";
                lblResult.Text = caught.Message;

            }
            return;
        }
        
        private void txtN1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != ',' && e.KeyChar != (char)13 && e.KeyChar !=(char)8)
                e.KeyChar = (char)0;
            else
            {
                if (e.KeyChar == (char)13)
                    txtN2.Focus();
                else
                {
                    if (e.KeyChar == (char)8)
                        txtN2.Focus();
                    else
                    {
                        int i;
                        i=txtN1.Text.IndexOf(',');
                        if (e.KeyChar==',' && i>=0)
                        {
                            e.KeyChar = (char)0;
                            MessageBox.Show("Proibido mais que uma virgula decimal");
                        }
                    }
                }
                
            }
        }

        private void txtN2_KeyPress(object sender, KeyPressEventArgs e)
        {


            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != ',' && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && (e.KeyChar != (char)13))
                e.KeyChar = (char)0;
            else
            {
                switch (e.KeyChar)
                {
                    case '+':
                        soma();
                        e.KeyChar = (char)0;
                        break;
                    case '-':
                        subtracao();
                        e.KeyChar = (char)0;
                        break;
                    case '*':
                        multiplicacao();
                        e.KeyChar = (char)0;
                        break;
                    case '/':
                        divisao();
                        e.KeyChar = (char)0;
                        break;
                }
                int i;
                i = txtN2.Text.IndexOf(',');
                if (e.KeyChar == ',' && i >= 0)
                {
                    e.KeyChar = (char)0;
                    MessageBox.Show("Proibido mais que uma virgula decimal");
                }
                else
                {
                    if (e.KeyChar == (char)13)
                    {
                        soma();
                    }
                }
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtN1.Text != "" || txtN2.Text != "")
            { txtN1.Text = "";
            txtN2.Text = "";
            lblResult.Text = "";
            txtN1.Focus();
            }
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            subtracao();
        }
        void subtracao()
        {

            float valorN1, valorN2, resultado;
            valorN1 = 0;
            valorN2 = 0;
            try
            {
                valorN1 = float.Parse(txtN1.Text);
                valorN2 = float.Parse(txtN2.Text);
                resultado = valorN1 - valorN2;
                lblResult.Text = resultado.ToString();
            }
            catch (Exception caught)
            {
                lblResult.Text = "";
                lblResult.Text = caught.Message;

            }
            return;
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            multiplicacao();
        }
        void multiplicacao()
        {

            float valorN1, valorN2, resultado;
            valorN1 = 0;
            valorN2 = 0;
            try
            {
                valorN1 = float.Parse(txtN1.Text);
                valorN2 = float.Parse(txtN2.Text);
                resultado = valorN1 * valorN2;
                lblResult.Text = resultado.ToString();
            }
            catch (Exception caught)
            {
                lblResult.Text = "";
                lblResult.Text = caught.Message;

            }
            return;
        }

        private void btndiv_Click(object sender, EventArgs e)
       {
            divisao();
            int valorn;
                valorn = int.Parse(txtN2.Text);
                if (valorn == 0)
                { MessageBox.Show("Divisão por 0 impossivel"); 
                    txtN2.Focus();
                    txtN2.SelectAll();
                }


        }
        void divisao()
        {

            float valorN1, valorN2, resultado;
            valorN1 = 0;
            valorN2 = 0;
            try
            {
                valorN1 = float.Parse(txtN1.Text);
                valorN2 = float.Parse(txtN2.Text);
                resultado = valorN1 / valorN2;
                lblResult.Text = resultado.ToString();
            }
            catch (Exception caught)
            {
                lblResult.Text = "";
                lblResult.Text = caught.Message;

            }
            return;
        }

        private void lblResult_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (float.Parse(lblResult.Text) < 0)
                    lblResult.ForeColor = Color.Red;
                else
                {
                    if (float.Parse(lblResult.Text) < 0)
                        lblResult.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblResult.ForeColor = SystemColors.ControlText;

            }
            
        }

     }
}     
