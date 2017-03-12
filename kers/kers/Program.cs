using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//Made by zentabit 2017
//Some program/game that introduces game logic

namespace kers
{
	class Program
	{
		private static string version = "0.2.4";
		private static int meaningOfLife = 42;
		static void Main(string[] args)
		{
			//Initialise some vars
			Console.Title = "KERS v" + version;
			int kers;
			int speed;

			//Get kers arg if possible
			if(args == null)
			{
				kers = 0;
				speed = 0;
			} else
			{
				try
				{
					kers = int.Parse(args[0]);
				} catch (Exception)
				{
					kers = 0;
				}
				speed = 0;
			}

			//Print start menu
			PrintStart(kers, speed);
			
			//Start main loop
			while (true){
				//Read input from user, separate cmd and args
				Console.Write("KERS> ");
				string rawCmd = Console.ReadLine();
				string[] cmd = rawCmd.Split();

				//detecting cmds
				switch (cmd[0].ToLower())
				{
					case "brake":
						Console.WriteLine("Braking...");
						try
						{
							Tuple<int, int> temp = Brake(kers, int.Parse(cmd[1]), speed);
							kers = temp.Item1;
							speed = temp.Item2;
						} catch (Exception)
						{
							Tuple<int, int> temp = Brake(kers, 100, speed);
							kers = temp.Item1;
							speed = temp.Item2;
						}
						Console.WriteLine("KERS level: {0}", kers);
						Console.WriteLine();
						break;

					case "accelerate":
						Console.WriteLine("Accelerating...");
						try
						{
							Tuple<int, int> temp = Accelerate(kers, int.Parse(cmd[1]), speed);
							kers = temp.Item1;
							speed = temp.Item2;
						} catch (Exception)
						{
							Tuple<int, int> temp = Accelerate(kers, 50, speed);
							kers = temp.Item1;
							speed = temp.Item2;
						}
						Console.WriteLine("KERS level: {0}. Speed is {1} km/h.", kers, speed);
						Console.WriteLine();
						break;

					case "kers":
						Console.WriteLine("Current KERS level is {0}", kers);
						Console.WriteLine();
						break;

					case "speed":
						Console.WriteLine("Current speed is {0} km/h", speed);
						Console.WriteLine();
						break;

					case "exit":
						Console.WriteLine(meaningOfLife);
						Environment.Exit(0);
						break;

					case "help":
						//TODO: Add help menu
						break;

					default:
						Console.WriteLine("Didn't get that");
						break;
				}
			}
		}

		//Brake method
		public static Tuple<int, int> Brake(int kersVar, int amount, int speeds)
		{
			//If kers isn't full and brake request isn't exceeding current speed, refuel KERS, else check if speed is zero or brake request is below current speed
			if (kersVar < 100 && (speeds - amount >= 0))
			{
				Console.WriteLine("KERS not full, refueling KERS!");
				kersVar += amount;
				speeds -= amount;
			}
			else if (kersVar < 100 && (speeds - amount <= 0))
			{
				if (speeds == 0)
				{
					kersVar = 0;
					Console.WriteLine("Speed is zero, didn't refuel.");
				}
				else
				{
					kersVar += speeds;
					Console.WriteLine("KERS not full, refueling KERS!");
				}
				speeds = 0;
			}
			else
			{
				Console.WriteLine("KERS full!");
			}
			return Tuple.Create(kersVar, speeds);
		}

		//Accelerate method
		public static Tuple<int, int> Accelerate(int kersVar, int amount, int speed)
		{
			//If acc request is available with KERS, use KERS, else just accelerate
			if (kersVar > 0 && (kersVar - amount >= 0))
			{
				Console.WriteLine("KERS available! Using KERS to boost.");
				kersVar -= amount;
				speed += amount * 2;
			}
			else
			{
				Console.WriteLine("KERS not available! Accelerating at normal speed.");
				speed += amount;
			}
			return Tuple.Create(kersVar, speed);
		}

		//Start menu method
		public static void PrintStart(int kers, int speed)
		{
			string welcome = "The Kinetic Energy Recovery System (KERS) v" + version;

			for (int i = 0; i < 70; i++)
			{
				Console.Write("-");
				Thread.Sleep(15);
			}
			Console.WriteLine();

			foreach (char c in welcome){
				Console.Write(c);
				Thread.Sleep(10);
			}
			Console.WriteLine();

			for (int i = 0; i < 70; i++)
			{
				Console.Write("-");
				Thread.Sleep(15);
			}
			Console.WriteLine();

			Console.WriteLine("The current KERS level is {0}. You are currently driving at {1} km/h.", kers, speed);
			Console.WriteLine("Please enter a command.");
			Console.WriteLine();
		}
	}
}
