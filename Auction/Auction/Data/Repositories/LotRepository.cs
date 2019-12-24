using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data.Interfaces;
using Auction.Data.Models;

namespace Auction.Data.Repositories
{
    public class LotRepository : ILot
    {
        private readonly AppDBContext _appDbContext;
        public LotRepository(AppDBContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public void AddPublicationDB(Lot lot)
        {
            _appDbContext.Lots.Add(lot);
            _appDbContext.SaveChanges();
        }
        public IEnumerable<Lot> AllLots()
        {
           return _appDbContext.Lots.ToList();
        }
        public IEnumerable<Lot> MyLot(User user)
        {
            return _appDbContext.Lots.Where(x => x.User.Id == user.Id).ToList();
        }
        public Lot GetLotDB(int id)
        {
            return _appDbContext.Lots.Where(x => x.Id == id).FirstOrDefault();
        }
        public void UpdateLot(Lot lot)
        {
            _appDbContext.Lots.Update(lot);
            _appDbContext.SaveChanges();
        }
        public void DeleteLot(Lot lot)
        {
            _appDbContext.Lots.Remove(lot);
            _appDbContext.SaveChanges();
        }
    }
}
