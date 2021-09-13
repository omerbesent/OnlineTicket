using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserSelectedSeatService
    {
        List<UserSelectedSeat> GetAll();
        UserSelectedSeat Get(int userSelectedSeatId);
        List<UserSelectedSeat> GetBySessionId(string sessionId, int eventId, string session);
        UserSelectedSeat GetBySeat(string sessionId, int eventId, string session, string seat);
        void Add(UserSelectedSeat userSelectedSeat);
        void Update(UserSelectedSeat userSelectedSeat);
        void Delete(int userSelectedSeatId);
        void CheckAndDeleteSession(int eventId, string session);
        bool CheckSeat(int eventId, string session, string seat);
        void UpdateDeletionTime(string sessionId, int? userId, int eventId, string session);
    }
}
