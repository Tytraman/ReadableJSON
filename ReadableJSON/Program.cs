using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace ReadableJSON {
    class Program {

        [STAThread]
        static void Main(string[] args) {
            Console.WriteLine("Choisissez le fichier JSON à lire...");

            OpenFileDialog dialog = new OpenFileDialog {
                Title = "Sélectionner JSON",
                Filter = "Fichiers JSON (*.json)|*.json",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if(dialog.ShowDialog() == DialogResult.OK) {
                string file = File.ReadAllText(dialog.FileName);
                dynamic json = JsonConvert.DeserializeObject(file);
                string result = JsonConvert.SerializeObject(json, Formatting.Indented);
                Console.WriteLine("Sélectionner emplacement de sauvegarde...");
                SaveFileDialog saver = new SaveFileDialog {
                    Title = "Séctionner emplacement de sauvegarde",
                    Filter = "Fichiers JSON (*.json)|*.json",
                    DefaultExt = "json",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };
                if(saver.ShowDialog() == DialogResult.OK) {
                    File.WriteAllText(saver.FileName, result);
                    Console.WriteLine("Fichier enregistré avec succès!\nAppuyez sur une entrée pour quitter...");
                    Console.ReadLine();
                }else {
                    Environment.Exit(1);
                }
            } else {
                Environment.Exit(0);
            }
        }
    }
}
