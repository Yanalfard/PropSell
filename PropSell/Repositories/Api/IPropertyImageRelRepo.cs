using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IPropertyImageRelRepo
    {
        TblPropertyImageRel AddPropertyImageRel(TblPropertyImageRel propertyImageRel);
        bool DeletePropertyImageRel(int id);
        bool UpdatePropertyImageRel(TblPropertyImageRel propertyImageRel, int logId);
        List<TblPropertyImageRel> SelectAllPropertyImageRels();
        TblPropertyImageRel SelectPropertyImageRelById(int id);
        List<TblPropertyImageRel> SelectPropertyImageRelByPropertyId(int propertyId);
        List<TblPropertyImageRel> SelectPropertyImageRelByImageId(int imageId);

    }
}