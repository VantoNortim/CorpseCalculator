using System;

namespace CorpseCalculator.Items
{
	public class Item : IComparable
	{
		public string ItemName { get; private set; }
		public int RedMod { get; private set; }
		public int WhiteMod { get; private set; }

		public Item(string itemName, int redMod, int whiteMod)
		{
			ItemName = itemName;
			RedMod = redMod;
			WhiteMod = whiteMod;
		}

		public int CompareTo(object obj)
		{
			return String.CompareOrdinal(((Item) obj).ItemName, ItemName);
		}
	}
}