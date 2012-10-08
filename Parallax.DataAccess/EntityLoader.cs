using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Parallax.Data.Base;

namespace Parallax.DataAccess
{
	public class EntityLoader
	{
		private IDocumentSession DocumentSession { get; set; }

		public EntityLoader(IDocumentSession documentSession)
		{
			this.DocumentSession = documentSession;
		}

		public IEnumerable<T> LoadList<T>(int pageIndex, int pageSize) where T: BaseEntity
		{
			return this.DocumentSession.Query<T>().Skip(pageSize * (pageIndex)).Take(pageSize);
		}

		public T LoadItem<T>(string id)
		{
			return this.DocumentSession.Load<T>(id);
		}
	}
}
