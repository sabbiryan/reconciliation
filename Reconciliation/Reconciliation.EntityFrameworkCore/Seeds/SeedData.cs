﻿using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ReconciliationApp.EntityFrameworkCore.Seeds
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ReconciliationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ReconciliationDbContext>>());


            context.Database.Migrate();
            

            IncomeOrExpenseTypeBuilder.Build(context);
            IncomeOrExpenseBuilder.Build(context);
            ReconciliationBuilder.Build(context);
        }
    }
}
