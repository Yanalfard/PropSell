using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class PropertyService : IPropertyService
    {
        public TblProperty AddProperty(TblProperty property)
        {
            return (TblProperty)new PropertyRepo().AddProperty(property);
        }
        public bool DeleteProperty(int id)
        {
            return new PropertyRepo().DeleteProperty(id);
        }
        public bool UpdateProperty(TblProperty property, int logId)
        {
            return new PropertyRepo().UpdateProperty(property, logId);
        }
        public List<TblProperty> SelectAllPropertys()
        {
            return new PropertyRepo().SelectAllPropertys();
        }
        public TblProperty SelectPropertyById(int id)
        {
            return (TblProperty)new PropertyRepo().SelectPropertyById(id);
        }
        public TblProperty SelectPropertyByTitle(string title)
        {
            return new PropertyRepo().SelectPropertyByTitle(title);
        }
        public List<TblProperty> SelectPropertyByValid(bool valid)
        {
            return new PropertyRepo().SelectPropertyByValid(valid);
        }
        public List<TblProperty> SelectPropertyByShowToFriends(bool showToFriends)
        {
            return new PropertyRepo().SelectPropertyByShowToFriends(showToFriends);
        }
        public List<TblProperty> SelectPropertyByUserId(int userId)
        {
            return new PropertyRepo().SelectPropertyByUserId(userId);
        }
        public List<TblImage>SelectImagesByPropertyId(int propertyId)
        {
            List<TblPropertyImageRel> stp1 = new PropertyImageRelRepo().SelectPropertyImageRelByPropertyId(propertyId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblPropertyImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }
        public List<TblClient>SelectClientsByPropertyId(int propertyId)
        {
            List<TblPropertyClientRel> stp1 = new PropertyClientRelRepo().SelectPropertyClientRelByPropertyId(propertyId);
            List<TblClient> stp2 = new List<TblClient>();
            foreach (TblPropertyClientRel rel in stp1)
                stp2.Add(new ClientRepo().SelectClientById(rel.PropertyId));
            return stp2;
        }

    }
}