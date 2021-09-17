using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Interfaces
{
	interface ICheckout
	{
		void Scan(string sku);
		double Total();
	}
}
