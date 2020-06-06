namespace PropSell.Models.Regular
{
    public class TblProvince
    {
        public int id { get; set; }
        public string Name { get; set; }

        public TblProvince(int id)
        {
            this.id = id;
        }

		public TblProvince(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        public TblProvince(string name)
        {
            Name = name;
        }

        public TblProvince()
        {
            
        }
    }
}