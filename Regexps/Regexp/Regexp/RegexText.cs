using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Regexp
{
	[TestFixture]
    public class RegexText
    {
		[Test]
		public void Test1()
		{
			var match = Regex.Match("cat", "ca+t");

			Assert.IsNotNull(match.Groups);
			Assert.IsNotNull(match.Groups[0]);
			Assert.IsNotNullOrEmpty(match.Groups[0].Value);
			Assert.IsTrue(match.Groups[0].Success);
			Assert.IsNotNull(match.Groups[58765]);
			Assert.IsNullOrEmpty(match.Groups[58765].Value);
			Assert.IsNotNull(match.Groups[58765].Success);

			match = Regex.Match("cat", "c(?<groupName>a+)t");

			Assert.IsNotNull(match.Groups);
			Assert.IsNotNull(match.Groups[0]);
			Assert.IsNotNull(match.Groups[1]);
			Assert.IsNotNull(match.Groups["groupName"]);
			Assert.IsNotNullOrEmpty(match.Groups["groupName"].Value);
			Assert.IsNullOrEmpty(match.Groups["ololo"].Value);
		}

		private const int N = 1000000;

		[Test]
		public void PerfTest()
		{
			for (int i = 0; i < N; i++)
			{
				var match = Regex.Match("them theme them them", @"\b\w+\s\w+\b");
			}
		}
		
		[Test]
		public void PerfTestCompiled()
		{
			var regex = new Regex(@"\b\w+\s\w+\b");

			for (int i = 0; i < N; i++)
			{
				var match = regex.Match("them theme them them");
			}
		}
    }
}
