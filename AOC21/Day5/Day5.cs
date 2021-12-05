using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
	class Day5
	{
		string[] lines;
		List<Vector2[]> data;
		List<Vector2[]> filterdData;

		public Day5()
		{
			lines = System.IO.File.ReadAllLines(@"../../../Day5/input.txt");
			//ints = Array.ConvertAll(lines, s => int.Parse(s));
			List<string[]> split = new List<string[]>();
			foreach (var item in lines)
			{
				split.Add(item.Split(" -> "));
			}


			data = new List<Vector2[]>();
			foreach (var item in split)
			{
				int[] nums1 = Array.ConvertAll(item[0].Split(','), s => int.Parse(s));
				int[] nums2 = Array.ConvertAll(item[1].Split(','), s => int.Parse(s));
				Vector2 first = new Vector2(nums1[0], nums1[1]);
				Vector2 second = new Vector2(nums2[0], nums2[1]);
				var input = new Vector2[] { first, second };
				data.Add(input);
			}
			filterdData = data.Where(a => a[0].X == a[1].X || a[0].Y == a[1].Y).ToList();

		}

		public void run()
		{
			int result = 0;
			var firstset = new HashSet<Vector2>();
			var secondset = new HashSet<Vector2>();

			foreach (var item in data)
			{
				var coordinates = GetCoordinates(item[0], item[1]);
				foreach (var vector in coordinates)
				{
					if (firstset.Contains(vector))
					{
						if (secondset.Contains(vector)) continue;
						result++;
						secondset.Add(vector);
					}
					else
					{
						firstset.Add(vector);
					}
				}
			}
			Console.WriteLine(result);
		}

		private Vector2[] GetCoordinates(Vector2 from, Vector2 to)
		{
			var output = new List<Vector2>();
			// horizontal coordinates
			if (from.X == to.X)
			{
				if (from.Y < to.Y)
				{
					for (int i = (int)from.Y; i <= to.Y; i++)
					{
						output.Add(new Vector2(from.X, i));
					}
					return output.ToArray();
				}
				for (int i = (int)to.Y; i <= from.Y; i++)
				{
					output.Add(new Vector2(from.X, i));
				}
				return output.ToArray();
			}
			// vertical coordinates
			if (from.Y == to.Y)
			{
				if (from.X < to.X)
				{
					for (int i = (int)from.X; i <= to.X; i++)
					{
						output.Add(new Vector2(i, from.Y));
					}
					return output.ToArray();
				}
				for (int i = (int)to.X; i <= from.X; i++)
				{
					output.Add(new Vector2(i, from.Y));
				}
				return output.ToArray();
			}
			// diagonal coordinates
			int length = (int)(from.Y - to.Y);
			if (from.Y - to.Y < 0) length = (int)(to.Y - from.Y);

			Vector2 direction = new Vector2(-1, -1);
			if (from.Y < to.Y) direction.Y = 1;
			if (from.X < to.X) direction.X = 1;
			var vector = from;
			for (int i = 0; i <= length; i++)
			{
				output.Add(vector);
				vector.X = vector.X + direction.X;
				vector.Y = vector.Y + direction.Y;
			}

			return output.ToArray();
		}
	}
}
