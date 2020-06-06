using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IDealerRepo
    {
        TblDealer AddDealer(TblDealer dealer);
        bool DeleteDealer(int id);
        bool UpdateDealer(TblDealer dealer, int logId);
        List<TblDealer> SelectAllDealers();
        TblDealer SelectDealerById(int id);
        TblDealer SelectDealerByTellNo(string tellNo);
        List<TblDealer> SelectDealerByIdentification(int identification);
        TblDealer SelectDealerByName(string name);

    }
}