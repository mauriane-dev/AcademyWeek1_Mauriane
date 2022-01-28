using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Week1.Spese.Factory.Entities;

namespace Week1.Spese.Factory.Files
{
    public class GestioneFile
    {
        const string readPath = @"C:\Users\m.ngueti.sontsa\Desktop\AcademyWeek1_Mauriane\Week1.Spese.ConsoleApp\Week1.Spese.Factory\Files\spese.txt";
        const string writePath = @"C:\Users\m.ngueti.sontsa\Desktop\AcademyWeek1_Mauriane\Week1.Spese.ConsoleApp\Week1.Spese.Factory\Files\spese_rimborsate.txt";
        public static List<Spesa> ReadFromFile()
        {
            List<Spesa> spese = new List<Spesa>();

            try
            {
                if (File.Exists(readPath))
                {
                    using (StreamReader sr = new StreamReader(readPath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string record = sr.ReadLine();
                            string[] parts = record.Split(";");

                            string stato = " ";

                            DateTime data = DateTime.Parse(parts[0]);
                            CategoriaEnum categoria = (CategoriaEnum)Enum.Parse(typeof(CategoriaEnum), parts[1]);
                            string descrizione = parts[2];
                            double importo = Convert.ToDouble(parts[3]);

                            var spesa = new Spesa()
                            {
                                Data = data,
                                Category = categoria,
                                Descrizione = descrizione,
                                Importo = importo,
                            };

                            spese.Add(spesa);

                        }

                        sr.Close();

                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
            finally
            {

            }

            return spese;

            //Console.Read();
        }

        public static void WriteToFile(Spesa s)
        {
            const string sep = ";";
            char choice;
            string record = "";
            string stato = "";
            double rimborso = 0.0;

            using (StreamWriter sw = new StreamWriter(writePath, true))
            {
                DateTime data = s.Data;
                CategoriaEnum categoria = s.Category;
                string descrizione = s.Descrizione;
                double importo = s.Importo;

                if (importo > 2500)
                {
                    stato = "Non Approvato";
                    rimborso = 0.0;
                }
                else
                {
                    stato = "Approvato";

                    if (categoria == CategoriaEnum.Viaggio)
                        rimborso = importo + 50;
                    else if (categoria == CategoriaEnum.Alloggio)
                        rimborso = importo;
                    else if (categoria == CategoriaEnum.Vitto)
                        rimborso = importo * 0.7;
                    else if (categoria == CategoriaEnum.Altro)
                        rimborso = importo * 0.1;
                    else
                        Console.WriteLine("Categoria non esistente");
                }
               
                record = data + sep + categoria + sep + descrizione + sep + stato + sep + rimborso;

                sw.WriteLine(record);

                sw.Close();

            }
        }

    }
}
