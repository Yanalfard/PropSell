using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblProvince
    {
        public int id { get; set; }
        public string Name { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblProvince ToRegular()
        {
            return new TblProvince(id, Name);
        }

        public DtoTblProvince(TblProvince province, HttpStatusCode statusEffect)
        {
            id = province.id;
            Name = province.Name;

            StatusEffect = statusEffect;
        }

        public DtoTblProvince()
        {
        }
    }
}