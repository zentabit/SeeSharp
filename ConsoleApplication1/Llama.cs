using System;

namespace ConsoleApplication1 {
    public class Llama
    {
        string llama;
        public Llama(string name)
        {
            llama = "I am a llama. My name is " + name;
        }
        public void PrintName()
        {
            Console.Write(llama);
        }
    }
}

