using System;
using System.Text;

namespace RoolUp
{
	public class Output
	{
		public string CheckPrice(List<Chain> chains)
		{
			var priceToCheck = chains.Select(x => x.Price).First();
			var allHaveSameValue = chains.All(x => x.Price == priceToCheck);

			if (allHaveSameValue)
			{
				if (CheckMoreProduct(chains))
				{
                    var groupedChains = chains.GroupBy(x => x.Product)
                          .Select(g => new { Product = g.Key, Price = g.First().Price });
					var res = string.Join(", ", groupedChains.Select(x => $"{x.Product} {x.Price}"));
					return res;
                }
				else
				{
                    var res = chains.First();
                    return $"{res.Product} {res.Price}";
                }
            }

			return "";
		}
		private bool CheckMoreProduct(List<Chain> chains)
		{
            return chains.Select(x => x.Product).Distinct().Count() > 1;
        }
    }

}


