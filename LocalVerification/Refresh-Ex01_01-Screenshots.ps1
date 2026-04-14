$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Drawing

$projectRootPath = Split-Path -Parent $PSScriptRoot
$assetsPath = Join-Path $projectRootPath 'Ex01_01_ScreenshotAssets'
$docPath = Join-Path $projectRootPath 'Ex01_ScreenShots.doc'

if(!(Test-Path $assetsPath))
{
	New-Item -ItemType Directory -Path $assetsPath | Out-Null
}

$examples = @(
	@{
		Title = 'Mandatory Example 1'
		FileName = 'Ex01_01_Mandatory_Example_1.png'
		Inputs = @('1010101', '1111000', '1000001', '0110011')
	},
	@{
		Title = 'Mandatory Example 2'
		FileName = 'Ex01_01_Mandatory_Example_2.png'
		Inputs = @('0001000', '1111111', '1100111', '0101010')
	},
	@{
		Title = 'Mandatory Example 3'
		FileName = 'Ex01_01_Mandatory_Example_3.png'
		Inputs = @('0100100', '0000000', '1110111', '1001100')
	},
	@{
		Title = 'Mandatory Example 4'
		FileName = 'Ex01_01_Mandatory_Example_4.png'
		Inputs = @('0101010', '0101010', '1010101', '1010101')
	},
	@{
		Title = 'Additional Example 1 - All Numbers Divisible By 4'
		FileName = 'Ex01_01_Custom_Example_1.png'
		Inputs = @('1111100', '0010100', '0000000', '0101000')
	},
	@{
		Title = 'Additional Example 2 - Longest Sequence Tie Across All Numbers'
		FileName = 'Ex01_01_Custom_Example_2.png'
		Inputs = @('0011110', '0000111', '1100001', '0111100')
	}
)

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
	'using System.Text;'
) -join [Environment]::NewLine

$sourceBodies = $sourceFilePaths | ForEach-Object {
	$sourceFileContent = Get-Content -Raw (Join-Path $projectRootPath $_)
	[regex]::Replace($sourceFileContent, '(?m)^[ \t]*using\s+[A-Za-z0-9_.]+\s*;\s*(\r?\n)?', '')
}

$helperSourceCode = @"
namespace Ex01_01
{
	public static class ScreenshotReportGenerator
	{
		private const string k_BatchInputPromptMessage = "Please enter 4 binary numbers with 7 digits each:";

		public static string CreateTranscript(string[] i_BinaryNumbers)
		{
			BinarySeriesAnalyzer binarySeriesAnalyzer;
			BinarySeriesFormatter binarySeriesFormatter;
			BinarySeriesReport binarySeriesReport;
			StringBuilder transcriptBuilder;
			int binaryNumberIndex;

			binarySeriesAnalyzer = new BinarySeriesAnalyzer();
			binarySeriesFormatter = new BinarySeriesFormatter();
			binarySeriesReport = binarySeriesAnalyzer.CreateBinarySeriesReport(i_BinaryNumbers);
			transcriptBuilder = new StringBuilder();
			transcriptBuilder.AppendLine(k_BatchInputPromptMessage);

			for(binaryNumberIndex = 0; binaryNumberIndex < i_BinaryNumbers.Length; binaryNumberIndex++)
			{
				transcriptBuilder.AppendLine(i_BinaryNumbers[binaryNumberIndex]);
			}

			transcriptBuilder.Append(binarySeriesFormatter.FormatBinarySeriesReport(binarySeriesReport));

			return transcriptBuilder.ToString();
		}
	}
}
"@

$combinedSourceCode = $commonUsingBlock + [Environment]::NewLine + (($sourceBodies + $helperSourceCode) -join [Environment]::NewLine)
$compiler = New-Object Microsoft.CSharp.CSharpCodeProvider
$compilerParameters = New-Object System.CodeDom.Compiler.CompilerParameters
$compilerParameters.GenerateExecutable = $false
$compilerParameters.GenerateInMemory = $true
$compilerParameters.ReferencedAssemblies.Add('System.dll') | Out-Null
$compilerParameters.ReferencedAssemblies.Add('System.Core.dll') | Out-Null
$compiledAssemblyResults = $compiler.CompileAssemblyFromSource($compilerParameters, $combinedSourceCode)

