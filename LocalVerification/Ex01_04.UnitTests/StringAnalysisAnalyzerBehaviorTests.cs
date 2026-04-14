using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex01_04.UnitTests
{
	[TestClass]
	public class StringAnalysisAnalyzerBehaviorTests
	{
		[TestMethod]
		public void DigitsOnlyExample_Should_Report_The_Required_Values()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			object analyzerInstance = Section04CompilationHelper.CreateAnalyzerInstance(compiledAssembly);
			object reportInstance = Section04CompilationHelper.CreateStringAnalysisReport(analyzerInstance, "12481632");

			Assert.IsTrue(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsDigitsOnly"));
			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsEnglishLettersOnly"));
			Assert.IsTrue(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsDivisibleByFour"));
			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsPalindrome"));
		}

		[TestMethod]
		public void DescendingLettersExample_Should_Report_The_Required_Values()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			object analyzerInstance = Section04CompilationHelper.CreateAnalyzerInstance(compiledAssembly);
			object reportInstance = Section04CompilationHelper.CreateStringAnalysisReport(analyzerInstance, "HgFeDcBa");

			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsDigitsOnly"));
			Assert.IsTrue(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsEnglishLettersOnly"));
			Assert.AreEqual(4, Section04CompilationHelper.GetReportPropertyValue<int>(reportInstance, "UppercaseLettersCount"));
			Assert.IsTrue(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsInDescendingAlphabeticalOrder"));
			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsPalindrome"));
		}

		[TestMethod]
		public void CaseInsensitivePalindromeLettersExample_Should_Report_The_Required_Values()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			object analyzerInstance = Section04CompilationHelper.CreateAnalyzerInstance(compiledAssembly);
			object reportInstance = Section04CompilationHelper.CreateStringAnalysisReport(analyzerInstance, "AbCddCbA");

			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsDigitsOnly"));
			Assert.IsTrue(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsEnglishLettersOnly"));
			Assert.AreEqual(4, Section04CompilationHelper.GetReportPropertyValue<int>(reportInstance, "UppercaseLettersCount"));
			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsInDescendingAlphabeticalOrder"));
			Assert.IsTrue(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsPalindrome"));
		}

		[TestMethod]
		public void MixedContentExample_Should_Not_Be_Classified_As_Digits_Only_Or_Letters_Only()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			object analyzerInstance = Section04CompilationHelper.CreateAnalyzerInstance(compiledAssembly);
			object reportInstance = Section04CompilationHelper.CreateStringAnalysisReport(analyzerInstance, "A1b2C3d4");

			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsDigitsOnly"));
			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsEnglishLettersOnly"));
			Assert.IsFalse(Section04CompilationHelper.GetReportPropertyValue<bool>(reportInstance, "IsPalindrome"));
		}
	}
}
