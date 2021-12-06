using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day6
	{
		UInt64[] fishes = new UInt64[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

		public Day6()
		{
			string[] lines = System.IO.File.ReadAllLines(@"../../../Day6/input.txt");
			var data = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s)).ToList();
			foreach (var item in data)
			{
				fishes[item]++;
			}
		}

		public void run()
		{
			for (int i = 0; i < 256; i++)
			{
				var newFishes = new UInt64[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
				fishes.CopyTo(newFishes, 0);
				for (int j = 0; j < 9; j++)
				{
					if(j == 8)
					{
						newFishes[8] = fishes[0];
						newFishes[6] = fishes[0] + fishes[7];
					}
					else
					{
						newFishes[j] = fishes[j + 1];
					}
				}
				fishes = newFishes;
			}
			UInt64 counter = 0;
			foreach (var fish in fishes)
			{
				counter += fish;
			}
			Console.WriteLine(counter);
		}
	}
}
