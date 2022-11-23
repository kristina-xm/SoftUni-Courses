using System;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        public Stock(string Name, string Director, decimal PricePerShare, int TotalNumberOfShares)
        {
            this.companyName = Name;
            this.director = Director;
            this.pricePerShare = PricePerShare;
            this.totalNumberOfShares = TotalNumberOfShares;
            MarketCapitalization = PricePerShare * TotalNumberOfShares;
        }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Director { get => director; set => director = value; }
        public decimal PricePerShare { get => pricePerShare; set => pricePerShare = value; }
        public int TotalNumberOfShares { get => totalNumberOfShares; set => totalNumberOfShares = value; }
        public decimal MarketCapitalization { get => pricePerShare * totalNumberOfShares; set => marketCapitalization = value; }
        
        //public string Name
        //{
        //    get { return companyName; }
        //    set { companyName = value; }
        //}
        //public string Director 
        //{ 
        //    get { return director; }
        //    set { director = value; }
        //}
        //public decimal PricePerShare
        //{
        //    get { return pricePerShare; }  
        //    set { pricePerShare = value; }
        //}
        //public int TotalNumberOfShares
        //{
        //    get { return totalNumberOfShares; }
        //    set { totalNumberOfShares = value; }
        //}

        //public decimal MarketCapitalization
        //{
        //    get { return marketCapitalization; }
        //    set { marketCapitalization = value; } 
        //}

        public override string ToString()
        {
            return $"Company: {this.CompanyName}\nDirector: {this.Director}\nPrice per share: ${this.PricePerShare}\nMarket capitalization: ${this.MarketCapitalization}";
        }
    }
}
