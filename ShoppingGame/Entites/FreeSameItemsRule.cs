using ShoppingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Entites
{
	//apply this rule when user buy item more than numberOfItems
	class FreeSameItemsRule : IPricingRule
	{
		ShopItem item;
		int numberOfItems;
		public FreeSameItemsRule(ShopItem item, int numberOfItems)
		{
			this.item = item;
			this.numberOfItems = numberOfItems;
		}

		public double Run(List<ShopItem> items)
		{
			var numberOfItemsInCart = items.Count(s => s.SKU == this.item.SKU);
			//get number of items that user will get it for free
			var freeItems = numberOfItemsInCart / this.numberOfItems;
			//get total price of free items;
			return freeItems * this.item.Price;
		}
	}
}
