using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblPropertyClientRel
    {
        public int id { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblPropertyClientRel ToRegular()
        {
            return new TblPropertyClientRel(id, PropertyId, UserId, Status);
        }

        public DtoTblPropertyClientRel(TblPropertyClientRel propertyClientRel, HttpStatusCode statusEffect)
        {
            id = propertyClientRel.id;
            PropertyId = propertyClientRel.PropertyId;
            UserId = propertyClientRel.UserId;
            Status = propertyClientRel.Status;

            StatusEffect = statusEffect;
        }

        public DtoTblPropertyClientRel()
        {
        }
    }
}