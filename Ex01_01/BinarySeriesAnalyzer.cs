using System;

namespace Ex01_01
{
	internal class BinarySeriesAnalyzer
	{
		public BinarySeriesReport CreateBinarySeriesReport(string[] i_BinaryNumbers)
		{
			BinarySeriesReport binarySeriesReport;
			BinaryNumberInfo[] binaryNumberInfos;
			BinaryNumberInfo[] binaryNumberInfosSortedByDescendingDecimalValue;
			BinaryNumberInfo binaryNumberWithMostTransitions;
			string[] binaryRepresentationsWithLongestBitSequence;
			string[] binaryRepresentationsDivisibleByFour;
			int longestBitSequenceLength;
			int totalOneBits;
			double averageDecimalValue;

			binaryNumberInfos = createBinaryNumberInfos(i_BinaryNumbers);
			binaryNumberInfosSortedByDescendingDecimalValue = getBinaryNumberInfosSortedByDescendingDecimalValue(binaryNumberInfos);
			longestBitSequenceLength = getLongestBitSequenceLength(binaryNumberInfosSortedByDescendingDecimalValue);
			binaryRepresentationsWithLongestBitSequence = getBinaryRepresentationsWithLongestBitSequence(
				binaryNumberInfosSortedByDescendingDecimalValue,
				longestBitSequenceLength);
			totalOneBits = getTotalOneBits(binaryNumberInfos);
			binaryNumberWithMostTransitions = getBinaryNumberWithMostTransitions(binaryNumberInfos);
			binaryRepresentationsDivisibleByFour = getBinaryRepresentationsDivisibleByFourInAscendingDecimalOrder(
				binaryNumberInfosSortedByDescendingDecimalValue);
			averageDecimalValue = getAverageDecimalValue(binaryNumberInfos);
			binarySeriesReport = new BinarySeriesReport(
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
			BinaryNumberInfo[] binaryNumberInfos;
			int binaryNumberIndex;

			binaryNumberInfos = new BinaryNumberInfo[i_BinaryNumbers.Length];

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				binaryNumberInfos[binaryNumberIndex] = createBinaryNumberInfo(i_BinaryNumbers[binaryNumberIndex]);
			}

			return binaryNumberInfos;
		}

		private BinaryNumberInfo createBinaryNumberInfo(string i_BinaryRepresentation)
		{
			BinaryNumberInfo binaryNumberInfo;
			int decimalValue;
			int longestBitSequenceLength;
			int oneBitsCount;
			int transitionCount;

			decimalValue = convertBinaryStringToDecimal(i_BinaryRepresentation);
			longestBitSequenceLength = calculateLongestIdenticalBitSequenceLength(i_BinaryRepresentation);
			oneBitsCount = countOneBits(i_BinaryRepresentation);
			transitionCount = countTransitionsBetweenAdjacentBits(i_BinaryRepresentation);
			binaryNumberInfo = new BinaryNumberInfo(
				i_BinaryRepresentation,
				decimalValue,
				longestBitSequenceLength,
				oneBitsCount,
				transitionCount);

			return binaryNumberInfo;
		}

