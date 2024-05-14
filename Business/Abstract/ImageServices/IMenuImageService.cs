﻿using Core.Entities.Concrete;
using Core.Utilites.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract.ImageServices
{
	public interface IMenuImageService
	{
		IDataResult<List<MenuImage>> GetAll();
		IDataResult<MenuImage> GetByImageId(int id);
		IDataResult<MenuImage> GetImageByMenuId(int menuId);
		IResult Add(IFormFile file, MenuImage menuImage);
		IResult Update(IFormFile file, MenuImage menuImage);
		IResult Remove(MenuImage menuImage);
		IResult AddMenuEntity(MenuImage menuImage);
	}
}