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
			string[] validBinaryNumbers;
			int binaryNumberIndex;

			validBinaryNumbers = new string[k_NumberOfBinaryNumbers];
			Console.WriteLine(k_BatchInputPromptMessage);

			for(binaryNumberIndex = 0; binaryNumberIndex < k_NumberOfBinaryNumbers; binaryNumberIndex++)
			{
				validBinaryNumbers[binaryNumberIndex] = readValidBinaryNumber();
			}

			return validBinaryNumbers;
		}

		private string readValidBinaryNumber()
		{
			string binaryNumberFromUser;
			string validationErrorMessage;
			bool v_IsBinaryNumberValid;

			binaryNumberFromUser = string.Empty;
			validationErrorMessage = string.Empty;
			v_IsBinaryNumberValid = false;

			while(!v_IsBinaryNumberValid)
			{
				binaryNumberFromUser = Console.ReadLine();
				validationErrorMessage = getBinaryNumberValidationErrorMessage(binaryNumberFromUser);
				v_IsBinaryNumberValid = validationErrorMessage == string.Empty;

				if(!v_IsBinaryNumberValid)
				{
					Console.WriteLine(validationErrorMessage);
				}
			}

			return binaryNumberFromUser;
		}

		private string getBinaryNumberValidationErrorMessage(string i_BinaryNumber)
		{
			string validationErrorMessage;

			validationErrorMessage = string.Empty;

			if(isBinaryNumberEmpty(i_BinaryNumber))
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

		private bool isBinaryNumberEmpty(string i_BinaryNumber)
		{
			bool v_IsBinaryNumberEmpty;

			v_IsBinaryNumberEmpty = string.IsNullOrEmpty(i_BinaryNumber);

			return v_IsBinaryNumberEmpty;
		}

		private bool isBinaryNumberLengthValid(string i_BinaryNumber)
		{
			bool v_IsBinaryNumberLengthValid;

			v_IsBinaryNumberLengthValid = i_BinaryNumber.Length == k_BinaryNumberLength;

			return v_IsBinaryNumberLengthValid;
		}

		private bool containsOnlyBinaryDigits(string i_BinaryNumber)
		{
			bool v_ContainsOnlyBinaryDigits;
			int binaryDigitIndex;
			char currentCharacter;

			v_ContainsOnlyBinaryDigits = true;

			for(binaryDigitIndex = 0; binaryDigitIndex < i_BinaryNumber.Length && v_ContainsOnlyBinaryDigits; binaryDigitIndex++)
			{
				currentCharacter = i_BinaryNumber[binaryDigitIndex];
				v_ContainsOnlyBinaryDigits = isBinaryDigit(currentCharacter);
			}

			return v_ContainsOnlyBinaryDigits;
		}

		private bool isBinaryDigit(char i_Character)
		{
			bool v_IsBinaryDigit;

			v_IsBinaryDigit = Char.IsDigit(i_Character) && (i_Character == '0' || i_Character == '1');

			return v_IsBinaryDigit;
		}
	}
}
