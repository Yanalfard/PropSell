namespace PropSell.Models.Regular
{
    public class TblCity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        public TblCity(int id)
        {
            this.id = id;
        }

		public TblCity(int id, string name, int provinceId)
        {
            this.id = id;
            Name = name;
            ProvinceId = provinceId;
        }
        public TblCity(string name, int provinceId)
        {
            Name = name;
            ProvinceId = provinceId;
        }

        public TblCity()
        {
            
        }
    }
}