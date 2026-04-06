using System;

namespace Ex01_01
{
	internal class BinarySeriesRunner
	{
		public void Run()
		{
			BinarySeriesInputReader binarySeriesInputReader;
			BinarySeriesAnalyzer binarySeriesAnalyzer;
			BinarySeriesFormatter binarySeriesFormatter;
			BinarySeriesReport binarySeriesReport;
			string[] validBinaryNumbers;
			string formattedBinarySeriesReport;

			binarySeriesInputReader = new BinarySeriesInputReader();
			binarySeriesAnalyzer = new BinarySeriesAnalyzer();
			binarySeriesFormatter = new BinarySeriesFormatter();
			validBinaryNumbers = binarySeriesInputReader.ReadValidBinaryNumbers();
			binarySeriesReport = binarySeriesAnalyzer.CreateBinarySeriesReport(validBinaryNumbers);
			formattedBinarySeriesReport = binarySeriesFormatter.FormatBinarySeriesReport(binarySeriesReport);
			Console.WriteLine(formattedBinarySeriesReport);
		}
	}
}
