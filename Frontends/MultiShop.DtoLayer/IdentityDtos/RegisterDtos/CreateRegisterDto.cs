﻿namespace MultiShop.DtoLayer.IdentityDtos.RegisterDtos
{
	public class CreateRegisterDto
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
