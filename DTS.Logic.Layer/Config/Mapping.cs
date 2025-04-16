using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DTS.Logic.Layer.AutoMappers
{
    //public static class CustomAutoMapper
    //{
    //    public static void AddCustomConfiguredAutoMapper(this IServiceCollection services)
    //    {
    //        var config = new MapperConfiguration(cfg =>
    //        {
    //            cfg.AddProfile(new UserProfile());
    //        });

    //        var mapper = config.CreateMapper();

    //        services.AddSingleton(mapper);
    //    }
    //}

    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<StockProfile>();
                cfg.AddProfile<BillsProfile>();
                cfg.AddProfile<AccountsProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
