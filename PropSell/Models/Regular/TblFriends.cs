namespace PropSell.Models.Regular
{
    public class TblFriends
    {
        public int id { get; set; }
        public int MeId { get; set; }
        public int FriendId { get; set; }
        public int Status { get; set; }

        public TblFriends(int id)
        {
            this.id = id;
        }

        public TblFriends(int id, int meId, int friendId, int status)
        {
            this.id = id;
            MeId = meId;
            FriendId = friendId;
            Status = status;
        }
        public TblFriends(int meId, int friendId)
        {
            MeId = meId;
            FriendId = friendId;
        }

        public TblFriends()
        {

        }
    }
}