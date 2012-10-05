using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Parallax.Data.Base;

namespace Parallax.DataAccess
{
	public class EntitySaver
	{
		private IDocumentSession DocumentSession { get; set; }
		private ParallaxSession CurrentSession { get; set; }
	
		public EntitySaver(IDocumentSession documentSession, ParallaxSession currentSession)
		{
			this.DocumentSession = documentSession;
			this.CurrentSession = currentSession;
		}

		public void Add(BaseEntity entity, bool saveChanges=true)
		{
			entity.CreatedByUser = this.CurrentSession.CurrentUser;
			entity.CreatedDate = DateTime.UtcNow;
			entity.ModifiedByUser = this.CurrentSession.CurrentUser;
			entity.ModifiedDate = DateTime.UtcNow;

			this.DocumentSession.Store(entity);
			if(saveChanges)
			{
				this.DocumentSession.SaveChanges();
			}
		}

		public void SaveChanges()
		{
			this.DocumentSession.SaveChanges();
		}
	}
}