if($compiledAssemblyResults.Errors.Count -gt 0)
{
	throw ($compiledAssemblyResults.Errors | ForEach-Object { $_.ToString() } | Out-String)
}

$generatorType = $compiledAssemblyResults.CompiledAssembly.GetType('Ex01_01.ScreenshotReportGenerator')
$createTranscriptMethod = $generatorType.GetMethod('CreateTranscript')

function New-ConsoleScreenshotImage {
	param(
		[string]$TranscriptText,
		[string]$OutputPath
	)

	$padding = 28
	$font = New-Object System.Drawing.Font('Consolas', 18, [System.Drawing.FontStyle]::Regular, [System.Drawing.GraphicsUnit]::Pixel)
	$lines = $TranscriptText -split "`r?`n"
	$measurementBitmap = New-Object System.Drawing.Bitmap 1, 1
	$measurementGraphics = [System.Drawing.Graphics]::FromImage($measurementBitmap)
	$lineHeight = [Math]::Ceiling($font.GetHeight($measurementGraphics)) + 4
	$maxWidth = 0

	foreach($line in $lines)
	{
		$measuredWidth = [Math]::Ceiling($measurementGraphics.MeasureString($line, $font).Width)
		if($measuredWidth -gt $maxWidth)
		{
			$maxWidth = $measuredWidth
		}
	}

	$measurementGraphics.Dispose()
	$measurementBitmap.Dispose()
	$bitmapWidth = [int][Math]::Max($maxWidth + ($padding * 2), 1100)
	$bitmapHeight = [int](($lineHeight * $lines.Length) + ($padding * 2))
	$bitmap = New-Object System.Drawing.Bitmap $bitmapWidth, $bitmapHeight
	$graphics = [System.Drawing.Graphics]::FromImage($bitmap)
	$graphics.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::ClearTypeGridFit
	$backgroundBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(12, 12, 12))
	$textBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(235, 235, 235))

	$graphics.FillRectangle($backgroundBrush, 0, 0, $bitmapWidth, $bitmapHeight)

	for($lineIndex = 0; $lineIndex -lt $lines.Length; $lineIndex++)
	{
		$graphics.DrawString($lines[$lineIndex], $font, $textBrush, $padding, $padding + ($lineIndex * $lineHeight))
	}

	$bitmap.Save($OutputPath, [System.Drawing.Imaging.ImageFormat]::Png)
	$textBrush.Dispose()
	$backgroundBrush.Dispose()
	$graphics.Dispose()
	$bitmap.Dispose()
	$font.Dispose()
}

$imagePaths = @()

foreach($example in $examples)
{
	$transcript = $createTranscriptMethod.Invoke($null, (,([string[]]$example.Inputs)))
	$outputPath = Join-Path $assetsPath $example.FileName
	New-ConsoleScreenshotImage -TranscriptText $transcript -OutputPath $outputPath
	$imagePaths += [pscustomobject]@{ Title = $example.Title; Path = $outputPath }
}

$word = New-Object -ComObject Word.Application
$word.Visible = $false
$word.DisplayAlerts = 0
$document = $word.Documents.Open($docPath)
$selection = $word.Selection
$wdCollapseEnd = 0
$wdPageBreak = 7

$document.Content.Delete()
$selection.HomeKey(6) | Out-Null
$selection.Style = -2
$selection.TypeText('Ex01_01 Console Run Examples')
$selection.TypeParagraph()
$selection.Style = -1
$selection.TypeText('The first four screenshots are the mandatory lecturer examples. The last two are additional non-mandatory examples.')
$selection.TypeParagraph()
$selection.TypeParagraph()

for($exampleIndex = 0; $exampleIndex -lt $imagePaths.Count; $exampleIndex++)
{
	$selection.Style = -3
	$selection.TypeText($imagePaths[$exampleIndex].Title)
	$selection.TypeParagraph()
	$selection.Style = -1
	$selection.InlineShapes.AddPicture($imagePaths[$exampleIndex].Path) | Out-Null
	$selection.TypeParagraph()

	if($exampleIndex -lt $imagePaths.Count - 1)
	{
		$selection.InsertBreak($wdPageBreak)
	}
}

$document.Save()
$document.Close()
$word.Quit()





