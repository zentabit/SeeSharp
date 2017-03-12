using System;


namespace RunHuman
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h = new Human("Dick Dickinson", 1, 42, 0, 68);
            h.Hello();
            Console.WriteLine(h.CalBMI());
			h.SaySomething();
			Console.ReadLine();
        }
    }
}
