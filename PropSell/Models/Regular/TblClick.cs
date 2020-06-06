namespace PropSell.Models.Regular
{
    public class TblClick
    {
        public int id { get; set; }
        public string Date { get; set; }
        public int PropertyId { get; set; }

        public TblClick(int id)
        {
            this.id = id;
        }

		public TblClick(int id, string date, int propertyId)
        {
            this.id = id;
            Date = date;
            PropertyId = propertyId;
        }
        public TblClick(string date, int propertyId)
        {
            Date = date;
            PropertyId = propertyId;
        }

        public TblClick()
        {
            
        }
    }
}