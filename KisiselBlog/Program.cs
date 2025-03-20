using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabanı bağlantı dizesi için önce ortam değişkenine bak, yoksa appsettings.json'dan al
var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION") ?? 
    builder.Configuration.GetConnectionString("DefaultConnection");

// SQLite veritabanını ekleyelim
builder.Services.AddDbContext<KisiselBlog.Data.ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Proje servisi yerine Repository desenini kullanalım
builder.Services.AddScoped<KisiselBlog.Repository.IProjectRepository, KisiselBlog.Repository.ProjectRepository>();

var app = builder.Build();

// Veritabanını otomatik oluştur
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<KisiselBlog.Data.ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Hata ayıklama sayfasını göster
app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// Özel route tanımlama
app.MapControllerRoute(
    name: "portfolyo",
    pattern: "portfolyo",
    defaults: new { controller = "Home", action = "Portfolio" }
);

// Varsayılan route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Veritabanı dosyası için erişim kontrolü
if (app.Environment.IsProduction())
{
    try
    {
        var dbPath = Path.Combine(app.Environment.ContentRootPath, "kisiselBlog.db");
        if (File.Exists(dbPath))
        {
            // Dosya erişim haklarını ayarla (sadece uygulama kullanıcısı erişebilmeli)
            File.SetAttributes(dbPath, FileAttributes.Hidden);
            
            // Windows için ACL ayarları
            if (OperatingSystem.IsWindows())
            {
                // Uygulama havuzu kullanıcısına izin ver, diğerlerini kısıtla
                // Bu kısmı sunucu ortamına göre uyarlamanız gerekebilir
            }
        }
    }
    catch (Exception ex)
    {
        // Hata log'u ekle
    }
}

app.Run();
