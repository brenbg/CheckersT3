using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace CheckersBoard
{
    public partial class Form1 : Form
    {
        List<CellDetails> cells = new List<CellDetails>();
        const int cCellSize = 70;
        int boardLeft = 0;
        int boardTop = 0;
        int clickCount = 0, depth=6;
        CellDetails inicio, fin;
        CellDetails cNull;
        int filaInicio, columnaInicio, filaFin, columnaFin;
        int auxtipo = 0, tipo; //tenía tipo = -1
        Boolean hooman = true;
        Process cmd;

        TextureBrush cOscuro = new TextureBrush(Image.FromFile(@".\Imagenes\cC270.jpg"));
        TextureBrush cClaro = new TextureBrush(Image.FromFile(@".\Imagenes\cB70.jpg"));
        TextureBrush cFB = new TextureBrush(Image.FromFile(@".\Imagenes\cOFB70.png"));
        TextureBrush cFN = new TextureBrush(Image.FromFile(@".\Imagenes\cOFN70.png"));
        TextureBrush cRB = new TextureBrush(Image.FromFile(@".\Imagenes\cORB70.png"));
        TextureBrush cRN = new TextureBrush(Image.FromFile(@".\Imagenes\cORN70.png"));


        //int [,] tablero = new int[8,8];
        public Form1()
        {
            InitializeComponent();
            iniciaTablero();

            picTile.Size = new Size(cCellSize, cCellSize);

            //picBoard.MouseMove += PicBoard_MouseMove;
            picBoard.MouseClick += PicBoard_MouseClick;
            picBoard.Paint += PicBoard_Paint;
            CreateCells();

            boardLeft = picBoard.Location.X;
            boardTop = picBoard.Location.Y;
            cNull = new CellDetails();
            cNull.tipo = -3; //-3 indica que es null
            cNull.Dimension = new Rectangle();
            cNull.Location = new Point(-1, -1);
            cNull.ubicacion = -1;
        }
        private void PicBoard_Paint(object sender, PaintEventArgs e)
        {
            if (cells.Count > 0)
            {




                int fila = 0, columna = 0;

                for (int i = 0; i <= 63; i++)
                {
                    cells[i].Dimension.Height = 70;
                    cells[i].Dimension.Width = 70;
                    cells[i].ubicacion = i;
                    fila = i / 8;
                    columna = i % 8;

                    switch (tablero[columna, fila])
                    {
                        case -3:
                            e.Graphics.FillRectangle(cRB, cells[i].Dimension);
                            cells[i].tipo = -3;
                            cells[i].ubicacion = i;
                            break;
                        case -1:
                            e.Graphics.FillRectangle(cFB, cells[i].Dimension);
                            cells[i].tipo = -1;
                            break;
                        case 0:
                            e.Graphics.FillRectangle(cOscuro, cells[i].Dimension);
                            cells[i].tipo = 0;
                            break;
                        case 1:
                            e.Graphics.FillRectangle(cFN, cells[i].Dimension);
                            cells[i].tipo = 1;
                            break;
                        case 3:
                            e.Graphics.FillRectangle(cRN, cells[i].Dimension);
                            cells[i].tipo = 3;
                            break;
                        case 2:
                            e.Graphics.FillRectangle(cClaro, cells[i].Dimension);
                            cells[i].tipo = 2;
                            break;
                    }
                }
                /*cOscuro.Dispose();
                cClaro.Dispose();
                cFB.Dispose();
                cFN.Dispose();
                cRB.Dispose();
                cRN.Dispose();*/
            }
        }
        private void PicBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int nT;
            if (juego)
            {
                if (hooman)
                {
                    clickCount++;
                    CellDetails cell = FindCell(e);
                    if (cell != null && cell.Location.X > -1 && cell.Location.Y > -1)
                    {
                        if (((((cell.ubicacion / 8) % 2) != 0) && ((cell.ubicacion % 8) % 2 == 0)) || (((cell.ubicacion / 8) % 2 == 0) && ((cell.ubicacion % 8) % 2 != 0)))
                        {
                            if (clickCount % 2 != 0) //Primer clic del movimiento (elección de ficha a mover)
                            {
                                //picTile.Location = new Point(cell.Dimension.X + boardLeft, cell.Dimension.Y + boardTop);
                                //picTile.Visible = true;
                                inicio = cell;
                                //Console.WriteLine("Inicio " + inicio.Location.X + " " + inicio.Location.Y);
                            }
                            else //Segundo clic de movimiento (elección de a dónde se va a mover la ficha)
                            {
                                fin = cell;
                                //Console.Write("Fin " + fin.Location.X + " " + fin.Location.Y);

                                //encontrar posición en tablero
                                filaInicio = inicio.ubicacion / 8;
                                columnaInicio = inicio.ubicacion % 8;
                                filaFin = fin.ubicacion / 8;
                                columnaFin = fin.ubicacion % 8;
                                tipo = inicio.tipo;
                                // esta es la semi buena (funciona para movimientos simples -sin saltos) if (tablero[inicio.ubicacion % 8, inicio.ubicacion / 8] != 0 && tablero[fin.ubicacion % 8, fin.ubicacion / 8] == 0 && Math.Abs(distanciaX(inicio.ubicacion % 8, fin.ubicacion % 8)) == 1 && Math.Abs(distanciaY(inicio.ubicacion / 8, fin.ubicacion / 8)) == 1)
                                // segundo intento if (tablero[columnaInicio, filaInicio] != 0 && tablero[columnaFin, filaFin] == 0 /*&& distancia(columnaInicio,filaInicio,columnaFin,filaFin) == 1*/)
                                /*if(tablero[fin.ubicacion % 8,fin.ubicacion / 8] == 0 && ( (Math.Abs(distancia(inicio.ubicacion % 8, fin.ubicacion % 8)) == 1 && Math.Abs(distancia(inicio.ubicacion/8,fin.ubicacion/8)) == 1) 
                                    || (distancia(inicio.ubicacion%8,fin.ubicacion%8) == 2 && distancia(inicio.ubicacion/8,fin.ubicacion/8) == 2 && tablero[inicio.ubicacion%8 + 1, inicio.ubicacion/8 + 1] != 0) 
                                    || (distancia(inicio.ubicacion % 8, fin.ubicacion % 8) == -2 && distancia(inicio.ubicacion / 8, fin.ubicacion / 8) == -2 && tablero[inicio.ubicacion % 8 - 1, inicio.ubicacion / 8 - 1] != 0)
                                    || (distancia(inicio.ubicacion % 8, fin.ubicacion % 8) == 2 && distancia(inicio.ubicacion / 8, fin.ubicacion / 8) == -2 && tablero[inicio.ubicacion % 8 + 1, inicio.ubicacion / 8 - 1] != 0)
                                    || (distancia(inicio.ubicacion % 8, fin.ubicacion % 8) == -2 && distancia(inicio.ubicacion / 8, fin.ubicacion / 8) == 2 && tablero[inicio.ubicacion % 8 - 1, inicio.ubicacion / 8 + 1] != 0)
                                    ))*/
                                if (tablero[columnaInicio,filaInicio] < 0 && tablero[columnaFin, filaFin] == 0 && ((Math.Abs(distancia(columnaInicio, columnaFin)) == 1 && Math.Abs(distancia(filaInicio, filaFin)) == 1)
                                    || (distancia(columnaInicio, columnaFin) == 2 && distancia(filaInicio, filaFin) == 2 && tablero[columnaInicio + 1, filaInicio + 1] > 0) //Abajo derecha
                                    || (distancia(columnaInicio, columnaFin) == -2 && distancia(filaInicio, filaFin) == -2 && tablero[columnaInicio - 1, filaInicio - 1] > 0) //Arriba izquierda
                                    || (distancia(columnaInicio, columnaFin) == 2 && distancia(filaInicio, filaFin) == -2 && tablero[columnaInicio + 1, filaInicio - 1] > 0) //Arriba derecha
                                    || (distancia(columnaInicio, columnaFin) == -2 && distancia(filaInicio, filaFin) == 2 && tablero[columnaInicio - 1, filaInicio + 1] > 0) //Abajo izquierda
                                    ))
                                {
                                    //intercambia imgs
                                    auxtipo = inicio.tipo;
                                    inicio.tipo = fin.tipo;
                                    fin.tipo = auxtipo;
                                    tablero[inicio.ubicacion % 8, inicio.ubicacion / 8] = inicio.tipo;

                                    if (fin.Location.Y  == 0)
                                        tablero[fin.ubicacion % 8, fin.ubicacion / 8] = -3;
                                    else tablero[fin.ubicacion % 8, fin.ubicacion / 8] = fin.tipo;
                                    switch (distancia(columnaInicio, columnaFin))
                                    {
                                        case 2:
                                            if (distancia(filaInicio, filaFin) == 2)
                                                tablero[columnaInicio + 1, filaInicio + 1] = 0;
                                            else //distancia(filaInicio, filaFin) == -2
                                                tablero[columnaInicio + 1, filaInicio - 1] = 0;
                                            break;
                                        case -2:
                                            if (distancia(filaInicio, filaFin) == -2)
                                                tablero[columnaInicio - 1, filaInicio - 1] = 0;
                                            else //distancia(filaInicio, filaFin) == -2
                                                tablero[columnaInicio - 1, filaInicio + 1] = 0;
                                            break;
                                    }
                                    Console.WriteLine("Tipo Inicio: " + inicio.tipo + "\nTipo fin: " + fin.tipo);
                                    this.Refresh();
                                    hooman = false;
                                    lblDetails.Text = "Es mi turno, déjame pensar un poco";

                                    juega();
                                    lblDetails.Text = "Es tu turno";
                                    hooman = true;
                                }
                                else
                                {
                                    Console.WriteLine("Movimiento no válido");
                                    MessageBox.Show("Movimiento no válido", "Error", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
                else MessageBox.Show("Aún no es tu turno, espera un poco :3", "Un momento...", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Selecciona la dificultad y haz clic en ¡Jugar!", "Error", MessageBoxButtons.OK);
        }


        public void juega()
        {
            //Actualliza el tablero para dárselo a lisp
            diagonales();
            cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            //for (System.Int64 i = 0;i<99;i++) { int x = 4 * 5; }
            cmd.Start();

            cmd.StandardInput.WriteLine("clisp");
            cmd.StandardInput.WriteLine("(load " + '"' + "alfabeta.lsp" + '"' + ")");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            cmd.Close();

            //Actualiza el tablero ya que lisp movió
            actualizaTab();
            diagonales();
        }

        public void diagonales()
        {
            int k = 0, celda;
            StringBuilder s = new StringBuilder(depth + "\n(");
            //Genera tablero en cadena (sólo cuadros café)
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    celda = tablero[n, m];
                    if (celda != 2)
                    {
                        s.Append("(" + k + " . " + celda + ")");
                        k++;
                    }
                    /*if (k != 32)
                        s.Append(" ");*/
                }
            }
            s.Append(")");
            Console.WriteLine("s: " + s.ToString());
            File.WriteAllText(@".\data\in.txt", s.ToString());
        }

        public void actualizaTab()
        {
            StreamReader sr = new StreamReader(@".\data\out.txt");
            int aux, iInicio, iFin, nTipo;
            StringBuilder i = new StringBuilder();
            sr.Read(); //quita primer paréntesis
            //Lee iInicio
            i.Append((char)sr.Read());//lee el primer número
            if (sr.Peek() >= 48 && sr.Peek() <= 57) //si es de dos dígitos, lee el segundo
            {
                i.Append((char)sr.Read());
                Console.WriteLine(i.ToString());
            }
                    iInicio = int.Parse(i.ToString()); //convierto índice a int
                i.Remove(0, i.Length); // Se limpia i

            while (!(sr.Peek() >= 48 && sr.Peek() <= 57)) {
                //Console.WriteLine("Quité espacio algo: " + (char)sr.Read());//quita espacio
                sr.Read();
            }
            //Console.WriteLine("Quité punto" + (char)sr.Read());//quita punto
            //Console.WriteLine("Quité espacio 2:"+(char)sr.Read());//quita espacio
            i.Append((char)sr.Read());//lee el primer número
            //lee iFin
            if (sr.Peek() >= 48 && sr.Peek() <= 57) //si es de dos dígitos, lee el segundo
            {
                i.Append((char)sr.Read());
                Console.WriteLine("primer índice" + i.ToString());
            }
            iFin = int.Parse(i.ToString()); //convierto índice a int
            i.Remove(0, i.Length); // Se limpia i
            sr.Close();
            Console.WriteLine("iInicio: " + iInicio);
            Console.WriteLine("iFin: " + iFin);
            if ((iInicio / 4) % 2 == 0)
                iInicio = iInicio * 2 +1 ;
            else
                iInicio = iInicio * 2;
            if ((iFin / 4) % 2 == 0)
                iFin = iFin * 2 + 1;
            else
                iFin = iFin * 2;
            Console.WriteLine("iInicio: " + iInicio);
            Console.WriteLine("iFin: " + iFin);

            aux = tablero[iInicio % 8, iInicio / 8];
            tablero[iInicio % 8, iInicio / 8] = tablero[iFin % 8,iFin / 8];
            if (iFin / 8 == 7) 
                tablero[iFin % 8, iFin / 8] = 3;
            else tablero[iFin % 8, iFin / 8] = aux;
            Console.WriteLine("Tab en inicio " + tablero[iInicio % 8, iInicio / 8]);
            Console.WriteLine("Tab en fin " + tablero[iFin % 8, iFin / 8]);

            

                switch (distancia(iInicio % 8, iFin % 8))
            {
                case 2:
                    if (distancia(iInicio/8, iFin/8) == 2) 
                        tablero[iInicio%8 + 1, iInicio/8 + 1] = 0;
                    else //distancia(filaInicio, filaFin) == -2
                        tablero[iInicio%8 + 1, iInicio/8 - 1] = 0;
                    break;
                case -2:
                    if (distancia(iInicio/8, iFin/8) == -2)
                        tablero[iInicio%8 - 1, iInicio/8 - 1] = 0;
                    else //distancia(filaInicio, filaFin) == -2
                        tablero[iInicio%8 - 1, iInicio/8 + 1] = 0;
                    break;
            }

            imprimeTablero();
            this.Refresh();
        }
    




public void imprimeTablero()
        {
            Console.WriteLine("Nuevo tablero");
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    Console.Write(tablero[n, m]);
                }
                Console.WriteLine(" ");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            depth = 1;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (btnJugar.Text=="¡Jugar!") {
                groupBox1.Enabled = false;
                //bnNuevo.Enabled = true;
                //btnJugar.Enabled = false;
                btnJugar.Text = "Nueva partida";
                juego = true;
                //this.Refresh();
                lblDetails.Text = "Es tu turno";
            }
            else
            {
                juego = false;
                iniciaTablero();
                this.Refresh();
                diagonales(); //Reinicia tablero para lisp
                groupBox1.Enabled = true;
                //bnNuevo.Enabled = false;
                btnJugar.Text = "¡Jugar!";
                hooman = true;
                clickCount = 0;
            }
        }

        private void rBMedio_CheckedChanged(object sender, EventArgs e)
        {
            depth = 8;
        }

        private void rBDificil_CheckedChanged(object sender, EventArgs e)
        {
            depth = 9;
        }

        public int distancia(int xyi, int xyf)
        {
            return xyf - xyi;
        }

        /*public int distanciaY(int yi, int yf)
        {
            return yf - yi;
        }*/

        public int ocupado(int xi, int yi)
        {
            return tablero[xi, yi];
        }

        public Boolean desocupado(int xf, int yf)
        {
            return tablero[xf, yf] == 0;
        }
      
        private CellDetails FindCell(MouseEventArgs e)
        {
            CellDetails ret = null;
            foreach (CellDetails cell in cells)
            {
                if (cell.Dimension.Contains(e.Location))
                {
                    ret = cell;
                    break;
                }
            }
            return ret;
        }
        private void CreateCells()
        {
            CellDetails cell;
            Point cellLoc;
            //int rows = (picBoard.ClientSize.Height / cCellSize);
            //int cols = (picBoard.ClientSize.Width / cCellSize);
            int rows = 8, cols = 8, y = 0, x = 0;

            // Loop through the rows
            for (int row = 0; row < rows; row++)
            {
                // Loop through the columns
                for (int col = 0; col < cols; col++)
                {
                    cell = new CellDetails();
                    cellLoc = new Point();
                    x = col * cCellSize;
                    y = row * cCellSize;
                    //cellLoc.Y = row + 1;
                    //cellLoc.X = col + 1;
                    cellLoc.X = x;
                    cellLoc.Y = y;
                    cell.Location = cellLoc;
                    //cell.Dimension = new Rectangle(col * cCellSize, row * cCellSize, cCellSize, cCellSize);
                    cell.Dimension = new Rectangle(x, y, cCellSize, cCellSize);
                    cells.Add(cell);
                }
            }
            //lblDetails.Text = String.Format("Generated {0} cells.", cells.Count);
        }
    }

    public class CellDetails
    {
        public CellDetails() { }
        public void imprimir()
        {
            Console.WriteLine( "--Información de celda\nTipo: " + this.tipo + "\nUbicación: " + this.ubicacion + "\nLocation: " + this.Location.ToString() + "\n--fin Información celda");
        }
        //public Rectangle Dimension { get; set; }        
        public Point Location { get; set; }
        public Rectangle Dimension = new Rectangle(0, 0, 70, 70);
        public int tipo, ubicacion;       
    }

    
}
