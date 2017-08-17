using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility.Tests
{
	[TestFixture]
	class BuildURL_Tests
	{
		[TestCase("{ \"sample\": {\"someitem\": {\"thesearecool\": [{\"neat\": \"wow\"},{\"neat1\": \"tubular\"}]}}}", "http://localhost:8080/xyz/?={{neat}}&{{neat1}}", "http://localhost:8080/xyz/?=wow&tubular")]
		[TestCase("", "http://localhost:8080/xyz/?={{neat}}&{{neat1}}", "http://localhost:8080/xyz/?={{neat}}&{{neat1}}")]
		[TestCase("", "", "")]
		[TestCase("{ \"sample\": {\"someitem\": {\"thesearecool\": [{\"neat\": \"wow\"},{\"neat1\": \"tubular\"}]}}}", "", "")]
		public void BuildURL_ValidObjectValidTargetUrl_ResultUrl(string objectdata, string targetURL,string output)
		{
			BuildURL build = new BuildURL();
			var watch = System.Diagnostics.Stopwatch.StartNew();
			var res = build.GenerateUrl(objectdata, targetURL);
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			Assert.Multiple(() => {
				Assert.AreEqual(output, res.Opt);
				Assert.IsTrue(elapsedMs < 100, "The actualCount was not greater than hundred");
			});
			
		}

		[TestCase("http://localhost:8080/xyz/?={{neat}}&{{Name}}",2)]
		[TestCase("http://localhost:8080/xyz/?=neat&{{Name}}", 1)]
		[TestCase("http://localhost:8080/xyz/?=neat&Name", 0)]
		[TestCase("http://localhost:8080/xyz/?={{neat}}&{{Name}}{{cgf}}{{vhgfhg}}{{cbcc}}", 5)]
		[TestCase("", 0)]
		[TestCase("null",0)]
		public void GetParamasToReplace_FromTargetUrl__ResultParamas(string x,int y)
		{
			BuildURL build = new BuildURL();
			//string test = "http://localhost:8080/xyz/?={{neat}}&{{Name}}";
			var watch = System.Diagnostics.Stopwatch.StartNew();
			var res = build.GetParamasToReplace(x);
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			Assert.Multiple(() => {
				
				Assert.AreEqual(res.Count, y);
				Assert.IsTrue(elapsedMs < 10, "The actualCount was not greater than ten");
			});
			

		}
	}
}
