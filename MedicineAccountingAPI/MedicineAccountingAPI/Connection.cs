﻿using MedicineAccountingAPI.DataLevel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAccountingAPI
{
    public class Connection
    {
        public static DbContextOptions<ContextMedicineAccounting> ConnectionOption()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ContextMedicineAccounting>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            return options;
        }
    }
}
