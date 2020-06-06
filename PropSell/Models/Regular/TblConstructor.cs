namespace PropSell.Models.Regular
{
    public class TblConstructor
    {
        public int id { get; set; }
        public string TellNo { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }

        public TblConstructor(int id)
        {
            this.id = id;
        }

		public TblConstructor(int id, string tellNo, string identification, string address)
        {
            this.id = id;
            TellNo = tellNo;
            Identification = identification;
            Address = address;
        }
        public TblConstructor(string tellNo, string identification, string address)
        {
            TellNo = tellNo;
            Identification = identification;
            Address = address;
        }

        public TblConstructor()
        {
            
        }
    }
}