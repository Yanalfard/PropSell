using System.Collections.Generic;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;

namespace PropSell.Services.Api
{
    public interface IPropertyService : IPropertyRepo
    {
        List<TblImage> SelectImagesByPropertyId(int propertyId);
        List<TblClient> SelectClientsByPropertyId(int propertyId);
        List<TblProperty> SelectFriendsProperties(int meId);
    }
}