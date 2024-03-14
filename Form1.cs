using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editorTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("texto.txt"))
            {
                Stream entrada = File.Open("texto.txt", FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);
                //string linha = leitor.ReadLine();
                //while (linha != null)
                //{
                //    textoConteudo.Text += linha;
                //    linha = leitor.ReadLine();
                //}
                textoConteudo.Text = leitor.ReadToEnd();
                leitor.Close();
                entrada.Close();
            }
        }

        //private void botaoGrava_Click(object sender, EventArgs e)
        //{
        //    Stream saida = File.Open("texto.txt", FileMode.Create);
        //    StreamWriter escritor = new StreamWriter(saida);
        //    escritor.Write(textoConteudo.Text);
        //    escritor.Close();
        //    saida.Close();
        //}

        private void botaoGrava_Click(object sender, EventArgs e)
        {
            using (Stream saida = File.Open("texto.txt", FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(saida))
            {
                escritor.Write(textoConteudo.Text);
            }
        }
    }
}
