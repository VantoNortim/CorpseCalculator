using System.Collections.Generic;
using CorpseCalculator.Items;

namespace CorpseCalculator
{
	public class CalcResult
	{
		public IEnumerable<IEnumerable<Item>> AllResults { get; private set; }
		public IEnumerable<Item> Highest { get; private set; }
		public int highestRed { get; private set; }
		public int highestWhite { get; private set; }

		public CalcResult(IEnumerable<IEnumerable<Item>> allResults, IEnumerable<Item> highest, int highestRed, int highestWhite)
		{
			AllResults = allResults;
			Highest = highest;
			this.highestRed = highestRed;
			this.highestWhite = highestWhite;
		}
	}
}