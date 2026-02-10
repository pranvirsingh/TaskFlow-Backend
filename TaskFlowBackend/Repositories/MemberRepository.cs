using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Data;
using TaskFlowBackend.Dtos;
using TaskFlowBackend.Interfaces.Repositories;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MemberRepository> _logger;

        public MemberRepository(AppDbContext context, ILogger<MemberRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<User?>> GetAllUsersDetails()
        {
            try
            {
                return await _context.Users.Where(x => x.Id != 1 && !x.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Fetching Details");
                return new List<User?>();
            }
        }

        public async Task<User?> GetUserById(GetUserById dto)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.Id == dto.Id && !x.IsDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Fetching Details");
                return null;
            }
        }

        public async Task<bool> AddUserAsync(AddUserDto dto)
        {
            try
            {
                var lastUserName = await _context.Users.Where(x => x.UserName.StartsWith("TF")).OrderByDescending(x => x.UserName).Select(x => x.UserName).FirstOrDefaultAsync();

                int nextNumber = 1;

                if (!string.IsNullOrEmpty(lastUserName))
                {
                    var numberPart = lastUserName.Substring(2);
                    if (int.TryParse(numberPart, out int lastNumber))
                    {
                        nextNumber = lastNumber + 1;
                    }
                }

                var newUserName = $"TF{nextNumber:D4}";

                var password = new Random().Next(100000, 999999).ToString();
                var user = new User
                {
                    UserName = newUserName,
                    Password = password,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Mobile = dto.Mobile,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Adding User");
                return false;
            }
        }


        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.Id == dto.Id && !x.IsDeleted);

                if (user == null)
                    return false;

                user.FullName = dto.FullName;
                user.Email = dto.Email;
                user.Mobile = dto.Mobile;
                user.IsActive = dto.IsActive;
                user.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Updating User");
                return false;
            }
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (user == null)
                    return false;

                user.IsDeleted = true;
                user.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error While Deleting User");
                return false;
            }
        }

    }
}
