using Microsoft.AspNetCore.SignalR;
using System.Security.Principal;

namespace WebMvc.Services
    {
    public interface IIdentiyService<T> 
        {
        T Get(IPrincipal principal);
        }
    }
