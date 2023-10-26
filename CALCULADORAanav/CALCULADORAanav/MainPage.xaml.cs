using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CALCULADORAanav
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public bool operacionClicked;
        public decimal primerNum;
        public decimal segundoNum;
        public decimal tercerNum;
        public string nombreOperacion;
        

        public void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (calcu.Text == "0" || operacionClicked)
            {
                operacionClicked = false;
                calcu.Text = button.Text;
            }
            else
            {
                //validacion para poner solo un punto
                if (button.Text == "." && calcu.Text.Contains("."))
                {

                }
                else
                {
                    calcu.Text += button.Text;
                }
            }
        }

        private void BtnLimpiar_Clicked(object sender, EventArgs e)
        {
            calcu.Text = "0";
            operacionClicked = false;
            primerNum = 0;
        }

        private void BtnX_Clicked(object sender, EventArgs e)
        {
            string numero = calcu.Text;
            if (numero != "0")
            {
                numero = numero.Remove(numero.Length - 1, 1);
                if (string.IsNullOrEmpty(numero))
                {
                    calcu.Text = "0";
                }
                else
                {
                    calcu.Text = numero;
                }
            }
        }

        private void BtnCommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            operacionClicked = true;
            nombreOperacion = button.Text;
            primerNum = Convert.ToDecimal(calcu.Text);
            segundoNum = Convert.ToDecimal(calcu.Text);
            tercerNum = Convert.ToDecimal(calcu.Text);
        }

        private async void BtnPorcentaje_Clicked(object sender, EventArgs e)
        {
            try
            {
                string numero = calcu.Text;
                if (numero != "0")
                {
                    decimal porcentaje = Convert.ToDecimal(numero);
                    string resultado = (porcentaje / 100).ToString("0.##");
                    calcu.Text = resultado;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Operacion Invalida", "Ok");
            }
        }

        private void Btnigual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal primerNum = Convert.ToDecimal(calcu.Text);
                decimal tercerNum = Convert.ToDecimal(calcu.Text);
                decimal segundoNum = Convert.ToDecimal(calcu.Text);
                string resultadoFinal = Calcular(primerNum, segundoNum, tercerNum).ToString("0.##");
                calcu.Text = resultadoFinal;
            }
            catch (Exception)
            {
                DisplayAlert("Error", "Operacion Invalida", "Ok");
            }
        }

        public decimal Calcular(decimal num1, decimal num2, decimal num3)
        {
            decimal resultado = 0;
            if (nombreOperacion == "+")
            {
                resultado = num1 += num2+= num3;
            }
            else if (nombreOperacion == "-")
            {
                resultado = num1 -= num2;
            }
            else if (nombreOperacion == "*")
            {
                resultado = num1 *= num2;
            }
            else if (nombreOperacion == "/")
            {
                resultado = num1 /= num2;
            }
            return resultado;
        }
    }
}
