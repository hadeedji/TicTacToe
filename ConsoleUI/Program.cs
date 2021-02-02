using System;

namespace ConsoleUI {
class Program {
    static void Main() {
        PlayersMenu menu = new PlayersMenu();
        var players = menu.GetPlayers();
        Console.WriteLine("Press enter to continue.");
        Console.ReadKey();
    }
}
}
