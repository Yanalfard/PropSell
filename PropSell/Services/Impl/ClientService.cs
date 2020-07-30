using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class ClientService : IClientService
    {
        public TblClient AddClient(TblClient client)
        {
            return (TblClient)new ClientRepo().AddClient(client);
        }
        public bool DeleteClient(int id)
        {
            return new ClientRepo().DeleteClient(id);
        }
        public bool UpdateClient(TblClient client, int logId)
        {
            return new ClientRepo().UpdateClient(client, logId);
        }
        public List<TblClient> SelectAllClients()
        {
            return new ClientRepo().SelectAllClients();
        }
        public TblClient SelectClientById(int id)
        {
            return (TblClient)new ClientRepo().SelectClientById(id);
        }
        public TblClient SelectClientByTellNo(string tellNo)
        {
            return new ClientRepo().SelectClientByTellNo(tellNo);
        }
        public List<TblClient> SelectClientByIdentification(int identification)
        {
            return new ClientRepo().SelectClientByIdentification(identification);
        }

        public List<TblClient> SelectClientByTellNoLike(string tellNo)
        {
            return new ClientRepo().SelectClientByTellNoLike(tellNo);
        }
    }
}