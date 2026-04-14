using System;

namespace Ex01_04
{
	internal class StringAnalysisAnalyzer
	{
		public StringAnalysisReport CreateStringAnalysisReport(string i_Input)
		{
			bool v_IsDigitsOnly = containsOnlyDigits(i_Input);
			bool v_IsEnglishLettersOnly = containsOnlyEnglishLetters(i_Input);
			bool v_IsDivisibleByFour = v_IsDigitsOnly && isNumberDivisibleByFour(i_Input);
			bool v_IsInDescendingAlphabeticalOrder = v_IsEnglishLettersOnly && isInDescendingAlphabeticalOrder(i_Input);
			bool v_IsPalindrome = isCaseInsensitivePalindrome(i_Input);
            int uppercaseLettersCount = 0;
			StringAnalysisReport stringAnalysisReport;

			if(v_IsEnglishLettersOnly)
			{
				uppercaseLettersCount = countUppercaseEnglishLetters(i_Input);
			}

			stringAnalysisReport = new StringAnalysisReport(
				i_Input,
				v_IsDigitsOnly,
				v_IsEnglishLettersOnly,
				v_IsDivisibleByFour,
				uppercaseLettersCount,
				v_IsInDescendingAlphabeticalOrder,
				v_IsPalindrome);

			return stringAnalysisReport;
		}

		private bool containsOnlyDigits(string i_Input)
		{
			bool v_ContainsOnlyDigits = true;

			for(int characterIndex = 0; characterIndex < i_Input.Length && v_ContainsOnlyDigits; characterIndex++)
			{
				v_ContainsOnlyDigits = Char.IsDigit(i_Input[characterIndex]);
			}

			return v_ContainsOnlyDigits;
		}

		private bool containsOnlyEnglishLetters(string i_Input)
		{
			bool v_ContainsOnlyEnglishLetters = true;

			for(int characterIndex = 0; characterIndex < i_Input.Length && v_ContainsOnlyEnglishLetters; characterIndex++)
			{
				v_ContainsOnlyEnglishLetters = isEnglishLetter(i_Input[characterIndex]);
			}

			return v_ContainsOnlyEnglishLetters;
		}

		private bool isEnglishLetter(char i_Character)
		{
			char lowercaseCharacter = Char.ToLower(i_Character);

			return lowercaseCharacter >= 'a' && lowercaseCharacter <= 'z';
		}

		private bool isNumberDivisibleByFour(string i_Input)
		{
			int parsedNumber = 0;
			bool v_IsNumberDivisibleByFour = int.TryParse(i_Input, out parsedNumber);

			if(v_IsNumberDivisibleByFour)
			{
				v_IsNumberDivisibleByFour = parsedNumber % 4 == 0;
			}

			return v_IsNumberDivisibleByFour;
		}

		private int countUppercaseEnglishLetters(string i_Input)
		{
			int uppercaseLettersCount = 0;

			for(int characterIndex = 0; characterIndex < i_Input.Length; characterIndex++)
			{
				if(Char.IsUpper(i_Input[characterIndex]))
				{
					uppercaseLettersCount++;
				}
			}

			return uppercaseLettersCount;
		}

		private bool isInDescendingAlphabeticalOrder(string i_Input)
		{
			bool v_IsInDescendingAlphabeticalOrder = true;

			for(int characterIndex = 1; characterIndex < i_Input.Length && v_IsInDescendingAlphabeticalOrder; characterIndex++)
			{
				v_IsInDescendingAlphabeticalOrder = getLowercaseCharacter(i_Input[characterIndex - 1]) > getLowercaseCharacter(i_Input[characterIndex]);
			}

			return v_IsInDescendingAlphabeticalOrder;
		}

		private char getLowercaseCharacter(char i_Character)
		{
			return Char.ToLower(i_Character);
		}

		private bool isCaseInsensitivePalindrome(string i_Input)
		{
			return isCaseInsensitivePalindromeRecursive(i_Input, 0, i_Input.Length - 1);
		}

		private bool isCaseInsensitivePalindromeRecursive(string i_Input, int i_LeftIndex, int i_RightIndex)
		{
			bool v_IsCaseInsensitivePalindrome = true;
			bool v_HasMoreCharactersToCompare = i_LeftIndex < i_RightIndex;

			if(v_HasMoreCharactersToCompare)
			{
				if(areCharactersEqualIgnoringCase(i_Input[i_LeftIndex], i_Input[i_RightIndex]))
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

		private bool areCharactersEqualIgnoringCase(char i_FirstCharacter, char i_SecondCharacter)
		{
			return getLowercaseCharacter(i_FirstCharacter) == getLowercaseCharacter(i_SecondCharacter);
		}
	}
}
