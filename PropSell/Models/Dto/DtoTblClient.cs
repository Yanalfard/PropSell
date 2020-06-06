using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblClient
    {
        public int id { get; set; }
        public string TellNo { get; set; }
        public string Identification { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblClient ToRegular()
        {
            return new TblClient(id, TellNo, Identification);
        }

        public DtoTblClient(TblClient client, HttpStatusCode statusEffect)
        {
            id = client.id;
            TellNo = client.TellNo;
            Identification = client.Identification;

            StatusEffect = statusEffect;
        }

        public DtoTblClient()
        {
        }
    }
}