		private int convertBinaryStringToDecimal(string i_BinaryRepresentation)
		{
			int decimalValue;
			int binaryDigitIndex;

			decimalValue = 0;

			for(binaryDigitIndex = 0; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
			{
				decimalValue *= 2;
				decimalValue += i_BinaryRepresentation[binaryDigitIndex] - '0';
			}

			return decimalValue;
		}

		private int calculateLongestIdenticalBitSequenceLength(string i_BinaryRepresentation)
		{
			int longestBitSequenceLength;
			int currentBitSequenceLength;
			int binaryDigitIndex;

			longestBitSequenceLength = 0;
			currentBitSequenceLength = 0;

			for(binaryDigitIndex = 0; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
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
			int oneBitsCount;
			int binaryDigitIndex;

			oneBitsCount = 0;

			for(binaryDigitIndex = 0; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
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
			int transitionCount;
			int binaryDigitIndex;

			transitionCount = 0;

			for(binaryDigitIndex = 1; binaryDigitIndex < i_BinaryRepresentation.Length; binaryDigitIndex++)
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
			BinaryNumberInfo[] binaryNumberInfosSortedByDescendingDecimalValue;
			int outerIndex;
			int innerIndex;

			binaryNumberInfosSortedByDescendingDecimalValue = (BinaryNumberInfo[])i_BinaryNumberInfos.Clone();

			for(outerIndex = 0; outerIndex < binaryNumberInfosSortedByDescendingDecimalValue.Length - 1; outerIndex++)
			{
				for(innerIndex = outerIndex + 1; innerIndex < binaryNumberInfosSortedByDescendingDecimalValue.Length; innerIndex++)
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
			BinaryNumberInfo currentBinaryNumberInfo;

			currentBinaryNumberInfo = io_BinaryNumberInfos[i_FirstBinaryNumberInfoIndex];
			io_BinaryNumberInfos[i_FirstBinaryNumberInfoIndex] = io_BinaryNumberInfos[i_SecondBinaryNumberInfoIndex];
			io_BinaryNumberInfos[i_SecondBinaryNumberInfoIndex] = currentBinaryNumberInfo;
		}

		private int getLongestBitSequenceLength(BinaryNumberInfo[] i_BinaryNumberInfosSortedByDescendingDecimalValue)
		{
			int longestBitSequenceLength;
			int binaryNumberIndex;

			longestBitSequenceLength = 0;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length; binaryNumberIndex++)
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
			string[] binaryRepresentationsWithLongestBitSequence;
			int longestBitSequenceCount;
			int binaryNumberIndex;
			int longestBitSequenceIndex;

			longestBitSequenceCount = 0;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length; binaryNumberIndex++)
			{
				if(i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].LongestBitSequenceLength ==
					i_LongestBitSequenceLength)
				{
					longestBitSequenceCount++;
				}
			}

			binaryRepresentationsWithLongestBitSequence = new string[longestBitSequenceCount];
			longestBitSequenceIndex = 0;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length; binaryNumberIndex++)
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
			int totalOneBits;
			int binaryNumberIndex;

			totalOneBits = 0;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfos.Length; binaryNumberIndex++)
			{
				totalOneBits += i_BinaryNumberInfos[binaryNumberIndex].OneBitsCount;
			}

			return totalOneBits;
		}

		private BinaryNumberInfo getBinaryNumberWithMostTransitions(BinaryNumberInfo[] i_BinaryNumberInfos)
		{
			BinaryNumberInfo binaryNumberWithMostTransitions;
			int binaryNumberIndex;

			binaryNumberWithMostTransitions = i_BinaryNumberInfos[0];

			for(binaryNumberIndex = 1; binaryNumberIndex < i_BinaryNumberInfos.Length; binaryNumberIndex++)
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
			string[] binaryRepresentationsDivisibleByFour;
			int divisibleByFourCount;
			int binaryNumberIndex;
			int divisibleByFourIndex;

			divisibleByFourCount = 0;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length; binaryNumberIndex++)
			{
				if(i_BinaryNumberInfosSortedByDescendingDecimalValue[binaryNumberIndex].DecimalValue % 4 == 0)
				{
					divisibleByFourCount++;
				}
			}

			binaryRepresentationsDivisibleByFour = new string[divisibleByFourCount];
			divisibleByFourIndex = divisibleByFourCount - 1;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfosSortedByDescendingDecimalValue.Length; binaryNumberIndex++)
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
			double averageDecimalValue;
			int totalDecimalValue;
			int binaryNumberIndex;

			totalDecimalValue = 0;

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumberInfos.Length; binaryNumberIndex++)
			{
				totalDecimalValue += i_BinaryNumberInfos[binaryNumberIndex].DecimalValue;
			}

			averageDecimalValue = totalDecimalValue / (double)i_BinaryNumberInfos.Length;

			return averageDecimalValue;
		}
	}
}
