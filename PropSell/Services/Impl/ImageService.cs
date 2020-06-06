using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class ImageService : IImageService
    {
        public TblImage AddImage(TblImage image)
        {
            return (TblImage)new ImageRepo().AddImage(image);
        }
        public bool DeleteImage(int id)
        {
            return new ImageRepo().DeleteImage(id);
        }
        public bool UpdateImage(TblImage image, int logId)
        {
            return new ImageRepo().UpdateImage(image, logId);
        }
        public List<TblImage> SelectAllImages()
        {
            return new ImageRepo().SelectAllImages();
        }
        public TblImage SelectImageById(int id)
        {
            return (TblImage)new ImageRepo().SelectImageById(id);
        }
        public TblImage SelectImageByName(string name)
        {
            return new ImageRepo().SelectImageByName(name);
        }

    }
}