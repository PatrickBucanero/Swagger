using Agenda.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapControllers();


app.UseSwagger();
app.UseSwaggerUI();



app.Run();
