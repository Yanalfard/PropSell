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
        TblProperty SelectPropertyByTitle(string title);
        List<TblProperty> SelectPropertyByValid(bool valid);
        List<TblProperty> SelectPropertyByShowToFriends(bool showToFriends);
        List<TblProperty> SelectPropertyByUserId(int userId);

    }
}