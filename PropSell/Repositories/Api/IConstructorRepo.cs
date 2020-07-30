using System.Collections.Generic;
using PropSell.Models.Regular;

namespace PropSell.Repositories.Api
{
    public interface IConstructorRepo
    {
        TblConstructor AddConstructor(TblConstructor constructor);
        bool DeleteConstructor(int id);
        bool UpdateConstructor(TblConstructor constructor, int logId);
        List<TblConstructor> SelectAllConstructors();
        TblConstructor SelectConstructorById(int id);
        TblConstructor SelectConstructorByTellNo(string tellNo);
        List<TblConstructor> SelectConstructorByIdentification(int identification);
        List<TblConstructor> SelectConstructorByTellNoLike(string tellNo);

    }
}