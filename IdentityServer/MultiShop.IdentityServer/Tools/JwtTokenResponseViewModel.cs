using System;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenResponseViewModel
    {
        public JwtTokenResponseViewModel(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
