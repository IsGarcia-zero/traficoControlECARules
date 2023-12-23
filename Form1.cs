using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;

namespace traficoControlECARules
{
    public partial class Form1 : Form
    {
        private int longitud = 20;
        private int longitudPixel = 40;
        private bool dibujar = false;
        private int[,] matriz;
        private Int64 generacion = 0;
        private static Color colorVida = Color.Black;
        private static Color colorFondo = Color.White;
        private Boolean[] reglaComponentes;
        private string ecaRule184Columna10;
        private string ecaRule184Columna11;
        private string ecaRule184Fila10;
        private string ecaRule184Fila11;
        private int porcentaje = 50;
        private int porcentajeCarril = 5;
        private int porcentajeVuelta = 15;
        private bool caminoLibre = true;
        public Form1()
        {
            InitializeComponent();
            matriz = new int[longitud, longitud];
            timer2.Enabled = true;
            timer2.Interval = 100;
        }

        private void pintarMatriz()
        {
            Bitmap bmp = new Bitmap(800, 800);
            for (int x = 0; x < longitud; x++)
            {
                for (int y = 0; y < longitud; y++)
                {
                    if (matriz[x, y] == 0)
                    {
                        pintarPixel(bmp, x, y, colorFondo);
                    }
                    else
                    {
                        pintarPixel(bmp, x, y, colorVida);
                    }
                }
            }
            //pintar la interseccion siosi
            if (generacion != 0)
            {
                if (ecaRule184Columna10[10] == '1' || ecaRule184Fila10[10] =='1')
                {
                    pintarPixel(bmp, 10, 10, colorVida);
                }

                if (ecaRule184Columna10[11] == '1' || ecaRule184Fila11[10] == '1')
                {
                    pintarPixel(bmp, 10, 11, colorVida);
                }

                if (ecaRule184Columna11[10] == '1' || ecaRule184Fila10[11] == '1')
                {
                    pintarPixel(bmp, 11, 10, colorVida);
                }

                if (ecaRule184Columna11[11] == '1' || ecaRule184Fila11[11] == '1')
                {
                    pintarPixel(bmp, 11, 11, colorVida);
                }
            }

            pictureBox1.Image = bmp;

        }

        private void pintarPixel(Bitmap bmp, int x, int y, Color color)
        {
            for (int i = 0; i < longitudPixel; i++)
            {
                for (int j = 0; j < longitudPixel; j++)
                {
                    bmp.SetPixel(i + (x * longitudPixel), j + (y * longitudPixel), color);
                }
            }
        }

        private void iniciarBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pintarMatriz();
        }

