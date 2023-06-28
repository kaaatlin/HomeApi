using FluentValidation;
using FluentValidation.AspNetCore;
using HomeApi.Configuration;
using HomeApi.Contracts.Validation;
using HomeApi.Data;
using HomeApi.Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HomeApi
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Подключаем автомаппинг
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            builder.Services.AddAutoMapper(assembly);

            /// Загрузка конфигурации из файла Json
            builder.Configuration.AddJsonFile("appsettings.json").AddJsonFile("appsettings.Development.json").AddJsonFile("HomeOptions.json");
                    

            // регистрация сервиса репозитория для взаимодействия с базой данных
            builder.Services.AddSingleton<IDeviceRepository, DeviceRepository>();
            builder.Services.AddSingleton<IRoomRepository, RoomRepository>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<HomeApiContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

            // Подключаем валидацию
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssembly(typeof(AddDeviceRequestValidator).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(UpdateRoomRequestValidator).Assembly);

            // Добавляем новый сервис
            builder.Services.Configure<HomeOptions>(builder.Configuration);

            // Загружаем только адрес (вложенный Json-объект) 
            builder.Services.Configure<Address>(builder.Configuration.GetSection("Address"));

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}