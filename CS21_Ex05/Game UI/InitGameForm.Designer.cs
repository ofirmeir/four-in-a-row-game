
namespace CS21_Ex05
{
    partial class InitGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.cbPlayer2 = new System.Windows.Forms.CheckBox();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.lblBoardSize = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblCols = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(23, 252);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(287, 27);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 17);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Players:";
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(52, 57);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(64, 17);
            this.lblPlayer1.TabIndex = 2;
            this.lblPlayer1.Text = "Player 1:";
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.Location = new System.Drawing.Point(161, 57);
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Size = new System.Drawing.Size(126, 22);
            this.txtPlayer1.TabIndex = 3;
            // 
            // cbPlayer2
            // 
            this.cbPlayer2.AutoSize = true;
            this.cbPlayer2.Location = new System.Drawing.Point(55, 107);
            this.cbPlayer2.Name = "cbPlayer2";
            this.cbPlayer2.Size = new System.Drawing.Size(86, 21);
            this.cbPlayer2.TabIndex = 4;
            this.cbPlayer2.Text = "Player 2:";
            this.cbPlayer2.UseVisualStyleBackColor = true;
            this.cbPlayer2.CheckedChanged += new System.EventHandler(this.cmbPlayer2_CheckedChanged);
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.Enabled = false;
            this.txtPlayer2.Location = new System.Drawing.Point(161, 105);
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Size = new System.Drawing.Size(126, 22);
            this.txtPlayer2.TabIndex = 5;
            // 
            // lblBoardSize
            // 
            this.lblBoardSize.AutoSize = true;
            this.lblBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBoardSize.Location = new System.Drawing.Point(20, 166);
            this.lblBoardSize.Name = "lblBoardSize";
            this.lblBoardSize.Size = new System.Drawing.Size(92, 17);
            this.lblBoardSize.TabIndex = 6;
            this.lblBoardSize.Text = "Board Size:";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(33, 203);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(46, 17);
            this.lblRows.TabIndex = 7;
            this.lblRows.Text = "Rows:";
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(173, 203);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(39, 17);
            this.lblCols.TabIndex = 8;
            this.lblCols.Text = "Cols:";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(85, 198);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(69, 22);
            this.numericUpDownRows.TabIndex = 9;
            this.numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(218, 198);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(69, 22);
            this.numericUpDownCols.TabIndex = 10;
            this.numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // InitGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 303);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.lblBoardSize);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.cbPlayer2);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(350, 350);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "InitGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.TextBox txtPlayer1;
        private System.Windows.Forms.CheckBox cbPlayer2;
        private System.Windows.Forms.TextBox txtPlayer2;
        private System.Windows.Forms.Label lblBoardSize;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
    }
}