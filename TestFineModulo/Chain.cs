using System;
namespace RoolUp
{
	public class Chain
	{
		private string _gtin;
        private string _variant;
        private string _product;
        private string _price;

        public string Gtin { get { return _gtin; } }

        public string Variant { get { return _variant; } }

        public string Product { get { return _product; } }

        public string Price { get { return _price; } }

        public Chain(string gtin, string variant, string product, string price)
        {
            _gtin = gtin;
            _variant = variant;
            _product = product;
            _price = price;
        }
    }
}

