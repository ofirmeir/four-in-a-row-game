using CS21_Ex05.Enums;
using CS21_Ex05.Models;
using System;
using System.Windows.Forms;

namespace CS21_Ex05
{
    public partial class InitGameForm : Form
    {
        public InitGameForm()
        {
            InitializeComponent();
            this.txtPlayer2.Text = "[computer]";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string message = "";
            bool isTextboxValid = isTextboxInputValid(out message);
            if (isTextboxValid) {
                GameData data = new GameData()
                {
                    Player1Name = this.txtPlayer1.Text,
                    Player2Name = !isSecondPlayerHuman() ? "computer" : this.txtPlayer2.Text,
                    Opponent = !isSecondPlayerHuman() ? eOpponent.Computer : eOpponent.Human,
                    Rows = (int)this.numericUpDownRows.Value,
                    Cols = (int)this.numericUpDownCols.Value,
                };
                // $G$ NTT-001 (-10) You shouldn't create and show the GameBoard From through the Settings From.
                UserInterfaceForm userInterface = new UserInterfaceForm(data);
                userInterface.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool isTextboxInputValid(out string io_Message)
        {
            io_Message = "";
            bool isValidPlayer1 = false;
            bool isValidPlayer2 = false;

            if (this.txtPlayer1.Text.Trim() == String.Empty)
            {
                io_Message = "Missing Player 1 Name";
            }
            else
            {
                isValidPlayer1 = true;
            }

            if (this.cbPlayer2.Checked == true && this.txtPlayer2.Text.Trim() == String.Empty)
            {
                io_Message = io_Message + Environment.NewLine + "Missing Player 2 Name";
            }
            else
            {
                isValidPlayer2 = true;
            }

            return isValidPlayer1 && isValidPlayer2;
        }

        private bool isSecondPlayerHuman()
        {
            return this.cbPlayer2.Checked;
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnStart_Click(sender, e);
            }
        }

        private void cmbPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbPlayer2.Checked)
            {
                this.txtPlayer2.Text = String.Empty;
                this.txtPlayer2.Enabled = true;
            }
            else
            {
                this.txtPlayer2.Text = "[computer]";
                this.txtPlayer2.Enabled = false;
            }
        }
    }
}