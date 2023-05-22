using System;
using System.Text;

namespace RoolUp
{
	public class Output
	{
		public string CheckPrice(List<Chain> chains)
		{
            var validChains = chains.Where(x => !string.IsNullOrEmpty(x.Price)).ToList();
            var priceToCheck = validChains.Select(x => x.Price).FirstOrDefault();
            var allHaveSameValue = validChains.All(x => x.Price == priceToCheck);

            if (allHaveSameValue)
            {
                if (CheckMoreProduct(validChains))
                {
                    if (AreAnyNullValues(validChains))
                    {
                        return StringChainResultNullPrice(validChains);
                    }

                    var groupedChains = validChains.GroupBy(x => x.Product)
                                                  .Select(g => new { Product = g.Key, Price = g.First().Price });

                    var res = string.Join(", ", groupedChains.Select(x => $"{x.Product} {x.Price}"));
                    return res;
                }
                else
                {
                    var res = validChains.First();
                    return $"{res.Product} {res.Price}";
                }
            }

            return "";
        }

        private bool CheckMoreProduct(List<Chain> chains)
		{
            return chains.Select(x => x.Product).Distinct().Count() > 1;
        }

		private bool AreAnyNullValues(List<Chain> chains)
		{
            return chains.Any(x => string.IsNullOrEmpty(x.Price));

        }

		private string StringChainResultNullPrice(List<Chain> chains)
		{
            var chainNull = chains.First(x => string.IsNullOrEmpty(x.Price));
            var gtinChildNotNull = string.Join(", "
                                        ,chains.Where(x => x.Variant == chainNull.Variant && !string.IsNullOrEmpty(x.Price))
                                               .Select(x => $"{x.Gtin} {x.Price}"));
            var variantNotDirectParentGtinNull = string.Join(", "
                                        ,chains.Where(x => x.Variant != chainNull.Variant && !string.IsNullOrEmpty(x.Price))
                                               .Select(x => $"{x.Variant} {x.Price}"));

            var result = gtinChildNotNull + ", " + variantNotDirectParentGtinNull;

            return result;
        }
    }

}


