using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day8
	{
		List<int> dataPartOne = new List<int>();
		List<List<string>> data = new List<List<string>>();
		List<List<string>> outputs = new List<List<string>>();
		bool[][] values = new bool[][]
		{
			new bool[] { true, true, true, false, true, true, true }, //0
			new bool[] { false, false, true, false, false, true, false }, //1
			new bool[] { true, false, true, true, true, false, true }, //2
			new bool[] { true, false, true, true, false, true, true },  // 3
			new bool[] { false, true, true, true, false, true, false }, //4
			new bool[] { true, true, false, true, false, true, true }, //5
			new bool[] { true, true, false, true, true, true, true }, //6 
			new bool[] { true, false, true, false, false, true, false }, //7
			new bool[] { true, true, true, true, true, true, true }, //8 
			new bool[] { true, true, true, true, false, true, true }, //9
		};

		public Day8()
		{
			string[] lines = System.IO.File.ReadAllLines(@"../../../Day8/input.txt");

			// part one
			foreach (var item in lines)
			{
				var output = item.Split(" | ")[1].Split(' ');
				foreach (var value in output)
				{
					dataPartOne.Add(value.Length);
				}
			}
			foreach (var item in lines)
			{
				var items = item.Split(" | ");
				outputs.Add(items[1].Split(' ').ToList());
				var list = items[0].Split(' ').ToList();
				list.AddRange(items[1].Split(' ').ToList());
				data.Add(list);
			}
		}

		public void run()
		{
			// part one
			int counter = 0;
			foreach (var item in dataPartOne)
			{
				if (item == 2 || item == 7 || item == 4 || item == 3)
					counter++;
			}
			Console.WriteLine(counter);
			// part two
			int sum = 0;
			int index = 0;
			foreach (var item in data)
			{
				// possible correct locations
				bool[][] pos = new bool[][]
				{
					new bool[] { true, true, true, true, true, true, true },//a
					new bool[] { true, true, true, true, true, true, true },//b
					new bool[] { true, true, true, true, true, true, true },//c
					new bool[] { true, true, true, true, true, true, true },//d
					new bool[] { true, true, true, true, true, true, true },//e
					new bool[] { true, true, true, true, true, true, true },//f
					new bool[] { true, true, true, true, true, true, true },//g
				};
				// set 1's 4's 7's and 8's first
				foreach (var value in item)
				{
					if (value.Length == 2 || value.Length == 7 || value.Length == 4 || value.Length == 3)
					{
						for (int i = 0; i < pos.Length; i++)
						{
							int count = 0;
							foreach (var letter in value)
							{
								if (i == CharToIndex(letter)) count++;
							}
							for (int j = 0; j < pos[i].Length; j++)
							{
								if(count == 0)
								{
									if (values[CountToNum(value.Length)][j])
										pos[i][j] = false;
								}
								else
								{
									if (!values[CountToNum(value.Length)][j])
										pos[i][j] = false;
								}
							}
						}
					}
				}
				string number = "";

				List<int> oneOrThree = new List<int>();
				List<int> twoOrFive = new List<int>();
				List<int> FourOrsix = new List<int>();
				for (int i = 0; i < pos.Length; i++)
				{
					if (pos[i][1])
						oneOrThree.Add(i);
					if (pos[i][2])
						twoOrFive.Add(i);
					if (pos[i][4])
						FourOrsix.Add(i);
				}

				// figuring out the numbers
				foreach (var output in outputs[index])
				{
					if(CountToNum(output.Length) != 0)
					{
						number += CountToNum(output.Length);
						continue;
					}

					List<int> indexes = new List<int>();
					foreach (var letter in output)
					{
						indexes.Add(CharToIndex(letter));
					}

					if (output.Length == 5)
					{
						if(indexes.Contains(oneOrThree[0]) ^ indexes.Contains(oneOrThree[1]))
						{
							if (indexes.Contains(twoOrFive[0]) ^ indexes.Contains(twoOrFive[1]))
							{
								number += 2;
								continue;
							}
							number += 3;
							continue;
						}
						number += 5;
						continue;
					}
					if (output.Length == 6)
					{
						if (indexes.Contains(oneOrThree[0]) ^ indexes.Contains(oneOrThree[1]))
						{
							number += 0;
							continue;
						}
						if (indexes.Contains(twoOrFive[0]) ^ indexes.Contains(twoOrFive[1]))
						{
							number += 6;
							continue;
						}
						number += 9;
					}
				}
				sum += int.Parse(number);
				index++;
			}
			Console.WriteLine(sum);
			
		}
		private int CharToIndex(char input)
		{
			if (input == 'a') return 0;
			if (input == 'b') return 1;
			if (input == 'c') return 2;
			if (input == 'd') return 3;
			if (input == 'e') return 4;
			if (input == 'f') return 5;
			if (input == 'g') return 6;
			return -1;
		}

		private int CountToNum(int count)
		{
			if (count == 2) return 1;
			if (count == 3) return 7;
			if (count == 4) return 4;
			if (count == 7) return 8;
			return 0;
		}
	}
}
