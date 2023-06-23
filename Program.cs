using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NewCard;
using NewCard.Data;
using NewCard.Services;
using System.Security.Authentication;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuracao.JWTkey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }); 

builder.Services.AddControllers().ConfigureApiBehaviorOptions
    (state => {state.SuppressModelStateInvalidFilter = true; });

builder.Services.AddDbContext<NewCardContext>();
builder.Services.AddTransient<TokenService>();    //Sempre cria token novo quando instanciado

//builder.Services.AddScoped(); //1 para cada requisição=[httpPost("/")=> new requst 123])
//builder.Services.AddSingleton(); //1 por app / morre so quando fecha o app

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();




