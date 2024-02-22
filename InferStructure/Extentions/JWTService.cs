using System.Security.Claims;
using System.Text;
using Application.Common;
using Domin.Entities.User;
using InferStructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace InferStructure.Extentions;

public static class JWTService
{
    public static void ConfigureJWTServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);


        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<AppSignInManager>();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

            // Add the security definition for JWT
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });

            // Add the security requirement for Swagger
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });
        });


        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.Authority = "https://localhost:7054/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero, // default: 5 min
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ValidateAudience = false, //default : false
                    ValidAudience = jwtSettings["Audience"],
                    ValidateIssuer = false, //default : false
                    ValidIssuer = jwtSettings["Issuer"]
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context => { return Task.CompletedTask; },
                    OnTokenValidated = async context =>
                    {
                        var signInManager = context.HttpContext.RequestServices.GetRequiredService<AppSignInManager>();

                        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                        if (claimsIdentity.Claims?.Any() != true)

                            context.Fail("This token has no claims.");
                    },
                    OnChallenge = async context =>
                    {
                        if (context.AuthenticateFailure is SecurityTokenExpiredException)
                        {
                            context.HandleResponse();
                            var errorMessage = new
                            {
                                message = "Token is expired. refresh your token",
                                statusCode = StatusCodes.Status401Unauthorized
                            };
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsJsonAsync(errorMessage);
                        }

                        else if (context.AuthenticateFailure != null)
                        {
                            context.HandleResponse();


                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            var errorMessage = new
                            {
                                message = "Token is Not Valid",
                                statusCode = StatusCodes.Status401Unauthorized
                            };
                            await context.Response.WriteAsJsonAsync(errorMessage);
                        }

                        else
                        {
                            context.HandleResponse();

                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            var errorMessage = new
                            {
                                message = "Invalid access token. Please login",
                                statusCode = StatusCodes.Status401Unauthorized
                            };
                            await context.Response.WriteAsJsonAsync(
                                errorMessage);
                        }
                    },
                    OnForbidden = async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        var errorMessage = new
                        {
                            message = "Forbidden",
                            statusCode = StatusCodes.Status401Unauthorized
                        };
                        await context.Response.WriteAsJsonAsync(
                            errorMessage);
                    }
                };
            });
    }
}