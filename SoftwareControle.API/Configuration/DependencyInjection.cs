using SoftwareControle.Repositório;
using SoftwareControle.Repositorio.Context;
using SoftwareControle.Services.Services.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoftwareControle.Repository.Repositorio.Ordem;
using SoftwareControle.Repository.Repositorio.Usuario;
using System.Text;

namespace SoftwareControle.WebUi.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
    {
        //Repositorio
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddScoped<IFerramentaRepositorio, FerramentaRepositorio>();
        services.AddScoped<IOrdemRepositorio, OrdemRepositorio>();
        services.AddScoped<IRelatorioRepositorio, RelatorioRepositorio>();

		//Services
		services.AddScoped<IUsuarioService, UsuarioService>();
		services.AddScoped<IFerramentaService, FerramentaService>();
		services.AddScoped<IOrdemService, OrdemService>();
		services.AddScoped<IRelatorioService, RelatorioService>();

		return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("SoftwareControleConnection"),
                assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext)
                .Assembly.FullName));
        });

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]!))
                };
            }); 

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(policy =>
        {
            policy.AddPolicy("OpenCorsPolicy", opt =>
                opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        return services;
    }
}
