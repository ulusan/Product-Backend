﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //bu class bir kişinin claimlerine ulaşmak için .net te olan class
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            //? = null anlamına gelir
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
