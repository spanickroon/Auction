using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repositories
{
    public class PurchaseRepository : IPurchase
    {
        private readonly AppDBContext _appDbContext;
        public PurchaseRepository(AppDBContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public void AddPurchaseDB(Purchase purchase)
        {
            _appDbContext.Purchases.Add(purchase);
            _appDbContext.SaveChanges();
        }
        public IEnumerable<Purchase> AllPurchases()
        {
            return _appDbContext.Purchases.ToList();
        }
        public IEnumerable<Purchase> MyPurchase(User user)
        {
            return _appDbContext.Purchases.Where(x => x.User.Id == user.Id).ToList();
        }
        public Purchase GetPurchaseDB(int id)
        {
            return _appDbContext.Purchases.Where(x => x.Id == id).FirstOrDefault();
        }
        public void UpdatePurchase(Purchase lot)
        {
            _appDbContext.Purchases.Update(lot);
            _appDbContext.SaveChanges();
        }
        public void DeletePurchase(Purchase lot)
        {
            _appDbContext.Purchases.Remove(lot);
            _appDbContext.SaveChanges();
        }
    }
}
