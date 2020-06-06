using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblDealer
    {
        public int id { get; set; }
        public string TellNo { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblDealer ToRegular()
        {
            return new TblDealer(id, TellNo, Identification, Address, Name);
        }

        public DtoTblDealer(TblDealer dealer, HttpStatusCode statusEffect)
        {
            id = dealer.id;
            TellNo = dealer.TellNo;
            Identification = dealer.Identification;
            Address = dealer.Address;
            Name = dealer.Name;

            StatusEffect = statusEffect;
        }

        public DtoTblDealer()
        {
        }
    }
}