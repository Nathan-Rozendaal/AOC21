using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day9
	{
		List<List<int>> data = new List<List<int>>();
		Dictionary<string, int> lowPoints = new Dictionary<string, int>();
		public Day9()
		{
			string[] lines = System.IO.File.ReadAllLines(@"../../../Day9/input.txt");
			foreach (var item in lines)
			{
				data.Add(Array.ConvertAll(item.ToCharArray(), s => int.Parse(s.ToString())).ToList());
			}
		}

		public void run()
		{
			int riskSum = 0;
			for (int i = 0; i < data.Count; i++)
			{
				for (int j = 0; j < data[i].Count; j++)
				{
					var values = GetAdjecentValues(new Vector2(j, i));
					if (data[i][j] < values.Min())
					{
						lowPoints.Add(i + "," + j, 0);
						riskSum += data[i][j] + 1;
					}
				}
			}
			Console.WriteLine(riskSum);
			for (int i = 0; i < data.Count; i++)
			{
				for (int j = 0; j < data[i].Count; j++)
				{
					if(data[i][j] != 9)
					{
						flow(new Vector2(j, i));
					}
				}
			}
			var basins = lowPoints.Values.ToList();
			basins.Sort();
			Console.WriteLine(basins[^1] * basins[^2] * basins[^3]);
		}
		private void flow(Vector2 coord)
		{
			if(lowPoints.ContainsKey(coord.Y + "," + coord.X))
			{
				lowPoints[coord.Y + "," + coord.X] += 1;
			}
			else
			{
				flow(GetLowestAdjecentCoord(coord));
			}
		}
		private Vector2 GetLowestAdjecentCoord(Vector2 coord)
		{
			var values = GetAdjecentValues(coord);
			return GetAdjecentCoords(coord)[values.IndexOf(values.Min())];
		}
		private List<int> GetAdjecentValues(Vector2 coord)
		{
			List<int> output = new List<int>();
			foreach (var item in GetAdjecentCoords(coord))
			{
				output.Add(data[(int)item.Y][(int)item.X]);
			}
			return output;
		}
		private List<Vector2> GetAdjecentCoords(Vector2 coord)
		{
			List<Vector2> output = new List<Vector2>();

			if (WithinBounds((int)coord.X, (int)coord.Y - 1)) output.Add(new Vector2(coord.X, coord.Y - 1));
			if (WithinBounds((int)coord.X - 1, (int)coord.Y)) output.Add(new Vector2(coord.X - 1, coord.Y));
			if (WithinBounds((int)coord.X + 1, (int)coord.Y)) output.Add(new Vector2(coord.X + 1, coord.Y));
			if (WithinBounds((int)coord.X, (int)coord.Y + 1)) output.Add(new Vector2(coord.X, coord.Y + 1));
			return output;
		}
		private bool WithinBounds(int x, int y)
		{
			if (x < 0) return false;
			if (x >= data[0].Count) return false;
			if (y < 0) return false;
			if (y >= data.Count) return false;
			return true;
		}
	}
}
