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
		// for part two
		List<Vector2[]> data;
		// for part one
		List<Vector2[]> filterdData;

		public Day5()
		{
			lines = System.IO.File.ReadAllLines(@"../../../Day5/input.txt");
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
					else firstset.Add(vector);
				}
			}
			Console.WriteLine(result);
		}

		private Vector2[] GetCoordinates(Vector2 from, Vector2 to)
		{
			var output = new List<Vector2>();

			int length = (int)Math.Max( 
				Math.Abs(from.Y - to.Y), 
				Math.Abs(from.X - to.X));

			Vector2 direction = new Vector2(
				Math.Clamp(to.X - from.X, -1, 1) , 
				Math.Clamp(to.Y - from.Y, -1, 1));

			for (int i = 0; i <= length; i++)
			{
				output.Add(from);
				from.X += direction.X;
				from.Y += direction.Y;
			}
			return output.ToArray();
		}
	}
}
