var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// في المستقبل سنضيف هنا إعدادات قاعدة البيانات (DbContext)
// builder.Services.AddDbContext<...>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ---------------------------------------------------------
// 1. تعريف مسار المناطق (Areas) للموديولات (HR, Legal, etc..)
// هذا التوجيه يأتي أولاً لكي يفحص النظام هل الرابط يخص موديول معين أم لا
// ---------------------------------------------------------
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// ---------------------------------------------------------
// 2. المسار الافتراضي (الصفحة الرئيسية للمشروع ككل)
// ---------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();