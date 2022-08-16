using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string email;
        private decimal moneyToInvest;
        private string brokerName;

        public Investor(string Name, string Email, decimal MoneyToInvest, string BrokerName)
        {
            this.portfolio = new List<Stock>();
            this.fullName = Name;
            this.email = Email;
            this.moneyToInvest = MoneyToInvest;
            this.brokerName = BrokerName;
        }


        public int Count
        {
            get => this.Portfolio.Count;
        }

        public void BuyStock(Stock stock)
        {
            if (!this.Portfolio.Contains(stock))
            {
                if (stock.MarketCapitalization >= 10000 && this.MoneyToInvest >= stock.PricePerShare)
                {
                    Portfolio.Add(stock);
                    this.MoneyToInvest -= stock.PricePerShare;
                }
            }
            
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            
            var stock = Portfolio.Find(x => x.CompanyName == companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.Portfolio.Remove(stock);
                this.MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            var stock = this.Portfolio.Find(x => x.CompanyName == companyName);
            if (stock != null)
            {
                return stock;
            }
            return null;     
        }

        public Stock FindBiggestCompany()
        {
            if (this.portfolio.Count == 0)
            {
                return null;
            }
            //if (Portfolio.Count != 0)
            //{
            //    var maxStock = Portfolio.Max(x => x.MarketCapitalization);
            //    var biggestCompany = Portfolio.Find(x => x.MarketCapitalization == maxStock);
            //    return biggestCompany;
            //}
            //return null;

            return this.Portfolio
              .OrderByDescending(x => x.MarketCapitalization)
              .FirstOrDefault();
        }

        public string InvestorInformation()
        {
            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:\n{string.Join("\n", Portfolio)}";
        }

        public List<Stock> Portfolio { get => portfolio; set => portfolio = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string EmailAddress { get => email; set => email = value; }
        public decimal MoneyToInvest { get => moneyToInvest; set => moneyToInvest = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }

        //public List<Stock> Portfolio
        //{
        //    get { return portfolio; }
        //    set { portfolio = value; }
        //}

        //public string FullName
        //{
        //    get { return fullName; }   
        //    set { fullName = value; }
        //}

        //public string Email
        //{
        //    get { return email; }
        //    set { email = value; }
        //}

        //public decimal MoneyToInvest
        //{
        //    get { return moneyToInvest; }
        //    set { moneyToInvest = value;}
        //}

        //public string BrokerName
        //{
        //    get { return brokerName; }
        //    set { brokerName = value; }
        //}


    }
}
