using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class ClientRepo : IClientRepo
    {
        public TblClient AddClient(TblClient client)
        {
            return (TblClient)new MainProvider().Add(client);
        }
        public bool DeleteClient(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblClient, id);
        }
        public bool UpdateClient(TblClient client, int logId)
        {
            return new MainProvider().Update(client, logId);
        }
        public List<TblClient> SelectAllClients()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblClient).Cast<TblClient>().ToList();
        }
        public TblClient SelectClientById(int id)
        {
            return (TblClient)new MainProvider().SelectById(MainProvider.Tables.TblClient, id);
        }
        public TblClient SelectClientByTellNo(string tellNo)
        {
            return new MainProvider().SelectClientByTellNo(tellNo);
        }
        public List<TblClient> SelectClientByIdentification(int identification)
        {
            return new MainProvider().SelectClientByIdentification(identification);
        }

        public List<TblClient> SelectClientByTellNoLike(string tellNo)
        {
            return new MainProvider().SelectClientByTellNoLike(tellNo);
        }
    }
}