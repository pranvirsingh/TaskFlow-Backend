using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Data;
using TaskFlowBackend.Interfaces.Repositories;
using TaskFlowBackend.Models;
using TaskFlowBackend.Dtos;

namespace TaskFlowBackend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthRepository> _logger;

        public AuthRepository(AppDbContext context, ILogger<AuthRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User?> GetUserAsync(LoginRequestDto query)
        {
            try
            {
                return await _context.Users
                    .FirstOrDefaultAsync(x =>
                        x.UserName == query.username &&
                        x.Password == query.password &&
                        x.IsDeleted == false &&
                        x.IsActive == true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Logging");
                return null;
            }
        }

        public async Task<User?> GetUserDetailsByIdAsync(int userId)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Fetching Details");
                return null;
            }
        }

        public async Task<bool> UpdateProfileAsync(int userId, UpdateProfileDto dto)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.Id == userId && !x.IsDeleted);

                if (user == null)
                    return false;

                user.FullName = dto.FullName;
                user.Email = dto.Email;
                user.Mobile = dto.Mobile;
                user.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating profile");
                return false;
            }
        }


    }
}
