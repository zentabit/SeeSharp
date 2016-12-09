using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the llama creator! Please enter your llama's name: ");
            Llama myLlama = new Llama(Console.ReadLine());
            myLlama.PrintName();
            Console.ReadLine();
        }
    }
}
