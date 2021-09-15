﻿using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISessionDal : IEntityRepository<Session>
    {
        //Custom Operations
        public bool AddAll(Session[] entitySave);
        public bool UpdateAll(Session[] entitySave, Session[] entityDelete);
        public bool DeleteAll(Session[] entityDelete);
    }
}
