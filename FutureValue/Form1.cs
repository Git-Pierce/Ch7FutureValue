using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int years = 0;
            decimal yearlyInterestRate = 0;
            decimal monthlyInvestment = 0;

            try
            {
                monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                years = Convert.ToInt32(txtYears.Text);
            }
            catch (FormatException)
            {

                MessageBox.Show("A format exception has occured. Please check your entries", "Entry Error");
            }
            catch (OverflowException)
            {

                MessageBox.Show("An overflow exception has occured. Please enter smaller values", "Overflow Error");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.GetType().ToString(), "Error");
            }


            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

            decimal futureValue = this.CalculateFutureValue(
                monthlyInvestment, monthlyInterestRate, months);
            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
        }

        private decimal CalculateFutureValue(decimal monthlyInvestment, 
            decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }
            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}