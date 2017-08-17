using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility.Tests
{
	[TestFixture]
	class JSONToDictionary_Test
	{

		//[TestCase("{ \"sample\": {\"someitem\": {\"thesearecool\": [{\"neat\": \"wow\"},{\"neat\": \"tubular\"}]}}}",)]
		public void DictionaryBuilder_ValidJSON_Dictionary(string objectData, Dictionary<string,string> comparer)
		{
			//Arrange
			//JSONToDictionary jsonToDictionaryObject = new JSONToDictionary();
			String validJsonString = "{ \"sample\": {\"someitem\": {\"thesearecool\": [{\"neat\": \"wow\"},{\"neat\": \"tubular\"}]}}}";
			Dictionary<string, string> expectedResult = new Dictionary<string, string>();
			expectedResult.Add("sample.someitem.thesearecool[0].neat", "wow");
			expectedResult.Add("sample.someitem.thesearecool[1].neat", "tubular");

			//ACt
			var watch = System.Diagnostics.Stopwatch.StartNew();
			var result = JsonToDictionary.DictionatryBuilder(validJsonString);

			//Assert
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			Assert.Multiple(() => {

				Assert.That(result, Is.EqualTo(expectedResult));
				Assert.IsTrue(elapsedMs < 10, "The actualCount was not greater than ten");
			});
			
		}
	}
}
