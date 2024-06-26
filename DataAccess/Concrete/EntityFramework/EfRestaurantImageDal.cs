﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRestaurantImageDal : EfEntityRepositoryBase<RestaurantImage, SqlContext>, IRestaurantImageDal
	{
	}
}
