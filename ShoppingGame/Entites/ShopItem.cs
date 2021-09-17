using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Entites
{
	public class ShopItem
	{
		public ShopItem()
		{

		}

		public ShopItem(string sku, string name, double price)
		{
			this.SKU = sku;
			this.Name = name;
			this.Price = price;
		}
		public string SKU { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
