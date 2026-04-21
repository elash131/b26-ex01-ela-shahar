using System.Text;

namespace Ex01_02
{
	internal enum eTreeMeasurements
	{
		TrunkRowsCount = 2,
		FirstLetterOffset = 0,
		FirstRowNumber = 1,
		FirstRowLettersCount = 1,
		LettersAddedPerRow = 2,
		FixedTreeHeight = 7,
		AlphabetLength = 26,
	}

	public static class LetterTreeBuilder
	{
		private const char k_FirstLetter = 'A';

		public static string BuildTree(int i_Height)
		{
			const bool v_AppendNewLine = true;
			StringBuilder treeBuilder = new StringBuilder();
			int canopyRowsCount = i_Height - (int)eTreeMeasurements.TrunkRowsCount;
			int maxContentWidth = calculateMaxContentWidth(canopyRowsCount);
			int currentRowNumber = (int)eTreeMeasurements.FirstRowNumber;
			int currentLetterOffset = (int)eTreeMeasurements.FirstLetterOffset;

			for(int rowIndex = 1; rowIndex <= canopyRowsCount; rowIndex++)
			{
				appendTreeRow(
					treeBuilder,
					currentRowNumber,
					buildCanopyContent(rowIndex, ref currentLetterOffset),
					maxContentWidth,
					v_AppendNewLine);
				currentRowNumber++;
			}

			appendTrunkRows(treeBuilder, ref currentRowNumber, currentLetterOffset, maxContentWidth);

			return treeBuilder.ToString();
		}

		private static string buildCanopyContent(int i_RowIndex, ref int io_CurrentLetterOffset)
		{
			StringBuilder rowBuilder = new StringBuilder();
			int lettersInRow = (i_RowIndex * (int)eTreeMeasurements.LettersAddedPerRow) - (int)eTreeMeasurements.FirstRowLettersCount;

			for(int letterIndex = 0; letterIndex < lettersInRow; letterIndex++)
			{
				if(letterIndex > 0)
				{
					rowBuilder.Append(' ');
				}

				rowBuilder.Append(getLetterByOffset(io_CurrentLetterOffset));
				io_CurrentLetterOffset++;
			}

			return rowBuilder.ToString();
		}

		private static void appendTrunkRows(
			StringBuilder io_TreeBuilder,
			ref int io_CurrentRowNumber,
			int i_CurrentLetterOffset,
			int i_MaxContentWidth)
		{
			string trunkContent = buildTrunkContent(i_CurrentLetterOffset);

			for(int trunkRowIndex = 0; trunkRowIndex < (int)eTreeMeasurements.TrunkRowsCount; trunkRowIndex++)
			{
				appendTreeRow(
					io_TreeBuilder,
					io_CurrentRowNumber,
					trunkContent,
					i_MaxContentWidth,
					trunkRowIndex < (int)eTreeMeasurements.TrunkRowsCount - 1);
				io_CurrentRowNumber++;
			}
		}

		private static string buildTrunkContent(int i_CurrentLetterOffset)
		{
			string trunkContent = string.Format("|{0}|", getLetterByOffset(i_CurrentLetterOffset));

			return trunkContent;
		}

		private static void appendTreeRow(
			StringBuilder io_TreeBuilder,
			int i_RowNumber,
			string i_RowContent,
			int i_MaxContentWidth,
			bool i_AppendNewLine)
		{
			int leadingSpacesCount = (i_MaxContentWidth - i_RowContent.Length) / 2;

			io_TreeBuilder.Append(i_RowNumber);
			io_TreeBuilder.Append(' ');
			io_TreeBuilder.Append(' ', leadingSpacesCount);
			io_TreeBuilder.Append(i_RowContent);

			if(i_AppendNewLine)
			{
				io_TreeBuilder.AppendLine();
			}
		}

		private static int calculateMaxContentWidth(int i_CanopyRowsCount)
		{
			int maxContentWidth =
				(i_CanopyRowsCount * ((int)eTreeMeasurements.LettersAddedPerRow + (int)eTreeMeasurements.TrunkRowsCount)) -
				(((int)eTreeMeasurements.LettersAddedPerRow + (int)eTreeMeasurements.FirstRowLettersCount));

			return maxContentWidth;
		}

		private static char getLetterByOffset(int i_LetterOffset)
		{
			return (char)(k_FirstLetter + (i_LetterOffset % (int)eTreeMeasurements.AlphabetLength));
		}
	}
}
