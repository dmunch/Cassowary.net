using System;

namespace Cassowary
{
	public static class Console
	{
		static Console()
		{
			Out = new System.IO.StringWriter();
		}

		public static void WriteLine(params object[] p)
		{
			Out.WriteLine (p);
		}

		public static void WriteLine(string formatString, params object[] p)
		{
			Out.WriteLine (formatString, p);
		}

		public static System.IO.TextWriter Out;

		public static class Error
		{
			public static void WriteLine(params object[] p)
			{
				Out.WriteLine (p);
			}

			public static void WriteLine(string formatString, params object[] p)
			{
				Out.WriteLine (formatString, p);
			}
		}
	}
}

