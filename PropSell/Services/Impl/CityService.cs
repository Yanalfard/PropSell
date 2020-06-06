using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class CityService : ICityService
    {
        public TblCity AddCity(TblCity city)
        {
            return (TblCity)new CityRepo().AddCity(city);
        }
        public bool DeleteCity(int id)
        {
            return new CityRepo().DeleteCity(id);
        }
        public bool UpdateCity(TblCity city, int logId)
        {
            return new CityRepo().UpdateCity(city, logId);
        }
        public List<TblCity> SelectAllCitys()
        {
            return new CityRepo().SelectAllCitys();
        }
        public TblCity SelectCityById(int id)
        {
            return (TblCity)new CityRepo().SelectCityById(id);
        }
        public TblCity SelectCityByName(string name)
        {
            return new CityRepo().SelectCityByName(name);
        }
        public List<TblCity> SelectCityByProvinceId(int provinceId)
        {
            return new CityRepo().SelectCityByProvinceId(provinceId);
        }

    }
}