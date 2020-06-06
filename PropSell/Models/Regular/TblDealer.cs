namespace PropSell.Models.Regular
{
    public class TblDealer
    {
        public int id { get; set; }
        public string TellNo { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public TblDealer(int id)
        {
            this.id = id;
        }

		public TblDealer(int id, string tellNo, string identification, string address, string name)
        {
            this.id = id;
            TellNo = tellNo;
            Identification = identification;
            Address = address;
            Name = name;
        }
        public TblDealer(string tellNo, string identification, string address, string name)
        {
            TellNo = tellNo;
            Identification = identification;
            Address = address;
            Name = name;
        }

        public TblDealer()
        {
            
        }
    }
}