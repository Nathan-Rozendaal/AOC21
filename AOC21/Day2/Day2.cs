using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day2
	{
		string[] lines;

		public Day2()
		{
			lines = System.IO.File.ReadAllLines(@"../../../Day2/input.txt");
		}

		public void run()
		{
			// part one
			int horizontal = 0;
			int depth = 0;
			foreach (var line in lines)
			{
				string[] parts = line.Split(' ');
				int amount = int.Parse(parts[1]);
				if (parts[0] == "forward") horizontal += amount;
				if (parts[0] == "up") depth -= amount;
				if (parts[0] == "down") depth += amount;
			}
			Console.WriteLine(horizontal * depth);
			// part two
			int aim = 0;
			horizontal = 0;
			depth = 0;
			foreach (var line in lines)
			{
				string[] parts = line.Split(' ');
				int amount = int.Parse(parts[1]);
				if (parts[0] == "forward")
				{
					horizontal += amount;
					depth += aim * amount;
				}
				if (parts[0] == "up") aim -= amount;
				if (parts[0] == "down") aim += amount;
			}
			Console.WriteLine(horizontal * depth);
		}
	}
}
