using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parallax.Data.Base;

namespace Parallax.Data.Tasks
{
	public class Task : BaseEntity
	{
		public string Description { get; set; }
		public string Details { get; set; }
		public ParallaxUser CreatedByUser { get; set; }
		public ParallaxUser AssignedToUser { get; set; }
	}
}
