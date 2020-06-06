using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class ClickService : IClickService
    {
        public TblClick AddClick(TblClick click)
        {
            return (TblClick)new ClickRepo().AddClick(click);
        }
        public bool DeleteClick(int id)
        {
            return new ClickRepo().DeleteClick(id);
        }
        public bool UpdateClick(TblClick click, int logId)
        {
            return new ClickRepo().UpdateClick(click, logId);
        }
        public List<TblClick> SelectAllClicks()
        {
            return new ClickRepo().SelectAllClicks();
        }
        public TblClick SelectClickById(int id)
        {
            return (TblClick)new ClickRepo().SelectClickById(id);
        }
        public List<TblClick> SelectClickByPropertyId(int propertyId)
        {
            return new ClickRepo().SelectClickByPropertyId(propertyId);
        }

    }
}