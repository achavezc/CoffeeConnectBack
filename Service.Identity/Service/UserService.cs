using Core.Common.Auth;
using Core.Common.Domain.Model;
using Service.Identity.Domain.Model;
using Service.Identity.Domain.Repository;
using Service.Identity.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Identity.Service
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository repository,
            IEncrypter encrypter,
            IJwtHandler jwtHandler)
        {
            _repository = repository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _repository.GetAsync(email);
            if (user != null)
            {
                throw new ResultException(new Result { ErrCode = "email_in_use", Message = $"Email: '{email}' is already in use." });
            }
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _repository.AddAsync(user);
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _repository.GetAsync(email);
            if (user == null)
            {
                throw new ResultException(new Result { ErrCode = "invalid_credentials", Message = $"Invalid credentials." });
            }
            if (!user.ValidatePassword(password, _encrypter))
            {
                throw new ResultException(new Result { ErrCode = "invalid_credentials", Message = $"Invalid credentials." });
            }

            return _jwtHandler.Create(user.Id);
        }
    }
}
