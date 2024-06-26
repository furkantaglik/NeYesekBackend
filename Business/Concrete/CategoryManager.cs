﻿using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilites.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete.DTOs.CategoryDto;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
	ICategoryDal _categoryDal;
	IRestaurantDal _restaurantDal;
	public CategoryManager(ICategoryDal categoryDal ,IRestaurantDal restaurantDal)
	{
		_categoryDal = categoryDal;
		_restaurantDal = restaurantDal;
	}

	public IDataResult<Category> Add(Category category)
	{
		_categoryDal.Add(category);
		return new SuccessDataResult<Category>(category, "Kategori Eklendi");
	}

	public IDataResult<List<Category>> GetAll()
	{
		var data = _categoryDal.GetAll();
		return new SuccessDataResult<List<Category>>(data);
	}

	public IDataResult<List<CategoryDetailDto>> GetAllCategoryDetails()
	{
		var data = _categoryDal.GetAllCategoryDetails();
		return new SuccessDataResult<List<CategoryDetailDto>>(data);
	}

	public IDataResult<Category> GetById(int Id)
	{
		var data = _categoryDal.Get(p => p.Id == Id);
		return new SuccessDataResult<Category>(data);
	}

	public IDataResult<CategoryDetailDto> GetCategoryDetail(int categoryId)
	{
		var data = _categoryDal.GetCategoryDetail(categoryId);
		return new SuccessDataResult<CategoryDetailDto>(data);
	}

	public IDataResult<List<CategoryDetailDto>> GetCategoryDetailsByProduct(int productId)
	{
		var data = _categoryDal.GetCategoryDetailsByProduct(productId);
		return new SuccessDataResult<List<CategoryDetailDto>>(data);
	}

	public IDataResult<List<CategoryDetailDto>> GetCategoryDetailsByResturant(int restaurantId)
	{
		var data = _categoryDal.GetCategoryDetailsByRestaurant(restaurantId);
		return new SuccessDataResult<List<CategoryDetailDto>>(data);
	}

	public IResult Remove(Category category)
	{
		_categoryDal.Delete(category);
		return new SuccessResult("Kategori silindi");
	}

	public IResult Update(Category category)
	{
		_categoryDal.Update(category);
		_categoryDal.AddCategoryToRestaurant(category.Id, category.Restaurants[0].Id);
		return new SuccessResult("Kategori Güncellendi");


	}
}