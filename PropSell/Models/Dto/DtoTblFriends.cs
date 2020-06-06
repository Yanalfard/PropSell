using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblFriends
    {
        public int id { get; set; }
        public int MeId { get; set; }
        public int FriendId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblFriends ToRegular()
        {
            return new TblFriends(id, MeId, FriendId);
        }

        public DtoTblFriends(TblFriends friends, HttpStatusCode statusEffect)
        {
            id = friends.id;
            MeId = friends.MeId;
            FriendId = friends.FriendId;

            StatusEffect = statusEffect;
        }

        public DtoTblFriends()
        {
        }
    }
}