using Core.Common.Domain.Model;
using Service.Identity.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Identity.Domain.Model
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Code { get; protected set; }
        public string Name { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ResultException(new Result { ErrCode = "empty_user_email", Message = "User email can not be empty." });
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ResultException(new Result { ErrCode = "empty_user_name", Message = "User name can not be empty." });
            }
            Id = Guid.NewGuid();
            Code = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ResultException(new Result { ErrCode = "empty_password", Message = "Password can not be empty." });
            }
            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}
