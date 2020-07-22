namespace PropSell.Models.Regular
{
    public class TblPropertyClientRel
    {
        public int id { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string PostDate { get; set; }

        public TblPropertyClientRel(int id)
        {
            this.id = id;
        }

        public TblPropertyClientRel(int id, int propertyId, int userId, int status, string postDate)
        {
            this.id = id;
            PropertyId = propertyId;
            UserId = userId;
            Status = status;
            PostDate = postDate;
        }
        public TblPropertyClientRel(int propertyId, int userId, int status, string postDate)
        {
            PropertyId = propertyId;
            UserId = userId;
            Status = status;
            PostDate = postDate;
        }

        public TblPropertyClientRel()
        {

        }
    }
}