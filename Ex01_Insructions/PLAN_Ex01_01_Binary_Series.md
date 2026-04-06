# Ex01_01 Binary Series Implementation Plan

> **For agentic workers:** REQUIRED: Use `.agent/skills/executing-plans/SKILL.md` to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build `Ex01_01` so it reads 4 valid 7-bit binary numbers, prints them in descending decimal order with their original binary form, and prints all required statistics exactly as the lecturer sample shows.

**Architecture:** Keep `Program.cs` as a thin entry point. Move the real work into small helper classes: one for validated input, one for manual binary/statistics logic, and one for exact output formatting. Do not use a built-in binary-to-decimal converter.

**Tech Stack:** C#, .NET Framework 4.7.2, Console app, Visual Studio for Windows

---

## File Structure

- Modify: `Ex01_01/Program.cs`
- Create: `Ex01_01/BinarySeriesRunner.cs`
- Create: `Ex01_01/BinarySeriesAnalyzer.cs`
- Create: `Ex01_01/BinarySeriesFormatter.cs`

## Spec Notes To Honor

- Input: exactly 4 numbers.
- Each number must be a valid 7-character binary string.
- Invalid input must show an error and re-prompt.
- Sort output by decimal value descending, but keep the original binary string beside each decimal number.
- Required statistics:
  - average of the 4 decimal values
  - longest run of identical bits, with the binary example output formatted exactly as required by the samples
  - total count of `1` bits across all 4 numbers
  - number with the most transitions between `0` and `1`
  - how many numbers are divisible by 4
- Tie rule for transitions: if several numbers share the max transition count, print the smallest decimal value among them.
- The section wording says to print one example for the longest run, but sample `D` prints all tied binary numbers. Follow the sample behavior.
- The divisible-by-4 sample with 3 values is printed in ascending decimal order inside the parentheses. Match that behavior.
- Output format is English and must match the sample style exactly.

### Task 1: Prepare The Project Shell

**Files:**
- Modify: `Ex01_01/Program.cs`
- Create: `Ex01_01/BinarySeriesRunner.cs`

- [ ] Verify `Ex01_01` is inside the solution and set as startup project.
- [ ] Keep `Program.Main()` minimal and make it call `BinarySeriesRunner.Run()`.
- [ ] Add a runner class that owns the top-level flow only: read input, analyze input, print report.
- [ ] Commit when the project still builds with empty method bodies.

### Task 2: Implement Input Validation

**Files:**
- Modify: `Ex01_01/BinarySeriesRunner.cs`

- [ ] Write a helper flow that reads one line at a time until the user enters a valid 7-character binary value.
- [ ] Reject any input that is not length 7.
- [ ] Reject any input containing characters other than `0` and `1`.
- [ ] Read exactly 4 valid values and keep them as strings so the original binary text is preserved.
- [ ] Use a clear English validation message and re-prompt immediately after invalid input.
- [ ] Manually verify invalid cases such as `101`, `10101012`, `abcdefg`, and empty input.
- [ ] Commit.

### Task 3: Implement Manual Binary Conversion

**Files:**
- Create: `Ex01_01/BinarySeriesAnalyzer.cs`

- [ ] Add a method such as `ConvertBinaryStringToDecimal(string i_BinaryNumber)`.
- [ ] Implement the conversion manually using positional logic.
- [ ] Do not use `Convert.ToInt32(binary, 2)` or any equivalent built-in binary converter.
- [ ] Add a small internal representation that pairs the original binary string with the computed decimal value.
- [ ] Add sorting logic for descending decimal output.
- [ ] Manually verify conversion with `0000000`, `0001000`, `0110011`, `1111111`.
- [ ] Commit.

### Task 4: Implement The Required Statistics

**Files:**
- Modify: `Ex01_01/BinarySeriesAnalyzer.cs`

- [ ] Add a method for average and format later with 2 digits after the decimal point.
- [ ] Add a method for longest identical-bit run across all 4 strings.
- [ ] When reporting the longest run, collect every binary string that shares the maximum run length so the sample-`D` behavior can be reproduced.
- [ ] Add a method that counts all `1` bits across the 4 strings.
- [ ] Add a method that counts transitions per number.
- [ ] Apply the tie rule for transitions by choosing the smallest decimal number among tied candidates.
- [ ] Add a method that counts how many decimal values are divisible by 4 and returns the matching binary strings in ascending decimal order for output.
- [ ] Manually verify the lecturer samples before formatting output.
- [ ] Commit.

### Task 5: Match The Required Output Format

**Files:**
- Create: `Ex01_01/BinarySeriesFormatter.cs`
- Modify: `Ex01_01/BinarySeriesRunner.cs`

- [ ] Format the descending list in the exact sample style:
  - `Decimal numbers in descending order: 120 (1111000), ...`
- [ ] Format average with exactly 2 digits after the decimal point.
- [ ] Format the longest run line so it prints one binary value or all tied binary values exactly as required by the samples.
- [ ] Format the transitions line and divisible-by-4 line exactly like the PDF examples.
- [ ] Avoid extra spaces, extra blank lines, or different label text.
- [ ] Run the 4 mandatory sample inputs from the PDF and compare line by line.
- [ ] Run at least 1 additional custom input of your own and save its screenshot too.
- [ ] Capture screenshots and paste them into `Ex01_ScreenShots.doc`.
- [ ] Commit.

## Mandatory Manual Verification

- [ ] `1010101, 1111000, 1000001, 0110011`
- [ ] `0101010, 1100111, 1111111, 0001000`
- [ ] `1001100, 1110111, 0000000, 0100100`
- [ ] `1010101, 1010101, 0101010, 0101010`
- [ ] 1 additional custom run of your choice that demonstrates another edge case

## Done Criteria

- The program compiles and runs from Visual Studio.
- Invalid input loops until valid input is provided.
- Binary conversion is manual.
- All 4 sample runs match the lecturer output format.
- At least 1 additional custom run example was captured.
- Screenshots were added to `Ex01_ScreenShots.doc`.
