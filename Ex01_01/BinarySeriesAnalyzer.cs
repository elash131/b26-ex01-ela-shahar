using System;

namespace Ex01_01
{
	internal class BinarySeriesAnalyzer
	{
		public BinarySeriesReport CreateBinarySeriesReport(string[] i_BinaryNumbers)
		{
			BinaryNumberInfo[] binaryNumberInfos = createBinaryNumberInfos(i_BinaryNumbers);
			BinaryNumberInfo[] binaryNumberInfosSortedByDescendingDecimalValue =
				getBinaryNumberInfosSortedByDescendingDecimalValue(binaryNumberInfos);
			int longestBitSequenceLength = getLongestBitSequenceLength(binaryNumberInfosSortedByDescendingDecimalValue);
			string[] binaryRepresentationsWithLongestBitSequence = getBinaryRepresentationsWithLongestBitSequence(
				binaryNumberInfosSortedByDescendingDecimalValue,
				longestBitSequenceLength);
			int totalOneBits = getTotalOneBits(binaryNumberInfos);
			BinaryNumberInfo binaryNumberWithMostTransitions = getBinaryNumberWithMostTransitions(binaryNumberInfos);
			string[] binaryRepresentationsDivisibleByFour = getBinaryRepresentationsDivisibleByFourInAscendingDecimalOrder(
				binaryNumberInfosSortedByDescendingDecimalValue);
			double averageDecimalValue = getAverageDecimalValue(binaryNumberInfos);
			BinarySeriesReport binarySeriesReport = new BinarySeriesReport(
				binaryNumberInfosSortedByDescendingDecimalValue,
				averageDecimalValue,
				longestBitSequenceLength,
				binaryRepresentationsWithLongestBitSequence,
				totalOneBits,
				binaryNumberWithMostTransitions,
				binaryRepresentationsDivisibleByFour);

			return binarySeriesReport;
		}

		private BinaryNumberInfo[] createBinaryNumberInfos(string[] i_BinaryNumbers)
		{
			BinaryNumberInfo[] binaryNumberInfos = new BinaryNumberInfo[i_BinaryNumbers.Length];

			for(int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				binaryNumberInfos[binaryNumberIndex] = createBinaryNumberInfo(i_BinaryNumbers[binaryNumberIndex]);
			}

			return binaryNumberInfos;
		}

		private BinaryNumberInfo createBinaryNumberInfo(string i_BinaryRepresentation)
		{
			int decimalValue = convertBinaryStringToDecimal(i_BinaryRepresentation);
			int longestBitSequenceLength = calculateLongestIdenticalBitSequenceLength(i_BinaryRepresentation);
			int oneBitsCount = countOneBits(i_BinaryRepresentation);
			int transitionCount = countTransitionsBetweenAdjacentBits(i_BinaryRepresentation);
			BinaryNumberInfo binaryNumberInfo = new BinaryNumberInfo(
				i_BinaryRepresentation,
				decimalValue,
				longestBitSequenceLength,
				oneBitsCount,
				transitionCount);

			return binaryNumberInfo;
		}

