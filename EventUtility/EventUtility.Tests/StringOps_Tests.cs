using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility.Tests
{
	[TestFixture]
	class StringOps_Tests
	{
		[TestCase("bdahas}}","bdahas")]
		[TestCase("bdahas", "bdahas")]
		[TestCase("bdahas}}{!@#$%{!@#$%^", "bdahas")]
		[TestCase("","")]
		[TestCase(null, null)]
		public void TrimBraces_RemoveCurlyBracesFromTheEnd(string input, string output)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			Assert.Multiple(() => {

				Assert.AreEqual(output, StringOps.TrimBraces(input));
				Assert.IsTrue(elapsedMs < 10, "The actualCount was not greater than ten");
			});
			
		}

		[TestCase("bda[has", "bda")]
		[TestCase("bda[has[[[[]", "bda")]
		[TestCase("b[[da[has", "b")]
		[TestCase("[bda[saa", "")]
		public void TrimBrackets_ReturnSubstring(string input, string output)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			Assert.Multiple(() => {
				Assert.AreEqual(output, StringOps.TrimString(input));
				Assert.IsTrue(elapsedMs < 10, "The actualCount was not greater than ten");
			});
			
		}
		


	}
}
