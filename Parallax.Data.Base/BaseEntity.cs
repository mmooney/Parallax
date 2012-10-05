using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parallax.Data.Base
{
	public abstract class BaseEntity
	{
		public string Id { get; set; }

		public ParallaxUser CreatedByUser { get; set;}
		public DateTime CreatedDate { get; set; }
		public ParallaxUser ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
