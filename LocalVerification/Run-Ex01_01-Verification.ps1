$ErrorActionPreference = 'Stop'

$projectRootPath = Split-Path -Parent $PSScriptRoot
$sourceFilePaths = @(
	'Ex01_01\Program.cs',
	'Ex01_01\BinarySeriesRunner.cs',
	'Ex01_01\BinarySeriesInputReader.cs',
	'Ex01_01\BinarySeriesAnalyzer.cs',
	'Ex01_01\BinarySeriesFormatter.cs',
	'Ex01_01\BinaryNumberInfo.cs',
	'Ex01_01\BinarySeriesReport.cs'
)
$commonUsingBlock = @(
	'using System;',
	'using System.IO;',
	'using System.Text;'
) -join [Environment]::NewLine
$sourceBodies = $sourceFilePaths | ForEach-Object {
	$sourceFileContent = Get-Content -Raw (Join-Path $projectRootPath $_)
	[regex]::Replace($sourceFileContent, '(?m)^[ \t]*using\s+[A-Za-z0-9_.]+\s*;\s*(\r?\n)?', '')
}
$verificationSourceCode = @"
namespace Ex01_01
{
	public static class Ex0101VerificationHarness
	{
		private const string k_BatchInputPromptMessage = "Please enter 4 binary numbers with 7 digits each:";
		private const string k_EmptyInputMessage = "The input cannot be empty. Please enter exactly 7 binary digits.";
		private const string k_InvalidLengthInputMessage = "The input must contain exactly 7 binary digits.";
		private const string k_InvalidCharactersInputMessage = "The input must contain only binary digits: 0 or 1.";

		public static string RunAllTests()
		{
			StringBuilder verificationSummary;
			int passedTestsCount;
			int failedTestsCount;

			verificationSummary = new StringBuilder();
			passedTestsCount = 0;
			failedTestsCount = 0;

			runTest("Sample A output", verifySampleAOutput, verificationSummary, ref passedTestsCount, ref failedTestsCount);
			runTest("Sample B output", verifySampleBOutput, verificationSummary, ref passedTestsCount, ref failedTestsCount);
			runTest("Sample C output", verifySampleCOutput, verificationSummary, ref passedTestsCount, ref failedTestsCount);
			runTest("Sample D output", verifySampleDOutput, verificationSummary, ref passedTestsCount, ref failedTestsCount);
			runTest("Empty input validation", verifyEmptyInputValidation, verificationSummary, ref passedTestsCount, ref failedTestsCount);
			runTest("Invalid length validation", verifyInvalidLengthValidation, verificationSummary, ref passedTestsCount, ref failedTestsCount);
			runTest("Invalid characters validation", verifyInvalidCharactersValidation, verificationSummary, ref passedTestsCount, ref failedTestsCount);

			verificationSummary.AppendLine(string.Format("Total: {0} passed, {1} failed", passedTestsCount, failedTestsCount));

			return verificationSummary.ToString();
		}

		private static void runTest(
			string i_TestName,
			Func<string> i_TestMethod,
			StringBuilder io_VerificationSummary,
			ref int io_PassedTestsCount,
			ref int io_FailedTestsCount)
		{
			string failureMessage;

			try
			{
				failureMessage = i_TestMethod();

				if(string.IsNullOrEmpty(failureMessage))
				{
					io_PassedTestsCount++;
					io_VerificationSummary.AppendLine(string.Format("PASS - {0}", i_TestName));
				}
				else
				{
					io_FailedTestsCount++;
					io_VerificationSummary.AppendLine(string.Format("FAIL - {0}: {1}", i_TestName, failureMessage));
				}
			}
			catch(Exception exception)
			{
				io_FailedTestsCount++;
				io_VerificationSummary.AppendLine(string.Format("FAIL - {0}: {1}", i_TestName, exception.Message));
			}
		}

		private static string verifySampleAOutput()
		{
			string actualOutput;
			string expectedOutput;
			string[] binaryNumbers;

			binaryNumbers = new string[] { "0110011", "1000001", "1111000", "1010101" };
			actualOutput = formatBinarySeriesReport(binaryNumbers);
			expectedOutput = createMultilineString(
				"Decimal numbers in descending order: 120 (1111000), 85 (1010101), 65 (1000001), 51 (0110011)",
				"Average: 80.25",
				"Longest bit sequence: 5 (1000001)",
				"Total 1-bits: 14",
				"Number with most transitions: 85 (1010101) - 6 transitions",
				"Numbers divisible by 4: 1 (1111000)");

			return getOutputMismatchMessage(expectedOutput, actualOutput);
		}

