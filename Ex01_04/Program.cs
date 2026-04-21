using System;

namespace Ex01_04
{
	public class Program
	{
		static void Main()
		{
			runStringAnalysis();
		}

		private static void runStringAnalysis()
		{
			string validInput = readValid8CharactersInput();

			printStringAnalysisReport(validInput);
		}

		private static string readValid8CharactersInput()
		{
			string validInput = string.Empty;
			bool v_ShouldReadAnotherInput = true;

			Console.WriteLine("Please enter an 8-character string:");
			while (v_ShouldReadAnotherInput)
			{
				validInput = Console.ReadLine();
				v_ShouldReadAnotherInput = !isInputLengthValid(validInput);

				if (v_ShouldReadAnotherInput)
				{
					Console.WriteLine("The input must contain exactly 8 characters.");
				}
			}

			return validInput;
		}

		private static bool isInputLengthValid(string i_Input)
		{
			bool v_IsInputLengthValid = i_Input != null;

			if (v_IsInputLengthValid)
			{
				v_IsInputLengthValid = i_Input.Length == 8;
			}

			return v_IsInputLengthValid;
		}

		private static void printStringAnalysisReport(string i_Input)
		{
			bool v_IsDigitsOnly = containsOnlyDigits(i_Input);
			bool v_IsEnglishLettersOnly = containsOnlyEnglishLetters(i_Input);
			bool v_IsPalindrome = isCaseInsensitivePalindrome(i_Input);
			bool v_IsDivisibleByFour = false;
			bool v_IsInDescendingAlphabeticalOrder = false;
			int uppercaseLettersCount = 0;

			if (v_IsDigitsOnly)
			{
				v_IsDivisibleByFour = isNumberDivisibleByFour(i_Input);
			}

			if (v_IsEnglishLettersOnly)
			{
				uppercaseLettersCount = countUppercaseEnglishLetters(i_Input);
				v_IsInDescendingAlphabeticalOrder = isInDescendingAlphabeticalOrder(i_Input);
			}

			Console.WriteLine("Is palindrome: {0}", formatBooleanAnswer(v_IsPalindrome));
			if (v_IsDigitsOnly)
			{
				Console.WriteLine("Is divisible by 4 without remainder: {0}", formatBooleanAnswer(v_IsDivisibleByFour));
			}

			if (v_IsEnglishLettersOnly)
			{
				Console.WriteLine("Number of uppercase letters: {0}", uppercaseLettersCount);
				Console.WriteLine("Is in descending alphabetical order: {0}", formatBooleanAnswer(v_IsInDescendingAlphabeticalOrder));
			}
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

		private static bool containsOnlyEnglishLetters(string i_Input)
		{
			bool v_ContainsOnlyEnglishLetters = true;

			for (int characterIndex = 0; characterIndex < i_Input.Length && v_ContainsOnlyEnglishLetters; characterIndex++)
			{
				v_ContainsOnlyEnglishLetters = isEnglishLetter(i_Input[characterIndex]);
			}

			return v_ContainsOnlyEnglishLetters;
		}

		private static bool isEnglishLetter(char i_Character)
		{
			char lowercaseCharacter = Char.ToLower(i_Character);
			bool v_IsEnglishLetter = lowercaseCharacter >= 'a' && lowercaseCharacter <= 'z';

			return v_IsEnglishLetter;
		}

		private static bool isNumberDivisibleByFour(string i_Input)
		{
			bool v_IsNumberDivisibleByFour = int.TryParse(i_Input, out int parsedNumber);

			if (v_IsNumberDivisibleByFour)
			{
				v_IsNumberDivisibleByFour = parsedNumber % 4 == 0;
			}

			return v_IsNumberDivisibleByFour;
		}

		private static int countUppercaseEnglishLetters(string i_Input)
		{
			int uppercaseLettersCount = 0;

			for (int characterIndex = 0; characterIndex < i_Input.Length; characterIndex++)
			{
				if (Char.IsUpper(i_Input[characterIndex]))
				{
					uppercaseLettersCount++;
				}
			}

			return uppercaseLettersCount;
		}

		private static bool isInDescendingAlphabeticalOrder(string i_Input)
		{
			bool v_IsInDescendingAlphabeticalOrder = true;

			for (int characterIndex = 1; characterIndex < i_Input.Length && v_IsInDescendingAlphabeticalOrder; characterIndex++)
			{
				v_IsInDescendingAlphabeticalOrder = getLowercaseCharacter(i_Input[characterIndex - 1]) > getLowercaseCharacter(i_Input[characterIndex]);
			}

			return v_IsInDescendingAlphabeticalOrder;
		}

		private static char getLowercaseCharacter(char i_Character)
		{
			char lowercaseCharacter = Char.ToLower(i_Character);

			return lowercaseCharacter;
		}

		private static bool isCaseInsensitivePalindrome(string i_Input)
		{
			bool v_IsCaseInsensitivePalindrome = isCaseInsensitivePalindromeRecursive(i_Input, 0, i_Input.Length - 1);

			return v_IsCaseInsensitivePalindrome;
		}

		private static bool isCaseInsensitivePalindromeRecursive(string i_Input, int i_LeftIndex, int i_RightIndex)
		{
			bool v_IsCaseInsensitivePalindrome = true;
			bool v_HasMoreCharactersToCompare = i_LeftIndex < i_RightIndex;

			if (v_HasMoreCharactersToCompare)
			{
				if (areCharactersEqualIgnoringCase(i_Input[i_LeftIndex], i_Input[i_RightIndex]))
				{
					v_IsCaseInsensitivePalindrome = isCaseInsensitivePalindromeRecursive(i_Input, i_LeftIndex + 1, i_RightIndex - 1);
				}
				else
				{
					v_IsCaseInsensitivePalindrome = false;
				}
			}

			return v_IsCaseInsensitivePalindrome;
		}

		private static bool areCharactersEqualIgnoringCase(char i_FirstCharacter, char i_SecondCharacter)
		{
			bool v_AreCharactersEqualIgnoringCase = getLowercaseCharacter(i_FirstCharacter) == getLowercaseCharacter(i_SecondCharacter);

			return v_AreCharactersEqualIgnoringCase;
		}

		private static string formatBooleanAnswer(bool i_BooleanAnswer)
		{
			string formattedBooleanAnswer = "No";

			if (i_BooleanAnswer)
			{
				formattedBooleanAnswer = "Yes";
			}

			return formattedBooleanAnswer;
		}
	}
}
