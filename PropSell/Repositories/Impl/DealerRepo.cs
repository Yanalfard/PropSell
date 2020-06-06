using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class DealerRepo : IDealerRepo
    {
        public TblDealer AddDealer(TblDealer dealer)
        {
            return (TblDealer)new MainProvider().Add(dealer);
        }
        public bool DeleteDealer(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblDealer, id);
        }
        public bool UpdateDealer(TblDealer dealer, int logId)
        {
            return new MainProvider().Update(dealer, logId);
        }
        public List<TblDealer> SelectAllDealers()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblDealer).Cast<TblDealer>().ToList();
        }
        public TblDealer SelectDealerById(int id)
        {
            return (TblDealer)new MainProvider().SelectById(MainProvider.Tables.TblDealer, id);
        }
        public TblDealer SelectDealerByTellNo(string tellNo)
        {
            return new MainProvider().SelectDealerByTellNo(tellNo);
        }
        public List<TblDealer> SelectDealerByIdentification(int identification)
        {
            return new MainProvider().SelectDealerByIdentification(identification);
        }
        public TblDealer SelectDealerByName(string name)
        {
            return new MainProvider().SelectDealerByName(name);
        }

    }
}