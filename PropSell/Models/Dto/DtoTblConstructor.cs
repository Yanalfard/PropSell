using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblConstructor
    {
        public int id { get; set; }
        public string TellNo { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblConstructor ToRegular()
        {
            return new TblConstructor(id, TellNo, Identification, Address);
        }

        public DtoTblConstructor(TblConstructor constructor, HttpStatusCode statusEffect)
        {
            id = constructor.id;
            TellNo = constructor.TellNo;
            Identification = constructor.Identification;
            Address = constructor.Address;

            StatusEffect = statusEffect;
        }

        public DtoTblConstructor()
        {
        }
    }
}