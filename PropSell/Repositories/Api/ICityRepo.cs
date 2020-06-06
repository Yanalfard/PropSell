using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface ICityRepo
    {
        TblCity AddCity(TblCity city);
        bool DeleteCity(int id);
        bool UpdateCity(TblCity city, int logId);
        List<TblCity> SelectAllCitys();
        TblCity SelectCityById(int id);
        TblCity SelectCityByName(string name);
        List<TblCity> SelectCityByProvinceId(int provinceId);

    }
}