using NAudio.Wave;
using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace Ses_Deneme
{
    public class Program
    {
        static void Main(string[] args)
        {
            AudioFileReader audio = null;
            float[] buffer = null;
            float gain;

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
                Console.WriteLine("Export      [Press 4]");
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
                        buffer = new float[(int)(audio.Length / sizeof(float))];
                        audio.Read(buffer, 0, buffer.Length);
                        
                        Console.WriteLine("\r\n" + "File Loaded" + "\r\n");
                        Console.WriteLine("Press Any Key To Return" +"\r\n");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case "2":

                        if (!loaded)
                        {
                            break;
                        }

                        Console.Clear();
                        Console.Write("Enter The Gain Value: ");

                        bool success = float.TryParse(Console.ReadLine(), out gain);

                        if (success && gain != 0)
                        {
                            for (int i = 0; i < buffer.Length; i++)
                            {
                                buffer[i] *= gain;
                            }
                            Console.WriteLine("\r\n" + "Gain Applied" + "\r\n");
                        }
                        else
                        {
                            Console.WriteLine("\r\n" + "Invalid Gain Value" + "\r\n");
                        }

                        Console.WriteLine("Press Any Key To Return" + "\r\n");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case "3":

                        if (!loaded)
                        {
                            break;
                        }

                        Console.Clear();
                        Array.Reverse(buffer);

                        Console.WriteLine("Audio Reversed" + "\r\n");
                        Console.WriteLine("Press Any Key To Return" + "\r\n");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case "4":

                        if (!loaded)
                        {
                            break;
                        }

                        Console.Clear();
                        Console.Write("Enter Output Path: ");

                        try
                        {
                            using (var write = new WaveFileWriter(Console.ReadLine(), audio.WaveFormat))
                            {
                                write.WriteSamples(buffer, 0, buffer.Length);
                            }
                            Console.WriteLine("\r\n" + "File Exported" + "\r\n");
                        }

                        catch (Exception)
                        {
                            Console.WriteLine("\r\n" + "Invalid Output Path" + "\r\n");
                        }
                        Console.WriteLine("Press Any Key To Return" + "\r\n");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case "0":

                        return;
                }
            }
            Console.ReadLine();
            //C:\Users\ozlem\Desktop\FL Studio Musics\This Is Awesome.mp3
        }
    }
}