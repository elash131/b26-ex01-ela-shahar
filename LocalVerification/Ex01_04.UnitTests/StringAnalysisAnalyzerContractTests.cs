using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex01_04.UnitTests
{
	[TestClass]
	public class StringAnalysisAnalyzerContractTests
	{
		[TestMethod]
		public void StringAnalysisAnalyzer_ShouldExist()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			Type analyzerType = Section04CompilationHelper.GetAnalyzerType(compiledAssembly);

			Assert.IsNotNull(analyzerType);
		}

		[TestMethod]
		public void StringAnalysisReport_ShouldExist()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			Type reportType = Section04CompilationHelper.GetReportType(compiledAssembly);

			Assert.IsNotNull(reportType);
		}

		[TestMethod]
		public void Analyzer_ShouldExpose_CreateStringAnalysisReport_Method_With_Single_String_Parameter()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			Type analyzerType = Section04CompilationHelper.GetAnalyzerType(compiledAssembly);
			MethodInfo createStringAnalysisReportMethod = analyzerType.GetMethod(
				"CreateStringAnalysisReport",
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			Assert.IsNotNull(createStringAnalysisReportMethod);
			Assert.AreEqual(1, createStringAnalysisReportMethod.GetParameters().Length);
			Assert.AreEqual(typeof(string), createStringAnalysisReportMethod.GetParameters()[0].ParameterType);
			Assert.AreEqual("StringAnalysisReport", createStringAnalysisReportMethod.ReturnType.Name);
		}

		[TestMethod]
		public void Report_ShouldExpose_The_Required_Public_Properties()
		{
			Assembly compiledAssembly = Section04CompilationHelper.CompileSection04Assembly();
			Type reportType = Section04CompilationHelper.GetReportType(compiledAssembly);
			string[] expectedPropertyNames =
			{
				"IsDigitsOnly",
				"IsEnglishLettersOnly",
				"IsDivisibleByFour",
				"UppercaseLettersCount",
				"IsInDescendingAlphabeticalOrder",
				"IsPalindrome"
			};
			string[] actualPropertyNames = reportType
				.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				.Select(i_PropertyInfo => i_PropertyInfo.Name)
				.ToArray();

			foreach(string expectedPropertyName in expectedPropertyNames)
			{
				CollectionAssert.Contains(actualPropertyNames, expectedPropertyName);
			}
		}
	}
}
