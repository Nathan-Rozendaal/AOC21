using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day7
	{
		List<int> data;
		public Day7()
		{
			string[] lines = System.IO.File.ReadAllLines(@"../../../Day7/input.txt");
			data = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s)).ToList();
		}

		public void run()
		{
			// part one
			data.Sort();
			int median = data[data.Count / 2];
			int fuel = 0;
			foreach (var item in data)
			{
				fuel += Math.Abs(item - median);
			}
			Console.WriteLine(fuel);

			//part two
			int avarage = (int)data.Average();
			fuel = 0;
			foreach (var item in data)
			{
				for (int i = 1; i <= Math.Abs(item - avarage); i++)
				{
					fuel += i;
				}
			}
			Console.WriteLine(fuel);
		}
	}
}
