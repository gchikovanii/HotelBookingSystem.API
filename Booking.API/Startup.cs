using Booking.Application.Services.Abstraction.HotelAggregate;
using Booking.Application.Services.Abstraction.OrdersAggregate;
using Booking.Application.Services.Abstraction.RoomAggregate;
using Booking.Application.Services.Implementation.HotelAggregate;
using Booking.Application.Services.Implementation.OrdersAggregate;
using Booking.Application.Services.Implementation.RoomAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using Booking.Infrastructure.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<INumberOfRoomsByTypesRepository, NumberOfRoomsByTypesRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<INumberOfRoomsService, NumberOfRoomsService>();
            services.AddTransient<IOrderService, OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
        }
    }
}
