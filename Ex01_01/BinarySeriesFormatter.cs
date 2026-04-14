using System.Text;

namespace Ex01_01
{
	internal class BinarySeriesFormatter
	{
		public string FormatBinarySeriesReport(BinarySeriesReport i_BinarySeriesReport)
		{
			StringBuilder formattedBinarySeriesReport = new StringBuilder();

			formattedBinarySeriesReport.AppendLine(createDescendingDecimalNumbersLine(i_BinarySeriesReport.BinaryNumberInfosSortedByDescendingDecimalValue));
			formattedBinarySeriesReport.AppendLine(string.Format("Average: {0:F2}", i_BinarySeriesReport.AverageDecimalValue));
			formattedBinarySeriesReport.AppendLine(
				string.Format(
					"Longest bit sequence: {0} ({1})",
					i_BinarySeriesReport.LongestBitSequenceLength,
					createCommaSeparatedBinaryRepresentations(i_BinarySeriesReport.BinaryRepresentationsWithLongestBitSequence)));
			formattedBinarySeriesReport.AppendLine(string.Format("Total 1-bits: {0}", i_BinarySeriesReport.TotalOneBits));
			formattedBinarySeriesReport.AppendLine(
				string.Format(
					"Number with most transitions: {0} ({1}) - {2} transitions",
					i_BinarySeriesReport.BinaryNumberWithMostTransitions.DecimalValue,
					i_BinarySeriesReport.BinaryNumberWithMostTransitions.BinaryRepresentation,
					i_BinarySeriesReport.BinaryNumberWithMostTransitions.TransitionCount));
			formattedBinarySeriesReport.Append(
				createNumbersDivisibleByFourLine(i_BinarySeriesReport.BinaryRepresentationsDivisibleByFour));

			return formattedBinarySeriesReport.ToString();
		}

		private string createDescendingDecimalNumbersLine(BinaryNumberInfo[] i_BinaryNumberInfosSortedByDescendingDecimalValue)
		{
			StringBuilder descendingDecimalNumbersLine = new StringBuilder();

			descendingDecimalNumbersLine.Append("Decimal numbers in descending order: ");

			for(int binaryNumberIndex = 0;
				binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length;
				binaryNumberIndex++)
			{
				if(binaryNumberIndex > 0)
				{
					descendingDecimalNumbersLine.Append(", ");
				}

				descendingDecimalNumbersLine.Append(
					string.Format(
						"{0} ({1})",
						i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].DecimalValue,
						i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].BinaryRepresentation));
			}

			return descendingDecimalNumbersLine.ToString();
		}

		private string createNumbersDivisibleByFourLine(string[] i_BinaryRepresentationsDivisibleByFour)
		{
			StringBuilder numbersDivisibleByFourLine = new StringBuilder();

			numbersDivisibleByFourLine.Append(string.Format("Numbers divisible by 4: {0}", i_BinaryRepresentationsDivisibleByFour.Length));

			if(i_BinaryRepresentationsDivisibleByFour.Length > 0)
			{
				numbersDivisibleByFourLine.Append(
					string.Format(" ({0})", createCommaSeparatedBinaryRepresentations(i_BinaryRepresentationsDivisibleByFour)));
			}

			return numbersDivisibleByFourLine.ToString();
		}

		private string createCommaSeparatedBinaryRepresentations(string[] i_BinaryRepresentations)
		{
			StringBuilder commaSeparatedBinaryRepresentations = new StringBuilder();

			for(int binaryRepresentationIndex = 0; binaryRepresentationIndex < i_BinaryRepresentations.Length; binaryRepresentationIndex++)
			{
				if(binaryRepresentationIndex > 0)
				{
					commaSeparatedBinaryRepresentations.Append(", ");
				}

				commaSeparatedBinaryRepresentations.Append(i_BinaryRepresentations[binaryRepresentationIndex]);
			}

			return commaSeparatedBinaryRepresentations.ToString();
		}
	}
}
