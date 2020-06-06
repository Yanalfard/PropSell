namespace PropSell.Models.Regular
{
    public class TblImage
    {
        public int id { get; set; }
        public string Name { get; set; }

        public TblImage(int id)
        {
            this.id = id;
        }

		public TblImage(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        public TblImage(string name)
        {
            Name = name;
        }

        public TblImage()
        {
            
        }
    }
}