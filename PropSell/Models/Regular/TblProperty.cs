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
        public int CityId { get; set; }
        public string Neighborhood { get; set; }

        public TblProperty(int id)
        {
            this.id = id;
        }

		public TblProperty(int id, string title, string description, bool valid, bool showToFriends, int userId, int cityId, string neighborhood)
        {
            this.id = id;
            Title = title;
            Description = description;
            Valid = valid;
            ShowToFriends = showToFriends;
            UserId = userId;
            CityId = cityId;
            Neighborhood = neighborhood;
        }
        public TblProperty(string title, string description, bool valid, bool showToFriends, int userId, int cityId, string neighborhood)
        {
            Title = title;
            Description = description;
            Valid = valid;
            ShowToFriends = showToFriends;
            UserId = userId;
            CityId = cityId;
            Neighborhood = neighborhood;
        }

        public TblProperty()
        {
            
        }
    }
}