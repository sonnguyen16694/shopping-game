using ShoppingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Entites
{
	class FreeAttachmentItemsRule : IPricingRule
	{
		ShopItem paidItem;
		ShopItem freeItem;
		public FreeAttachmentItemsRule(ShopItem paidItem, ShopItem freeItem)
		{
			this.paidItem = paidItem;
			this.freeItem = freeItem;
		}
		public double Run(List<ShopItem> items)
		{
			int numberOfPaidItems = items.Count(s => s.SKU == paidItem.SKU);
			int numberOfFreeItems = items.Count(s => s.SKU == freeItem.SKU);
			return Math.Min(numberOfPaidItems, numberOfFreeItems) * freeItem.Price;
		}
	}
}
