namespace Ex01_01
{
	internal class BinarySeriesReport
	{
		private BinaryNumberInfo[] m_BinaryNumberInfosSortedByDescendingDecimalValue;
		private double m_AverageDecimalValue;
		private int m_LongestBitSequenceLength;
		private string[] m_BinaryRepresentationsWithLongestBitSequence;
		private int m_TotalOneBits;
		private BinaryNumberInfo m_BinaryNumberWithMostTransitions;
		private string[] m_BinaryRepresentationsDivisibleByFour;

		public BinarySeriesReport(
			BinaryNumberInfo[] i_BinaryNumberInfosSortedByDescendingDecimalValue,
			double i_AverageDecimalValue,
			int i_LongestBitSequenceLength,
			string[] i_BinaryRepresentationsWithLongestBitSequence,
			int i_TotalOneBits,
			BinaryNumberInfo i_BinaryNumberWithMostTransitions,
			string[] i_BinaryRepresentationsDivisibleByFour)
		{
			BinaryNumberInfosSortedByDescendingDecimalValue = i_BinaryNumberInfosSortedByDescendingDecimalValue;
			AverageDecimalValue = i_AverageDecimalValue;
			LongestBitSequenceLength = i_LongestBitSequenceLength;
			BinaryRepresentationsWithLongestBitSequence = i_BinaryRepresentationsWithLongestBitSequence;
			TotalOneBits = i_TotalOneBits;
			BinaryNumberWithMostTransitions = i_BinaryNumberWithMostTransitions;
			BinaryRepresentationsDivisibleByFour = i_BinaryRepresentationsDivisibleByFour;
		}

		public BinaryNumberInfo[] BinaryNumberInfosSortedByDescendingDecimalValue
		{
			get
			{
				return m_BinaryNumberInfosSortedByDescendingDecimalValue;
			}

			private set
			{
				m_BinaryNumberInfosSortedByDescendingDecimalValue = value;
			}
		}

		public double AverageDecimalValue
		{
			get
			{
				return m_AverageDecimalValue;
			}

			private set
			{
				m_AverageDecimalValue = value;
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

		public string[] BinaryRepresentationsWithLongestBitSequence
		{
			get
			{
				return m_BinaryRepresentationsWithLongestBitSequence;
			}

			private set
			{
				m_BinaryRepresentationsWithLongestBitSequence = value;
			}
		}

		public int TotalOneBits
		{
			get
			{
				return m_TotalOneBits;
			}

			private set
			{
				m_TotalOneBits = value;
			}
		}

		public BinaryNumberInfo BinaryNumberWithMostTransitions
		{
			get
			{
				return m_BinaryNumberWithMostTransitions;
			}

			private set
			{
				m_BinaryNumberWithMostTransitions = value;
			}
		}

		public string[] BinaryRepresentationsDivisibleByFour
		{
			get
			{
				return m_BinaryRepresentationsDivisibleByFour;
			}

			private set
			{
				m_BinaryRepresentationsDivisibleByFour = value;
			}
		}
	}
}
