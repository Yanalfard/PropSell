using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class FriendsService : IFriendsService
    {
        public TblFriends AddFriends(TblFriends friends)
        {
            return (TblFriends)new FriendsRepo().AddFriends(friends);
        }
        public bool DeleteFriends(int id)
        {
            return new FriendsRepo().DeleteFriends(id);
        }
        public bool UpdateFriends(TblFriends friends, int logId)
        {
            return new FriendsRepo().UpdateFriends(friends, logId);
        }
        public List<TblFriends> SelectAllFriendss()
        {
            return new FriendsRepo().SelectAllFriendss();
        }
        public TblFriends SelectFriendsById(int id)
        {
            return (TblFriends)new FriendsRepo().SelectFriendsById(id);
        }
        public List<TblFriends> SelectFriendsByMeId(int meId)
        {
            return new FriendsRepo().SelectFriendsByMeId(meId);
        }
        public List<TblFriends> SelectFriendsByFriendId(int friendId)
        {
            return new FriendsRepo().SelectFriendsByFriendId(friendId);
        }

        public List<TblFriends> SelectFriendsByFriendIdAndMeId(int friendId, int meId)
        {
            return new FriendsRepo().SelectFriendsByFriendIdAndMeId(friendId, meId);
        }
    }
}