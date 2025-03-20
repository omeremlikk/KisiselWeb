using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabanı yolunu App_Data klasörüne ayarla
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "kisiselBlog.db");
var connectionString = $"Data Source={dbPath};Mode=ReadWrite;";

// SQLite veritabanını ekleyelim
builder.Services.AddDbContext<KisiselBlog.Data.ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Proje servisi yerine Repository desenini kullanalım
builder.Services.AddScoped<KisiselBlog.Repository.IProjectRepository, KisiselBlog.Repository.ProjectRepository>();

var app = builder.Build();

// Veritabanı dizinini oluştur
Directory.CreateDirectory(Path.Combine(app.Environment.ContentRootPath, "App_Data"));

// Veritabanını otomatik oluştur
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try 
    {
        var context = services.GetRequiredService<KisiselBlog.Data.ApplicationDbContext>();
        
        // Veritabanı yolunu ve varlığını kontrol et
        Console.WriteLine($"Veritabanı yolu: {dbPath}");
        Console.WriteLine($"Veritabanı dosyası mevcut: {File.Exists(dbPath)}");
        
        // Veritabanı bağlantısını test et
        context.Database.EnsureCreated();
        
        // Projeleri kontrol et
        var projects = context.Projects.ToList();
        Console.WriteLine($"Veritabanındaki toplam proje sayısı: {projects.Count}");
        foreach (var project in projects)
        {
            Console.WriteLine($"Proje ID: {project.Id}, Başlık: {project.Title}, IsFeatured: {project.IsFeatured}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Veritabanı hatası: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
    }
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
        if (File.Exists(dbPath))  // Burada var olan dbPath değişkenini kullan
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
        // Hata logunu yazdır
        Console.WriteLine($"Veritabanı dosyası ayarlanırken hata oluştu: {ex.Message}");
    }
}

app.Run();
