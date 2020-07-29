using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IPropertyRepo
    {
        TblProperty AddProperty(TblProperty property);
        bool DeleteProperty(int id);
        bool UpdateProperty(TblProperty property, int logId);
        List<TblProperty> SelectAllPropertys();
        TblProperty SelectPropertyById(int id);
        List<TblProperty> SelectPropertyByTitle(string title);
        List<TblProperty> SelectPropertyByValid(bool valid);
        List<TblProperty> SelectPropertyByShowToFriends(bool showToFriends);
        List<TblProperty> SelectPropertyByUserId(int userId);
        List<TblProperty> SelectPropertyByCityId(int cityId);
        List<TblProperty> SelectLatestProperties(int count);
        List<TblProperty> SelectPropertiesByPriceBetween(long min, long max);
        List<TblProperty> SelectPropertyByIsOnFirstPage(bool isOnFirstPage);


    }
}