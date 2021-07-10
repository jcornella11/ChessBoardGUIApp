using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }

        //2D Array of Cell Objects
        public Cell[,] theGrid;

        public Board(int s) 
        {
            Size = s;
            //Initalization of the Array
            theGrid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++) 
            {
                for (int j = 0; j < Size; j++) 
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //Step 1: Clear All Legal Moves from previous turn
            for (int r = 0; r < Size; r++) 
            {
                for (int c = 0; c < Size; c++) 
                {
                    theGrid[r, c].LegalNextMove = false;
                }
            }
            //Step 2: Find all legal moves and mark the square.
            switch (chessPiece) 
            {
                case "Knight":

                    if (currentCell.RowNumber > 2 && currentCell.ColumnNumber > 1)
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber > 2 && currentCell.ColumnNumber < Size - 1)
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber > 1 && currentCell.ColumnNumber < Size - 2)
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 1 && currentCell.ColumnNumber < Size - 2)
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 2 && currentCell.ColumnNumber < Size - 1)
                    {
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 2 && currentCell.ColumnNumber > 1)
                    {
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 1 && currentCell.ColumnNumber > 2)
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber > 1 && currentCell.ColumnNumber < Size - 2)
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    }
                    break;

                case "King":
                    if (currentCell.RowNumber > 1 && currentCell.ColumnNumber > 1)
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (currentCell.ColumnNumber > 1)
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 1 && currentCell.ColumnNumber > 1)
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber > 1)
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 1)
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber > 1 && currentCell.ColumnNumber < Size - 1)
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }

                    if (currentCell.ColumnNumber < Size - 1)
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }

                    if (currentCell.RowNumber < Size - 1 && currentCell.ColumnNumber < Size - 1)
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
        
                    break;

                case "Rook":

                    for (int i = 0; i < Size; i++) 
                    {
                        for (int j = 0; j < Size; j++) 
                        {
                            if (currentCell.ColumnNumber < Size - j)
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber + j].LegalNextMove = true;
                            }

                            if (currentCell.ColumnNumber >= j)
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j].LegalNextMove = true;
                            }

                            if (currentCell.RowNumber < Size - i)
                            {
                                theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                            }

                            if (currentCell.RowNumber >= i)
                            {
                                theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                            }
                        }
                    }
                    break;

                case "Bishop":
                   

                    for (int i = 0; i < Size; i++) 
                    {
                        for (int j = 0; j < Size; j++) 
                        {
                            if (currentCell.RowNumber < Size - i && currentCell.ColumnNumber < Size - j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + j].LegalNextMove = true;
                                }
                            }

                            if (currentCell.RowNumber >= i && currentCell.ColumnNumber >= j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - j].LegalNextMove = true;
                                }
                            }

                            if (currentCell.RowNumber >= i && currentCell.ColumnNumber < Size - j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + j].LegalNextMove = true;
                                }
                            }

                            if (currentCell.RowNumber < Size - i && currentCell.ColumnNumber >= j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - j].LegalNextMove = true;
                                }
                            }
                        }
                    }

                    break;

                case "Queen":

                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            if (currentCell.ColumnNumber < Size - j)
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber + j].LegalNextMove = true;
                            }

                            if (currentCell.ColumnNumber >= j)
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColumnNumber - j].LegalNextMove = true;
                            }

                            if (currentCell.RowNumber < Size - i)
                            {
                                theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                            }

                            if (currentCell.RowNumber >= i)
                            {
                                theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                            }
                        }
                    }

                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            if (currentCell.RowNumber < Size - i && currentCell.ColumnNumber < Size - j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + j].LegalNextMove = true;
                                }
                            }

                            if (currentCell.RowNumber >= i && currentCell.ColumnNumber >= j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - j].LegalNextMove = true;
                                }
                            }

                            if (currentCell.RowNumber >= i && currentCell.ColumnNumber < Size - j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + j].LegalNextMove = true;
                                }
                            }

                            if (currentCell.RowNumber < Size - i && currentCell.ColumnNumber >= j)
                            {
                                if (i == j)
                                {
                                    theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - j].LegalNextMove = true;
                                }
                            }
                        }
                    }

                    break;

                default:
                    break;
            }
        
        }

    }
}
