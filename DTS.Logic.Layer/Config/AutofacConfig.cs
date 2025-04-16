using Autofac;
using DTS.Core.SystemIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Logic.Layer.DataIO;

namespace DTS.Logic.Layer.Config
{
    public class AutofacConfig : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockLogic>().AsSelf().As<IStockLogic>().InstancePerLifetimeScope();
            builder.RegisterType<UserLogic>().AsSelf().As<IUserLogic>().InstancePerLifetimeScope();
            builder.RegisterType<AccountsLogic>().AsSelf().As<IAccountsLogic>().InstancePerLifetimeScope();
            builder.RegisterType<BillsLogic>().AsSelf().As<IBillsLogic>().InstancePerLifetimeScope();
            builder.RegisterType<EarLibraryLogic>().AsSelf().As<IEarLibraryLogic>().InstancePerLifetimeScope();
            builder.RegisterType<DirectoryHelper>();
        }
    }
}
