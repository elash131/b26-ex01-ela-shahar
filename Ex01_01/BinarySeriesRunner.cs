using System;

namespace Ex01_01
{
	internal class BinarySeriesRunner
	{
		public void Run()
		{
			BinarySeriesInputReader binarySeriesInputReader = new BinarySeriesInputReader();
			BinarySeriesAnalyzer binarySeriesAnalyzer = new BinarySeriesAnalyzer();
			BinarySeriesFormatter binarySeriesFormatter = new BinarySeriesFormatter();
			string[] validBinaryNumbers = binarySeriesInputReader.ReadValidBinaryNumbers();
			BinarySeriesReport binarySeriesReport = binarySeriesAnalyzer.CreateBinarySeriesReport(validBinaryNumbers);
			string formattedBinarySeriesReport = binarySeriesFormatter.FormatBinarySeriesReport(binarySeriesReport);

			Console.WriteLine(formattedBinarySeriesReport);
		}
	}
}
