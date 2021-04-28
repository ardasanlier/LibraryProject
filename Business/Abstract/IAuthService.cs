using Core.Entities.Concrete;
using Core.Utilites.Results;
using Core.Utilites.Security.JWT;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult Update(UserForUpdateDto userForUpdateDto);
        IDataResult<User> GetByMail(string email);
    }
}
