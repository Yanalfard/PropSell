namespace PropSell.Models.Regular
{
    public class TblPropertyImageRel
    {
        public int id { get; set; }
        public int PropertyId { get; set; }
        public int ImageId { get; set; }

        public TblPropertyImageRel(int id)
        {
            this.id = id;
        }

		public TblPropertyImageRel(int id, int propertyId, int imageId)
        {
            this.id = id;
            PropertyId = propertyId;
            ImageId = imageId;
        }
        public TblPropertyImageRel(int propertyId, int imageId)
        {
            PropertyId = propertyId;
            ImageId = imageId;
        }

        public TblPropertyImageRel()
        {
            
        }
    }
}