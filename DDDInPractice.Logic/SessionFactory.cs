﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Reflection;
using Raven.Client;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.AcceptanceCriteria;

using FluentNHibernate.Conventions.Instances;
using NHibernate.Mapping;

namespace DDDInPractice.Logic
{
    public static class SessionFactory
    {
        private static ISessionFactory _factory;
        internal static ISession OpenSession()
        {
            return _factory.OpenSession();
        }
        public static void Init(string connectionString)
        {
            _factory = BuildSessionFactory(connectionString);

        }

        private static ISessionFactory BuildSessionFactory(string connectionstring)
        {
            FluentConfiguration configuration = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionstring))
                    .Mappings(m => m.FluentMappings
                        .AddFromAssembly(Assembly.GetExecutingAssembly())
                        .Conventions.Add(FluentNHibernate.Conventions.Helpers.ForeignKey.EndsWith("ID"),
                            ConventionBuilder.Property
                                .When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                                    .Conventions.Add<TableNameConvention>()
                                    .Conventions.Add<HiLoConvention>()
            );

            return configuration.BuildSessionFactory();
        }

        public class TableNameConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table("[dbo].[" + instance.EntityType.Name + "]");
            }
        }

        public class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.HiLo("[dbo].[Ids]", "NextHigh", "9", "EntityName = " + instance.EntityType.Name + "*");
            }
        }
    }
}