using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS21_Ex05
{
    internal class GameManager
    {
        private Board m_Board;
        private int m_GameWinner = -1;
        private int m_Turn;
        public int Turn
        {
            get
            {
                return m_Turn;
            }
            set
            {
                m_Turn = value;
            }
        }

        public Board GameBoard
        {
            get
            {
                return m_Board;
            }
        }

        public GameManager(int i_RowsSize, int i_ColumnSize)
        {
            m_Board = new Board(i_RowsSize, i_ColumnSize);
            m_Board.intializeBoard();
            m_Turn = 0;
        }

        internal void StartGame()
        {
            m_Board.resetBoard();
            m_Turn = 0;
            m_GameWinner = -1;
        }

        internal bool GameOver()
        {
            bool isGameOver = false;

            if (!m_Board.isBoardNotFull())
            {
                isGameOver = true;
            } 
            else if (m_GameWinner != -1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        internal void MakeTurn(int i_ColumnNumber, int i_Player)
        {
            bool isAWinner = false;
            bool foundAnEmptyCoordinate = false;

            for (int i = m_Board.RowSize - 1; (i >= 0) && (!foundAnEmptyCoordinate); i--)
            {
                if (!m_Board.isCoordinateAssigned(i, i_ColumnNumber))
                {
                    m_Board.writeSymbolOnCoordinate(i, i_ColumnNumber, m_Turn);
                    isAWinner = CheckBoardFourSymbolSquence(i, i_ColumnNumber);
                    foundAnEmptyCoordinate = true;
                }
            }

            if (isAWinner)
            {
                m_GameWinner = i_Player;
            }

            switchTurns();
        }

        private void switchTurns()
        {
            m_Turn = m_Turn == 0 ? 1 : 0;
        }

        internal bool isColumnFull(int i_ColumnNumber)
        {
            return m_Board.isCoordinateAssigned(0, i_ColumnNumber);
        }

        /*
         * Quit Method: adds a point to the other player by setting the winner to the other player
         */
        internal void Quit(int i_Player)
        {
            m_GameWinner = (i_Player == 0) ? 1 : 0;
        }

        // $G$ DSN-003 (-2) This method is too long. Should be split into several methods.
        internal bool CheckBoardFourSymbolSquence(int i_RowCoordinate, int i_ColumnCoordinate)
        {
            int countSequence = 1;
            bool caseFound = false;

            // Horizontal Sequence
            for (int currentColumn = 0; currentColumn < (m_Board.ColumnSize - 1) && !caseFound; currentColumn++)
            {
                if (m_Board.isEqualSymbol(i_RowCoordinate, currentColumn, i_RowCoordinate, currentColumn + 1) &&
                    m_Board.isCoordinateAssigned(i_RowCoordinate, currentColumn) && m_Board.isCoordinateAssigned(i_RowCoordinate, currentColumn + 1))
                {
                    countSequence++;
                }
                else
                {
                    countSequence = 1;
                }

                caseFound = (countSequence == 4) ? true : false;
            }

            if (!caseFound)
            {
                // Vertical Sequence
                for (int currentRow = 0; currentRow < (m_Board.RowSize - 1) && !caseFound; currentRow++)
                {
                    if (m_Board.isEqualSymbol(currentRow, i_ColumnCoordinate, currentRow + 1, i_ColumnCoordinate) && m_Board.isCoordinateAssigned(currentRow, i_ColumnCoordinate)
                        && m_Board.isCoordinateAssigned(currentRow + 1, i_ColumnCoordinate))
                    {
                        countSequence++;
                    }
                    else
                    {
                        countSequence = 1;
                    }

                    caseFound = (countSequence == 4) ? true : false;
                }
            }

            // TODO : Diagonal Sequence
            if (!caseFound)
            {
                for(int i = 0; i <= (m_Board.RowSize - 4) && !caseFound; i++)
                {
                    for(int j = 0; j <= (m_Board.ColumnSize - 4) && !caseFound; j++)
                    {
                        // checking if the \ diagonal is not 'E'
                        if (m_Board.isCoordinateAssigned(i, j) && m_Board.isCoordinateAssigned(i + 1, j + 1)
                            && m_Board.isCoordinateAssigned(i + 2, j + 2) && m_Board.isCoordinateAssigned(i + 3, j + 3))
                        {
                            // checking if the \ diagonal had the same symbol
                            if (m_Board.isEqualSymbol(i, j, i+1, j+1) && m_Board.isEqualSymbol(i + 1, j + 1, i + 2, j + 2)
                            && m_Board.isEqualSymbol(i + 2, j + 2, i + 3, j + 3))
                            {
                                caseFound = true;
                            }
                        }
                        // checking if the / diagonal is not 'E'
                        if (m_Board.isCoordinateAssigned(i, j + 3) && m_Board.isCoordinateAssigned(i + 1, j + 2)
                            && m_Board.isCoordinateAssigned(i + 2, j + 1) && m_Board.isCoordinateAssigned(i + 3, j))
                        {
                            // checking if the / diagonal had the same symbol
                            if (m_Board.isEqualSymbol(i, j + 3, i + 1, j + 2) && m_Board.isEqualSymbol(i + 1, j + 2, i + 2, j + 1)
                            && m_Board.isEqualSymbol(i + 2, j + 1, i + 3, j))
                            {
                                caseFound = true;
                            }
                        }
                    }
                }
            }

            return caseFound;
        }

        internal int[] getPointsStatus()
        {
            int[] pointsStatus = { 0, 0 };

            if(m_GameWinner != -1)
            {
                pointsStatus[m_GameWinner] = 1;
            }

            return pointsStatus;
        }
    }
}