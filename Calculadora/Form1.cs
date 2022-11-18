using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        // var globais
        string resultado = "0", a, sinal;
        object tela;
        int conta_operador = 0, cont_virgula = 0, b;
        DataTable dt = new DataTable();
        Boolean apertou_operador = true, igual_tem_valor = false, virgula_dpois = false, nao_pode_0 = false, primera_conta_dps_igual = false, erro = false, num_aposvirgula = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void btm_virgula_Click(object sender, EventArgs e)
        {
            if (virgula_dpois == true && cont_virgula == 0)
            {
                txb_screen.Text = txb_screen.Text + ".";
                cont_virgula += 1;
            }
        }

        private void btm_fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btm_Limpar_Click(object sender, EventArgs e)
        {
            txb_screen.Text = null;
            txb_auxiliar.Text = null;
            apertou_operador = true;
            igual_tem_valor = false;
            virgula_dpois = false;
            nao_pode_0 = false;
            sinal = "";
            resultado = "";
            conta_operador = 0;
            cont_virgula = 0;
            num_aposvirgula = false;
            primera_conta_dps_igual = false;
            txb_screen.Font = new Font(Font.FontFamily, 48);
            txb_screen.BackColor = Color.White;
            txb_screen.ForeColor = Color.Black;
            txb_screen.BackColor = Color.White;
        }

        private void numeroPressionado(object sender, EventArgs e)
        {
            System.Windows.Forms.Button botao = (System.Windows.Forms.Button)sender;
            if (erro == true)
            {
                txb_screen.Text = botao.Text;
                apertou_operador = true;
                virgula_dpois = true;
                txb_auxiliar.Text = null;
                igual_tem_valor = false;
                nao_pode_0 = false;
                sinal = "";
                resultado = "";
                conta_operador = 0;
                cont_virgula = 0;
                primera_conta_dps_igual = false;
                erro = false;
                txb_screen.Font = new Font(Font.FontFamily, 48);
                txb_screen.BackColor = Color.White;
                txb_screen.ForeColor = Color.Black;
                txb_screen.BackColor = Color.White;
            }
            else
            {
                if (txb_screen.Text.Contains("."))
                {
                    txb_screen.Text += botao.Text;
                    apertou_operador = true;
                    virgula_dpois = true;
                    num_aposvirgula = true;
                }
                else
                {
                    txb_screen.Text += botao.Text;
                    apertou_operador = true;
                    virgula_dpois = true;
                }

            }


        }
        private void Operacao(object sender, EventArgs e)
        {
            System.Windows.Forms.Button operacao = (System.Windows.Forms.Button)sender;
            if (txb_screen.Text != "")
            {
                if ((cont_virgula > 0 && num_aposvirgula == true) || (cont_virgula == 0))
                {
                    if (apertou_operador == true)
                    {
                        if (igual_tem_valor == true && primera_conta_dps_igual == false)
                        {
                            switch (operacao.Text)
                            {
                                case "+":

                                    resultado = "(" + resultado + ")" + "+";
                                    apertou_operador = false;
                                    sinal = "1";
                                    break;
                                case "-":

                                    resultado = "(" + resultado + ")" + "-";
                                    apertou_operador = false;
                                    sinal = "2";
                                    break;
                                case "*":
                                    resultado = "(" + resultado + ")" + "*";
                                    apertou_operador = false;
                                    sinal = "3";
                                    break;
                                case "/":
                                    resultado = "(" + resultado + ")" + "/";
                                    apertou_operador = false;
                                    sinal = "4";
                                    break;


                            }

                            conta_operador += 1;
                            cont_virgula = 0;
                            primera_conta_dps_igual = true;
                            txb_auxiliar.Text = resultado;
                        }
                        else
                        {
                            switch (operacao.Text)
                            {
                                case "+":
                                    a = txb_screen.Text;
                                    resultado = resultado + a + "+";
                                    apertou_operador = false;
                                    sinal = "1";
                                    break;
                                case "-":
                                    a = txb_screen.Text;
                                    resultado += a + "-";
                                    apertou_operador = false;
                                    sinal = "2";
                                    break;
                                case "*":
                                    a = txb_screen.Text;
                                    resultado += a + "*";
                                    apertou_operador = false;
                                    sinal = "3";
                                    break;
                                case "/":
                                    if (txb_screen.Text == "0")
                                    {
                                        nao_pode_0 = true;
                                    }
                                    else
                                    {
                                        a = txb_screen.Text;
                                        resultado += a + "/";
                                        apertou_operador = false;
                                        sinal = "4";

                                    }
                                    break;
                            }
                        }
                        txb_screen.Text = null;
                        conta_operador += 1;
                        cont_virgula = 0;
                        txb_auxiliar.Text = resultado;
                        num_aposvirgula = false;
                    }
                }


            }
            
                if (apertou_operador == false)
                {
                    var n = txb_auxiliar.Text.ToArray();

                    n[n.Length - 1] = char.Parse(operacao.Text);
                    txb_auxiliar.Text = new string(n);

                }
            
        }

        private void btm_igual_Click(object sender, EventArgs e)
        {
            if (txb_screen.Text != "")
            {
                if ((cont_virgula > 0 && num_aposvirgula == true) || (cont_virgula == 0))
                {
                    if (conta_operador > 0)
                    {
                        switch (sinal)
                        {
                            case "1":
                                a = txb_screen.Text;
                                resultado = resultado + a;

                                break;
                            case "2":
                                a = txb_screen.Text;
                                resultado = resultado + a;
                                break;
                            case "3":
                                a = txb_screen.Text;
                                resultado = resultado + a;
                                break;
                            case "4":
                                if (txb_screen.Text == "0")
                                {
                                    txb_auxiliar.Text += "0";
                                    txb_screen.Text = "Não pode dividir por 0!";
                                    txb_screen.Font = new Font(Font.FontFamily, 20);
                                    txb_screen.BackColor = Color.White;
                                    txb_screen.ForeColor = Color.Red;
                                    txb_screen.BackColor = Color.White;
                                    nao_pode_0 = true;
                                    erro = true;
                                }
                                else
                                {
                                    a = txb_screen.Text;
                                    resultado = resultado + a;
                                }
                                break;
                        }
                        if (nao_pode_0 == false)
                        {
                            igual_tem_valor = true;
                            tela = dt.Compute(resultado, "");
                            txb_screen.Text = tela.ToString();
                            txb_auxiliar.Text = resultado;
                            sinal = null;
                            num_aposvirgula = false;
                            primera_conta_dps_igual = false;
                        }
                    }
                }
            }
        }
    }
}


