﻿using KevApp.Api.Models;
using KevApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace KevApp.Api.Extensions;

public static class ProgramExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        JwtOptions jwtOptions = new JwtOptions();
        var jwtConfigSection = config.GetSection(nameof(JwtOptions));
        jwtConfigSection.Bind(jwtOptions);
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecurityKey));
        jwtOptions.SecurityKeyToken = securityKey;
        services.Configure<JwtOptions>(c =>
        {
            c.Audience = jwtOptions.Audience;
            c.Issuer = jwtOptions.Issuer;
            c.SecurityKey = jwtOptions.SecurityKey;
            c.SecurityKeyToken = jwtOptions.SecurityKeyToken;
            c.DefaultAuthenticateScheme = jwtOptions.DefaultAuthenticateScheme;
            c.DefaultChallengeScheme = jwtOptions.DefaultChallengeScheme;
            c.DefaultScheme = jwtOptions.DefaultScheme;
        });

        services.AddAuthentication(_ =>
        {
            _.DefaultAuthenticateScheme = jwtOptions.DefaultAuthenticateScheme;
            _.DefaultChallengeScheme = jwtOptions.DefaultChallengeScheme;
            _.DefaultScheme = jwtOptions.DefaultScheme;
        })
        .AddJwtBearer(_ => _.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = jwtOptions.SecurityKeyToken,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
        });


        return services;
    }

    public static IServiceCollection AddSwaggerAuthorizeHeader(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
        return services;
    }
}
