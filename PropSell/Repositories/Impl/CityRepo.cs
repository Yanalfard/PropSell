using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class CityRepo : ICityRepo
    {
        public TblCity AddCity(TblCity city)
        {
            return (TblCity)new MainProvider().Add(city);
        }
        public bool DeleteCity(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblCity, id);
        }
        public bool UpdateCity(TblCity city, int logId)
        {
            return new MainProvider().Update(city, logId);
        }
        public List<TblCity> SelectAllCitys()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblCity).Cast<TblCity>().ToList();
        }
        public TblCity SelectCityById(int id)
        {
            return (TblCity)new MainProvider().SelectById(MainProvider.Tables.TblCity, id);
        }
        public TblCity SelectCityByName(string name)
        {
            return new MainProvider().SelectCityByName(name);
        }
        public List<TblCity> SelectCityByProvinceId(int provinceId)
        {
            return new MainProvider().SelectCityByProvinceId(provinceId);
        }

    }
}