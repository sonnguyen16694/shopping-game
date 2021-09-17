using ShoppingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Entites
{
	public class Checkout: ICheckout
	{
		public List<IPricingRule> rules;
		List<ShopItem> items = new List<ShopItem>();

		public Checkout(List<IPricingRule> rules)
		{
			this.rules = rules;
		}

		public void Scan(string sku)
		{
			var item = Catelogue.FindItem(sku);
			if(item != null)
			{
				this.items.Add(item);
			} else
			{
				throw new Exception($"SKU not found ${sku}");
			}
		}

		public double Total()
		{
			double total = 0;
			this.items.ForEach(s => total += s.Price);
			//run each rule to get discount price and then take total price minus the discount price
			this.rules.ForEach(rule => total -= rule.Run(this.items));

			return total;
		}
	}
}
