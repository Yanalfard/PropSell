using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class DealerService : IDealerService
    {
        public TblDealer AddDealer(TblDealer dealer)
        {
            return (TblDealer)new DealerRepo().AddDealer(dealer);
        }
        public bool DeleteDealer(int id)
        {
            return new DealerRepo().DeleteDealer(id);
        }
        public bool UpdateDealer(TblDealer dealer, int logId)
        {
            return new DealerRepo().UpdateDealer(dealer, logId);
        }
        public List<TblDealer> SelectAllDealers()
        {
            return new DealerRepo().SelectAllDealers();
        }
        public TblDealer SelectDealerById(int id)
        {
            return (TblDealer)new DealerRepo().SelectDealerById(id);
        }
        public TblDealer SelectDealerByTellNo(string tellNo)
        {
            return new DealerRepo().SelectDealerByTellNo(tellNo);
        }
        public List<TblDealer> SelectDealerByIdentification(int identification)
        {
            return new DealerRepo().SelectDealerByIdentification(identification);
        }
        public TblDealer SelectDealerByName(string name)
        {
            return new DealerRepo().SelectDealerByName(name);
        }

    }
}