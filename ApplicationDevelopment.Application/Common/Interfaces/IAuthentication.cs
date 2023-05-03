using ApplicationDevelopment.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Application.Common.Interfaces
{
   public interface IAuthentication
    {

        Task<ResponseDTO> Register(RegisterDTO model);
        Task<ResponseDTO> Login(LoginDTO model);
        Task<IEnumerable<UserDetailsDTO>> GetUserDetails();
        
    }
}
