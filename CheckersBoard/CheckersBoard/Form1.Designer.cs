namespace CheckersBoard
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //#region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>

        private void InitializeComponent()
        {
            
            this.picBoard = new System.Windows.Forms.PictureBox();
            this.picTile = new System.Windows.Forms.PictureBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.nuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBDificil = new System.Windows.Forms.RadioButton();
            this.rBMedio = new System.Windows.Forms.RadioButton();
            this.rBFacil = new System.Windows.Forms.RadioButton();
            this.btnJugar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoard
            // 
            this.picBoard.Location = new System.Drawing.Point(16, 26);
            this.picBoard.Margin = new System.Windows.Forms.Padding(4);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(560, 560);
            this.picBoard.TabIndex = 0;
            this.picBoard.TabStop = false;
            // 
            // picTile
            // 
            this.picTile.BackColor = System.Drawing.Color.Blue;
            this.picTile.Location = new System.Drawing.Point(191, 82);
            this.picTile.Margin = new System.Windows.Forms.Padding(4);
            this.picTile.Name = "picTile";
            this.picTile.Size = new System.Drawing.Size(68, 63);
            this.picTile.TabIndex = 1;
            this.picTile.TabStop = false;
            this.picTile.Visible = false;
            // 
            // lblDetails
            // 
            this.lblDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDetails.Location = new System.Drawing.Point(0, 608);
            this.lblDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(861, 28);
            this.lblDetails.TabIndex = 2;
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(0, 600);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(100, 50);
            this.nuevo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBDificil);
            this.groupBox1.Controls.Add(this.rBMedio);
            this.groupBox1.Controls.Add(this.rBFacil);
            this.groupBox1.Location = new System.Drawing.Point(657, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dificultad";
            // 
            // rBDificil
            // 
            this.rBDificil.AutoSize = true;
            this.rBDificil.Location = new System.Drawing.Point(17, 75);
            this.rBDificil.Name = "rBDificil";
            this.rBDificil.Size = new System.Drawing.Size(62, 21);
            this.rBDificil.TabIndex = 2;
            this.rBDificil.TabStop = true;
            this.rBDificil.Text = "Difícil";
            this.rBDificil.UseVisualStyleBackColor = true;
            this.rBDificil.CheckedChanged += new System.EventHandler(this.rBDificil_CheckedChanged);
            // 
            // rBMedio
            // 
            this.rBMedio.AutoSize = true;
            this.rBMedio.Location = new System.Drawing.Point(17, 48);
            this.rBMedio.Name = "rBMedio";
            this.rBMedio.Size = new System.Drawing.Size(67, 21);
            this.rBMedio.TabIndex = 1;
            this.rBMedio.TabStop = true;
            this.rBMedio.Text = "Medio";
            this.rBMedio.UseVisualStyleBackColor = true;
            this.rBMedio.CheckedChanged += new System.EventHandler(this.rBMedio_CheckedChanged);
            // 
            // rBFacil
            // 
            this.rBFacil.AutoSize = true;
            this.rBFacil.Checked = true;
            this.rBFacil.Location = new System.Drawing.Point(17, 21);
            this.rBFacil.Name = "rBFacil";
            this.rBFacil.Size = new System.Drawing.Size(58, 21);
            this.rBFacil.TabIndex = 0;
            this.rBFacil.TabStop = true;
            this.rBFacil.Text = "Fácil";
            this.rBFacil.UseVisualStyleBackColor = true;
            this.rBFacil.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(674, 272);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(75, 43);
            this.btnJugar.TabIndex = 5;
            this.btnJugar.Text = "¡Jugar!";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 636);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.picTile);
            this.Controls.Add(this.picBoard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers";
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void iniciaTablero()
        {
            
            this.tablero = new int[8, 8];
            //iniciaTablero();
            
            for (int m = 0; m < 8; m++)
                for (int n = 0; n < 8; n++)
                {
                    if (m % 2 == 0)  //fila par empieza con claro
                    {
                        if (n % 2 == 1) //en fila par las columnas impares tiene fichas
                        {
                            if (m < 3)
                                tablero[n, m] = 1;
                            else if (m > 4)
                                tablero[n, m] = -1;
                            else tablero[n, m] = 0;
                        }
                        else
                        {
                            tablero[n, m] = 2;
                        }
                    }
                    else //fila impar
                    {
                        if (n % 2 == 0) //en fila impar las columnas pares tienen fichas
                        {
                            if (m < 3)
                                tablero[n, m] = 1;
                            else if (m > 4)
                                tablero[n, m] = -1;
                            else tablero[n, m] = 0;
                        }
                        else
                        {
                            tablero[n, m] = 2;
                        }
                    }
                }

            System.Console.WriteLine("Tablero inicial");
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    System.Console.Write(tablero[n, m]);
                }
                System.Console.WriteLine(" ");
            }
        }
        //#endregion
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.PictureBox picTile;
        private System.Windows.Forms.Button nuevo;
        private int[,] tablero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBFacil;
        private System.Windows.Forms.RadioButton rBDificil;
        private System.Windows.Forms.RadioButton rBMedio;
        private System.Windows.Forms.Button btnJugar;
        private bool juego;
    }
}

