using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data.Interfaces;
using Auction.Data.Models;

namespace Auction.Data.Repositories
{
    public class BetRepository : IBet
    {
        private readonly AppDBContext _appDbContext;
        public BetRepository(AppDBContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public void AddBetDB(Bet comment)
        {
            _appDbContext.Bets.Add(comment);
            _appDbContext.SaveChanges();
        }
        public IEnumerable<Bet> AllBets()
        {
            return _appDbContext.Bets.ToList();
        }
        public void DeleteBet(Bet bet)
        {
            _appDbContext.Bets.Remove(bet);
            _appDbContext.SaveChanges();
        }
        public Bet GetBetDB(int id)
        {
            return _appDbContext.Bets.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateBet(Bet comment)
        {
            _appDbContext.Bets.Update(comment);
            _appDbContext.SaveChanges();
        }
    }
}
