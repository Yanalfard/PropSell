using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class PropertyClientRelService : IPropertyClientRelService
    {
        public TblPropertyClientRel AddPropertyClientRel(TblPropertyClientRel propertyClientRel)
        {
            return (TblPropertyClientRel)new PropertyClientRelRepo().AddPropertyClientRel(propertyClientRel);
        }
        public bool DeletePropertyClientRel(int id)
        {
            return new PropertyClientRelRepo().DeletePropertyClientRel(id);
        }
        public bool UpdatePropertyClientRel(TblPropertyClientRel propertyClientRel, int logId)
        {
            return new PropertyClientRelRepo().UpdatePropertyClientRel(propertyClientRel, logId);
        }
        public List<TblPropertyClientRel> SelectAllPropertyClientRels()
        {
            return new PropertyClientRelRepo().SelectAllPropertyClientRels();
        }
        public TblPropertyClientRel SelectPropertyClientRelById(int id)
        {
            return (TblPropertyClientRel)new PropertyClientRelRepo().SelectPropertyClientRelById(id);
        }
        public List<TblPropertyClientRel> SelectPropertyClientRelByPropertyId(int propertyId)
        {
            return new PropertyClientRelRepo().SelectPropertyClientRelByPropertyId(propertyId);
        }
        public List<TblPropertyClientRel> SelectPropertyClientRelByUserId(int userId)
        {
            return new PropertyClientRelRepo().SelectPropertyClientRelByUserId(userId);
        }

    }
}