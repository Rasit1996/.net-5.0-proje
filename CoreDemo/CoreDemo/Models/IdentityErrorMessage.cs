using Microsoft.AspNetCore.Identity;

namespace CoreDemo.Models
{
    public class IdentityErrorMessage:IdentityErrorDescriber
    {
        
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code=nameof(PasswordRequiresUpper),Description="Şifre en az 1 büyük karakter içermelidir!" };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Şifre en az 1 küçük karekter içermelidir!" };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { Code = nameof(PasswordTooShort), Description = "Şifre en az 6 karekter uzunluğunda olmalı!" };
        }

     
    }
}
