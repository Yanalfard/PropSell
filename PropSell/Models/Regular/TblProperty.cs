namespace PropSell.Models.Regular
{
    public class TblProperty
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Valid { get; set; }
        public bool ShowToFriends { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }

        public TblProperty(int id)
        {
            this.id = id;
        }

		public TblProperty(int id, string title, string description, bool valid, bool showToFriends, int userId, int status)
        {
            this.id = id;
            Title = title;
            Description = description;
            Valid = valid;
            ShowToFriends = showToFriends;
            UserId = userId;
            Status = status;
        }
        public TblProperty(string title, string description, bool valid, bool showToFriends, int userId, int status)
        {
            Title = title;
            Description = description;
            Valid = valid;
            ShowToFriends = showToFriends;
            UserId = userId;
            Status = status;
        }

        public TblProperty()
        {
            
        }
    }
}