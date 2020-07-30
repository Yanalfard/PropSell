using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSell.Models.Regular;
using PropSell.Repositories.Impl;
using PropSell.Services.Api;

namespace PropSell.Services.Impl
{
    public class ConstructorService : IConstructorService
    {
        public TblConstructor AddConstructor(TblConstructor constructor)
        {
            return (TblConstructor)new ConstructorRepo().AddConstructor(constructor);
        }
        public bool DeleteConstructor(int id)
        {
            return new ConstructorRepo().DeleteConstructor(id);
        }
        public bool UpdateConstructor(TblConstructor constructor, int logId)
        {
            return new ConstructorRepo().UpdateConstructor(constructor, logId);
        }
        public List<TblConstructor> SelectAllConstructors()
        {
            return new ConstructorRepo().SelectAllConstructors();
        }
        public TblConstructor SelectConstructorById(int id)
        {
            return (TblConstructor)new ConstructorRepo().SelectConstructorById(id);
        }
        public TblConstructor SelectConstructorByTellNo(string tellNo)
        {
            return new ConstructorRepo().SelectConstructorByTellNo(tellNo);
        }
        public List<TblConstructor> SelectConstructorByIdentification(int identification)
        {
            return new ConstructorRepo().SelectConstructorByIdentification(identification);
        }

        public List<TblConstructor> SelectConstructorByTellNoLike(string tellNo)
        {
            return new ConstructorRepo().SelectConstructorByTellNoLike(tellNo);
        }
    }
}