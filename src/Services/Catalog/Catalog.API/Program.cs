var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//add Marten configuration
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("PostgresDb")!);
}).UseLightweightSessions();

var app = builder.Build();

//Configure HTTP request pipeline
app.MapCarter();

app.Run();
