using System.Text;

namespace Ex01_04
{
	internal class StringAnalysisFormatter
	{
		public string FormatStringAnalysisReport(StringAnalysisReport i_StringAnalysisReport)
		{
			StringBuilder formattedStringAnalysisReport = new StringBuilder();

			formattedStringAnalysisReport.Append(createPalindromeLine(i_StringAnalysisReport.IsPalindrome));
			if(i_StringAnalysisReport.IsDigitsOnly)
			{
				formattedStringAnalysisReport.AppendLine();
				formattedStringAnalysisReport.Append(createDivisibleByFourLine(i_StringAnalysisReport.IsDivisibleByFour));
			}

			if(i_StringAnalysisReport.IsEnglishLettersOnly)
			{
				formattedStringAnalysisReport.AppendLine();
				formattedStringAnalysisReport.AppendLine(createUppercaseLettersCountLine(i_StringAnalysisReport.UppercaseLettersCount));
				formattedStringAnalysisReport.Append(createDescendingAlphabeticalOrderLine(i_StringAnalysisReport.IsInDescendingAlphabeticalOrder));
			}

			return formattedStringAnalysisReport.ToString();
		}

		private string createPalindromeLine(bool i_IsPalindrome)
		{
			return string.Format("Is palindrome: {0}", formatBooleanAnswer(i_IsPalindrome));
		}

		private string createDivisibleByFourLine(bool i_IsDivisibleByFour)
		{
			return string.Format("Is divisible by 4 without remainder: {0}", formatBooleanAnswer(i_IsDivisibleByFour));
		}

		private string createUppercaseLettersCountLine(int i_UppercaseLettersCount)
		{
			return string.Format("Number of uppercase letters: {0}", i_UppercaseLettersCount);
		}

		private string createDescendingAlphabeticalOrderLine(bool i_IsInDescendingAlphabeticalOrder)
		{
			return string.Format("Is in descending alphabetical order: {0}", formatBooleanAnswer(i_IsInDescendingAlphabeticalOrder));
		}

		private string formatBooleanAnswer(bool i_BooleanAnswer)
		{
			string formattedBooleanAnswer = "No";

			if(i_BooleanAnswer)
			{
				formattedBooleanAnswer = "Yes";
			}

			return formattedBooleanAnswer;
		}
	}
}
