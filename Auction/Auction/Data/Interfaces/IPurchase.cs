using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Interfaces
{
    public interface IPurchase
    {
        public void AddPurchaseDB(Purchase purchase);
        public IEnumerable<Purchase> AllPurchases();
        public IEnumerable<Purchase> MyPurchase(User user);
        public Purchase GetPurchaseDB(int id);
        public void UpdatePurchase(Purchase purchase);
        public void DeletePurchase(Purchase purchase);
    }
}
