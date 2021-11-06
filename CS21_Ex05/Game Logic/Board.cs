using CS21_Ex05.Enums;
using System;
using System.Windows.Forms;

// $G$ DSN-002 (-10) No UI seperation! This class merge the Logic board with the Visual board of the game.

namespace CS21_Ex05
{
    internal class Board
    {
        private readonly Button[,] m_Board;
        private int m_ColumnsSize;
        private int m_RowsSize;

        public int ColumnSize
        {
            get
            {
                return m_ColumnsSize;
            }
        }

        public int RowSize
        {
            get
            {
                return m_RowsSize;
            }
        }

        public Board(int i_RowsSize, int i_ColumnsSize)
        {
            this.m_RowsSize = i_RowsSize;
            this.m_ColumnsSize = i_ColumnsSize;
            this.m_Board = new Button[m_RowsSize, m_ColumnsSize];
        }

        internal void resetBoard()
        {
            for(int i = 0; i < m_RowsSize; i++)
            {
                for(int j = 0; j < m_ColumnsSize; j++)
                {
                    if (isCoordinateAssigned(i, j))
                    {
                        this.GetCoordinateLabel(i,j).Text = String.Empty;
                    }
                }
            }
        }

        internal void intializeBoard()
        {
            for (int i = 0; i < m_RowsSize; i++)
            {
                for (int j = 0; j < m_ColumnsSize; j++)
                {
                    m_Board[i, j] = new Button();
                }
            }
        }

        internal bool isCoordinateAssigned(int i_RowCoordinate, int i_ColumnCoordinate)
        {
            bool isAssigned = false;

            if (m_Board[i_RowCoordinate, i_ColumnCoordinate].Text != String.Empty)
            {
                isAssigned = true;
            }

            return isAssigned;
        }

        internal void writeSymbolOnCoordinate(int i_RowCoordinate, int i_ColumnCoordinate, int i_Turn)
        {
            if (i_Turn == 0)
            {
                m_Board[i_RowCoordinate, i_ColumnCoordinate].Text = "X";
            }
            else
            {
                m_Board[i_RowCoordinate, i_ColumnCoordinate].Text = "O";
            }
        }

        internal bool isEqualSymbol(int i_CurrentRowCoordinate, int i_CurrentColumnCoordinate, int i_OtherRowCoordinate, int i_OtherColumnCoordinate)
        {
            bool isEqual = false;

            if (m_Board[i_CurrentRowCoordinate, i_CurrentColumnCoordinate].Text == m_Board[i_OtherRowCoordinate, i_OtherColumnCoordinate].Text)
            {
                isEqual = true;
            }

            return isEqual;
        }

        internal Button GetCoordinateLabel(int i_CurrentRowCoordinate, int i_CurrentColumnCoordinate)
        {
            return m_Board[i_CurrentRowCoordinate, i_CurrentColumnCoordinate];
        }

        internal bool isBoardNotFull()
        {
            bool isNotFull = false;

            for (int currentRowIndex = 0; currentRowIndex < m_RowsSize; currentRowIndex++)
            {
                for (int currentColumnIndex = 0; currentColumnIndex < m_ColumnsSize; currentColumnIndex++)
                {
                    if (m_Board[currentRowIndex, currentColumnIndex].Text == String.Empty)
                    {
                        isNotFull = true;
                    }
                }
            }

            return isNotFull;
        }
    }
}