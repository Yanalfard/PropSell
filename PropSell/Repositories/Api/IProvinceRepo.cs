using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IProvinceRepo
    {
        TblProvince AddProvince(TblProvince province);
        bool DeleteProvince(int id);
        bool UpdateProvince(TblProvince province, int logId);
        List<TblProvince> SelectAllProvinces();
        TblProvince SelectProvinceById(int id);
        TblProvince SelectProvinceByName(string name);

    }
}