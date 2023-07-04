using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewCard;
using NewCard.Data;
using NewCard.Services;
using System.Security.Authentication;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfiguracaoAutenticacao(builder);
ConfiguracaoMVC(builder);
ConfiguracaoServicos(builder);

var app = builder.Build();
CarregarConfiguracoes(app);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

if(app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}
app.Run();


void ConfiguracaoAutenticacao(WebApplicationBuilder builder)
{
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
}

void ConfiguracaoMVC(WebApplicationBuilder builder)
{
    builder
      .Services
      .AddControllers()
      .ConfigureApiBehaviorOptions(state => { state.SuppressModelStateInvalidFilter = true; });
}

void CarregarConfiguracoes(WebApplication app)
{
    Configuracao.JWTkey = app.Configuration.GetValue<string>("JWTkey");
    Configuracao.ApiKey = app.Configuration.GetValue<string>("ApiKey");
    Configuracao.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");

    var smtp = new SmtpConfiguracao();
    app.Configuration.GetSection("Smtp").Bind(smtp);
    Configuracao.Smtp = smtp;
}

void ConfiguracaoServicos(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<NewCardContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddTransient<TokenService>();//Sempre cria token novo quando instanciado
    //builder.Services.AddTransient<EmailService>();
    //builder.Services.AddScoped(); //1 para cada requisição=[httpPost("/")=> new requst 123])
    //builder.Services.AddSingleton(); //1 por app / morre so quando fecha o app
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

