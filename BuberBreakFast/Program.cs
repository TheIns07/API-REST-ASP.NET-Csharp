using BubberBreakFast.Services.Breakfast;

var builder = WebApplication.CreateBuilder(args);{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastServices, BreakfastServices>(); 
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

