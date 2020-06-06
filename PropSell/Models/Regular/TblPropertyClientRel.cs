namespace PropSell.Models.Regular
{
    public class TblPropertyClientRel
    {
        public int id { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }

        public TblPropertyClientRel(int id)
        {
            this.id = id;
        }

		public TblPropertyClientRel(int id, int propertyId, int userId, int status)
        {
            this.id = id;
            PropertyId = propertyId;
            UserId = userId;
            Status = status;
        }
        public TblPropertyClientRel(int propertyId, int userId, int status)
        {
            PropertyId = propertyId;
            UserId = userId;
            Status = status;
        }

        public TblPropertyClientRel()
        {
            
        }
    }
}