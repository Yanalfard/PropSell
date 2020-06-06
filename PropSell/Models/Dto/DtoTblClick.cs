using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblClick
    {
        public int id { get; set; }
        public string Date { get; set; }
        public int PropertyId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblClick ToRegular()
        {
            return new TblClick(id, Date, PropertyId);
        }

        public DtoTblClick(TblClick click, HttpStatusCode statusEffect)
        {
            id = click.id;
            Date = click.Date;
            PropertyId = click.PropertyId;

            StatusEffect = statusEffect;
        }

        public DtoTblClick()
        {
        }
    }
}