using System;

namespace Ex01_04
{
	internal class StringAnalysisInputReader
	{
		private const int k_RequiredInputLength = 8;
		private const string k_InputPromptMessage = "Please enter an 8-character string:";
		private const string k_InvalidLengthInputMessage = "The input must contain exactly 8 characters.";

		public string ReadValidInput()
		{
			string validInput = string.Empty;
			bool v_ShouldReadAnotherInput = true;

			Console.WriteLine(k_InputPromptMessage);
			while(v_ShouldReadAnotherInput)
			{
				validInput = Console.ReadLine();
				v_ShouldReadAnotherInput = !isInputLengthValid(validInput);

				if(v_ShouldReadAnotherInput)
				{
					Console.WriteLine(k_InvalidLengthInputMessage);
				}
			}

			return validInput;
		}

		private bool isInputLengthValid(string i_Input)
		{
			bool v_IsInputLengthValid = i_Input != null;

			if(v_IsInputLengthValid)
			{
				v_IsInputLengthValid = i_Input.Length == k_RequiredInputLength;
			}

			return v_IsInputLengthValid;
		}
	}
}
