using BlazorWebApp.BlazorServer.Data;
using BlazorWebApp.BlazorServer.Data.Entities;
using BlazorWebApp.BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.BlazorServer.Services
{
    public class UserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }


        public async Task LoginAsync(LoginModel model)
        {
            var dbUser = await _context.Users
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(u => u.Email == model.Username);

            if(dbUser is not null)
            {
                //Login success
            }
            else
            {
                //Login failed
            }
                                       
        }

    }

}
