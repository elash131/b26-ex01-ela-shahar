using System;

namespace Ex01_01
{
	public class Program
	{
		private const int k_NumberOfBinaryNumbers = 4;
		private const int k_BinaryNumberLength = 7;

		static void Main()
		{
			runBinarySeries();
		}

		private static void runBinarySeries()
		{
			string[] binaryNumbers = readValidBinaryNumbers();
			int[] decimalNumbers = createDecimalNumbers(binaryNumbers);

			sortBinaryNumbersByDescendingDecimalValue(binaryNumbers, decimalNumbers);
			printBinarySeriesReport(binaryNumbers, decimalNumbers);
		}

		private static string[] readValidBinaryNumbers()
		{
			string[] validBinaryNumbers = new string[k_NumberOfBinaryNumbers];

			Console.WriteLine("Please enter 4 binary numbers with 7 digits each:");
			for (int binaryNumberIndex = 0; binaryNumberIndex < k_NumberOfBinaryNumbers; binaryNumberIndex++)
			{
				validBinaryNumbers[binaryNumberIndex] = readValidBinaryNumber();
			}

			return validBinaryNumbers;
		}

		private static string readValidBinaryNumber()
		{
			string binaryNumberFromUser = string.Empty;
			string validationErrorMessage = string.Empty;
			bool v_ShouldReadAnotherBinaryNumber = true;

			while (v_ShouldReadAnotherBinaryNumber)
			{
				binaryNumberFromUser = Console.ReadLine();
				validationErrorMessage = getBinaryNumberValidationErrorMessage(binaryNumberFromUser);
				v_ShouldReadAnotherBinaryNumber = validationErrorMessage != string.Empty;

				if (v_ShouldReadAnotherBinaryNumber)
				{
					Console.WriteLine(validationErrorMessage);
				}
			}

			return binaryNumberFromUser;
		}

		private static string getBinaryNumberValidationErrorMessage(string i_BinaryNumber)
		{
			string validationErrorMessage = string.Empty;

			if (!containsAtLeastOneCharacter(i_BinaryNumber))
			{
				validationErrorMessage = "The input cannot be empty. Please enter exactly 7 binary digits.";
			}
			else if (!isBinaryNumberLengthValid(i_BinaryNumber))
			{
				validationErrorMessage = "The input must contain exactly 7 binary digits.";
			}
			else if (!containsOnlyBinaryDigits(i_BinaryNumber))
			{
				validationErrorMessage = "The input must contain only binary digits: 0 or 1.";
			}

			return validationErrorMessage;
		}

		private static bool containsAtLeastOneCharacter(string i_BinaryNumber)
		{
			return !string.IsNullOrEmpty(i_BinaryNumber);
		}

		private static bool isBinaryNumberLengthValid(string i_BinaryNumber)
		{
			return i_BinaryNumber.Length == k_BinaryNumberLength;
		}

		private static bool containsOnlyBinaryDigits(string i_BinaryNumber)
		{
			bool v_ContainsOnlyBinaryDigits = true;

			for (int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryNumber.Length && v_ContainsOnlyBinaryDigits; binaryDigitIndex++)
			{
				v_ContainsOnlyBinaryDigits = isBinaryDigit(i_BinaryNumber[binaryDigitIndex]);
			}

			return v_ContainsOnlyBinaryDigits;
		}

		private static bool isBinaryDigit(char i_Character)
		{
			return i_Character == '0' || i_Character == '1';
		}

		private static int[] createDecimalNumbers(string[] i_BinaryNumbers)
		{
			int[] decimalNumbers = new int[i_BinaryNumbers.Length];

			for (int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				decimalNumbers[binaryNumberIndex] = convertBinaryStringToDecimal(i_BinaryNumbers[binaryNumberIndex]);
			}

			return decimalNumbers;
		}

		private static int convertBinaryStringToDecimal(string i_BinaryNumber)
		{
			int decimalValue = 0;

			for (int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryNumber.Length; binaryDigitIndex++)
			{
				decimalValue *= 2;
				decimalValue += i_BinaryNumber[binaryDigitIndex] - '0';
			}

			return decimalValue;
		}

		private static void sortBinaryNumbersByDescendingDecimalValue(string[] io_BinaryNumbers, int[] io_DecimalNumbers)
		{
			for (int outerIndex = 0; outerIndex < io_DecimalNumbers.Length - 1; outerIndex++)
			{
				for (int innerIndex = outerIndex + 1; innerIndex < io_DecimalNumbers.Length; innerIndex++)
				{
					if (io_DecimalNumbers[innerIndex] > io_DecimalNumbers[outerIndex])
					{
						swapBinaryNumberAndDecimalNumber(io_BinaryNumbers, io_DecimalNumbers, outerIndex, innerIndex);
					}
				}
			}
		}

