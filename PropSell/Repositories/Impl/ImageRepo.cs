using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class ImageRepo : IImageRepo
    {
        public TblImage AddImage(TblImage image)
        {
            return (TblImage)new MainProvider().Add(image);
        }
        public bool DeleteImage(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblImage, id);
        }
        public bool UpdateImage(TblImage image, int logId)
        {
            return new MainProvider().Update(image, logId);
        }
        public List<TblImage> SelectAllImages()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblImage).Cast<TblImage>().ToList();
        }
        public TblImage SelectImageById(int id)
        {
            return (TblImage)new MainProvider().SelectById(MainProvider.Tables.TblImage, id);
        }
        public TblImage SelectImageByName(string name)
        {
            return new MainProvider().SelectImageByName(name);
        }

    }
}