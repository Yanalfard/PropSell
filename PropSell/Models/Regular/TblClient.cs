namespace PropSell.Models.Regular
{
    public class TblClient
    {
        public int id { get; set; }
        public string TellNo { get; set; }
        public string Identification { get; set; }

        public TblClient(int id)
        {
            this.id = id;
        }

		public TblClient(int id, string tellNo, string identification)
        {
            this.id = id;
            TellNo = tellNo;
            Identification = identification;
        }
        public TblClient(string tellNo, string identification)
        {
            TellNo = tellNo;
            Identification = identification;
        }

        public TblClient()
        {
            
        }
    }
}