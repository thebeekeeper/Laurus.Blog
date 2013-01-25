using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

namespace Laurus.Components.Impl
{
	public class NhRepository : IRepository
	{
		public NhRepository(Type t)
		{
			_sessionFactory = CreateSessionFactory(t);
			_session = _sessionFactory.OpenSession();
		}

		T IRepository.Read<T>(int id)
		{
			T rval = default(T);
			using (var transaction = _session.BeginTransaction())
			{
				rval = _session.Load<T>(id);
				transaction.Commit();
			}
			return rval;

		}

		IQueryable<T> IRepository.Query<T>()
		{
			return _session.Query<T>();
		}

		void IRepository.Persist<T>(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Persist(entity);

				_session.SaveOrUpdate(entity);
				transaction.Commit();
			}
		}

		private ISessionFactory CreateSessionFactory(Type mappedType)
		{
			return Fluently.Configure().Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString("Server=(local)\\SQLEXPRESS;Database=Laurus;Trusted_Connection=True;"))
				.Mappings(m => m.FluentMappings.AddFromAssembly(mappedType.Assembly))
				//.Mappings(m => m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.LoadFrom("Laurus.Blog.Entity.dll")))
                //.ExposeConfiguration(BuildSchema)
				.BuildSessionFactory();
		}

		private void BuildSchema(Configuration config)
		{
			new SchemaExport(config).Create(false, true);
		}

		private ISessionFactory _sessionFactory;
		private ISession _session;
	}
}
