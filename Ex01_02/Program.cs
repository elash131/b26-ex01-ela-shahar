using System;

namespace Ex01_02
{
	public class Program
	{
		private const char k_FirstLetter = 'A';
		private const int k_LettersTreeHeight = 7;
		private const int k_TrunkHeight = 2;
		private const int k_FirstRowNumber = 1;
		private const int k_FirstLetterOffset = 0;
		private const int k_FirstRowLettersCount = 1;
		private const int k_LettersAddedPerRow = 2;
		private const int k_SpacesRemovedPerRow = 2;
		private const int k_AlphabetLength = 26;

		public static void Main()
		{
			printLettersTree(k_LettersTreeHeight);
		}

		private static void printLettersTree(int i_LettersTreeHeight)
		{
			int topRowsCount = i_LettersTreeHeight - k_TrunkHeight;
			int currentRowNumber = k_FirstRowNumber;
			int currentLetterOffset = k_FirstLetterOffset;
			int spacesBeforeTopRow = (topRowsCount - 1) * k_SpacesRemovedPerRow;
			int spacesBeforeTrunk = spacesBeforeTopRow - 1;

			printTreeRowsRec(topRowsCount, k_TrunkHeight, spacesBeforeTopRow, spacesBeforeTrunk, k_FirstRowLettersCount, ref currentRowNumber, ref currentLetterOffset);
		}

		private static void printTreeRowsRec(int i_TopRowsLeft, int i_TrunkRowsLeft, int i_SpacesBeforeTopRow, int i_SpacesBeforeTrunk, int i_LettersInRow, ref int io_CurrentRowNumber, ref int io_CurrentLetterOffset)
		{
			if (i_TopRowsLeft > 0)
			{
				Console.Write(io_CurrentRowNumber);
				Console.Write(' ');
				printCharsRec(' ', i_SpacesBeforeTopRow);
				printLettersRec(i_LettersInRow, ref io_CurrentLetterOffset, true);
				Console.WriteLine();
				io_CurrentRowNumber++;
				printTreeRowsRec(i_TopRowsLeft - 1, i_TrunkRowsLeft, i_SpacesBeforeTopRow - k_SpacesRemovedPerRow, i_SpacesBeforeTrunk, i_LettersInRow + k_LettersAddedPerRow, ref io_CurrentRowNumber, ref io_CurrentLetterOffset);
			}
			else if (i_TrunkRowsLeft > 0)
			{
				Console.Write(io_CurrentRowNumber);
				Console.Write(' ');
				printCharsRec(' ', i_SpacesBeforeTrunk);
				Console.Write('|');
				Console.Write(getLetterByOffset(io_CurrentLetterOffset));
				Console.Write('|');

				if (i_TrunkRowsLeft > 1)
				{
					Console.WriteLine();
				}

				io_CurrentRowNumber++;
				printTreeRowsRec(i_TopRowsLeft, i_TrunkRowsLeft - 1, i_SpacesBeforeTopRow, i_SpacesBeforeTrunk, i_LettersInRow, ref io_CurrentRowNumber, ref io_CurrentLetterOffset);
			}
		}

		private static void printCharsRec(char i_CharToPrint, int i_TimesLeft)
		{
			if (i_TimesLeft > 0)
			{
				Console.Write(i_CharToPrint);
				printCharsRec(i_CharToPrint, i_TimesLeft - 1);
			}
		}

		private static void printLettersRec(int i_LettersLeft, ref int io_CurrentLetterOffset, bool i_IsFirstLetterInRow)
		{
			if (i_LettersLeft > 0)
			{
				if (!i_IsFirstLetterInRow)
				{
					Console.Write(' ');
				}

				Console.Write(getLetterByOffset(io_CurrentLetterOffset));
				io_CurrentLetterOffset++;
				printLettersRec(i_LettersLeft - 1, ref io_CurrentLetterOffset, false);
			}
		}

		private static char getLetterByOffset(int i_LetterOffset)
		{
			char letter = (char)(k_FirstLetter + (i_LetterOffset % k_AlphabetLength));

			return letter;
		}
	}
}
