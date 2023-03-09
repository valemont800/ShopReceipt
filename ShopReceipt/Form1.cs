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

//Valentina Montoya
//ISC3U
//March 9, 2023
//Shop that is able to print a receipt based on one of the shops in The Legend of Zelda: Twilight Princess 

namespace ShopReceipt
{
    public partial class Form1 : Form
    {
        //global variables

        //prices of all items
        double shieldPrice = 5.25;
        double potionPrice = 3.00;
        double arrowPrice = 1.25;

        //initial amounts set to zero
        int numOfShields = 0;
        int numOfPotions = 0;
        int numOfArrows = 0;

        double tendered = 0;
        double totalPrice = 0;

        //variables for all calculations
        double taxAmount, taxRate, subTotal, change, shieldSum, arrowSum, potionSum;

        private void printButton_Click(object sender, EventArgs e)
        {
         
                

            //printer receipt sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.Printer);
            player.Play();

            //receipt title (inlcude background colour to expand)
            receiptLabel.Text = $"                          - Malo Mart -";

            
            receiptLabel.BackColor = Color.White;
            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);
            Thread.Sleep(500);
            receiptLabel.Refresh();

            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height + 14);

            //state initial prices and amount baught

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

            //state calculations

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

            //state tendered and change recieved

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

            //thank you message with picture and sound

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
            //reset amounts to 0

            numOfShields = 0;
            numOfPotions = 0;
            numOfArrows = 0;

            //reset calculations to 0

            tendered = 0;
            totalPrice = 0;
            subTotal = 0;
            taxAmount = 0;

            //reset text to display nothing
            subOutput.Text = $"";
            taxOutput.Text = $"";
            totalOutput.Text = $"";

            changeOutput.Text = $"";

            //reset input to display nothing
            shieldInput.Text = "";
            arrowInput.Text = "";
            potionInput.Text = "";
            tenderedInput.Text = "";


            //reset receipt to display nothing
            receiptLabel.Text = "";

            maloMartImage.Visible = false;

            //make the background colour of the receipt disappear
            receiptLabel.Size = new Size(receiptLabel.Size.Width, receiptLabel.Size.Height - 600);

            //easter egg song stops
            SoundPlayer player2 = new SoundPlayer(Properties.Resources.maloMartTheme_1_);
            player2.Stop();

        }

        public Form1()
        {
            InitializeComponent();
           
        }

       
       

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            { 

                //sound is played when button is clicked
               SoundPlayer player = new SoundPlayer(Properties.Resources.rupee);
                player.Play();

                //convert input given
                numOfShields = Convert.ToInt16(shieldInput.Text);
                numOfPotions = Convert.ToInt16(potionInput.Text);
                numOfArrows = Convert.ToInt16(arrowInput.Text);

                //tax
                taxRate = 0.13;

                //the price of each item is calculated
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

                //include easter egg when the release date of the game that inspired this has been inputed
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
                //when a letter is typed, display an error message

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
                //sound played when button is clicked
                SoundPlayer player = new SoundPlayer(Properties.Resources.rupee);
                player.Play();

                //convert inputed amount
                tendered = Convert.ToDouble(tenderedInput.Text);

                //change calculations
                change = tendered - totalPrice;

                //display change amount below
                changeOutput.Text = $"{change.ToString("C")}";

                //if tendered inputed is less than the price, display error message
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
                //if letters are inputed, display an error message

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
