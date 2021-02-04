using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI {
public class ConsoleInputController {
    public class Keybind {
        public ConsoleKey key { get; }
        public Action action { get; }

        public Keybind(ConsoleKey key, Action action) {
            this.key = key;
            this.action = action;
        }
    }
    
    public ConsoleKey key { get; private set; }

    private List<Keybind> keybinds { get; }

    public ConsoleInputController() {
        keybinds = new List<Keybind>();
    }
    
    public void AddKeybind(ConsoleKey keyToAdd, Action action) {
        keybinds.Add(new Keybind(keyToAdd, action));
    }

    //TODO: Inefficient function. Fix when you learn better LINQ
    public void Run() {
        FlushInput();
        
        do {
            key = Console.ReadKey(true).Key;
        } while (!keybinds.Select(keybind => keybind.key).Contains(key));

        foreach (Keybind keybind in keybinds.Where(keybind => keybind.key == key)) {
            keybind.action.Invoke();
        }
    }

    private static void FlushInput() {
        while (Console.KeyAvailable) {
            Console.ReadKey(true);
        }
    }
}
}
