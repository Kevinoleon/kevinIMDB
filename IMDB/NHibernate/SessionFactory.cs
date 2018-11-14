using ContosoUniversity.NHibernate.ClassMappings;
using NHibernate;
using NHibernate.Support;
using System;
using System.Configuration;

namespace ContosoUniversity.NHibernate
{
    public static class SessionFactory
	{
		private static readonly Type[] ClassMappingTypes = new[]
		{
			typeof(MovieMapping),
			typeof(ActorMapping),
			typeof(RoleMapping),
		};

		private static ISessionFactory BuildSessionFactory()
		{
			var configuration = Configurer.Configure("IMDBDB", ConfigurationManager.ConnectionStrings["CIMDBDB"], ClassMappingTypes);
			return configuration.BuildSessionFactory();
		}

		public static ISessionFactory Instance { get; } = BuildSessionFactory();
	}
}
