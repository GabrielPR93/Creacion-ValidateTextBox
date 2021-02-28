using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema5_Ejer5
{
    public partial class ValidateTextBox : UserControl
    {
        Color color = Color.Red;
        bool flagCadena = true;
        public ValidateTextBox()
        {
            InitializeComponent();
        }

        public enum etipo
        {
            NUMERICO,
            TEXTUAL
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Height = textBox1.Height + 20;
            textBox1.Width = this.Width - 20;
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush b = new SolidBrush(color);
            g.FillRectangle(b,5,5,this.Width-5,this.Height-5);

        }

        [Category("Varios")]
        [Description("Propiedad para acceder al text")]
        public string Text
        {
            set
            {
                textBox1.Text = value;
                this.Refresh();
            }
            get
            {
                return textBox1.Text;
            }
        }

        [Category("Varios")]
        [Description("Propiedad para acceder al Multiline")]
        public bool Multiline
        {
            set
            {
                textBox1.Multiline = value;
                this.Refresh();
            }
            get
            {
                return textBox1.Multiline;
            }
        }

        [Category("Varios")]
        [Description("Popiedad para Numérico o Textual")]
        private etipo tipo = etipo.TEXTUAL;

        public etipo Tipo
        {
            set
            {
                tipo = value;
                this.Refresh();
            }
            get
            {
                return tipo;
            }
        }

        public void compruebaCadena(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (tipo==etipo.TEXTUAL)
                {   //ASCII
                    //Letras Mayusculas del 65 al 90
                    //Letras Minusculas del 97 al 122
                    //Espacio el 32
                    // Retorno de carro la 13
                    if (cadena[i] >= 65 && cadena[i] <=90 || cadena[i]>=97 && cadena[i]<=122 || cadena[i]==32 ||cadena[i]==13)
                    {
                        if (flagCadena)
                        {
                            color = Color.Green;
                      
                        }
                    }
                    else
                    {
                        flagCadena = false;
                        color = Color.Red;
                    }
                }
                else
                {
                    //ASCII
                    // Numeros del 48 al 57
                    // Nueva linea el 10
                    if (cadena[i]>=48 && cadena[i]<=57 || cadena[i]==13 || cadena[i]==10)
                    {
                        if (flagCadena)
                        {
                            color = Color.Green;
                        }
                    }
                    else
                    {
                        flagCadena = false;
                        color = Color.Red;
                    }
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.OnTextChanged();
            flagCadena = true;
            compruebaCadena(textBox1.Text);
            Refresh();
        }
    }
}
