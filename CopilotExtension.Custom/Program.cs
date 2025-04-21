using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace CopilotExtension.Custom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
            builder.Services.AddAuthorization();
            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Copilot For Sales Extension v1", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri("https://login.microsoftonline.com/889dce7c-7548-438a-ae0c-b2bfd7a96a2e/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri("https://login.microsoftonline.com/889dce7c-7548-438a-ae0c-b2bfd7a96a2e/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                    {
                                        "api://93cfa68b-e023-479c-be77-011c499921d5/C4S.Read",
                                        "Reads Web Api"
                                    }
                            }
                        }
                    }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "oauth2"
                                },
                                Scheme = "oauth2",
                                Name = "oauth2",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                });
            });

            var app = builder.Build();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Copilot For Sales Extension v1");
                c.OAuthClientId("93cfa68b-e023-479c-be77-011c499921d5");
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}