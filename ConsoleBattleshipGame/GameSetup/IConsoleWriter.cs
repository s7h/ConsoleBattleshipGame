using ConsoleBattlefield.Models;
using System;

namespace ConsoleBattlefield.GameSetup
{
    public interface IConsoleWriter
    {
        void PrintLine(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = ConsoleColor.Black);
        void PrintAvatar(string avatar);
        MissileCoordinates ReadCoordinates();
        void ClearScreen();
    }
}
