using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class SecurityManager
    {
        public void AccessSensitiveInfo(User user)
        {
            if (!user.IsAuthenticated)
            {
                throw new AuthenticationException("User is not authenticated.");
            }

            if (!user.IsAuthorized("view_sensitive_info"))
            {
                throw new AuthorizationException("User is not authorized to access this information.");
            }

           
        }
    }
}
