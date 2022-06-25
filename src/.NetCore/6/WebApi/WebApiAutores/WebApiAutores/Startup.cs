﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiAutores.Filters;
using WebApiAutores.Middlewares;

namespace WebApiAutores;

public class Startup
{
    public Startup(IConfiguration configuration) 
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration {  get; }

    public void ConfigureServices(IServiceCollection services) 
    {

        services.AddControllers(opciones => {
            opciones.Filters.Add(typeof(MiFiltroExcepcion));
        }).AddJsonOptions(x => 
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "WebApiAutores", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) 
    {
        app.UseRespuestaHTTPLog();

        if (env.IsDevelopment()) 
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiAutores v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseResponseCaching();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => 
        {
            endpoints.MapControllers();
        });
    }
}