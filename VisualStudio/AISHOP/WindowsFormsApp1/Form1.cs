using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;

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
        string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
        String videoPath = "";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string content = File.ReadAllText(originalFilePath);

                JObject jsonObject = JObject.Parse(content);

                jsonObject["video_path"] = textBox1.Text;

                File.WriteAllText(originalFilePath, jsonObject.ToString());

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath);
                    using (Process process = Process.Start(startInfo))
                    {
                        if (process != null)
                        {
                            process.WaitForExit();

                            content = File.ReadAllText(originalFilePath);

                            jsonObject = JObject.Parse(content);

                            string video_path = (string)jsonObject["video_path"];
                            int personFound = (int)jsonObject["dudes_visible"];
                            Console.WriteLine(personFound);
                            DateTimeOffset time = DateTimeOffset.Now;
                            DateTime timestamp = time.UtcDateTime;  //converts to UTC timestamp, commonly used in brazil
                            connectAndInsert(video_path, personFound, timestamp);
                            Console.WriteLine("O script Python terminou de ser executado.");
                        }
                    }
                }
                catch (Exception ex)
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

        public void connectAndInsert(String fileName, int personFound, DateTime timestamp)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão com o banco de dados estabelecida!");

                    string sql = "INSERT INTO video (video_path, max_people, recording_time) VALUES (@valor1, @valor2, @valor3)";

                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        // Adicionar parâmetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("valor1", fileName);
                        cmd.Parameters.AddWithValue("valor2", personFound);
                        cmd.Parameters.AddWithValue("valor3", timestamp);

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                string selectedFileName = Path.GetFileName(selectedFilePath);

                if (File.Exists(originalFilePath))
                {
                    videoPath = selectedFilePath;
                    Console.WriteLine(videoPath);
                    textBox1.Text = videoPath;
                }
            }
        }
    }
}


