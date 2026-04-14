using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex01_04.UnitTests
{
	internal static class Section04CompilationHelper
	{
		private const string k_AnalyzerTypeFullName = "Ex01_04.StringAnalysisAnalyzer";
		private const string k_ReportTypeFullName = "Ex01_04.StringAnalysisReport";

		internal static Assembly CompileSection04Assembly()
		{
			string repositoryRootPath = findRepositoryRootPath();
			string ex0104Path = Path.Combine(repositoryRootPath, "Ex01_04");
			string[] sourceFilePaths = Directory.GetFiles(ex0104Path, "*.cs", SearchOption.TopDirectoryOnly);
			CompilerParameters compilerParameters = new CompilerParameters();
			CompilerResults compiledAssemblyResults;
			string[] sourceFileContents;

			if(sourceFilePaths.Length == 0)
			{
				Assert.Fail("No Section 4 source files were found in Ex01_04.");
			}

			sourceFileContents = sourceFilePaths.Select(i_SourceFilePath => File.ReadAllText(i_SourceFilePath)).ToArray();
			compilerParameters.GenerateExecutable = false;
			compilerParameters.GenerateInMemory = true;
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
			compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
			using(CSharpCodeProvider compiler = new CSharpCodeProvider())
			{
				compiledAssemblyResults = compiler.CompileAssemblyFromSource(compilerParameters, sourceFileContents);
			}

			if(compiledAssemblyResults.Errors.HasErrors)
			{
				string compilationErrors = string.Join(
					Environment.NewLine,
					compiledAssemblyResults.Errors
						.Cast<CompilerError>()
						.Select(i_CompilerError => i_CompilerError.ToString()));

				Assert.Fail(string.Format("Section 4 source files did not compile:{0}{1}", Environment.NewLine, compilationErrors));
			}

			return compiledAssemblyResults.CompiledAssembly;
		}

		internal static object CreateAnalyzerInstance(Assembly i_CompiledAssembly)
		{
			Type analyzerType = getRequiredType(i_CompiledAssembly, k_AnalyzerTypeFullName);

			return Activator.CreateInstance(analyzerType, true);
		}

		internal static Type GetAnalyzerType(Assembly i_CompiledAssembly)
		{
			return getRequiredType(i_CompiledAssembly, k_AnalyzerTypeFullName);
		}

		internal static Type GetReportType(Assembly i_CompiledAssembly)
		{
			return getRequiredType(i_CompiledAssembly, k_ReportTypeFullName);
		}

		internal static object CreateStringAnalysisReport(object i_AnalyzerInstance, string i_Input)
		{
			MethodInfo createStringAnalysisReportMethod = i_AnalyzerInstance
				.GetType()
				.GetMethod(
					"CreateStringAnalysisReport",
					BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			if(createStringAnalysisReportMethod == null)
			{
				Assert.Fail("StringAnalysisAnalyzer must expose a CreateStringAnalysisReport method.");
			}

			return createStringAnalysisReportMethod.Invoke(i_AnalyzerInstance, new object[] { i_Input });
		}

		internal static T GetReportPropertyValue<T>(object i_ReportInstance, string i_PropertyName)
		{
			PropertyInfo propertyInfo = i_ReportInstance.GetType().GetProperty(i_PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			if(propertyInfo == null)
			{
				Assert.Fail(string.Format("StringAnalysisReport must expose a {0} property.", i_PropertyName));
			}

			return (T)propertyInfo.GetValue(i_ReportInstance);
		}

		private static Type getRequiredType(Assembly i_CompiledAssembly, string i_TypeFullName)
		{
			Type requiredType = i_CompiledAssembly.GetType(i_TypeFullName, false);

			if(requiredType == null)
			{
				Assert.Fail(string.Format("Required type not found: {0}.", i_TypeFullName));
			}

			return requiredType;
		}

		private static string findRepositoryRootPath()
		{
			DirectoryInfo currentDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

			while(currentDirectoryInfo != null)
			{
				if(Directory.Exists(Path.Combine(currentDirectoryInfo.FullName, "Ex01_04")) &&
					Directory.Exists(Path.Combine(currentDirectoryInfo.FullName, "Ex01_Insructions")))
				{
					return currentDirectoryInfo.FullName;
				}

				currentDirectoryInfo = currentDirectoryInfo.Parent;
			}

			Assert.Fail("Could not locate the repository root for Section 4 tests.");

			return string.Empty;
		}
	}
}
