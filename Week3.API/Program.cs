using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Week3.Data.Context;
using Autofac.Extensions.DependencyInjection;
using Week3.Service.Dependecy_Resolvers_AutoFac;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyContext>(x =>
{
    // appsettingsde tanýmladýðýmýz connection stringi iþaret ettik isminden.
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(MyContext)).GetName().Name); // Migration'un yapýlacaðý assembly'i iþaret ettik.
    });
});
// Autofac kütüphanesi ayarlarý
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(ContainerBuilder => ContainerBuilder.RegisterModule(new ServiceModule()));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
