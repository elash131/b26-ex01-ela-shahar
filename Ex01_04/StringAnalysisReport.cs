namespace Ex01_04
{
	internal class StringAnalysisReport
	{
		private string m_OriginalInput;
		private bool m_IsDigitsOnly;
		private bool m_IsEnglishLettersOnly;
		private bool m_IsDivisibleByFour;
		private int m_UppercaseLettersCount;
		private bool m_IsInDescendingAlphabeticalOrder;
		private bool m_IsPalindrome;

		public StringAnalysisReport(
			string i_OriginalInput,
			bool i_IsDigitsOnly,
			bool i_IsEnglishLettersOnly,
			bool i_IsDivisibleByFour,
			int i_UppercaseLettersCount,
			bool i_IsInDescendingAlphabeticalOrder,
			bool i_IsPalindrome)
		{
			OriginalInput = i_OriginalInput;
			IsDigitsOnly = i_IsDigitsOnly;
			IsEnglishLettersOnly = i_IsEnglishLettersOnly;
			IsDivisibleByFour = i_IsDivisibleByFour;
			UppercaseLettersCount = i_UppercaseLettersCount;
			IsInDescendingAlphabeticalOrder = i_IsInDescendingAlphabeticalOrder;
			IsPalindrome = i_IsPalindrome;
		}

		public string OriginalInput
		{
			get
			{
				return m_OriginalInput;
			}

			private set
			{
				m_OriginalInput = value;
			}
		}

		public bool IsDigitsOnly
		{
			get
			{
				return m_IsDigitsOnly;
			}

			private set
			{
				m_IsDigitsOnly = value;
			}
		}

		public bool IsEnglishLettersOnly
		{
			get
			{
				return m_IsEnglishLettersOnly;
			}

			private set
			{
				m_IsEnglishLettersOnly = value;
			}
		}

		public bool IsDivisibleByFour
		{
			get
			{
				return m_IsDivisibleByFour;
			}

			private set
			{
				m_IsDivisibleByFour = value;
			}
		}

		public int UppercaseLettersCount
		{
			get
			{
				return m_UppercaseLettersCount;
			}

			private set
			{
				m_UppercaseLettersCount = value;
			}
		}

		public bool IsInDescendingAlphabeticalOrder
		{
			get
			{
				return m_IsInDescendingAlphabeticalOrder;
			}

			private set
			{
				m_IsInDescendingAlphabeticalOrder = value;
			}
		}

		public bool IsPalindrome
		{
			get
			{
				return m_IsPalindrome;
			}

			private set
			{
				m_IsPalindrome = value;
			}
		}
	}
}
