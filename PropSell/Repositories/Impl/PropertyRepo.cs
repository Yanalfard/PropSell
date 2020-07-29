using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class PropertyRepo : IPropertyRepo
    {
        public TblProperty AddProperty(TblProperty property)
        {
            return (TblProperty)new MainProvider().Add(property);
        }
        public bool DeleteProperty(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblProperty, id);
        }
        public bool UpdateProperty(TblProperty property, int logId)
        {
            return new MainProvider().Update(property, logId);
        }
        public List<TblProperty> SelectAllPropertys()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblProperty).Cast<TblProperty>().ToList();
        }
        public TblProperty SelectPropertyById(int id)
        {
            return (TblProperty)new MainProvider().SelectById(MainProvider.Tables.TblProperty, id);
        }
        public List<TblProperty> SelectPropertyByTitle(string title)
        {
            return new MainProvider().SelectPropertyByTitle(title);
        }
        public List<TblProperty> SelectPropertyByValid(bool valid)
        {
            return new MainProvider().SelectPropertyByValid(valid);
        }
        public List<TblProperty> SelectPropertyByShowToFriends(bool showToFriends)
        {
            return new MainProvider().SelectPropertyByShowToFriends(showToFriends);
        }
        public List<TblProperty> SelectPropertyByUserId(int userId)
        {
            return new MainProvider().SelectPropertyByUserId(userId);
        }
        public List<TblProperty> SelectPropertyByCityId(int cityId)
        {
            return new MainProvider().SelectPropertyByCityId(cityId);
        }

        public List<TblProperty> SelectLatestProperties(int count)
        {
            return new MainProvider().SelectLatestProperties(count);
        }

        public List<TblProperty> SelectPropertiesByPriceBetween(long min, long max)
        {
            return new MainProvider().SelectPropertiesByPriceBetween(min, max);
        }

        public List<TblProperty> SelectPropertyByIsOnFirstPage(bool isOnFirstPage)
        {
            return new MainProvider().SelectPropertyByIsOnFirstPage(isOnFirstPage);
        }
    }
}