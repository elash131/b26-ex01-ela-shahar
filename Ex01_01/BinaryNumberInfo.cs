namespace Ex01_01
{
	internal class BinaryNumberInfo
	{
		private string m_BinaryRepresentation;
		private int m_DecimalValue;
		private int m_LongestBitSequenceLength;
		private int m_OneBitsCount;
		private int m_TransitionCount;

		public BinaryNumberInfo(
			string i_BinaryRepresentation,
			int i_DecimalValue,
			int i_LongestBitSequenceLength,
			int i_OneBitsCount,
			int i_TransitionCount)
		{
			BinaryRepresentation = i_BinaryRepresentation;
			DecimalValue = i_DecimalValue;
			LongestBitSequenceLength = i_LongestBitSequenceLength;
			OneBitsCount = i_OneBitsCount;
			TransitionCount = i_TransitionCount;
		}

		public string BinaryRepresentation
		{
			get
			{
				return m_BinaryRepresentation;
			}

			private set
			{
				m_BinaryRepresentation = value;
			}
		}

		public int DecimalValue
		{
			get
			{
				return m_DecimalValue;
			}

			private set
			{
				m_DecimalValue = value;
			}
		}

		public int LongestBitSequenceLength
		{
			get
			{
				return m_LongestBitSequenceLength;
			}

			private set
			{
				m_LongestBitSequenceLength = value;
			}
		}

		public int OneBitsCount
		{
			get
			{
				return m_OneBitsCount;
			}

			private set
			{
				m_OneBitsCount = value;
			}
		}

		public int TransitionCount
		{
			get
			{
				return m_TransitionCount;
			}

			private set
			{
				m_TransitionCount = value;
			}
		}
	}
}
