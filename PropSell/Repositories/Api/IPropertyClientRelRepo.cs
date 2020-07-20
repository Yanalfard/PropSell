using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IPropertyClientRelRepo
    {
        TblPropertyClientRel AddPropertyClientRel(TblPropertyClientRel propertyClientRel);
        bool DeletePropertyClientRel(int id);
        bool UpdatePropertyClientRel(TblPropertyClientRel propertyClientRel, int logId);
        List<TblPropertyClientRel> SelectAllPropertyClientRels();
        TblPropertyClientRel SelectPropertyClientRelById(int id);
        List<TblPropertyClientRel> SelectPropertyClientRelByPropertyId(int propertyId);
        List<TblPropertyClientRel> SelectPropertyClientRelByUserId(int userId);

    }
}