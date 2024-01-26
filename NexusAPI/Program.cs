
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Administracao.Services;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.Repositories;
using NexusAPI.Dados.Services;
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
            builder.Services.AddScoped<TokenService, TokenService>();
            builder.Services.AddScoped<AnaliseRequisicaoService, AnaliseRequisicaoService>();
            builder.Services.AddScoped<VerificacaoManutencaoService, VerificacaoManutencaoService>();

            builder.Services.AddScoped<NotificacaoService, NotificacaoService>();
            builder.Services.AddScoped<PerfilService, PerfilService>();
            builder.Services.AddScoped<ProjetoService, ProjetoService>();
            builder.Services.AddScoped<UsuarioService, UsuarioService>();
            builder.Services.AddScoped<UsuarioPerfilService, UsuarioPerfilService>();

            builder.Services.AddScoped<AtribuicaoService, AtribuicaoService>();

            builder.Services.AddScoped<ComponenteService, ComponenteService>();
            builder.Services.AddScoped<EquipamentoService, EquipamentoService>();
            builder.Services.AddScoped<LocalizacaoService, LocalizacaoService>();
            builder.Services.AddScoped<ManutencaoService, ManutencaoService>();
            builder.Services.AddScoped<RequisicaoService, RequisicaoService>();
            builder.Services.AddScoped<SoftwareService, SoftwareService>();

            //Repositories
            builder.Services.AddScoped<NotificacaoRepository, NotificacaoRepository>();
            builder.Services.AddScoped<PerfilRepository, PerfilRepository>();
            builder.Services.AddScoped<ProjetoRepository, ProjetoRepository>();
            builder.Services.AddScoped<UsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<UsuarioPerfilRepository, UsuarioPerfilRepository>();

            builder.Services.AddScoped<AtribuicaoRepository, AtribuicaoRepository>();
            builder.Services.AddScoped<CicloVidaRepository, CicloVidaRepository>();

            builder.Services.AddScoped<ComponenteRepository, ComponenteRepository>();
            builder.Services.AddScoped<EquipamentoRepository, EquipamentoRepository>();
            builder.Services.AddScoped<LocalizacaoRepository, LocalizacaoRepository>();
            builder.Services.AddScoped<ManutencaoRepository, ManutencaoRepository>();
            builder.Services.AddScoped<RequisicaoRepository, RequisicaoRepository>();
            builder.Services.AddScoped<SoftwareRepository, SoftwareRepository>();

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

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();
            app.UseCors("AllowFrontend");

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
