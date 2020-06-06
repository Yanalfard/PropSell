using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IClickRepo
    {
        TblClick AddClick(TblClick click);
        bool DeleteClick(int id);
        bool UpdateClick(TblClick click, int logId);
        List<TblClick> SelectAllClicks();
        TblClick SelectClickById(int id);
        List<TblClick> SelectClickByPropertyId(int propertyId);

    }
}