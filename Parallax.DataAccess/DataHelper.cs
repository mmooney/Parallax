using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Document;

namespace Parallax.DataAccess
{
	public static class DataHelper
	{
		public static IDocumentStore GetDocumentStore()
		{
			var documentStore = new DocumentStore 
			{	
				Url = "http://localhost:8080/", 
				DefaultDatabase = "Parallax" 
			};
			documentStore.Initialize();
			return documentStore;
		}
	}
}
