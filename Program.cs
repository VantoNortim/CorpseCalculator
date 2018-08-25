using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpseCalculator.Items;

namespace CorpseCalculator
{
	internal class Program
	{
		private const int MinTarget = 12;

		public static void Main(string[] args)
		{
			Calculator calc = new Calculator(MinTarget);

			while (true)
			{
				Console.WriteLine("Enter RED:");
				int r = int.Parse(Console.ReadLine());
				Console.WriteLine("Enter WHITE:");
				int w = int.Parse(Console.ReadLine());
			
				var results = calc.Calculate(r, w);
			
				Console.WriteLine($"Highest found: Red:{results.highestRed} White:{results.highestWhite} (Highest possible white skulls with no red skulls)");
				Console.WriteLine(ItemListToString(results.Highest));

				if (results.AllResults.Any())
				{
					Console.WriteLine($"Best(Using the least items that yields over {MinTarget} white skills):");
					Console.WriteLine(ItemListToString(results.AllResults.Last()));
				}
				
				Console.WriteLine("Press enter to restart");
				Console.ReadLine();
				Console.Clear();
			}
		}

		private static string ItemListToString(IEnumerable<Item> list)
		{
			StringBuilder sb = new StringBuilder();
				
			foreach (var item in list)
			{
				if(item.RedMod == 0 && item.WhiteMod == 0) continue;
				sb.Append(item.ItemName + "; ");
			}

			return sb.ToString();
		}
	}
}