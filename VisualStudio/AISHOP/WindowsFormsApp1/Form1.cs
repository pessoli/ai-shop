using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string originalFilePath = @"C:\config.json";

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                string selectedFileName = Path.GetFileName(selectedFilePath);

                if (File.Exists(originalFilePath))
                {
                    try
                    {
                        string content = File.ReadAllText(originalFilePath);

                        JObject jsonObject = JObject.Parse(content);

                        jsonObject["video_path"] = selectedFilePath;

                        File.WriteAllText(originalFilePath, jsonObject.ToString());
                    }
                    catch (JsonReaderException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Not allowed to choose a file, open as adm.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("writing error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error processing:  " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Arquivo original não encontrado.");
                }
            }
        }
    }
}
