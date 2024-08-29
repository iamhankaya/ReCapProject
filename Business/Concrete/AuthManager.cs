using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Abstract.ForSecurity;
using Core.Utilities.Helpers.Concrete.ForSecurity;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        ITokenHelper _tokenHelper;
        IUserService _userService;

        public AuthManager(ITokenHelper tokenHelper,IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetOperationClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            IResult nullResult = BusinessRules.Run(UserMailCheck(userForLoginDto.Email));
            if (nullResult != null)
                return new ErrorDataResult<User>(UserMailCheck(userForLoginDto.Email).Message);
            

            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            var result = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.data.PasswordHash, userToCheck.data.PasswordSalt);

            if(result == false)
            {
                return new ErrorDataResult<User>(Messages.PasswordInvalid);
            }
            return new SuccessDataResult<User>(userToCheck.data,Messages.SuccessfulLogin);

        }

        public IDataResult<User> Register(UserForRegister userForRegister)
        {
            IResult result = BusinessRules.Run(UserExists(userForRegister.Email));
            if (result != null)
                return new ErrorDataResult<User>(result.Message);

            

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegister.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserSuccessfullyRegistered);
        }

        private IResult UserMailCheck(string email)
        {
            if(_userService.GetByEmail(email) == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult();
        }

        private IResult UserExists(string email)
        {
            if(_userService.GetByEmail(email).IsSuccess == true)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
