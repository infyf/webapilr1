using lr9.Interfaces;
using lr9.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDishData, DishData>(); 
builder.Services.AddScoped<ICategoryData, CategoryData>(); 
builder.Services.AddScoped<IBookingData, BookingData>(); 

//для кожного сервісу вибрано AddScoped, тому що сервіси повинні бути створені для кожного запиту, 
//що є оптимальним для обробки даних. Це дозволяє мати окремий екземпляр сервісу для кожного запиту, забезпечуючи коректне управління станом

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
