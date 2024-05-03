﻿using Business.Abstract;
using Entities.Concrete.DTOs.RestaurantDto;
using Entities.Concrete.DTOs.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("userlogin")]
		public ActionResult UserLogin(UserForLoginDto userForLoginDto)
		{
			var userToLogin = _authService.UserLogin(userForLoginDto);
			if (!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}

			var result = _authService.CreateAccessTokenForUser(userToLogin.Data);
			if (result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}

		[HttpPost("userregister")]
		public ActionResult UserRegister(UserForRegisterDto userForRegisterDto)
		{
			var userExists = _authService.UserExists(userForRegisterDto.Email);
			if (!userExists.Success)
			{
				return BadRequest(userExists.Message);
			}

			var registerResult = _authService.UserRegister(userForRegisterDto, userForRegisterDto.Password);
			var result = _authService.CreateAccessTokenForUser(registerResult.Data);
			if (result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}

		//-----------------------------------------------------------------------------
		//-----------------------------------------------------------------------------

		[HttpPost("restaurantregister")]
		public ActionResult RestaurantRegister(RestaurantForRegisterDto restaurantForRegisterDto)
		{
			var restaurantExists = _authService.RestaurantExists(restaurantForRegisterDto.Email);
			if (!restaurantExists.Success)
			{
				return BadRequest(restaurantExists.Message);
			}

			var registerResult = _authService.RestaurantRegister(restaurantForRegisterDto, restaurantForRegisterDto.Password);
			var result = _authService.CreateAccessTokenForRestaurant(registerResult.Data);
			if (result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}

		[HttpPost("restaurantlogin")]
		public ActionResult RestaurantLogin(RestaurantForLoginDto restaurantForLoginDto)
		{
			var restaurantToLogin = _authService.RestaurantLogin(restaurantForLoginDto);
			if (!restaurantToLogin.Success)
			{
				return BadRequest(restaurantToLogin.Message);
			}

			var result = _authService.CreateAccessTokenForRestaurant(restaurantToLogin.Data);
			if (result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}
	}
}