		private static void swapBinaryNumberAndDecimalNumber(
			string[] io_BinaryNumbers,
			int[] io_DecimalNumbers,
			int i_FirstIndex,
			int i_SecondIndex)
		{
			string tempBinaryNumber = io_BinaryNumbers[i_FirstIndex];
			int tempDecimalNumber = io_DecimalNumbers[i_FirstIndex];

			io_BinaryNumbers[i_FirstIndex] = io_BinaryNumbers[i_SecondIndex];
			io_DecimalNumbers[i_FirstIndex] = io_DecimalNumbers[i_SecondIndex];
			io_BinaryNumbers[i_SecondIndex] = tempBinaryNumber;
			io_DecimalNumbers[i_SecondIndex] = tempDecimalNumber;
		}

		private static void printBinarySeriesReport(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
		{
			int longestBitSequenceLength = getLongestBitSequenceLength(i_BinaryNumbers);
			int binaryNumberWithMostTransitionsIndex = getBinaryNumberWithMostTransitionsIndex(i_BinaryNumbers, i_DecimalNumbers);

			printDescendingDecimalNumbersLine(i_BinaryNumbers, i_DecimalNumbers);
			Console.WriteLine("Average: {0:F2}", getAverageDecimalValue(i_DecimalNumbers));
			Console.WriteLine(
				"Longest bit sequence: {0} ({1})",
				longestBitSequenceLength,
				createCommaSeparatedBinaryRepresentationsWithLongestBitSequence(i_BinaryNumbers, longestBitSequenceLength));
			Console.WriteLine("Total 1-bits: {0}", getTotalOneBits(i_BinaryNumbers));
			Console.WriteLine(
				"Number with most transitions: {0} ({1}) - {2} transitions",
				i_DecimalNumbers[binaryNumberWithMostTransitionsIndex],
				i_BinaryNumbers[binaryNumberWithMostTransitionsIndex],
				countTransitionsBetweenAdjacentBits(i_BinaryNumbers[binaryNumberWithMostTransitionsIndex]));
			printNumbersDivisibleByFourLine(i_BinaryNumbers, i_DecimalNumbers);
		}

		private static void printDescendingDecimalNumbersLine(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
		{
			string descendingDecimalNumbersLine = "Decimal numbers in descending order: ";

			for (int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				if (binaryNumberIndex > 0)
				{
					descendingDecimalNumbersLine += ", ";
				}

				descendingDecimalNumbersLine += string.Format("{0} ({1})", i_DecimalNumbers[binaryNumberIndex], i_BinaryNumbers[binaryNumberIndex]);
			}

			Console.WriteLine(descendingDecimalNumbersLine);
		}

		private static double getAverageDecimalValue(int[] i_DecimalNumbers)
		{
			int totalDecimalValue = 0;

			for (int decimalNumberIndex = 0; decimalNumberIndex < i_DecimalNumbers.Length; decimalNumberIndex++)
			{
				totalDecimalValue += i_DecimalNumbers[decimalNumberIndex];
			}

			return totalDecimalValue / (double)i_DecimalNumbers.Length;
		}

		private static int getLongestBitSequenceLength(string[] i_BinaryNumbers)
		{
			int longestBitSequenceLength = 0;

			for (int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				int currentLongestBitSequenceLength =
					calculateLongestIdenticalBitSequenceLength(i_BinaryNumbers[binaryNumberIndex]);

				if (currentLongestBitSequenceLength > longestBitSequenceLength)
				{
					longestBitSequenceLength = currentLongestBitSequenceLength;
				}
			}

			return longestBitSequenceLength;
		}

		private static int calculateLongestIdenticalBitSequenceLength(string i_BinaryNumber)
		{
			int longestBitSequenceLength = 0;
			int currentBitSequenceLength = 0;

			for (int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryNumber.Length; binaryDigitIndex++)
			{
				if (binaryDigitIndex == 0 || i_BinaryNumber[binaryDigitIndex] == i_BinaryNumber[binaryDigitIndex - 1])
				{
					currentBitSequenceLength++;
				}
				else
				{
					currentBitSequenceLength = 1;
				}

				if (currentBitSequenceLength > longestBitSequenceLength)
				{
					longestBitSequenceLength = currentBitSequenceLength;
				}
			}

			return longestBitSequenceLength;
		}

		private static string createCommaSeparatedBinaryRepresentationsWithLongestBitSequence(string[] i_BinaryNumbers, int i_LongestBitSequenceLength)
		{
			string commaSeparatedBinaryRepresentations = string.Empty;

			for (int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				if (calculateLongestIdenticalBitSequenceLength(i_BinaryNumbers[binaryNumberIndex]) == i_LongestBitSequenceLength)
				{
					if (commaSeparatedBinaryRepresentations != string.Empty)
					{
						commaSeparatedBinaryRepresentations += ", ";
					}

					commaSeparatedBinaryRepresentations += i_BinaryNumbers[binaryNumberIndex];
				}
			}

			return commaSeparatedBinaryRepresentations;
		}

		private static int getTotalOneBits(string[] i_BinaryNumbers)
		{
			int totalOneBits = 0;

			for (int binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				totalOneBits += countOneBits(i_BinaryNumbers[binaryNumberIndex]);
			}

			return totalOneBits;
		}

		private static int countOneBits(string i_BinaryNumber)
		{
			int oneBitsCount = 0;

			for (int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryNumber.Length; binaryDigitIndex++)
			{
				if (i_BinaryNumber[binaryDigitIndex] == '1')
				{
					oneBitsCount++;
				}
			}

			return oneBitsCount;
		}

		private static int getBinaryNumberWithMostTransitionsIndex(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
		{
			int binaryNumberWithMostTransitionsIndex = 0;

			for (int binaryNumberIndex = 1; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				int currentTransitionCount = countTransitionsBetweenAdjacentBits(i_BinaryNumbers[binaryNumberIndex]);
				int mostTransitionsCount = countTransitionsBetweenAdjacentBits(i_BinaryNumbers[binaryNumberWithMostTransitionsIndex]);

				if (currentTransitionCount > mostTransitionsCount)
				{
					binaryNumberWithMostTransitionsIndex = binaryNumberIndex;
				}
				else if (currentTransitionCount == mostTransitionsCount && i_DecimalNumbers[binaryNumberIndex] < i_DecimalNumbers[binaryNumberWithMostTransitionsIndex])
				{
					binaryNumberWithMostTransitionsIndex = binaryNumberIndex;
				}
			}

			return binaryNumberWithMostTransitionsIndex;
		}

		private static int countTransitionsBetweenAdjacentBits(string i_BinaryNumber)
		{
			int transitionCount = 0;

			for (int binaryDigitIndex = 1; binaryDigitIndex < i_BinaryNumber.Length; binaryDigitIndex++)
			{
				if (i_BinaryNumber[binaryDigitIndex] != i_BinaryNumber[binaryDigitIndex - 1])
				{
					transitionCount++;
				}
			}

			return transitionCount;
		}

		private static void printNumbersDivisibleByFourLine(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
		{
			string numbersDivisibleByFourLine = string.Format("Numbers divisible by 4: {0}", countNumbersDivisibleByFour(i_DecimalNumbers));
			string binaryRepresentationsDivisibleByFour = createCommaSeparatedBinaryRepresentationsDivisibleByFourInAscendingDecimalOrder(i_BinaryNumbers, i_DecimalNumbers);

			if (binaryRepresentationsDivisibleByFour != string.Empty)
			{
				numbersDivisibleByFourLine += string.Format(" ({0})", binaryRepresentationsDivisibleByFour);
			}

			Console.WriteLine(numbersDivisibleByFourLine);
		}

		private static int countNumbersDivisibleByFour(int[] i_DecimalNumbers)
		{
			int numbersDivisibleByFourCount = 0;

			for (int decimalNumberIndex = 0; decimalNumberIndex < i_DecimalNumbers.Length; decimalNumberIndex++)
			{
				if (i_DecimalNumbers[decimalNumberIndex] % 4 == 0)
				{
					numbersDivisibleByFourCount++;
				}
			}

			return numbersDivisibleByFourCount;
		}

		private static string createCommaSeparatedBinaryRepresentationsDivisibleByFourInAscendingDecimalOrder(
			string[] i_BinaryNumbers,
			int[] i_DecimalNumbers)
		{
			string commaSeparatedBinaryRepresentations = string.Empty;

			for (int binaryNumberIndex = i_BinaryNumbers.Length - 1; binaryNumberIndex >= 0; binaryNumberIndex--)
			{
				if (i_DecimalNumbers[binaryNumberIndex] % 4 == 0)
				{
					if (commaSeparatedBinaryRepresentations != string.Empty)
					{
						commaSeparatedBinaryRepresentations += ", ";
					}

					commaSeparatedBinaryRepresentations += i_BinaryNumbers[binaryNumberIndex];
				}
			}

			return commaSeparatedBinaryRepresentations;
		}
	}
}
