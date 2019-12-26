using System.Collections.Generic;
using Auction.Data.Models;

namespace Auction.Data.Interfaces
{
    public interface ILot
    {
        public void AddLotDB(Lot lot);
        public IEnumerable<Lot> AllLots();
        public IEnumerable<Lot> MyLot(User user);
        public Lot GetLotDB(int id);
        public void UpdateLot(Lot post);
        public void DeleteLot(Lot post);
    }
}
