using System;

namespace Ex01_05
{
	public class Program
	{
		static void Main()
		{
			runNumberAnalysis();
		}

		private static void runNumberAnalysis()
		{
			string validInput = readValid9DigitIntegerInput();

			printNumberAnalysisReport(validInput);
		}

		private static string readValid9DigitIntegerInput()
		{
			bool v_ShouldReadAnotherInput = true;
			string validInput = string.Empty;

			Console.WriteLine("Please enter a 9-digit integer number:");
			while (v_ShouldReadAnotherInput)
			{
				validInput = Console.ReadLine();

				if (validInput.Length != 9)
				{
					Console.WriteLine("The input must contain exactly 9 digits.");
				}
				else if (!containsOnlyDigits(validInput))
				{
					Console.WriteLine("Invalid input. Please enter an integer number.");
				}
				else
				{
					v_ShouldReadAnotherInput = false;
				}
			}

			return validInput;
		}

		private static bool containsOnlyDigits(string i_Input)
		{
			bool v_ContainsOnlyDigits = true;

			for (int characterIndex = 0; characterIndex < i_Input.Length && v_ContainsOnlyDigits; characterIndex++)
			{
				v_ContainsOnlyDigits = Char.IsDigit(i_Input[characterIndex]);
			}

			return v_ContainsOnlyDigits;
		}

		private static void printNumberAnalysisReport(string i_Input)
		{
			int digitsGreaterThanUnitsDigitCount = countDigitsGreaterThanUnitsDigit(i_Input);
			int digitsDivisibleByFourCount = countDigitsDivisibleByFour(i_Input);
			int largestDigitTimesSmallestDigit = calculateLargestDigitTimesSmallestDigit(i_Input);
			int differentDigitsCount = countDifferentDigits(i_Input);

			Console.WriteLine("Number of digits greater than the units digit: {0}", digitsGreaterThanUnitsDigitCount);
			Console.WriteLine("Number of digits divisible by 4: {0}", digitsDivisibleByFourCount);
			Console.WriteLine("Largest digit times smallest digit: {0}", largestDigitTimesSmallestDigit);
			Console.WriteLine("Number of different digits: {0}", differentDigitsCount);
		}

		private static int countDigitsGreaterThanUnitsDigit(string i_Number)
		{
			int unitDigit = i_Number[i_Number.Length - 1] - '0';
			int currentDigit;
			int countDigitsGreaterThanUnitsDigit = 0;

			for (int digitIndex = 0; digitIndex < i_Number.Length - 1; digitIndex++)
			{
				currentDigit = i_Number[digitIndex] - '0';
				if (currentDigit > unitDigit)
				{
					countDigitsGreaterThanUnitsDigit++;
				}
			}

			return countDigitsGreaterThanUnitsDigit;
		}

		private static int countDigitsDivisibleByFour(string i_Number)
		{
			int currentDigit;
			int countDigitsDivisibleByFour = 0;

			for (int digitIndex = 0; digitIndex < i_Number.Length; digitIndex++)
			{
				currentDigit = i_Number[digitIndex] - '0';
				if (currentDigit % 4 == 0)
				{
					countDigitsDivisibleByFour++;
				}
			}

			return countDigitsDivisibleByFour;
		}

		private static int calculateLargestDigitTimesSmallestDigit(string i_Number)
		{
			int largestDigit;
			int smallestDigit;
			int currentDigit;
			int largestDigitTimesSmallestDigit;

			largestDigit = smallestDigit = i_Number[0] - '0';
			for (int digitIndex = 1; digitIndex < i_Number.Length; digitIndex++)
			{
				currentDigit = i_Number[digitIndex] - '0';
				largestDigit = Math.Max(largestDigit, currentDigit);
				smallestDigit = Math.Min(smallestDigit, currentDigit);
			}

			largestDigitTimesSmallestDigit = largestDigit * smallestDigit;

			return largestDigitTimesSmallestDigit;
		}

		private static int countDifferentDigits(string i_Number)
		{
			int differentDigitsCount = 0;

			for (int digitToFind = 0; digitToFind <= 9; digitToFind++)
			{
				if (doesDigitAppearInNumber(i_Number, digitToFind))
				{
					differentDigitsCount++;
				}
			}

			return differentDigitsCount;
		}

		private static bool doesDigitAppearInNumber(string i_Number, int i_DigitToFind)
		{
			bool v_DoesDigitAppearInNumber = false;
			int digitIndex = 0;
			int currentDigit;

			while (digitIndex < i_Number.Length && !v_DoesDigitAppearInNumber)
			{
				currentDigit = i_Number[digitIndex] - '0';
				v_DoesDigitAppearInNumber = currentDigit == i_DigitToFind;

				digitIndex++;
			}

			return v_DoesDigitAppearInNumber;
		}
	}
}
