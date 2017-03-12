using System;
using System.Globalization;

namespace Shenba.DemoPackage.Core
{
	/// <summary>
	/// Demo
	/// </summary>
	public class Demo
	{
		/// <summary>
		/// Run
		/// </summary>
		public void Run()
		{
			Console.WriteLine($"You're using my demo package at {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
		}
	}
}
