using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            new Usuarios().Menu();
        }
    }
}
