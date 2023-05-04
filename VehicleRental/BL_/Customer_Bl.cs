using System;
using DL;
using Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;



//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


using System.IdentityModel.Tokens.Jwt;




namespace BL_
{
    public class Customer_Bl : ICustomer_Bl
    {
        ICustomer_DL _userDL;
        IConfiguration _configuration;
        IPasswordHashHelper _passwordHashHelper;
        public Customer_Bl(ICustomer_DL userDL, IConfiguration configuration, IPasswordHashHelper passwordHashHelper)
        {
            _userDL = userDL;
            _configuration = configuration;
            _passwordHashHelper = passwordHashHelper;

        }
        //??
        public async Task<CustomerTbl> getUser(string pasword, string email)
        {


            CustomerTbl user = await _userDL.getUser( pasword,email);
            if (user == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return WithoutPassword(user);

        //    CustomerTbl myUser = await _userDL.getUser(pasword, email);
        //    if (myUser == null)
        //        return null;
        //    return myUser;
        }

        public static List<CustomerTbl> WithoutPasswords(List<CustomerTbl> users)
        {
            return users.Select(x => WithoutPassword(x)).ToList();
        }


        public static CustomerTbl WithoutPassword(CustomerTbl user)
        {
            user.PasswordCust = null;
            return user;
        }


        public async Task putUser(string email, CustomerTbl userToUpdate)
        {
            // DL_ userDl = new DL_();
          await  _userDL.putUser(email, userToUpdate);
        }
        public async Task<CustomerTbl> postUser(CustomerTbl user)
        {
            //  DL_ userDl = new DL_();
          
            user.Salt = _passwordHashHelper.GenerateSalt(8);
            user.PasswordCust=    _passwordHashHelper.HashPassword(user.PasswordCust, user.Salt, 1000, 8);
            CustomerTbl myUser = await _userDL.postUser(user);
            if (myUser == null)
                return null;
            return myUser;
        }


    }
}
