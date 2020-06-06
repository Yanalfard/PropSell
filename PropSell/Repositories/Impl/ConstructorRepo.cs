using System.Collections.Generic;
using System.Linq;
using PropSell.Models.Regular;
using PropSell.Repositories.Api;
using PropSell.Utilities;

namespace PropSell.Repositories.Impl
{
    public class ConstructorRepo : IConstructorRepo
    {
        public TblConstructor AddConstructor(TblConstructor constructor)
        {
            return (TblConstructor)new MainProvider().Add(constructor);
        }
        public bool DeleteConstructor(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblConstructor, id);
        }
        public bool UpdateConstructor(TblConstructor constructor, int logId)
        {
            return new MainProvider().Update(constructor, logId);
        }
        public List<TblConstructor> SelectAllConstructors()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblConstructor).Cast<TblConstructor>().ToList();
        }
        public TblConstructor SelectConstructorById(int id)
        {
            return (TblConstructor)new MainProvider().SelectById(MainProvider.Tables.TblConstructor, id);
        }
        public TblConstructor SelectConstructorByTellNo(string tellNo)
        {
            return new MainProvider().SelectConstructorByTellNo(tellNo);
        }
        public List<TblConstructor> SelectConstructorByIdentification(int identification)
        {
            return new MainProvider().SelectConstructorByIdentification(identification);
        }

    }
}