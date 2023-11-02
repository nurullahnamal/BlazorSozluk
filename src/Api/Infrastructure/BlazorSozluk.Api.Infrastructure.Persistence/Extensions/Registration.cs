﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSozluk.Api.Infrastructure.Persistence.Extensions
{
    public  static  class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BlazorSozlukContext>(conf =>
            {
                var connStr = configuration["BlazorSozlukDbConnnectionString"].ToString();
                conf.UseSqlServer(connStr , opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            var seedData = new SeedData();
            seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            


            return services;
        }
    }
}
