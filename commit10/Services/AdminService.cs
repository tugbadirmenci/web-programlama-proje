using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;  // Admin modelini burada import edin
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAdminAsync(string username, string password)
        {
            var admin = new Admin
            {
                Username = username,
                Password = password
            };

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }
    }
}
