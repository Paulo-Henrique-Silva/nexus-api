
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Services;
using System.Text;

namespace NexusAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NexusAPI", Version = "v1" });

                // Configurações adicionais para autenticação
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT.",
                    Name = "Authorization",
                    BearerFormat = "JWT",
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
                        new string[] { }
                    }
                });
            });

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            #region InjeçãoDeDependência

            //Serviços
            builder.Services.AddScoped<UsuarioService, UsuarioService>();
            builder.Services.AddScoped<NotificacaoService, NotificacaoService>();
            builder.Services.AddScoped<TokenService, TokenService>();

            //Repositories
            builder.Services.AddScoped<UsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<NotificacaoRepository, NotificacaoRepository>();

            #endregion

            builder.Services.AddDbContext<DataContext>(obj => obj.UseSqlServer(builder.Configuration["Logging:ConnectionStrings:conexaoBD"]));

            //Auth JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Logging:Auth:issuer"],
                    ValidAudience = builder.Configuration["Logging:Auth:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Logging:Auth:chave"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); //Deve vir primeiro.
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
