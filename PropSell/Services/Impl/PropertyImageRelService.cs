using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class PropertyImageRelService : IPropertyImageRelService
    {
        public TblPropertyImageRel AddPropertyImageRel(TblPropertyImageRel propertyImageRel)
        {
            return (TblPropertyImageRel)new PropertyImageRelRepo().AddPropertyImageRel(propertyImageRel);
        }
        public bool DeletePropertyImageRel(int id)
        {
            return new PropertyImageRelRepo().DeletePropertyImageRel(id);
        }
        public bool UpdatePropertyImageRel(TblPropertyImageRel propertyImageRel, int logId)
        {
            return new PropertyImageRelRepo().UpdatePropertyImageRel(propertyImageRel, logId);
        }
        public List<TblPropertyImageRel> SelectAllPropertyImageRels()
        {
            return new PropertyImageRelRepo().SelectAllPropertyImageRels();
        }
        public TblPropertyImageRel SelectPropertyImageRelById(int id)
        {
            return (TblPropertyImageRel)new PropertyImageRelRepo().SelectPropertyImageRelById(id);
        }
        public List<TblPropertyImageRel> SelectPropertyImageRelByPropertyId(int propertyId)
        {
            return new PropertyImageRelRepo().SelectPropertyImageRelByPropertyId(propertyId);
        }
        public List<TblPropertyImageRel> SelectPropertyImageRelByImageId(int imageId)
        {
            return new PropertyImageRelRepo().SelectPropertyImageRelByImageId(imageId);
        }

    }
}