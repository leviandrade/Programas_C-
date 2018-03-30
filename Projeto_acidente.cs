//O projeto consiste em uma animação onde acontece um acidente de avião uma pessoa pula de paraquedas e se foga e uma explosão acontece
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wfa_foguete
{
    public partial class frm_foguete : Form
    {
        public frm_foguete()
        {
            InitializeComponent();
        }

        private void btndispara_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void btnpara_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        bool choque;
        private void timer1_Tick(object sender, EventArgs e)
        {
            picpassaro.Left = picpassaro.Left + 4;
            picpassaro1.Left = picpassaro1.Left + 4;
            picpassaro.Top = picpassaro.Top - 2;
            picpassaro.Visible = !picpassaro.Visible;
            picpassaro1.Top = picpassaro1.Top - 2;
            picpassaro1.Visible = !picpassaro1.Visible;
            if (choque == true)
            {
                picexplosao.Height = picexplosao.Height - 3;
                picexplosao.Width = picexplosao.Width - 4;
                picparaquedas.Top = picparaquedas.Top + 6;
                picexplosao.Visible = !picexplosao.Visible;
                picparaquedas.Visible = true;
             
            }
            else
            {

                picFoguete.Top = picFoguete.Top - 5;
                picFoguete.Left = picFoguete.Left + 10;
                if (picFoguete.Top % 7 == 0)
                {

                    picFoguete.Height = picFoguete.Height - 1;
                    picFoguete.Width = picFoguete.Width - 1;
                    picAviao.Height = picAviao.Height + 1;
                    picAviao.Width = picAviao.Width + 1;

                }
                picAviao.Top = picAviao.Top + 5;
                picAviao.Left = picAviao.Left + 10;
                if ((Math.Abs(picFoguete.Top - picAviao.Top) < 100) && (Math.Abs(picFoguete.Left - picAviao.Left) < 100))
                {
                    choque = true;
                    picFoguete.Visible = false;
                    picAviao.Visible = false;

                }
            }
            if ((Math.Abs(picparaquedas.Top - ClientSize.Height) < 40) && (Math.Abs(picparaquedas.Left - ClientSize.Height) < 40))
            {
                glub.Visible = !glub.Visible;
                glub1.Visible = !glub1.Visible;
                picparaquedas.Visible = false;
                glub.Top = glub.Top + 8;
                glub1.Top = glub1.Top + 8;
            }

                      
        }

        private void frm_foguete_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picFoguete.Top = this.ClientSize.Height - picFoguete.Height;
            picexplosao.Visible = false;
            picparaquedas.Visible = false;
            glub.Visible = false;
            glub1.Visible = false;

        }

        private void Acelera_Click(object sender, EventArgs e)
        {
            picAviao.Left = picAviao.Left + 5;
        }

        private void btnFim_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você quer mesmo sair?", "Sair", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        
       
        
    }

        
}
