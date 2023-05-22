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
                    return  string.Join(", ", chains.Distinct().Select(x => $"{x.Product} {x.Price}")); 
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
			var distinctProducts = chains.Select(x => x.Product).Distinct().Count();
			var res = distinctProducts > 1 ? true : false;
			return res;
		}
    }

}


