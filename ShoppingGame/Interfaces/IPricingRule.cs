using ShoppingGame.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Interfaces
{
	public interface IPricingRule
	{
		double Run(List<ShopItem> items);
	}
}
