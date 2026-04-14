using System;

namespace Ex01_01
{
	internal class BinarySeriesInputReader
	{
		private const int k_NumberOfBinaryNumbers = 4;
		private const int k_BinaryNumberLength = 7;
		private const string k_BatchInputPromptMessage = "Please enter 4 binary numbers with 7 digits each:";
		private const string k_EmptyInputMessage = "The input cannot be empty. Please enter exactly 7 binary digits.";
		private const string k_InvalidLengthInputMessage = "The input must contain exactly 7 binary digits.";
		private const string k_InvalidCharactersInputMessage = "The input must contain only binary digits: 0 or 1.";

		public string[] ReadValidBinaryNumbers()
		{
			string[] validBinaryNumbers = new string[k_NumberOfBinaryNumbers];

			Console.WriteLine(k_BatchInputPromptMessage);
			for(int binaryNumberIndex = 0; binaryNumberIndex < k_NumberOfBinaryNumbers; binaryNumberIndex++)
			{
				validBinaryNumbers[binaryNumberIndex] = readValidBinaryNumber();
			}

			return validBinaryNumbers;
		}

		private string readValidBinaryNumber()
		{
			string binaryNumberFromUser = string.Empty;
			string validationErrorMessage = string.Empty;

			do
			{
				binaryNumberFromUser = Console.ReadLine();
				validationErrorMessage = getBinaryNumberValidationErrorMessage(binaryNumberFromUser);

				if(validationErrorMessage != string.Empty)
				{
					Console.WriteLine(validationErrorMessage);
				}
			}
			while(validationErrorMessage != string.Empty);

			return binaryNumberFromUser;
		}

		private string getBinaryNumberValidationErrorMessage(string i_BinaryNumber)
		{
			string validationErrorMessage = string.Empty;

			if(!containsAtLeastOneCharacter(i_BinaryNumber))
			{
				validationErrorMessage = k_EmptyInputMessage;
			}
			else if(!isBinaryNumberLengthValid(i_BinaryNumber))
			{
				validationErrorMessage = k_InvalidLengthInputMessage;
			}
			else if(!containsOnlyBinaryDigits(i_BinaryNumber))
			{
				validationErrorMessage = k_InvalidCharactersInputMessage;
			}

			return validationErrorMessage;
		}

		private bool containsAtLeastOneCharacter(string i_BinaryNumber)
		{
			return !string.IsNullOrEmpty(i_BinaryNumber);
		}

		private bool isBinaryNumberLengthValid(string i_BinaryNumber)
		{
			return i_BinaryNumber.Length == k_BinaryNumberLength;
		}

		private bool containsOnlyBinaryDigits(string i_BinaryNumber)
		{
			bool v_ContainsOnlyBinaryDigits = true;

			for(int binaryDigitIndex = 0; binaryDigitIndex < i_BinaryNumber.Length && v_ContainsOnlyBinaryDigits; binaryDigitIndex++)
			{
				char currentCharacter = i_BinaryNumber[binaryDigitIndex];

				v_ContainsOnlyBinaryDigits = isBinaryDigit(currentCharacter);
			}

			return v_ContainsOnlyBinaryDigits;
		}

		private bool isBinaryDigit(char i_Character)
		{
			return Char.IsDigit(i_Character) && (i_Character == '0' || i_Character == '1');
		}
	}
}
