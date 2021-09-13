using Core.DataAccess;
using Entities.Concrete;

namespace OnlineTicket.DataAccess.Abstract
{
    public interface ISessionDal : IEntityRepository<Session>
    {
        //Custom Operations
        public bool AddAll(Session[] entitySave);
        public bool UpdateAll(Session[] entitySave, Session[] entityDelete);
    }
}
