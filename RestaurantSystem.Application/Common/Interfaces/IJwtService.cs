using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateToken(AppUser user, IList<string> roles);
}