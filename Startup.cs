using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WhatNumber
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .Map("/next-number", a => a.Run(RandomNumber.GetNextNumber))
                .Map("", a => a.Run(RandomNumber.ShowInstructions));

            RandomNumber.StartedAt = DateTimeOffset.UtcNow;
        }
    }
}