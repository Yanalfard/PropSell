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
            return new PropertyRepo().SelectAllPropertys().Where(i => i.Valid).ToList();
        }
        public TblProperty SelectPropertyById(int id)
        {
            return (TblProperty)new PropertyRepo().SelectPropertyById(id);
        }
        public List<TblProperty> SelectPropertyByTitle(string title)
        {
            return new PropertyRepo().SelectPropertyByTitle(title).Where(i => i.Valid).ToList();
        }
        public List<TblProperty> SelectPropertyByValid(bool valid)
        {
            return new PropertyRepo().SelectPropertyByValid(valid).Where(i => i.Valid).ToList();
        }
        public List<TblProperty> SelectPropertyByShowToFriends(bool showToFriends)
        {
            return new PropertyRepo().SelectPropertyByShowToFriends(showToFriends).Where(i => i.Valid).ToList();
        }
        public List<TblProperty> SelectPropertyByUserId(int userId)
        {
            return new PropertyRepo().SelectPropertyByUserId(userId).Where(i => i.Valid).ToList();
        }
        public List<TblProperty> SelectPropertyByCityId(int cityId)
        {
            return new PropertyRepo().SelectPropertyByCityId(cityId).Where(i => i.Valid).ToList();
        }

        public List<TblProperty> SelectLatestProperties(int count)
        {
            return new PropertyRepo().SelectLatestProperties(count).Where(i => i.Valid).ToList();
        }

        public List<TblImage> SelectImagesByPropertyId(int propertyId)
        {
            List<TblPropertyImageRel> stp1 = new PropertyImageRelRepo().SelectPropertyImageRelByPropertyId(propertyId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblPropertyImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }
        public List<TblClient> SelectClientsByPropertyId(int propertyId)
        {
            List<TblPropertyClientRel> stp1 = new PropertyClientRelRepo().SelectPropertyClientRelByPropertyId(propertyId);
            List<TblClient> stp2 = new List<TblClient>();
            foreach (TblPropertyClientRel rel in stp1)
                stp2.Add(new ClientRepo().SelectClientById(rel.PropertyId));
            return stp2;
        }

        public List<TblProperty> SelectFriendsProperties(int meId)
        {
            try
            {
                List<TblProperty> friendsProperties = new List<TblProperty>();
                List<TblFriends> friends = new FriendsRepo().SelectFriendsByMeId(meId);
                foreach (TblFriends friend in friends)
                {
                    List<TblPropertyClientRel> rels =
                        new PropertyClientRelRepo().SelectPropertyClientRelByUserId(friend.MeId);
                    foreach (TblPropertyClientRel rel in rels)
                    {
                        friendsProperties.AddRange(new PropertyRepo().SelectPropertyByUserId(rel.UserId).Where(i => i.ShowToFriends).Where(j => j.Valid));
                    }
                }
                return friendsProperties;
            }
            catch
            {
                return new List<TblProperty>();
            }
        }

        public List<TblProperty> SelectPropertiesByPriceBetween(long min, long max)
        {
            return new PropertyRepo().SelectPropertiesByPriceBetween(min, max);
        }

        public List<TblProperty> SelectPropertyByIsOnFirstPage(bool isOnFirstPage)
        {
            return new PropertyRepo().SelectPropertyByIsOnFirstPage(isOnFirstPage);
        }
    }
}