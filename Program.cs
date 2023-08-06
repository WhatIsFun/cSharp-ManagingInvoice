namespace cSharp_Managing_Invoices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("      Welcome To    ");
            Console.WriteLine(" +-+-+-+-+-+-+-+-+-+\r\n |W|h|a|t|I|s|F|u|n|\r\n +-+-+-+-+-+-+-+-+-+");
            Console.WriteLine("  Managing Invoices  \n");

            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
        }
    }
}