        private void pausaBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (generacion == 0)
            {
                string columna10 = extraerColumna(10);
                string fila10 = extraerFila(10);
                string columna11 = extraerColumna(11);
                string fila11 = extraerFila(11);

                ecaRule184Columna10 = ecaRule184(columna10);
                ecaRule184Columna11 = ecaRule184(columna11);
                ecaRule184Fila10 = ecaRule184(fila10);
                ecaRule184Fila11 = ecaRule184(fila11);


                asignarColumna(10, ecaRule184Columna10);
                asignarColumna(11, ecaRule184Columna11);
                asignarFila(10, ecaRule184Fila10);
                asignarFila(11, ecaRule184Fila11);
            }
            else
            {
                if (probabilidadVuelta())
                {
                    Random r = new Random();


                    if (ecaRule184Columna11[9] == '1')
                    {
                        if (ecaRule184Fila10[10] == '0')
                        {
                            StringBuilder sd = new StringBuilder(ecaRule184Columna11);
                            sd[9] = '0';
                            ecaRule184Columna11 = sd.ToString();
                            StringBuilder sb = new StringBuilder(ecaRule184Fila10);
                            sb[10] = '1';
                            ecaRule184Fila10 = sb.ToString();
                        }
                    }

                    if (ecaRule184Fila11[9] == '1')
                    {
                        if (ecaRule184Columna10[10] == '0')
                        {
                            StringBuilder sd = new StringBuilder(ecaRule184Fila11);
                            sd[9] = '0';
                            ecaRule184Fila11 = sd.ToString();
                            StringBuilder sb = new StringBuilder(ecaRule184Columna10);
                            sb[10] = '1';
                            ecaRule184Columna10 = sb.ToString();
                        }
                    }

                }

                if (probabilidadCarril())
                {

                    for (int f = 0; f < ecaRule184Columna11.Length; f++)
                    {
                        Random r = new Random();
                        int numero = r.Next(1, 5);
                        if (numero == 1)
                        {
                            if (ecaRule184Columna11[f] == '1' && ecaRule184Columna10[f] == '0')
                            {
                                StringBuilder sd = new StringBuilder(ecaRule184Columna11);
                                sd[f] = '0';
                                ecaRule184Columna11 = sd.ToString();
                                StringBuilder sb = new StringBuilder(ecaRule184Columna10);
                                sb[f] = '1';
                                ecaRule184Columna10 = sb.ToString();
                            }
                        }
                        else if (numero == 2)
                        {
                            if (ecaRule184Columna10[f] == '1' && ecaRule184Columna11[f] == '0')
                            {
                                StringBuilder sd = new StringBuilder(ecaRule184Columna10);
                                sd[f] = '0';
                                ecaRule184Columna10 = sd.ToString();
                                StringBuilder sb = new StringBuilder(ecaRule184Columna11);
                                sb[f] = '1';
                                ecaRule184Columna11 = sb.ToString();
                            }
                        }
                        else if (numero == 3)
                        {
                            if (ecaRule184Fila11[f] == '1' && ecaRule184Fila10[f] == '0')
                            {
                                StringBuilder sd = new StringBuilder(ecaRule184Fila11);
                                sd[f] = '0';
                                ecaRule184Fila11 = sd.ToString();
                                StringBuilder sb = new StringBuilder(ecaRule184Fila10);
                                sb[f] = '1';
                                ecaRule184Fila10 = sb.ToString();
                            }
                        }
                        else if (numero == 4)
                        {
                            if (ecaRule184Fila10[f] == '1' && ecaRule184Fila11[f] == '0')
                            {
                                StringBuilder sd = new StringBuilder(ecaRule184Fila10);
                                sd[f] = '0';
                                ecaRule184Fila10 = sd.ToString();
                                StringBuilder sb = new StringBuilder(ecaRule184Fila11);
                                sb[f] = '1';
                                ecaRule184Fila11 = sb.ToString();
                            }
                        }
                    }

                }

                if (ecaRule184Fila10[9] == '1' && ecaRule184Columna10[10] == '1')
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }if (ecaRule184Columna10[9] == '1' && ecaRule184Fila10[10] == '1')
                {
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }if (ecaRule184Fila11[9] == '1' && ecaRule184Columna10[11] == '1')
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }if (ecaRule184Columna10[10] =='1' && ecaRule184Fila11[10] == '1')
                {
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }

                if (ecaRule184Fila10[10] == '1' && ecaRule184Columna11[10] == '1')
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }

                if (ecaRule184Columna11[9] == '1' && ecaRule184Fila10[11] == '1')
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }

                if (ecaRule184Fila11[10] == '1' && ecaRule184Columna11[11] == '1')
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }

                if (ecaRule184Columna11[10] == '1' && ecaRule184Fila11[11] == '1')
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                    caminoLibre = false;
                }
                if (caminoLibre || comprovacion())
                {
                    ecaRule184Columna10 = ecaRule184(ecaRule184Columna10);
                    ecaRule184Columna11 = ecaRule184(ecaRule184Columna11);
                    ecaRule184Fila10 = ecaRule184(ecaRule184Fila10);
                    ecaRule184Fila11 = ecaRule184(ecaRule184Fila11);

                    asignarColumna(10, ecaRule184Columna10);
                    asignarColumna(11, ecaRule184Columna11);
                    asignarFila(10, ecaRule184Fila10);
                    asignarFila(11, ecaRule184Fila11);
                }
            }
            label1.Text = $"C10: {ecaRule184Columna10.Count(c => c == '1')}";
            label2.Text = $"C11: {ecaRule184Columna11.Count(c => c == '1')}";
            label3.Text = $"F10: {ecaRule184Fila10.Count(c => c == '1')}";
            label4.Text = $"F11: {ecaRule184Fila11.Count(c => c == '1')}";
            label8.Text = $"Generacion: {generacion}";
            generacion++;
            pintarMatriz();
        }

        private bool comprovacion()
        {
            if (ecaRule184Columna11[9] == '1' && ecaRule184Columna10[10] == '1')
            {
                return false;
            }
            else if (ecaRule184Columna10[9] == '1' && ecaRule184Fila10[10] == '1')
            {
                return false;
            }
            else if (ecaRule184Fila11[9] == '1' && ecaRule184Columna10[11] == '1')
            {
                return false;
            }
            else if (ecaRule184Columna10[10] == '1' && ecaRule184Fila11[10] == '1')
            {
                return false;
            }
            else if (ecaRule184Fila10[10] == '1' && ecaRule184Columna11[10] == '1')
            {
                return false;
            }
            else if (ecaRule184Columna11[9] == '1' && ecaRule184Fila10[11] == '1')
            {
                return false;
            }
            else if (ecaRule184Fila11[10] == '1' && ecaRule184Columna11[11] == '1')
            {
                return false;
            }
            else if (ecaRule184Columna11[10] == '1' && ecaRule184Fila11[11] == '1')
            {
                return false;
            }
            else
            {
                caminoLibre = true;
                return true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dibujar = true;
            int x = e.X / longitudPixel;
            int y = e.Y / longitudPixel;
            if ((x == 10 || x == 11) || (y == 10 || y == 11))
            {
                matriz[x, y] = matriz[x, y] == 1 ? 0 : 1;
                pintarMatriz();
            }
        }

        private bool probabilidadVuelta()
        {
            Random r = new Random();
            int numero = r.Next(1, 101);
            if (numero <= porcentajeVuelta)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool probabilidadCarril()
        {
            int eC10 = ecaRule184Columna10.Count(c => c == '1');
            int eC11 = ecaRule184Columna11.Count(c => c == '1');
            int eF10 = ecaRule184Fila10.Count(c => c == '1');
            int eF11 = ecaRule184Fila11.Count(c => c == '1');
            Random r = new Random();
            int numero = r.Next(1, 101);
            if (eC10 >= 13 || eC11 >= 13 || eF10 >= 13 || eF11 >= 13)
            {
                if (numero <= 60)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (numero <= porcentajeCarril)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private void asignarFila(int fila, string cadena)
        {
            char[] cadenaMala = cadena.ToCharArray();
            for (int i = 0; i < cadenaMala.Length; i++)
            {
                matriz[i, fila] = cadenaMala[i] == '1' ? 1 : 0;
            }
        }

        private void asignarColumna(int columna, string cadena)
        {
            char[] cadenaMala = cadena.ToCharArray();
            for (int i = 0; i < cadenaMala.Length; i++)
            {
                matriz[columna, i] = cadenaMala[i] == '1' ? 1 : 0;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dibujar = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujar)
            {
                int x = e.X / longitudPixel;
                int y = e.Y / longitudPixel;
                if ((x == 10 || x == 11) || (y == 10 || y == 11))
                {
                    matriz[x, y] = matriz[x, y] == 1 ? 0 : 1;
                    pintarMatriz();
                }
            }
        }

        private string extraerColumna(int columnaa)
        {
            string columna = "";
            for (int i = 0; i < longitud; i++)
            {
                columna += matriz[columnaa, i].ToString();
            }
            return columna;
        }

        private string extraerFila(int fila)
        {
            string columna = "";
            for (int i = 0; i < longitud; i++)
            {
                columna += matriz[i, fila].ToString();
            }
            return columna;
        }

        private string ecaRule184(string cadenaAProcesar)
        {
            String reglaConvertida = Convert.ToString(184, 2).Trim();
            int mayo = 8;
            if (reglaConvertida.Length < mayo)
            {
                int faltante = mayo - reglaConvertida.Length;
                for (int i = 0; i < faltante; i++)
                {
                    reglaConvertida = "0" + reglaConvertida;
                }
            }

            Boolean[] componentes = new Boolean[reglaConvertida.Length];
            char[] reverso = reglaConvertida.ToCharArray();
            Array.Reverse(reverso);
            for (int i = 0; i < reglaConvertida.Length; i++)
            {
                if (reverso[i] == '1')
                {
                    componentes[i] = true;
                }
                else
                {
                    componentes[i] = false;
                }
            }
            reglaComponentes = componentes;
            char[] cadenaMala = cadenaAProcesar.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < cadenaMala.Length; j++)
            {
                var sd = new StringBuilder();
                if (j == 0)
                {
                    sd.Append((cadenaMala[cadenaMala.Length - 1]).ToString());
                    sd.Append(cadenaMala[j].ToString());
                    sd.Append(cadenaMala[j + 1].ToString());

                    sb.Append(union(sd.ToString()));
                }
                else if (j == cadenaMala.Length - 1)
                {
                    sd.Append(cadenaMala[j - 1].ToString());
                    sd.Append(cadenaMala[j].ToString());
                    sd.Append(cadenaMala[0].ToString());

                    sb.Append(union(sd.ToString()));
                }
                else
                {
                    sd.Append(cadenaMala[j - 1].ToString());
                    sd.Append(cadenaMala[j].ToString());
                    sd.Append(cadenaMala[j + 1].ToString());

                    sb.Append(union(sd.ToString()));
                }
            }
            return sb.ToString();
        }
        private String union(String sd2)
        {
            int conv = Convert.ToInt32(sd2, 2);
            return reglaComponentes[conv] ? "1" : "0";
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            generacion = 0;
            for (int x = 0; x < longitud; x++)
            {
                for (int y = 0; y < longitud; y++)
                {
                    matriz[x, y] = 0;
                }
            }
            pintarMatriz();
        }

        private void randomLlenar_Click(object sender, EventArgs e)
        {
            llenarRandom();
        }

        private void llenarRandom()
        {
            Random rnd = new Random();
            int[] filasColumnasEspecificas = { 10, 11 };

            foreach (int fila in filasColumnasEspecificas)
            {
                if (fila < matriz.GetLength(0))
                {
                    for (int col = 0; col < matriz.GetLength(1); col++)
                    {
                        matriz[fila, col] = rnd.Next(100) < porcentaje ? 1 : 0;
                    }
                }
            }

            foreach (int col in filasColumnasEspecificas)
            {
                if (col < matriz.GetLength(1))
                {
                    for (int fila = 0; fila < matriz.GetLength(0); fila++)
                    {

                        if (fila != 10 && fila != 11)
                        {
                            matriz[fila, col] = rnd.Next(100) < porcentaje ? 1 : 0;
                        }
                    }
                }
            }
            pintarMatriz();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int valor = hScrollBar1.Value;
            porcentaje = valor;
            label5.Text = $"Porcentaje: {valor}%";
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            int valor = hScrollBar3.Value;
            porcentajeCarril = valor;
            label7.Text = $"Porcentaje Cambio Carril: {valor}%";
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            int valor = hScrollBar2.Value;
            porcentajeVuelta = valor;
            label6.Text = $"Porcentaje Vuelta: {valor}%";
        }
    }
}
