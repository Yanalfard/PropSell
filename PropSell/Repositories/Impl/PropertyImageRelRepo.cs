using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class PropertyImageRelRepo : IPropertyImageRelRepo
    {
        public TblPropertyImageRel AddPropertyImageRel(TblPropertyImageRel propertyImageRel)
        {
            return (TblPropertyImageRel)new MainProvider().Add(propertyImageRel);
        }
        public bool DeletePropertyImageRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPropertyImageRel, id);
        }
        public bool UpdatePropertyImageRel(TblPropertyImageRel propertyImageRel, int logId)
        {
            return new MainProvider().Update(propertyImageRel, logId);
        }
        public List<TblPropertyImageRel> SelectAllPropertyImageRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPropertyImageRel).Cast<TblPropertyImageRel>().ToList();
        }
        public TblPropertyImageRel SelectPropertyImageRelById(int id)
        {
            return (TblPropertyImageRel)new MainProvider().SelectById(MainProvider.Tables.TblPropertyImageRel, id);
        }
        public List<TblPropertyImageRel> SelectPropertyImageRelByPropertyId(int propertyId)
        {
            return new MainProvider().SelectPropertyImageRel(propertyId, MainProvider.PropertyImageRel.PropertyId);
        }
        public List<TblPropertyImageRel> SelectPropertyImageRelByImageId(int imageId)
        {
            return new MainProvider().SelectPropertyImageRel(imageId, MainProvider.PropertyImageRel.ImageId);
        }

    }
}