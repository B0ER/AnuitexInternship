﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Model.Account.Response;
using Store.BusinessLogic.Options;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Helpers
{
    public class JwtManager
    {
        private readonly JwtAuthOptions _jwtAuthOptions;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtManager(IOptions<JwtAuthOptions> jwtAuthOptions)
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        private string GenerateJwt(ClaimsIdentity identity, TimeSpan expireTokenMinutes)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _jwtAuthOptions.Issuer,
                _jwtAuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(expireTokenMinutes),
                signingCredentials: new SigningCredentials(_jwtAuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = _jwtSecurityTokenHandler.WriteToken(jwt);
            return encodedJwt;
        }

        public string GenerateAccessToken(ApplicationUser user, IEnumerable<string> userRoles)
        {
            var accessClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.NormalizedUserName)
            };

            foreach (var userRole in userRoles) accessClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var accessClaimsIdentity = new ClaimsIdentity(accessClaims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return GenerateJwt(accessClaimsIdentity, _jwtAuthOptions.AccessTokenExpiration);
        }

        public string GenerateRefreshToken(ApplicationUser user)
        {
            var refreshClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var accessClaimsIdentity = new ClaimsIdentity(refreshClaims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return GenerateJwt(accessClaimsIdentity, _jwtAuthOptions.RefreshTokenExpiration);
        }
    }
}