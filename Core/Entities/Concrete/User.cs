﻿using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class User : IEntity
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string TelNo { get; set; }
	public string Adress { get; set; }
	public byte[]? PasswordSalt { get; set; }
	public byte[]? PasswordHash { get; set; }
	public bool Status { get; set; }
	public List<Comment>? Comments { get; set; }
}
