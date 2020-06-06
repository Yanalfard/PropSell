using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class ProvinceService : IProvinceService
    {
        public TblProvince AddProvince(TblProvince province)
        {
            return (TblProvince)new ProvinceRepo().AddProvince(province);
        }
        public bool DeleteProvince(int id)
        {
            return new ProvinceRepo().DeleteProvince(id);
        }
        public bool UpdateProvince(TblProvince province, int logId)
        {
            return new ProvinceRepo().UpdateProvince(province, logId);
        }
        public List<TblProvince> SelectAllProvinces()
        {
            return new ProvinceRepo().SelectAllProvinces();
        }
        public TblProvince SelectProvinceById(int id)
        {
            return (TblProvince)new ProvinceRepo().SelectProvinceById(id);
        }
        public TblProvince SelectProvinceByName(string name)
        {
            return new ProvinceRepo().SelectProvinceByName(name);
        }

    }
}