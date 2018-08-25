using System.Collections.Generic;

namespace CorpseCalculator.Items
{
	class ItemCollection
	{
		public static ItemCollection Instance { get; } = new ItemCollection();

		public List<Item> AllItems { get; private set; } = new List<Item>();
		
		private ItemCollection()
		{
			AddItem("Blood", -1, 1);
			AddItem("Fat", -1, 1);
			AddItem("Skull", 1, 0);
			AddItem("Skin", 1, -1);
			AddItem("Lye", 1, 1);
			AddItem("Acid", -1, -1);
			AddItem("Glue", 0, 1);
			AddItem("Dark", 2, 0);
			AddItem("Silver", -1, 1);
			AddItem("Golden", -2, +2);


			int len = AllItems.Count;
			for (int i = 0; i < len; i++)
			{
				AllItems.Add(new Item("EMTPY" + i, 0, 0));
			}
		}

		private void AddItem(string name, int redMod, int whiteMod)
		{
			AllItems.Add(new Item(name, redMod, whiteMod));
		}
	}
}