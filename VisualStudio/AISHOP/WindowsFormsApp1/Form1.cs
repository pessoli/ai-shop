using System;
using System.Diagnostics;
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

        string originalFilePath = @"C:\Users\luk\Desktop\ai-pattern\config.json";
        string pythonPath = @"C:\Users\luk\Desktop\ai-pattern\python/main.py";
        string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=shop";

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

                        try
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath);
                            using (Process process = Process.Start(startInfo))
                            {
                                if (process != null)
                                {
                                    process.WaitForExit();
                                    Console.WriteLine("O script Python terminou de ser executado.");
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    catch (JsonReaderException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Not allowed to choose a file, open as adm." + ex.ToString());
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
