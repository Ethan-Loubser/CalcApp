using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalcApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private decimal firstNumber;
        private string OperandName;
        private bool IsOpClicked;

        private void Common_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (LblResult.Text == "0")
            {
                IsOpClicked = false;
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
            IsOpClicked = false;
        }

        private void btnX_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;

            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

        private void btnPerc_Clicked(object sender, EventArgs e)
        {
            decimal number = decimal.Parse(LblResult.Text);

            decimal result = number / 100;

            LblResult.Text = result.ToString();
        }

        private void CommonOP_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            IsOpClicked = true;
            OperandName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
        }

        public decimal Calculate(decimal numOne, decimal numTwo)
        {
            decimal result = 0;
            if (OperandName == "+")
            {
                result = numOne + numTwo;
            }
            else if (OperandName == "-")
            {
                result = numOne - numTwo;
            }
            else if (OperandName == "*")
            {
                result = numOne * numTwo;
            }
            else if (OperandName == "/")
            {
                result = numOne / numTwo;
            }
            return result;
        }

        private async void btnResult_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                LblResult.Text = finalResult;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
