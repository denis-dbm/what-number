using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WhatNumber
{
    static class RandomNumber
    {
        internal static DateTimeOffset StartedAt;
        private static readonly Random rnd = new Random();

        public static Task ShowInstructions(HttpContext context) => 
            context.Response.WriteAsync($"Service was started at {StartedAt} on host {Environment.MachineName}. Please, use /next-number to get a number.");

        public static Task GetNextNumber(HttpContext context) => context.Response.WriteAsync(rnd.Next().ToString());
    }
}