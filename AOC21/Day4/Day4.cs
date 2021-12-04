using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day4
	{
		string[] lines;
		int[] numbers;
		List<List<int>> boards = new List<List<int>>();

		public Day4()
		{
			lines = System.IO.File.ReadAllLines(@"../../../Day4/input.txt");
			//ints = Array.ConvertAll(lines, s => int.Parse(s));
			numbers = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));

			List<int> board = new List<int>();
			for (int i = 2; i < lines.Length; i++)
			{
				if (lines[i] == "")
				{
					boards.Add(board);
					board = new List<int> (); ;
					continue;
				}
				var values = Array.ConvertAll(lines[i].Split(' ').Where(s => s != "").ToArray(), s => int.Parse(s));
				foreach (var value in values)
				{
					board.Add(value);
				}
			}
		}

		public void run()
		{
			foreach (var number in numbers)
			{
				for (int i = 0; i < boards.Count(); i++)
				{
					boards[i] = checkNumber(boards[i], number);
				}
				for (int i = 0; i < boards.Count(); i++)
				{
					if (hasWon(boards[i]))
					{
						int sum = 0;
						for (int j = 0; j < boards[i].Count; j++)
						{
							if (j % 5 == 0) Console.WriteLine();
							Console.Write(boards[i][j] + " ");
							if (boards[i][j] != -1)
							{
								sum += boards[i][j];
							}
						}
						Console.WriteLine(sum * number);
						boards.RemoveAt(i);
					}
				}
			}
		}
		private List<int> checkNumber(List<int> board, int number)
		{
			for (int i = 0; i < board.Count; i++)
			{
				if (board[i] == number) board[i] = -1;
			}
			return board;
		}
		private bool hasWon(List<int> board)
		{
			List<int> SumsVertical = new List<int>(){0,0,0,0,0};
			int index = 0;
			for (int i = 0; i < 5; i++)
			{
				int sumHorizontal = 0;
				for (int j = 0; j < 5; j++)
				{
					int value = board[index];
					index++;
					SumsVertical[j] += value;
					sumHorizontal += value;
				}
				if (sumHorizontal == -5) return true;
			}
			foreach (var sum in SumsVertical)
			{
				if (sum == -5) return true;
			}
			return false;
		}
	}
}
