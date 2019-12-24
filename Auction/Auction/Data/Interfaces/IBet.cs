using System.Collections.Generic;
using Auction.Data.Models;

namespace Auction.Data.Interfaces
{
    public interface IBet
    {
        public void AddBetDB(Bet comment);
        public IEnumerable<Bet> AllBets();
        public void DeleteBet(Bet comment);
        public Bet GetBetDB(int id);
        public void UpdateBet(Bet comment);
    }
}
