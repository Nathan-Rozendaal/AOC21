using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day3
	{
		string[] lines;

		public Day3()
		{
			lines = System.IO.File.ReadAllLines(@"../../../Day3/input.txt");
			//ints = Array.ConvertAll(lines, s => int.Parse(s));
		}

		public void run()
		{
			//part one
			string result = "";
			int[] counters = new int[12];
			foreach (var num in lines)
			{
				for (int i = 0; i < num.Length; i++)
				{
					if (num[i] == '1') counters[i]++;
				}
			}

			for (int i = 0; i < counters.Length; i++)
			{ 
				if(counters[i] >= lines.Count() / 2)
					result += '1';
				else
					result += '0';
			}
			uint value = Convert.ToUInt16(result, 2);
			Console.WriteLine(value * (~value & 0x0FFF));

			//part two
			List<string> oxy = lines.ToList();
			int counter = 0;
			while (oxy.Count > 1)
			{
				int amount = 0;
				foreach (var measurement in oxy)
				{
					if (measurement[counter] == '1') amount++;
				}

				char most = '0';
				if (amount >= oxy.Count / 2) most = '1';

				oxy = oxy.Where(s => s[counter] == most).ToList();
				counter++;
			}

			List<string> co2 = lines.ToList();
			counter = 0;
			while (co2.Count > 1)
			{
				int amount = 0;
				foreach (var measurement in co2)
				{
					if (measurement[counter] == '1') amount++;
				}

				char least = '1';
				if (amount >= co2.Count / 2) least = '0';

				co2 = co2.Where(s => s[counter] == least).ToList();
				counter++;
			}
			Console.WriteLine(Convert.ToUInt16(co2[0], 2) * Convert.ToUInt16(oxy[0], 2));
		}
	}
}
