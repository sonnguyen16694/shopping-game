using ShoppingGame.Entites;
using ShoppingGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame
{
	class Program
	{
		static List<IPricingRule> PricingRules = new List<IPricingRule>()
		{
			new FreeAttachmentItemsRule(Catelogue.FindItem("mbp"), Catelogue.FindItem("vga"))
			, new FreeSameItemsRule(Catelogue.FindItem("atv"), 3)
			, new DiscountPriceRule(Catelogue.FindItem("ipd"), 4,549.99 - 499.99)
		};
		static void Main(string[] args)
		{
			Console.Title = "Shopping Game";
			//testing cases follow requirement
			Case1();
			Case2();
			Case3();

			//user input test cases
			RunMoreTests();

			Console.WriteLine("Thanks you for using me!");
			Console.ReadLine();
		}

		static void Case1()
		{
			Console.WriteLine("SKUs Scanned: atv, atv, atv, vga");
			var checkout = new Checkout(PricingRules);
			checkout.Scan("atv");
			checkout.Scan("atv");
			checkout.Scan("atv");
			checkout.Scan("vga");
			var cost = checkout.Total();
			Console.WriteLine($"Total expected: ${cost}");
		}
		static void Case2()
		{
			Console.WriteLine("SKUs Scanned: atv, ipd, ipd, atv, ipd, ipd, ipd");
			var checkout = new Checkout(PricingRules);
			checkout.Scan("atv");
			checkout.Scan("ipd");
			checkout.Scan("ipd");
			checkout.Scan("atv");
			checkout.Scan("ipd");
			checkout.Scan("ipd");
			checkout.Scan("ipd");
			var cost = checkout.Total();
			Console.WriteLine($"Total expected: ${cost}");
		}
		static void Case3()
		{
			Console.WriteLine("SKUs Scanned: mbp, vga, ipd");
			var checkout = new Checkout(PricingRules);
			checkout.Scan("mbp");
			checkout.Scan("vga");
			checkout.Scan("ipd");
			var cost = checkout.Total();
			Console.WriteLine($"Total expected: ${cost}");
		}

		static void RunMoreTests()
		{
			var isEndTest = false;
			while(!isEndTest)
			{
				
				Console.Write("Do you want to continue?(y/n): ");
				var userKeyIn = Console.ReadKey();
				Console.WriteLine("");
				if (userKeyIn.Key != ConsoleKey.Y )
				{
					isEndTest = true;
				} 
				else
				{
					StartUserTest();
				}
			}
			
		}

		static void StartUserTest()
		{
			try
			{
				Console.Write("Please input your SKU scanned (seperate by comma): ");
				var inputScanned = Console.ReadLine();
				var skus = inputScanned.Split(',');
				var checkout = new Checkout(PricingRules);
				foreach(var sku in skus)
				{
					checkout.Scan(sku.Trim().ToLower());
				}
				
				var cost = checkout.Total();
				Console.WriteLine($"Total expected: ${cost}");
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			
		}
	}
}
