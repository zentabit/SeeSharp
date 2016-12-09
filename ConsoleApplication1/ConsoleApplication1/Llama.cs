using System;

namespace ConsoleApplication1 {
    public class Llama
    {
        string name;
        public Llama(string Name)
        {
            name = Name;
        }
        public void PrintName()
        {
            Console.Write("I am a llama. My name is " + name + ".");
        }
    }
}

