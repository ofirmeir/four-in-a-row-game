using CS21_Ex05.Enums;
using CS21_Ex05.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CS21_Ex05.Board;

namespace CS21_Ex05
{
    public partial class UserInterfaceForm : Form
    {
        private int m_FirstPlayerPointsStatus = 0;
        private int m_SecondPlayerPointsStatus = 0;
        private int[] m_NewGamePointsStatus = new int[2] { 0, 0 };
        private static GameManager m_Game;
        private Button[] m_columnButtons;
        private GameData m_GameData;
        private Label m_lblPlayerOne;
        private Label m_lblPlayerTwo;
        private int m_LeftMargin;
        // $G$ CSS-004 (-2) Bad static members variable name (should be in the form of s_PascalCase).
        private static Random m_RandomNumber;
        private const int k_ColumnButtonsWidth = 20;
        private const int k_SpacingBetweenButtons = 10;
        private const int k_DisplayButtonsSquareSideSize = 20;

        public UserInterfaceForm(GameData i_Data)
        {
            InitializeComponent();
            this.m_GameData = i_Data;
            this.m_columnButtons = new Button[m_GameData.Cols];
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        internal void InitializeGame()
        {
            m_Game = new GameManager(this.m_GameData.Rows, this.m_GameData.Cols);
            m_RandomNumber = new Random();
            setTurn();
        }

        // $G$ DSN-999 (-5) the ui should not know what is AI - the game manger in the logic section should use ai in computer turns.
        private void setTurn()
        {
            if (this.m_GameData.Opponent == eOpponent.Computer)
            {
                m_Game.Turn = 0;
            }
            else
            {
                // $G$ NTT-999 (-5) There is no need to re-instantiate the random instance every time it is used.
                Random randomNumber = new Random();
                m_Game.Turn = randomNumber.Next(0, 1);
            }
        }

        private void calculateMarginSize()
        {
            m_LeftMargin = ((this.Size.Width) - (((this.m_GameData.Cols - 1) *
                (k_ColumnButtonsWidth + k_SpacingBetweenButtons)) + k_ColumnButtonsWidth)) / 2;
        }

        internal void DrawColumnButtons()
        {
            int xCoordinate = m_LeftMargin;
            int yCoordinate = 10;

            for (int i = 0; i < this.m_GameData.Cols; i++)
            {
                Button btnColumnButton = new Button();
                btnColumnButton.Text = (i + 1).ToString();
                btnColumnButton.Width = k_ColumnButtonsWidth;
                btnColumnButton.Location = new Point(xCoordinate, yCoordinate);
                btnColumnButton.Click += btnCol_Click;
                this.Controls.Add(btnColumnButton);
                m_columnButtons[i] = btnColumnButton;
                xCoordinate += k_ColumnButtonsWidth + k_SpacingBetweenButtons;
            }
        }

        internal void DrawBoardDisplayCellsAndLables()
        {
            int xCoordinate = m_LeftMargin;
            int yCoordinate = 20;

            Board board = m_Game.GameBoard;
            Button btnDisplayCell;

            for (int i = 0; i < this.m_GameData.Rows; i++)
            {
                yCoordinate += 30;
                xCoordinate = m_LeftMargin;
                for (int j = 0; j < this.m_GameData.Cols; j++)
                {
                    btnDisplayCell = board.GetCoordinateLabel(i, j);
                    btnDisplayCell.Text = String.Empty;
                    btnDisplayCell.Width = k_DisplayButtonsSquareSideSize;
                    btnDisplayCell.Height = k_DisplayButtonsSquareSideSize;
                    btnDisplayCell.Location = new Point(xCoordinate, yCoordinate);
                    btnDisplayCell.ForeColor = Color.Black;
                    btnDisplayCell.BackColor = Color.White;
                    btnDisplayCell.TextAlign = ContentAlignment.MiddleCenter;
                    xCoordinate += k_ColumnButtonsWidth + k_SpacingBetweenButtons;
                    this.Controls.Add(btnDisplayCell);
                }
            }

            DrawBoardLabels(yCoordinate);
        }

        internal void DrawBoardLabels(int i_YCoordinate)
        {
            int xCoordinate = 0;
            int yCoordinate = i_YCoordinate;
            
            xCoordinate = this.Width / 5;
            yCoordinate += 40;
            this.m_lblPlayerOne = new Label();
            m_lblPlayerOne.Text = m_GameData.Player1Name + " : 0";
            m_lblPlayerOne.AutoSize = true;
            m_lblPlayerOne.Location = new Point(xCoordinate, yCoordinate);
            m_lblPlayerOne.ForeColor = Color.Black;
            m_lblPlayerOne.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(m_lblPlayerOne);
            this.m_lblPlayerTwo = new Label();
            m_lblPlayerTwo.Text = m_GameData.Player2Name + " : 0";
            m_lblPlayerTwo.AutoSize = true;
            xCoordinate += 10*(m_GameData.Cols+1);
            m_lblPlayerTwo.Location = new Point(xCoordinate, yCoordinate);
            m_lblPlayerTwo.ForeColor = Color.Black;
            m_lblPlayerTwo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(m_lblPlayerTwo);
        }

        internal void StartNewGame()
        {
            this.m_NewGamePointsStatus = new int[] { 0, 0 };
            m_Game.StartGame();
            enableAllColumnButtons();
        }

        private void MakeComputerTurn()
        {
            int ComputerColumnNumber = 0;
 
            if ((m_GameData.Opponent == eOpponent.Computer) && (m_Game.Turn == 1))
            {
                ComputerColumnNumber = getComputerColumnValue();
                while (m_Game.isColumnFull(ComputerColumnNumber - 1))
                {
                    ComputerColumnNumber = getComputerColumnValue();
                }

                m_Game.MakeTurn(ComputerColumnNumber - 1, m_Game.Turn);
            }

            if (m_Game.GameOver())
            {
                updatePointsStatus();
                bool result = this.isGameOverMessage();
                if (result)
                {
                    this.StartNewGame();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private int getComputerColumnValue()
        {
            return m_RandomNumber.Next(m_GameData.Cols) + 1;
        }

        private bool isGameOverMessage()
        {
            string messageBoxText = String.Empty;
            string messageBoxTitle = String.Empty;
            string winningPlayer = String.Empty;

            if (isGameEndedWithDraw())
            {
                messageBoxTitle = "A Tie!";
                messageBoxText =
                    string.Format(
                    @"Tie!!
Another Round?");
            }
            else
            {
                messageBoxTitle = "A Win!";
                if (isPlayerOneWinner())
                {
                    winningPlayer = "1: " + m_GameData.Player1Name;
                }
                else
                {
                    winningPlayer = "2: " + m_GameData.Player2Name;
                }

                messageBoxText = string.Format(
@"Player {0} Won!!
Another Round?",
winningPlayer);
            }

            DialogResult result = MessageBox.Show(messageBoxText, messageBoxTitle, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
            return result == DialogResult.Yes;
        }

        private bool isGameEndedWithDraw()
        {
            return m_NewGamePointsStatus[0] == m_NewGamePointsStatus[1];
        }

        private bool isPlayerOneWinner()
        {
            return m_NewGamePointsStatus[0] > m_NewGamePointsStatus[1] ? true : false;
        }

        private void UserInterfaceForm_Load(object sender, EventArgs e)
        {
            this.Width = this.m_GameData.Cols * 40;
            this.Height = (this.m_GameData.Rows * 40) + 80;

            this.calculateMarginSize();
            this.DrawColumnButtons();
            this.InitializeGame();
            this.DrawBoardDisplayCellsAndLables();
            this.StartNewGame();
        }

        private void disableButtonsOfFullColumns()
        {
            for(int i = 0; i < m_GameData.Cols; i++)
            {
                if (m_Game.isColumnFull(i))
                {
                    m_columnButtons[i].Enabled = false;
                }
            }
        }

        private void enableAllColumnButtons()
        {
            for (int i = 0; i < m_GameData.Cols; i++)
            {
                m_columnButtons[i].Enabled = true;
            }
        }

        private void btnCol_Click(object sender, EventArgs e)
        {
            int selectedCol = int.Parse((sender as Button).Text);

            m_Game.MakeTurn(selectedCol - 1, m_Game.Turn);
            if (m_Game.GameOver())
            {
                updatePointsStatus();
                bool result = this.isGameOverMessage();
                if (result)
                {
                    this.StartNewGame();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MakeComputerTurn();
            }

            disableButtonsOfFullColumns();
        }

        private void updatePointsStatus()
        {
            this.m_NewGamePointsStatus = m_Game.getPointsStatus();
            this.m_FirstPlayerPointsStatus += this.m_NewGamePointsStatus[0];
            this.m_SecondPlayerPointsStatus += this.m_NewGamePointsStatus[1];
            this.m_lblPlayerOne.Text = m_GameData.Player1Name + ": " + this.m_FirstPlayerPointsStatus.ToString();
            this.m_lblPlayerTwo.Text = m_GameData.Player2Name + ": " + this.m_SecondPlayerPointsStatus.ToString();
        }

        private void UserInterfaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Game.GameOver())
            {
                e.Cancel = false;
            }
            else
            {
                m_Game.Quit(m_Game.Turn);
                updatePointsStatus();
                if (isGameOverMessage())
                {
                    e.Cancel = true;
                    this.StartNewGame();
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    }
}