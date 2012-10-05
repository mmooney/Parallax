using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parallax.Data.Base
{
	public class ParallaxSession
	{
		public ParallaxUser CurrentUser { get; private set; }

		public ParallaxSession(ParallaxUser currentUser)
		{
			this.CurrentUser = currentUser;
		}
	}
}
