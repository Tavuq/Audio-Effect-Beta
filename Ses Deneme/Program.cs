using NAudio.Wave;
using System.ComponentModel.Design;

namespace Ses_Deneme
{
    public class Program
    {
        static void Main(string[] args)
        {
            AudioFileReader audio = null;
            float[] buffer = null;

            bool work = true;
            bool loaded = false;

            while (work)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("|--Audio Effect Menu--|" + "\r\n");

                if (!loaded)
                {
                    Console.WriteLine("Select File [Press 1]");
                }

                else if (loaded)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Select File [Press 1]");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Gain        [Press 2]");
                Console.WriteLine("Reverse     [Press 3]");
                Console.WriteLine("Save        [Press 4]");
                Console.WriteLine("Exit        [Press 0]");

                string choice = Console.ReadKey().KeyChar.ToString();

                switch (choice)
                {
                    case "1":

                        if (loaded)
                        {
                            break;
                        }

                        Console.Clear();
                        Console.Write("Enter The File Path: ");

                        string path = Console.ReadLine();

                        loaded = true;

                        audio = new AudioFileReader(path);
                        buffer = new float[(int)(audio.Length / 4)];
                        audio.Read(buffer, 0, buffer.Length);
                        
                        Console.WriteLine("\r\n" + "File Loaded" + "\r\n");
                        Console.WriteLine("Press Any Key To Return" +"\r\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":

                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    case "0":

                        return;
                }
            }
            Console.ReadLine();
        }
    }
}