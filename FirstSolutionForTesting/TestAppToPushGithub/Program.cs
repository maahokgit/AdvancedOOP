using System;

namespace TestAppToPushGithub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the console!");

            ConsoleKeyInfo myFavoriteKey = Console.ReadKey(true);

            Console.WriteLine("My fav key is " + myFavoriteKey.Key);

            Console.ReadKey();
        }
    }
}
