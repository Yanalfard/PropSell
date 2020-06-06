using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IImageRepo
    {
        TblImage AddImage(TblImage image);
        bool DeleteImage(int id);
        bool UpdateImage(TblImage image, int logId);
        List<TblImage> SelectAllImages();
        TblImage SelectImageById(int id);
        TblImage SelectImageByName(string name);

    }
}