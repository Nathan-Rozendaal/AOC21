using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day1
	{
		int[] ints;
		
		public Day1()
		{
			string[] lines = System.IO.File.ReadAllLines(@"../../../Day1/input.txt");
			ints = Array.ConvertAll(lines, s => int.Parse(s));
		}

		public void run()
		{
			//part one
			int prev = int.MaxValue;
			int counter = 0;
			for (int i = 0; i < ints.Length; i++)
			{
				if (ints[i] > prev) counter++;
				prev = ints[i];
			}
			Console.WriteLine(counter);

			//part two
			List<int> list = new List<int>();
			for (int i = 0; i < ints.Length - 2; i++)
			{
				list.Add(ints[i] + ints[i + 1] + ints[i + 2]);
			}

			prev = int.MaxValue;
			counter = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] > prev) counter++;
				prev = list[i];
			}
			Console.WriteLine(counter);
		}
		
	}
}
