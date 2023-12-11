using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Podaj ścieżkę do pliku: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            Console.WriteLine("Zawartość pliku:");
            DisplayFileContent(filePath);
        }
        else
        {
            Console.WriteLine("Plik nie istnieje. Tworzenie nowego pliku...");

            using (StreamWriter writer = File.CreateText(filePath))
            {
                Console.WriteLine("Wprowadzaj tekst (wpisz 'END;;' aby zakończyć):");
                string inputLine;

                do
                {
                    inputLine = Console.ReadLine();
                    if (inputLine != "END;;")
                    {
                        writer.WriteLine(inputLine);
                    }
                } while (inputLine != "END;;");
            }

            Console.WriteLine("Plik został zapisany.");
        }
    }

    static void DisplayFileContent(string filePath)
    {
        using (StreamReader reader = File.OpenText(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
