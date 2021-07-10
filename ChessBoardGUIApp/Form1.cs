using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {

        static public Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        String selectedPiece = "";

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid() 
        {
            //the function will fill the panel control with buttons
            int buttonSize = panel1.Width / myBoard.Size; //calculate width of each button
            panel1.Height = panel1.Width; //set the grid to be square

            //nested loop to create buttons and put them on the panel
            for (int r = 0; r < myBoard.Size; r++) 
            {
                for (int c = 0; c < myBoard.Size; c++) 
                {
                    btnGrid[r, c] = new Button();

                    //make each button square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click; //Add the same click event to each button
                    panel1.Controls.Add(btnGrid[r, c]); //Place the button on the Panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); //position it in the x,y

                    //for testing purposes. Remove Later
                    btnGrid[r,c].Text = r.ToString() + "|" + c.ToString();

                    //the Tag attribute will hold the row and column number in a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            //Get the Row and Column Number of the Button that was just Clicked
            string[] strArr = (sender as Button).Tag.ToString().Split("|");
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            //run a helper function to label all legal moves for this piece. 
            Cell currentCell = myBoard.theGrid[r, c];
            myBoard.MarkNextLegalMoves(currentCell, "Bishop");
            updateButtonLabels();

            //reset the background color of all buttons to the default (original) color. 
            for (int i = 0; i < myBoard.Size; i++) 
            {
                for (int j = 0; j < myBoard.Size; j++) 
                {
                    btnGrid[i, j].BackColor = default(Color);
                }
            }

            //set the background of the clicked button to something different
            (sender as Button).BackColor = Color.Cornsilk;
        }

        public void updateButtonLabels() 
        {
            for (int r = 0; r < myBoard.Size; r++) 
            {
                for (int c = 0; c < myBoard.Size; c++) 
                {
                    btnGrid[r, c].Text = "";
                    if (myBoard.theGrid[r, c].CurrentlyOccupied) btnGrid[r, c].Text = "Bishop";
                    if (myBoard.theGrid[r, c].LegalNextMove) btnGrid[r, c].Text = "Legal";
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedPiece = comboBox1.SelectedItem.ToString();
        }
    }
}