		private int convertBinaryStringToDecimal(string i_BinaryRepresentation)
		{
			int decimalValue = 0;

			for(int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
			{
				decimalValue *= 2;
				decimalValue += i_BinaryRepresentation[binaryDigitIndex] - '0';
			}

			return decimalValue;
		}

		private int calculateLongestIdenticalBitSequenceLength(string i_BinaryRepresentation)
		{
			int longestBitSequenceLength = 0;
			int currentBitSequenceLength = 0;

			for(int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
			{
				if(binaryDigitIndex == 0 || i_BinaryRepresentation[binaryDigitIndex] == i_BinaryRepresentation[binaryDigitIndex - 1])
				{
					currentBitSequenceLength++;
				}
				else
				{
					currentBitSequenceLength = 1;
				}

				longestBitSequenceLength = Math.Max(longestBitSequenceLength, currentBitSequenceLength);
			}

			return longestBitSequenceLength;
		}

		private int countOneBits(string i_BinaryRepresentation)
		{
			int oneBitsCount = 0;

			for(int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
			{
				if(i_BinaryRepresentation[binaryDigitIndex] == '1')
				{
					oneBitsCount++;
				}
			}

			return oneBitsCount;
		}

		private int countTransitionsBetweenAdjacentBits(string i_BinaryRepresentation)
		{
			int transitionCount = 0;

			for(int binaryDigitIndex = 1; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
			{
				if(i_BinaryRepresentation[binaryDigitIndex] != i_BinaryRepresentation[binaryDigitIndex - 1])
				{
					transitionCount++;
				}
			}

			return transitionCount;
		}

		private BinaryNumberInfo[] getBinaryNumberInfosSortedByDescendingDecimalValue(BinaryNumberInfo[] i_BinaryNumberInfos)
		{
			BinaryNumberInfo[] binaryNumberInfosSortedByDescendingDecimalValue =
				(BinaryNumberInfo[])i_BinaryNumberInfos.Clone();

			for(int outerIndex = 0; outerIndex < binaryNumberInfosSortedByDescendingDecimalValue.Length - 1; outerIndex++)
			{
				for(int innerIndex = outerIndex + 1;
					innerIndex < binaryNumberInfosSortedByDescendingDecimalValue.Length;
					innerIndex++)
				{
					if(binaryNumberInfosSortedByDescendingDecimalValue[innerIndex].DecimalValue >
						binaryNumberInfosSortedByDescendingDecimalValue[outerIndex].DecimalValue)
					{
						swapBinaryNumberInfos(
							binaryNumberInfosSortedByDescendingDecimalValue,
							outerIndex,
							innerIndex);
					}
				}
			}

			return binaryNumberInfosSortedByDescendingDecimalValue;
		}

		private void swapBinaryNumberInfos(
			BinaryNumberInfo[] io_BinaryNumberInfos,
			int i_FirstBinaryNumberInfoIndex,
			int i_SecondBinaryNumberInfoIndex)
		{
			BinaryNumberInfo currentBinaryNumberInfo = io_BinaryNumberInfos[i_FirstBinaryNumberInfoIndex];

			io_BinaryNumberInfos[i_FirstBinaryNumberInfoIndex] = io_BinaryNumberInfos[i_SecondBinaryNumberInfoIndex];
			io_BinaryNumberInfos[i_SecondBinaryNumberInfoIndex] = currentBinaryNumberInfo;
		}

		private int getLongestBitSequenceLength(BinaryNumberInfo[] i_BinaryNumberInfosSortedByDescendingDecimalValue)
		{
			int longestBitSequenceLength = 0;

			for(int binaryNumberIndex = 0;
				binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length;
				binaryNumberIndex++)
			{
				longestBitSequenceLength = Math.Max(
					longestBitSequenceLength,
					i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].LongestBitSequenceLength);
			}

			return longestBitSequenceLength;
		}

		private string[] getBinaryRepresentationsWithLongestBitSequence(
			BinaryNumberInfo[] i_BinaryNumberInfosSortedByDescendingDecimalValue,
			int i_LongestBitSequenceLength)
		{
			int longestBitSequenceCount = 0;

			for(int binaryNumberIndex = 0;
				binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length;
				binaryNumberIndex++)
			{
				if(i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].LongestBitSequenceLength ==
					i_LongestBitSequenceLength)
				{
					longestBitSequenceCount++;
				}
			}

			string[] binaryRepresentationsWithLongestBitSequence = new string[longestBitSequenceCount];
			int longestBitSequenceIndex = 0;

			for(int binaryNumberIndex = 0;
				binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length;
				binaryNumberIndex++)
			{
				if(i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].LongestBitSequenceLength ==
					i_LongestBitSequenceLength)
				{
					binaryRepresentationsWithLongestBitSequence[longestBitSequenceIndex] =
						i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].BinaryRepresentation;
					longestBitSequenceIndex++;
				}
			}

			return binaryRepresentationsWithLongestBitSequence;
		}

		private int getTotalOneBits(BinaryNumberInfo[] i_BinaryNumberInfos)
		{
			int totalOneBits = 0;

			for(int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfos.Length; binaryNumberIndex++)
			{
				totalOneBits += i_BinaryNumberInfos[binaryNumberIndex].OneBitsCount;
			}

			return totalOneBits;
		}

		private BinaryNumberInfo getBinaryNumberWithMostTransitions(BinaryNumberInfo[] i_BinaryNumberInfos)
		{
			BinaryNumberInfo binaryNumberWithMostTransitions = i_BinaryNumberInfos[0];

			for(int binaryNumberIndex = 1; binaryNumberIndex < i_BinaryNumberInfos.Length; binaryNumberIndex++)
			{
				if(i_BinaryNumberInfos[binaryNumberIndex].TransitionCount > binaryNumberWithMostTransitions.TransitionCount)
				{
					binaryNumberWithMostTransitions = i_BinaryNumberInfos[binaryNumberIndex];
				}
				else if(
					i_BinaryNumberInfos[binaryNumberIndex].TransitionCount == binaryNumberWithMostTransitions.TransitionCount &&
					i_BinaryNumberInfos[binaryNumberIndex].DecimalValue < binaryNumberWithMostTransitions.DecimalValue)
				{
					binaryNumberWithMostTransitions = i_BinaryNumberInfos[binaryNumberIndex];
				}
			}

			return binaryNumberWithMostTransitions;
		}

		private string[] getBinaryRepresentationsDivisibleByFourInAscendingDecimalOrder(
			BinaryNumberInfo[] i_BinaryNumberInfosSortedByDescendingDecimalValue)
		{
			int divisibleByFourCount = 0;

			for(int binaryNumberIndex = 0;
				binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length;
				binaryNumberIndex++)
			{
				if(i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].DecimalValue % 4 == 0)
				{
					divisibleByFourCount++;
				}
			}

			string[] binaryRepresentationsDivisibleByFour = new string[divisibleByFourCount];
			int divisibleByFourIndex = divisibleByFourCount - 1;

			for(int binaryNumberIndex = 0;
				binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length;
				binaryNumberIndex++)
			{
				if(i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].DecimalValue % 4 == 0)
				{
					binaryRepresentationsDivisibleByFour[divisibleByFourIndex] =
						i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].BinaryRepresentation;
					divisibleByFourIndex--;
				}
			}

			return binaryRepresentationsDivisibleByFour;
		}

		private double getAverageDecimalValue(BinaryNumberInfo[] i_BinaryNumberInfos)
		{
			int totalDecimalValue = 0;

			for(int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfos.Length; binaryNumberIndex++)
			{
				totalDecimalValue += i_BinaryNumberInfos[binaryNumberIndex].DecimalValue;
			}

			return totalDecimalValue / (double)i_BinaryNumberInfos.Length;
		}
	}
}
