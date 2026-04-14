using System;

namespace Ex01_04
{
	internal class StringAnalysisRunner
	{
		public void Run()
		{
			StringAnalysisInputReader stringAnalysisInputReader = new StringAnalysisInputReader();
			StringAnalysisAnalyzer stringAnalysisAnalyzer = new StringAnalysisAnalyzer();
			StringAnalysisFormatter stringAnalysisFormatter = new StringAnalysisFormatter();
			string validInput = stringAnalysisInputReader.ReadValidInput();
			StringAnalysisReport stringAnalysisReport = stringAnalysisAnalyzer.CreateStringAnalysisReport(validInput);
			string formattedStringAnalysisReport = stringAnalysisFormatter.FormatStringAnalysisReport(stringAnalysisReport);

			Console.WriteLine(formattedStringAnalysisReport);
		}
	}
}
