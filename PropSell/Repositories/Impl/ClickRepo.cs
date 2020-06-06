using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class ClickRepo : IClickRepo
    {
        public TblClick AddClick(TblClick click)
        {
            return (TblClick)new MainProvider().Add(click);
        }
        public bool DeleteClick(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblClick, id);
        }
        public bool UpdateClick(TblClick click, int logId)
        {
            return new MainProvider().Update(click, logId);
        }
        public List<TblClick> SelectAllClicks()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblClick).Cast<TblClick>().ToList();
        }
        public TblClick SelectClickById(int id)
        {
            return (TblClick)new MainProvider().SelectById(MainProvider.Tables.TblClick, id);
        }
        public List<TblClick> SelectClickByPropertyId(int propertyId)
        {
            return new MainProvider().SelectClickByPropertyId(propertyId);
        }

    }
}