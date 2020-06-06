using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblCity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblCity ToRegular()
        {
            return new TblCity(id, Name, ProvinceId);
        }

        public DtoTblCity(TblCity city, HttpStatusCode statusEffect)
        {
            id = city.id;
            Name = city.Name;
            ProvinceId = city.ProvinceId;

            StatusEffect = statusEffect;
        }

        public DtoTblCity()
        {
        }
    }
}