		private static string verifySampleBOutput()
		{
			string actualOutput;
			string expectedOutput;
			string[] binaryNumbers;

			binaryNumbers = new string[] { "0001000", "1111111", "1100111", "0101010" };
			actualOutput = formatBinarySeriesReport(binaryNumbers);
			expectedOutput = createMultilineString(
				"Decimal numbers in descending order: 127 (1111111), 103 (1100111), 42 (0101010), 8 (0001000)",
				"Average: 70.00",
				"Longest bit sequence: 7 (1111111)",
				"Total 1-bits: 16",
				"Number with most transitions: 42 (0101010) - 6 transitions",
				"Numbers divisible by 4: 1 (0001000)");

			return getOutputMismatchMessage(expectedOutput, actualOutput);
		}

		private static string verifySampleCOutput()
		{
			string actualOutput;
			string expectedOutput;
			string[] binaryNumbers;

			binaryNumbers = new string[] { "0100100", "0000000", "1110111", "1001100" };
			actualOutput = formatBinarySeriesReport(binaryNumbers);
			expectedOutput = createMultilineString(
				"Decimal numbers in descending order: 119 (1110111), 76 (1001100), 36 (0100100), 0 (0000000)",
				"Average: 57.75",
				"Longest bit sequence: 7 (0000000)",
				"Total 1-bits: 11",
				"Number with most transitions: 36 (0100100) - 4 transitions",
				"Numbers divisible by 4: 3 (0000000, 0100100, 1001100)");

			return getOutputMismatchMessage(expectedOutput, actualOutput);
		}

		private static string verifySampleDOutput()
		{
			string actualOutput;
			string expectedOutput;
			string[] binaryNumbers;

			binaryNumbers = new string[] { "0101010", "0101010", "1010101", "1010101" };
			actualOutput = formatBinarySeriesReport(binaryNumbers);
			expectedOutput = createMultilineString(
				"Decimal numbers in descending order: 85 (1010101), 85 (1010101), 42 (0101010), 42 (0101010)",
				"Average: 63.50",
				"Longest bit sequence: 1 (1010101, 1010101, 0101010, 0101010)",
				"Total 1-bits: 14",
				"Number with most transitions: 42 (0101010) - 6 transitions",
				"Numbers divisible by 4: 0");

			return getOutputMismatchMessage(expectedOutput, actualOutput);
		}

		private static string verifyEmptyInputValidation()
		{
			string consoleOutput;
			string[] binaryNumbers;
			string simulatedConsoleInput;

			simulatedConsoleInput = createInputString(string.Empty, "1010101", "1111000", "1000001", "0110011");
			binaryNumbers = readValidBinaryNumbers(simulatedConsoleInput, out consoleOutput);

			return getInputValidationMismatchMessage(
				k_EmptyInputMessage,
				consoleOutput,
				binaryNumbers,
				1);
		}

		private static string verifyInvalidLengthValidation()
		{
			string consoleOutput;
			string[] binaryNumbers;
			string simulatedConsoleInput;

			simulatedConsoleInput = createInputString("101", "1010101", "1111000", "1000001", "0110011");
			binaryNumbers = readValidBinaryNumbers(simulatedConsoleInput, out consoleOutput);

			return getInputValidationMismatchMessage(
				k_InvalidLengthInputMessage,
				consoleOutput,
				binaryNumbers,
				1);
		}

		private static string verifyInvalidCharactersValidation()
		{
			string consoleOutput;
			string[] binaryNumbers;
			string simulatedConsoleInput;

			simulatedConsoleInput = createInputString("10101a1", "1010101", "1111000", "1000001", "0110011");
			binaryNumbers = readValidBinaryNumbers(simulatedConsoleInput, out consoleOutput);

			return getInputValidationMismatchMessage(
				k_InvalidCharactersInputMessage,
				consoleOutput,
				binaryNumbers,
				1);
		}

		private static string getInputValidationMismatchMessage(
			string i_ExpectedValidationMessage,
			string i_ConsoleOutput,
			string[] i_BinaryNumbers,
			int i_ExpectedPromptCount)
		{
			string mismatchMessage;

			mismatchMessage = string.Empty;

			if(!i_ConsoleOutput.Contains(i_ExpectedValidationMessage))
			{
				mismatchMessage = string.Format(
					"Expected validation message was not shown. Expected to find: [{0}]",
					i_ExpectedValidationMessage);
			}
			else if(countOccurrences(i_ConsoleOutput, k_BatchInputPromptMessage) != i_ExpectedPromptCount)
			{
				mismatchMessage = string.Format(
					"Unexpected prompt count. Expected {0}, actual {1}.",
					i_ExpectedPromptCount,
					countOccurrences(i_ConsoleOutput, k_BatchInputPromptMessage));
			}
			else if(i_BinaryNumbers.Length != 4)
			{
				mismatchMessage = string.Format(
					"Expected 4 validated binary numbers, actual {0}.",
					i_BinaryNumbers.Length);
			}
			else if(i_BinaryNumbers[0] != "1010101")
			{
				mismatchMessage = string.Format(
					"First accepted binary number mismatch. Expected [1010101], actual [{0}].",
					i_BinaryNumbers[0]);
			}

			return mismatchMessage;
		}

