﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSessionDal : EfEntityRepositoryBase<Session, OnlineTicketContext>, ISessionDal
    {
        public bool AddAll(Session[] entitySave)
        {
            using (var context = new OnlineTicketContext())
            {
                context.AddRange(entitySave);
                context.SaveChanges();

                return true;
            }
        }
         
        public bool DeleteAll(Session[] entityDelete)
        {
            using (var context = new OnlineTicketContext())
            {
                context.RemoveRange(entityDelete);
                context.SaveChanges();

                return true;
            }
        }
    }
}
