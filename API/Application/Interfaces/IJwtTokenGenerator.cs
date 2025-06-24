using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Interfaces
{
  /// <summary>
  /// Interface for JWT token generation and validation operations
  /// </summary>
  public interface IJwtTokenGenerator
  {
    /// <summary>
    /// Generates a JWT token for the specified user
    /// </summary>
    /// <param name="user">The user for whom to generate the token</param>
    /// <returns>A JWT token string</returns>
    string GenerateToken(User user);

    /// <summary>
    /// Generates a JWT token with custom claims
    /// </summary>
    /// <param name="user">The user for whom to generate the token</param>
    /// <param name="additionalClaims">Additional claims to include in the token</param>
    /// <returns>A JWT token string</returns>
    string GenerateTokenWithClaims(User user, IEnumerable<Claim> additionalClaims);

    /// <summary>
    /// Validates a JWT token and returns the user ID if valid
    /// </summary>
    /// <param name="token">The JWT token to validate</param>
    /// <returns>The user ID if token is valid, null otherwise</returns>
    Guid? ValidateToken(string token);

    /// <summary>
    /// Validates a token and returns all claims
    /// </summary>
    /// <param name="token">The JWT token to validate</param>
    /// <returns>Collection of claims if token is valid, null otherwise</returns>
    IEnumerable<Claim> ValidateTokenAndGetClaims(string token);

    /// <summary>
    /// Refreshes an existing token
    /// </summary>
    /// <param name="token">The existing token to refresh</param>
    /// <returns>A new JWT token string if refresh is successful, null otherwise</returns>
    Task<string> RefreshTokenAsync(string token);

    /// <summary>
    /// Revokes a specific token
    /// </summary>
    /// <param name="token">The token to revoke</param>
    /// <returns>True if token was successfully revoked, false otherwise</returns>
    Task<bool> RevokeTokenAsync(string token);

    /// <summary>
    /// Checks if a token has been revoked
    /// </summary>
    /// <param name="token">The token to check</param>
    /// <returns>True if token is revoked, false otherwise</returns>
    Task<bool> IsTokenRevokedAsync(string token);
  }
}