using NewCard.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions
    (state => {state.SuppressModelStateInvalidFilter = true; });

builder.Services.AddDbContext<NewCardContext>();

var app = builder.Build();
app.MapControllers();

app.Run();




