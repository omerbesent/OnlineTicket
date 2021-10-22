using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserSelectedSeatService
    {
        IDataResult<List<UserSelectedSeat>> GetAll();
        IDataResult<UserSelectedSeat> Get(int userSelectedSeatId);
        IDataResult<List<UserSelectedSeat>> GetBySessionId(string sessionId, int eventId, string session);
        IDataResult<UserSelectedSeat> GetBySeat(string sessionId, int eventId, string session, string seat);
        IResult Add(UserSelectedSeat userSelectedSeat);
        IResult Update(UserSelectedSeat userSelectedSeat);
        IResult Delete(int userSelectedSeatId);
        IResult CheckAndDeleteSession(int eventId, string session);
        IDataResult<bool> CheckSeat(int eventId, string session, string seat);
        IResult UpdateDeletionTime(string sessionId, int? userId, int eventId, string session);
    }
}
