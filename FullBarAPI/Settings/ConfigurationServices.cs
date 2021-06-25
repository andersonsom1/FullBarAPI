using FullBarAPI.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Settings
{
    public static class ConfigurationServices
    {
        public static void AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //CONFIGURATION
            //services.Configure<AppConfiguration>(configuration);
            ModelMapper mapper = new ModelMapper();
            mapper.AddMappings(typeof(ConfigurationServices).Assembly.ExportedTypes);
            HbmMapping hbmMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration nhconfiguration = new Configuration().DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = configuration.GetConnectionString("SqlConnection").Replace("Directory", AppDomain.CurrentDomain.BaseDirectory);
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Update;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            
            nhconfiguration.AddMapping(hbmMapping);
            ISessionFactory sessionFactory = nhconfiguration.BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession()  );
        }
    }
}
