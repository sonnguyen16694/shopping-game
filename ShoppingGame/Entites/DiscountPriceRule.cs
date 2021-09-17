using ShoppingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Entites
{
	//apply this class when user buy more than numberOfItemsToDiscount
	class DiscountPriceRule : IPricingRule
	{
		ShopItem item;
		int numberOfItemsToDiscount;
		double discountPrice;
		public DiscountPriceRule(ShopItem item, int numberOfItemsToDiscount, double discountPrice)
		{
			this.item = item;
			this.numberOfItemsToDiscount = numberOfItemsToDiscount;
			this.discountPrice = discountPrice;
		}

		public double Run(List<ShopItem> items)
		{
			var numberOfItemsInCart = items.Count(s => s.SKU == this.item.SKU); 

			return numberOfItemsInCart >= this.numberOfItemsToDiscount ? numberOfItemsInCart * discountPrice : 0;
		}
	}
}
