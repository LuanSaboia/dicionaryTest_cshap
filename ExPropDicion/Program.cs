using System;
using System.IO;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {

                    Dictionary<string, int> dictionary = new Dictionary<string, int>();

                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string nome = line[0];
                        int voto = int.Parse(line[1]);
                        dictionary[nome] = voto;

                        if (dictionary.ContainsKey(nome))
                        {
                            dictionary[nome] += voto;
                        } else dictionary[nome] = voto;
                    }
                    foreach (var item in dictionary)
                    {
                        Console.WriteLine(item.Key+ " " + item.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}