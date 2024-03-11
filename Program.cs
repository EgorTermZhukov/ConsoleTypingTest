using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTypingTest;


namespace ConsoleTypingTest
{

    class Program
    {
        static int Main()
        {
            Game game = new Game();

            game.SetupConsole();
            game.StartGame();

            return 0;
        }
    }
}