﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCountyDal : EfEntityRepositoryBase<County, OnlineTicketContext>, ICountyDal
    {

    }
}
