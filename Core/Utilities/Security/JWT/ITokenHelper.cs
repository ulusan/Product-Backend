using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;


namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanıcı adını ve şifresini yazdıktan sonra buraya gelir.
        //sonra createtoken fonksiyonu çalışır ve doğruysa jwt üretir ve kullanıcıya verir.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
