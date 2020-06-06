using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class ProvinceRepo : IProvinceRepo
    {
        public TblProvince AddProvince(TblProvince province)
        {
            return (TblProvince)new MainProvider().Add(province);
        }
        public bool DeleteProvince(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblProvince, id);
        }
        public bool UpdateProvince(TblProvince province, int logId)
        {
            return new MainProvider().Update(province, logId);
        }
        public List<TblProvince> SelectAllProvinces()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblProvince).Cast<TblProvince>().ToList();
        }
        public TblProvince SelectProvinceById(int id)
        {
            return (TblProvince)new MainProvider().SelectById(MainProvider.Tables.TblProvince, id);
        }
        public TblProvince SelectProvinceByName(string name)
        {
            return new MainProvider().SelectProvinceByName(name);
        }

    }
}