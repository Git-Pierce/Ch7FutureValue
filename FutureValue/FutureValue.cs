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
    public partial class FutureValue : Form
    {
        public FutureValue()
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
                if (isValidData())
                {
                    /* this is a comment */
                    monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                    yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    years = Convert.ToInt32(txtYears.Text);
                }
                
            }
            catch (FormatException)
            {

                MessageBox.Show("A format exception has occured. Please check your entries", "Entry Error");
                //txtFutureValue.Focus();
                //throw fe;
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
            //if (monthlyInvestment <= 0)
            //{
            //    throw new Exception("Monthly investment must > 0.");
            //}
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }
            return futureValue;
        }
        public bool isValidData()
        {
            return
                isPresent(txtMonthlyInvestment, "Monthly Investment") &&
                isPresent(txtInterestRate, "Yearly Interest Rate") &&
                isPresent(txtYears, "Number of Years");
        }
        public bool isPresent(TextBox textBox, string name)
        {
            bool success = true;
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                success = false;
                return success;
            }
            return success;
        }
        public bool IsInt32(TextBox textBox, string name)
        {
            /* you fill in the code from the textbook */
            //Checks for valid numeric value

            return true;
        }
        public bool IsDecimal(TextBox textBox, string name)
        {
            return true;
        }
        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
        {
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}