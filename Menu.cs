using System;
using System.Threading;
namespace Game14th
{
    public static class Menu
    {
        public static void Return()
        {
            Console.WriteLine("Press Enter to return to the menu");
            Console.ReadLine();
            for (var i = 5; i != 0; i--)
            {
                Console.WriteLine("Returning to menu in " + i);
                Thread.Sleep(1000);
            }
        }
    }
}