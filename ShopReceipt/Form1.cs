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
using System.Media;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Net.Security;

namespace ShopReceipt
{
    public partial class Form1 : Form
    {
        //global variables

        //prices
        double shieldPrice = 5.25;
        double potionPrice = 3.00;
        double arrowPrice = 1.25;

        //amount
        int numOfShields = 0;
        int numOfPotions = 0;
        int numOfArrows = 0;

        double tendered = 0;
        double totalPrice = 0;

        //variables
        double taxAmount, taxRate, subTotal, change, shieldSum, arrowSum, potionSum;

        private void printButton_Click(object sender, EventArgs e)
        {
            //check
            if (numOfShields == 0)
            {
                receiptLabel.Text += "";
            }
                

            //sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.Printer);
            player.Play();

            //receipt text
            receiptLabel.Text = $"                          - Malo Mart -";

            receiptLabel.BackColor = Color.White;
            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n\n     Hylien Shields      x{numOfShields}      @      {shieldPrice}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            player.Play();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n     Red Potions          x{numOfPotions}      @       {potionPrice}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n     Arrows                  x{numOfArrows}      @      {arrowPrice}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            player.Play();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n\n    Subtotal                                      {subTotal.ToString("C")}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n    Tax                                               {taxAmount.ToString("C")}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            player.Play();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n    Total                                           {totalPrice.ToString("C")}";
            Thread.Sleep(500);    
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n\n     Tendered                                  {tendered.ToString("C")}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            player.Play();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += $"\n     Change                                       {change.ToString("C")}";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += "\n----------------------------------------------------";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            SoundPlayer player2 = new SoundPlayer(Properties.Resources.chestOpening);
            player2.Play();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += "\nThank You for Shopping at Malo Mart !";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            receiptLabel.Text += "\n             Have a Nice Day :]";
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 181);
            receiptLabel.Refresh();
            Thread.Sleep(500);

            maloMartImage.Visible = true;
            receiptLabel.Refresh();
            



        }


        private void newButton_Click(object sender, EventArgs e)
        {
            //reset amount

            numOfShields = 0;
            numOfPotions = 0;
            numOfArrows = 0;

            tendered = 0;
            totalPrice = 0;

            //reset text
            subOutput.Text = $"";
            taxOutput.Text = $"";
            totalOutput.Text = $"";

            changeOutput.Text = $"";

            //reset input
            shieldInput.Text = "";
            arrowInput.Text = "";
            potionInput.Text = "";
            tenderedInput.Text = "";


            //reset receipt
            receiptLabel.Text = "";

            maloMartImage.Visible = false;

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height - 600);

            //easter egg song stops
            SoundPlayer player2 = new SoundPlayer(Properties.Resources.maloMartTheme_1_);
            player2.Stop();

        }

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            { 

                //sound
               SoundPlayer player = new SoundPlayer(Properties.Resources.rupee);
                player.Play();

                //convert input
                numOfShields = Convert.ToInt16(shieldInput.Text);
                numOfPotions = Convert.ToInt16(potionInput.Text);
                numOfArrows = Convert.ToInt16(arrowInput.Text);

                //tax
                taxRate = 0.13;

                //math
                shieldSum = shieldPrice * numOfShields;
                arrowSum = arrowPrice * numOfArrows;
                potionSum = potionPrice * numOfPotions;

                subTotal = shieldSum + arrowSum + potionSum;
                taxAmount = subTotal * taxRate;
                totalPrice = subTotal + taxAmount;

                //convert amount
                subTotal = Convert.ToDouble(subTotal);
                taxAmount = Convert.ToDouble(taxAmount);
                totalPrice = Convert.ToDouble(totalPrice);

                //text output
                subOutput.Text = $"{subTotal.ToString("C")}";
                taxOutput.Text = $"{taxAmount.ToString("C")}";
                totalOutput.Text = $"{totalPrice.ToString("C")}";

                //easter egg
                if (numOfShields == 11 && numOfPotions == 19 && numOfArrows == 2006)
                {
                    SoundPlayer player2 = new SoundPlayer(Properties.Resources.maloMartTheme_1_);
                    player2.Play();

                    receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 250);
                    receiptLabel.Refresh();

                    receiptLabel.Text = ":OO You found the easter egg !!!";
                    receiptLabel.Text += "\nGood job :]";
                }

            }
            catch
            {
                subOutput.Text = "ERROR :[";
                taxOutput.Text = "ERROR :[";
                totalOutput.Text = "ERROR :[";

                shieldInput.Text = "ERROR :[";
                arrowInput.Text = "ERROR :[";
                potionInput.Text = "ERROR :[";

                changeOutput.Text = "";

                receiptLabel.Text = "    Please input numbers and not words !";
                receiptLabel.Text += "      \n    Click on |Next Order| to try again !";


            }


        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                //sound
                SoundPlayer player = new SoundPlayer(Properties.Resources.rupee);
                player.Play();

                //convert
                tendered = Convert.ToDouble(tenderedInput.Text);

                //math
                change = tendered - totalPrice;

                //text
                changeOutput.Text = $"{change.ToString("C")}";

                //error
                if (tendered < totalPrice)
                {
                    tenderedInput.Text = "ERROR :[";
                    changeOutput.Text = "ERROR :[";

                    receiptLabel.Text = " Please input a value higher than the total price !";
                    receiptLabel.Text += "      \n    Click on |Next Order| to try again !";

                }
            }
            catch
            {
                subOutput.Text = "";
                taxOutput.Text = "";
                totalOutput.Text = "";

                shieldInput.Text = "";
                arrowInput.Text = "";
                potionInput.Text = "";

                changeOutput.Text = "ERROR :[";

                receiptLabel.Text = "    Please input numbers and not words !";
                receiptLabel.Text += "      \n    Click on |Next Order| to try again !";
                    

            }

        }
    }
}
