using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using Combinatorics.Collections;
using CorpseCalculator.Items;

namespace CorpseCalculator
{
	public class Calculator
	{
		private static readonly ItemCollection _items = Items.ItemCollection.Instance;

		private readonly int _minTarget;

		public Calculator(int minTarget)
		{
			this._minTarget = minTarget;
		}

		public CalcResult Calculate(int initialRed, int initialWhite)
		{
			IEnumerable<IEnumerable<Item>> allcombs = new List<IEnumerable<Item>>();
			List<IEnumerable<Item>> results = new List<IEnumerable<Item>>();
			
			Combinations<Item> res = new Combinations<Item>(_items.AllItems, _items.AllItems.Count / 2);
			allcombs = res.Distinct();

			IEnumerable<Item> highestSet = new List<Item>();
			int hR = 0;
			int hW = 0;
			
			int highest = -99;
			foreach (var itemList in allcombs)
			{
				int cRed = initialRed;
				int cWhite = initialWhite;
				foreach (var item in itemList)
				{
					cRed += item.RedMod;
					cWhite += item.WhiteMod;
				}
				//Console.WriteLine($"R:{cRed} W:{cWhite}");
				if (cRed == 0 && cWhite > highest)
				{
					hR = cRed;
					highest = hW = cWhite;
					highestSet = itemList;
				}
				if(cRed == 0 && cWhite >= _minTarget) results.Add(itemList);
			}
			
			return new CalcResult(results, highestSet, hR, hW);
		}
		
	}
}