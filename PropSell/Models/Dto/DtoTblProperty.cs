using System.Net;
using PropSell.Models.Regular;

namespace PropSell.Models.Dto
{
    public class DtoTblProperty
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Valid { get; set; }
        public bool ShowToFriends { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string Neighborhood { get; set; }
        public long Price { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblProperty ToRegular()
        {
            return new TblProperty(id, Title, Description, Valid, ShowToFriends, UserId, CityId, Neighborhood, Price);
        }

        public DtoTblProperty(TblProperty property, HttpStatusCode statusEffect)
        {
            id = property.id;
            Title = property.Title;
            Description = property.Description;
            Valid = property.Valid;
            ShowToFriends = property.ShowToFriends;
            UserId = property.UserId;
            CityId = property.CityId;
            Neighborhood = property.Neighborhood;
            Price = property.Price;
            StatusEffect = statusEffect;
        }

        public DtoTblProperty()
        {
        }
    }
}