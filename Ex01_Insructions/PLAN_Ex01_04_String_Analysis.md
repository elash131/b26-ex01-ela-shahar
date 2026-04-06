# Ex01_04 String Analysis Implementation Plan

> **For agentic workers:** REQUIRED: Use `.agent/skills/executing-plans/SKILL.md` to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build `Ex01_04` so it reads an 8-character string and reports the required facts for numeric-only input, English-letter-only input, and the recursive case-insensitive palindrome check.

**Architecture:** Keep the input as a string from start to finish. Create one analysis service that classifies the input and computes the needed answers, with a separate recursive palindrome helper so that requirement is impossible to skip accidentally.

**Tech Stack:** C#, .NET Framework 4.7.2, Console app, Visual Studio for Windows

---

## File Structure

- Create: `Ex01_04/Ex01_04.csproj`
- Create: `Ex01_04/Program.cs`
- Create: `Ex01_04/StringAnalysisRunner.cs`
- Create: `Ex01_04/StringAnalysisService.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

## Spec Notes To Honor

- Input length must be exactly 8 characters.
- If all characters are digits:
  - report whether the represented number is divisible by 4
- If all characters are English letters:
  - report uppercase count
  - report whether the letters are in descending alphabetical order
- In all cases:
  - report whether the string is a palindrome
  - the palindrome check must be recursive
  - the palindrome check must be case-insensitive
- Required examples:
  - `HgFeDcBa`
  - `12481632`
  - `AbCddCbA`
  - plus 2 additional examples chosen to cover more cases

### Task 1: Create The Project

**Files:**
- Create: `Ex01_04/Ex01_04.csproj`
- Create: `Ex01_04/Program.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

- [ ] Add `Ex01_04` to the solution.
- [ ] Keep `Program.Main()` minimal and delegate to a runner.
- [ ] Confirm the empty project builds.
- [ ] Commit.

### Task 2: Validate And Classify The Input

**Files:**
- Create: `Ex01_04/StringAnalysisRunner.cs`
- Create: `Ex01_04/StringAnalysisService.cs`

- [ ] Read one input string from the user.
- [ ] Reject input that is not exactly 8 characters long.
- [ ] Use `Char` and `string` methods to classify:
  - all digits
  - all English letters
  - mixed content
- [ ] Re-prompt on invalid length.
- [ ] Commit.

### Task 3: Implement Numeric-Only Analysis

**Files:**
- Modify: `Ex01_04/StringAnalysisService.cs`

- [ ] Add a helper that checks whether an 8-digit string represents a number divisible by 4.
- [ ] Prefer a simple last-two-digits rule or a safe parse flow, but keep the logic easy to explain.
- [ ] Only print the divisibility-by-4 result when the input is all digits.
- [ ] Manually verify with `12481632`.
- [ ] Commit.

### Task 4: Implement Letter-Only Analysis

**Files:**
- Modify: `Ex01_04/StringAnalysisService.cs`

- [ ] Add a helper that counts uppercase English letters.
- [ ] Add a helper that checks whether the letters are in descending alphabetical order.
- [ ] Keep this check case-insensitive or normalize case before comparison.
- [ ] Only print these two results when the input is all English letters.
- [ ] Manually verify with `HgFeDcBa` and `AbCddCbA`.
- [ ] Commit.

### Task 5: Implement Recursive Palindrome Check

**Files:**
- Modify: `Ex01_04/StringAnalysisService.cs`

- [ ] Add a recursive helper method for palindrome detection.
- [ ] Normalize case before comparing characters.
- [ ] Make sure mixed strings still get the palindrome result.
- [ ] Manually verify non-palindrome and palindrome cases.
- [ ] Commit.

### Task 6: Manual Verification And Screenshots

**Files:**
- No new files

- [ ] Run the 3 mandatory lecturer examples.
- [ ] Add 2 extra examples that cover additional cases, for example:
  - mixed input that is not all digits or all letters
  - numeric palindrome or non-descending letters
- [ ] Capture all 5 runs and paste them into `Ex01_ScreenShots.doc`.
- [ ] Commit.

## Done Criteria

- `Ex01_04` exists and builds.
- Input length validation works.
- Numeric-only logic prints only the numeric result plus palindrome.
- Letter-only logic prints only the letter results plus palindrome.
- Palindrome logic is recursive and case-insensitive.
- Five screenshots exist in `Ex01_ScreenShots.doc`.
