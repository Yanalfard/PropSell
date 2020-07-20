using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class PropertyClientRelRepo : IPropertyClientRelRepo
    {
        public TblPropertyClientRel AddPropertyClientRel(TblPropertyClientRel propertyClientRel)
        {
            return (TblPropertyClientRel)new MainProvider().Add(propertyClientRel);
        }
        public bool DeletePropertyClientRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPropertyClientRel, id);
        }
        public bool UpdatePropertyClientRel(TblPropertyClientRel propertyClientRel, int logId)
        {
            return new MainProvider().Update(propertyClientRel, logId);
        }
        public List<TblPropertyClientRel> SelectAllPropertyClientRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPropertyClientRel).Cast<TblPropertyClientRel>().ToList();
        }
        public TblPropertyClientRel SelectPropertyClientRelById(int id)
        {
            return (TblPropertyClientRel)new MainProvider().SelectById(MainProvider.Tables.TblPropertyClientRel, id);
        }
        public List<TblPropertyClientRel> SelectPropertyClientRelByPropertyId(int propertyId)
        {
            return new MainProvider().SelectPropertyClientRel(propertyId, MainProvider.PropertyClientRel.PropertyId);
        }
        public List<TblPropertyClientRel> SelectPropertyClientRelByUserId(int userId)
        {
            return new MainProvider().SelectPropertyClientRel(userId, MainProvider.PropertyClientRel.UserId);
        }

    }
}