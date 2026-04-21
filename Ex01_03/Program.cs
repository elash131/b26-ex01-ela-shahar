using System;

namespace Ex01_03
{
	public class Program
	{
		private const char k_FirstLetter = 'A';
		private const int k_TrunkHeight = 2;
		private const int k_FirstRowNumber = 1;
		private const int k_FirstLetterOffset = 0;
		private const int k_FirstRowLettersCount = 1;
		private const int k_LettersAddedPerRow = 2;
		private const int k_SpacesRemovedPerRow = 2;
		private const int k_AlphabetLength = 26;
		private const int k_MinHeight = 4;
		private const int k_MaxHeight = 15;
		private const string k_HeightPromptMessage = "Please enter tree height ({0}-{1}): ";
		private const string k_InvalidInputMessage = "Invalid input. Please enter a number between {0} and {1}.";

		public static void Main()
		{
			runDynamicLettersTree();
		}

		private static void runDynamicLettersTree()
		{
			int treeHeight = getTreeHeightFromUser();

			printLettersTree(treeHeight);
		}

		private static int getTreeHeightFromUser()
		{
			int treeHeight = 0;
			string inputFromUser = getHeightInput();

			if (!isNumber(inputFromUser))
			{
				printInvalidInputMessage();
				treeHeight = getTreeHeightFromUser();
			}
			else
			{
				treeHeight = int.Parse(inputFromUser);

				if (!isTreeHeightInRange(treeHeight))
				{
					printInvalidInputMessage();
					treeHeight = getTreeHeightFromUser();
				}
			}

			return treeHeight;
		}

		private static string getHeightInput()
		{
			string inputFromUser;

			printHeightPrompt();
			inputFromUser = Console.ReadLine();

			return inputFromUser;
		}

		private static void printHeightPrompt()
		{
			string heightPromptMessage = string.Format(k_HeightPromptMessage, k_MinHeight, k_MaxHeight);

			Console.Write(heightPromptMessage);
		}

		private static void printInvalidInputMessage()
		{
			string invalidInputMessage = string.Format(k_InvalidInputMessage, k_MinHeight, k_MaxHeight);

			Console.WriteLine(invalidInputMessage);
		}

		private static bool isNumber(string i_InputFromUser)
		{
			bool v_IsNumber;
			int numberFromUser;

			v_IsNumber = int.TryParse(i_InputFromUser, out numberFromUser);

			return v_IsNumber;
		}

		private static bool isTreeHeightInRange(int i_TreeHeight)
		{
			bool v_IsTreeHeightInRange = i_TreeHeight >= k_MinHeight && i_TreeHeight <= k_MaxHeight;

			return v_IsTreeHeightInRange;
		}

		private static void printLettersTree(int i_LettersTreeHeight)
		{
			int topRowsCount = i_LettersTreeHeight - k_TrunkHeight;
			int currentRowNumber = k_FirstRowNumber;
			int currentLetterOffset = k_FirstLetterOffset;
			int spacesBeforeTopRow = (topRowsCount - 1) * k_SpacesRemovedPerRow;
			int spacesBeforeTrunk = spacesBeforeTopRow - 1;

			printTopRowsRec(topRowsCount, spacesBeforeTopRow, k_FirstRowLettersCount, ref currentRowNumber, ref currentLetterOffset);
			printTrunkRowsRec(k_TrunkHeight, spacesBeforeTrunk, currentLetterOffset, ref currentRowNumber);
		}

		private static void printTopRowsRec(int i_RowsLeft, int i_SpacesBeforeRow, int i_LettersInRow, ref int io_CurrentRowNumber, ref int io_CurrentLetterOffset)
		{
			if (i_RowsLeft > 0)
			{
				printRowNumber(io_CurrentRowNumber);
				printCharsRec(' ', i_SpacesBeforeRow);
				printLettersRec(i_LettersInRow, ref io_CurrentLetterOffset, true);
				Console.WriteLine();
				io_CurrentRowNumber++;
				printTopRowsRec(i_RowsLeft - 1, i_SpacesBeforeRow - k_SpacesRemovedPerRow, i_LettersInRow + k_LettersAddedPerRow, ref io_CurrentRowNumber, ref io_CurrentLetterOffset);
			}
		}

		private static void printTrunkRowsRec(int i_RowsLeft, int i_SpacesBeforeTrunk, int i_TrunkLetterOffset, ref int io_CurrentRowNumber)
		{
			if (i_RowsLeft > 0)
			{
				printRowNumber(io_CurrentRowNumber);
				printCharsRec(' ', i_SpacesBeforeTrunk);
				Console.Write('|');
				Console.Write(getLetterByOffset(i_TrunkLetterOffset));
				Console.Write('|');

				if (i_RowsLeft > 1)
				{
					Console.WriteLine();
				}

				io_CurrentRowNumber++;
				printTrunkRowsRec(i_RowsLeft - 1, i_SpacesBeforeTrunk, i_TrunkLetterOffset, ref io_CurrentRowNumber);
			}
		}

		private static void printRowNumber(int i_RowNumber)
		{
			Console.Write("{0,2} ", i_RowNumber);
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
