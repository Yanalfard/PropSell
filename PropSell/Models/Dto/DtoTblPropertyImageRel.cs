using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblPropertyImageRel
    {
        public int id { get; set; }
        public int PropertyId { get; set; }
        public int ImageId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblPropertyImageRel ToRegular()
        {
            return new TblPropertyImageRel(id, PropertyId, ImageId);
        }

        public DtoTblPropertyImageRel(TblPropertyImageRel propertyImageRel, HttpStatusCode statusEffect)
        {
            id = propertyImageRel.id;
            PropertyId = propertyImageRel.PropertyId;
            ImageId = propertyImageRel.ImageId;

            StatusEffect = statusEffect;
        }

        public DtoTblPropertyImageRel()
        {
        }
    }
}