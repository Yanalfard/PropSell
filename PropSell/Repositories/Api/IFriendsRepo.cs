using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IFriendsRepo
    {
        TblFriends AddFriends(TblFriends friends);
        bool DeleteFriends(int id);
        bool UpdateFriends(TblFriends friends, int logId);
        List<TblFriends> SelectAllFriendss();
        TblFriends SelectFriendsById(int id);
        List<TblFriends> SelectFriendsByMeId(int meId);
        List<TblFriends> SelectFriendsByFriendId(int friendId);
        List<TblFriends> SelectFriendsByFriendIdAndMeId(int friendId, int meId);

    }
}