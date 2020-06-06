using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class FriendsRepo : IFriendsRepo
    {
        public TblFriends AddFriends(TblFriends friends)
        {
            return (TblFriends)new MainProvider().Add(friends);
        }
        public bool DeleteFriends(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblFriends, id);
        }
        public bool UpdateFriends(TblFriends friends, int logId)
        {
            return new MainProvider().Update(friends, logId);
        }
        public List<TblFriends> SelectAllFriendss()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblFriends).Cast<TblFriends>().ToList();
        }
        public TblFriends SelectFriendsById(int id)
        {
            return (TblFriends)new MainProvider().SelectById(MainProvider.Tables.TblFriends, id);
        }
        public List<TblFriends> SelectFriendsByMeId(int meId)
        {
            return new MainProvider().SelectFriendsByMeId(meId);
        }
        public List<TblFriends> SelectFriendsByFriendId(int friendId)
        {
            return new MainProvider().SelectFriendsByFriendId(friendId);
        }

    }
}