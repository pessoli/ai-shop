using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String filePath = @"C:\Users\luk\Desktop\ai pattern\config.json";

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);

                MessageBox.Show("Arquivo selecionado: " + fileName);
            }

            if (File.Exists(filePath))
            {
                // Lendo o conteúdo do arquivo
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Conteúdo do arquivo:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }

        }
    }
}
