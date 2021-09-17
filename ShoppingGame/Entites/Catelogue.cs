using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Entites
{
	public static class Catelogue
	{
		static List<ShopItem> items = new List<ShopItem>() {
				new ShopItem("ipd", "Super iPad", 549.99),
				new ShopItem("mbp", "MacBook Pro",1399.99),
				new ShopItem("atv", "Apple TV", 109.50),
				new ShopItem("vga", "VGA adapter", 30.00),
		};

		public static int TotalItems()
		{
			return items.Count;
		}

		public static ShopItem FindItem(string sku)
		{
			var item  = items.FirstOrDefault(s => s.SKU == sku);
			if(item != null)
			{
				return item;
			}
			throw new Exception($"SKU not found {sku}");

		}
	}
}
