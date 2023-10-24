using BookInfo.API.DbContext;
using BookInfo.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookInfo.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly BookContextInfo _bookContextInfo;
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        public AuthenticationController(IConfiguration configuration,
            BookContextInfo bookContextInfo)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _bookContextInfo = bookContextInfo ??
                throw new ArgumentNullException(nameof(bookContextInfo));
        }


        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            // Step 1: Validate the username/password 
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // The claims that
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("book", user.Book));

            // creating the actual token
            var jwtSecurityToken = new JwtSecurityToken(  // new up a jwt security token 
                _configuration["Authentication:Issuer"], // pass through issuer and audience
                _configuration["Authentication:Audience"],
                claimsForToken, // pass through claims 
                DateTime.UtcNow, // start of token validity. B4 this time the toke cannot be used and validation will fail
                DateTime.UtcNow.AddHours(1), // indicates the end of token validity. After this the token is invalid
                signingCredentials); // pass thru signing credentials

            // to effectively write a token, new up a handler and call WriteToken on it
            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            // result in a token string which can be returned

            return Ok(tokenToReturn);

        }

        //private User ValidateUserCredentials(string? userName, string? password)
        //{
        //    // Perform a case-insensitive query to get a subset of possible matches
        //    var possibleMatches = _bookContextInfo.Users
        //        .Where(u => u.UserName.ToUpper() == userName.ToUpper() && u.Password == password)
        //        .ToList();

        //    // Perform a case-sensitive check on the subset
        //    var user = possibleMatches
        //        .FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.Ordinal));

        //    return user;
        //}

        private User ValidateUserCredentials(string? userName, string? password)
        {
            // Retrieve the user with the given username
            var user = _bookContextInfo.Users
                .FirstOrDefault(u => u.UserName.ToUpper() == userName.ToUpper());

            // If the user exists and the hashed password matches the given password
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }
    }
}
