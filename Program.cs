using iTextSharp.text;
using iTextSharp.text.pdf;

namespace cSharp_Managing_Invoices
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string password = "112233";
            int passTry = 5;
            while (true)
            {
                Console.Write("Please enter the password>> ");
                string pass = Console.ReadLine();
                if (pass == password)
                {
                    Console.WriteLine("      Welcome To    ");
                    Console.WriteLine(" +-+-+-+-+-+-+-+-+-+\r\n |W|h|a|t|I|s|F|u|n|\r\n +-+-+-+-+-+-+-+-+-+");
                    Console.WriteLine("  Managing Invoices  \n");

                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Menu();
                }
                else
                {

                    if (passTry == 0)
                    {
                        Console.WriteLine("All attempts are exhausted !!!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Failed Password");
                        Console.WriteLine($"You have {passTry} left. Be wise");
                        passTry--;
                    }
                }
            }  
        }
    }
}