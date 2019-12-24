using System;
using Auction.Data.Models;

namespace Auction.Data.Interfaces
{
    public interface IUser
    {
        public User GetUserDB(string id);
    }
}
