using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblImage
    {
        public int id { get; set; }
        public string Name { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblImage ToRegular()
        {
            return new TblImage(id, Name);
        }

        public DtoTblImage(TblImage image, HttpStatusCode statusEffect)
        {
            id = image.id;
            Name = image.Name;

            StatusEffect = statusEffect;
        }

        public DtoTblImage()
        {
        }
    }
}