		private static string formatBinarySeriesReport(string[] i_BinaryNumbers)
		{
			BinarySeriesAnalyzer binarySeriesAnalyzer;
			BinarySeriesFormatter binarySeriesFormatter;
			BinarySeriesReport binarySeriesReport;
			string formattedBinarySeriesReport;

			binarySeriesAnalyzer = new BinarySeriesAnalyzer();
			binarySeriesFormatter = new BinarySeriesFormatter();
			binarySeriesReport = binarySeriesAnalyzer.CreateBinarySeriesReport(i_BinaryNumbers);
			formattedBinarySeriesReport = binarySeriesFormatter.FormatBinarySeriesReport(binarySeriesReport);

			return formattedBinarySeriesReport;
		}

		private static string[] readValidBinaryNumbers(string i_SimulatedConsoleInput, out string o_ConsoleOutput)
		{
			BinarySeriesInputReader binarySeriesInputReader;
			string[] validBinaryNumbers;
			TextReader originalInput;
			TextWriter originalOutput;
			StringReader simulatedInput;
			StringWriter simulatedOutput;

			binarySeriesInputReader = new BinarySeriesInputReader();
			originalInput = Console.In;
			originalOutput = Console.Out;
			simulatedInput = new StringReader(i_SimulatedConsoleInput);
			simulatedOutput = new StringWriter();
			validBinaryNumbers = null;

			try
			{
				Console.SetIn(simulatedInput);
				Console.SetOut(simulatedOutput);
				validBinaryNumbers = binarySeriesInputReader.ReadValidBinaryNumbers();
			}
			finally
			{
				Console.SetIn(originalInput);
				Console.SetOut(originalOutput);
			}

			o_ConsoleOutput = simulatedOutput.ToString();

			return validBinaryNumbers;
		}

		private static string createMultilineString(params string[] i_Lines)
		{
			string multilineString;

			multilineString = string.Join(Environment.NewLine, i_Lines);

			return multilineString;
		}

		private static string createInputString(params string[] i_Lines)
		{
			string inputString;

			inputString = string.Join(Environment.NewLine, i_Lines) + Environment.NewLine;

			return inputString;
		}

		private static int countOccurrences(string i_Text, string i_ExpectedFragment)
		{
			int occurrencesCount;
			int currentIndex;

			occurrencesCount = 0;
			currentIndex = 0;

			while((currentIndex = i_Text.IndexOf(i_ExpectedFragment, currentIndex, StringComparison.Ordinal)) >= 0)
			{
				occurrencesCount++;
				currentIndex += i_ExpectedFragment.Length;
			}

			return occurrencesCount;
		}

		private static string getOutputMismatchMessage(string i_ExpectedOutput, string i_ActualOutput)
		{
			string mismatchMessage;

			mismatchMessage = string.Empty;

			if(i_ExpectedOutput != i_ActualOutput)
			{
				mismatchMessage = string.Format(
					"Expected output [{0}] but got [{1}].",
					i_ExpectedOutput,
					i_ActualOutput);
			}

			return mismatchMessage;
		}
	}
}
"@
$combinedSourceCode = $commonUsingBlock + [Environment]::NewLine + (($sourceBodies + $verificationSourceCode) -join [Environment]::NewLine)
$compiler = New-Object Microsoft.CSharp.CSharpCodeProvider
$compilerParameters = New-Object System.CodeDom.Compiler.CompilerParameters
$compilerParameters.GenerateExecutable = $false
$compilerParameters.GenerateInMemory = $true
$compilerParameters.ReferencedAssemblies.Add('System.dll') | Out-Null
$compilerParameters.ReferencedAssemblies.Add('System.Core.dll') | Out-Null
$compiledAssemblyResults = $compiler.CompileAssemblyFromSource(
	$compilerParameters,
	$combinedSourceCode)

if($compiledAssemblyResults.Errors.Count -gt 0)
{
	$compiledAssemblyResults.Errors | ForEach-Object {
		Write-Error $_.ToString()
	}

	exit 1
}

$verificationType = $compiledAssemblyResults.CompiledAssembly.GetType('Ex01_01.Ex0101VerificationHarness')
$verificationMethod = $verificationType.GetMethod('RunAllTests')
$verificationResult = $verificationMethod.Invoke($null, @())

Write-Output $verificationResult

if(($verificationResult -split [Environment]::NewLine | Where-Object { $_ -like 'FAIL -*' }).Count -gt 0)
{
	exit 1
}

exit 0



