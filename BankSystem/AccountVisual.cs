using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BankSystem
{
    //BankSystem.RegistrationForm Acess;
    public partial class AccountVisual : Form
    {
        public AccountVisual()
        {
            InitializeComponent();
        }
        private bool CheckInput(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (!(x[i] >= '0' && x[i] <= '9')) return false;
            }
            return true;
        }
      
        private void depositBtn_Click(object sender, EventArgs e)
        {
            double Value;
         
            if (CheckInput(richTextBox1.Text))
            {
                
                Value = Convert.ToDouble(richTextBox1.Text);
                CustomerData.Current.AMT += Value;
                
                CustomerData.UpdateAcc();
                MessageBox.Show("Your Order Has Been Processed!", "Confirm");
                this.Close();
  
            }
            else
            {
                MessageBox.Show("Please Enter A Correct Value!", "Error");
            }

        }

        private void withdrawBtn_Click(object sender, EventArgs e)
        {
            if (CheckInput(richTextBox1.Text))
            {
                if (CustomerData.Current.AMT < Double.Parse(richTextBox1.Text))
                {
                    CustomerData.Current.AMT -= Double.Parse(richTextBox1.Text);
                    MessageBox.Show("Withdrawal Successful!");

                }
                else
                    MessageBox.Show("Insufficient Balance");
            
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Entry");
            }
          
        }
    }
}
