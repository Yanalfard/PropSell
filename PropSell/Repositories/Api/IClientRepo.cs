using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IClientRepo
    {
        TblClient AddClient(TblClient client);
        bool DeleteClient(int id);
        bool UpdateClient(TblClient client, int logId);
        List<TblClient> SelectAllClients();
        TblClient SelectClientById(int id);
        TblClient SelectClientByTellNo(string tellNo);
        List<TblClient> SelectClientByIdentification(int identification);
        List<TblClient> SelectClientByTellNoLike(string tellNo);
    }
}