var builder = WebApplication.CreateBuilder(args);
// Thêm dịch vụ vào container
builder.Services.AddControllers();
var app = builder.Build();
// Cấu hình pipeline HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();