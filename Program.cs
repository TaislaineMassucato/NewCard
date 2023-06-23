using NewCard.Data;
using NewCard.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions
    (state => {state.SuppressModelStateInvalidFilter = true; });

builder.Services.AddDbContext<NewCardContext>();
builder.Services.AddTransient<TokenService>();    //Sempre cria token novo quando instanciado

//builder.Services.AddScoped(); //1 para cada requisição=[httpPost("/")=> new requst 123])
//builder.Services.AddSingleton(); //1 por app / morre so quando fecha o app

var app = builder.Build();
app.MapControllers();

app.Run();




