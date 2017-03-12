using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
			Ping p = new Ping();
			for(int i = 0; i < 256; i++){
				PingReply pr = p.Send("192.168.1." + i, 5);
				Console.WriteLine(pr.Address);
			}
			Console.Write("Welcome to the llama creator! Please enter your llama's name: ");
            Llama myLlama = new Llama(Console.ReadLine());
            myLlama.PrintName();
            Console.ReadLine();
        }
    }
}
