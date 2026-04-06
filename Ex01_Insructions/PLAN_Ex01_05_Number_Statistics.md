# Ex01_05 Number Statistics Implementation Plan

> **For agentic workers:** REQUIRED: Use `.agent/skills/executing-plans/SKILL.md` to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build `Ex01_05` so it reads a 9-digit number string and reports the four required statistics without using arrays or extra data structures.

**Architecture:** Store the input as a 9-character string, not as a numeric type, so leading zeros stay intact. Use simple loops and scalar variables only. For unique-digit counting, use nested scans rather than arrays or collections.

**Tech Stack:** C#, .NET Framework 4.7.2, Console app, Visual Studio for Windows

---

## File Structure

- Create: `Ex01_05/Ex01_05.csproj`
- Create: `Ex01_05/Program.cs`
- Create: `Ex01_05/NumberStatisticsRunner.cs`
- Create: `Ex01_05/NumberStatisticsService.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

## Spec Notes To Honor

- Input must contain exactly 9 digits.
- Preserve leading zeros.
- Required outputs:
  - how many digits are larger than the units digit, excluding the units digit itself
  - how many digits are divisible by 4
  - product of the largest digit and the smallest digit
  - how many distinct digits appear
- Do not use arrays or other data structures.
- Required examples:
  - `314159265`
  - `008040080`
  - plus 2 additional examples

### Task 1: Create The Project

**Files:**
- Create: `Ex01_05/Ex01_05.csproj`
- Create: `Ex01_05/Program.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

- [ ] Add `Ex01_05` to the solution.
- [ ] Keep `Program.Main()` minimal and delegate to a runner.
- [ ] Confirm the project builds.
- [ ] Commit.

### Task 2: Validate The Input Correctly

**Files:**
- Create: `Ex01_05/NumberStatisticsRunner.cs`
- Create: `Ex01_05/NumberStatisticsService.cs`

- [ ] Read the input as a string.
- [ ] Reject input that is not exactly 9 characters long.
- [ ] Reject any input containing non-digit characters.
- [ ] Keep the validated value as a string so values like `008040080` remain unchanged.
- [ ] Use a clear English validation message and re-prompt until valid.
- [ ] Commit.

### Task 3: Implement The Four Statistics

**Files:**
- Modify: `Ex01_05/NumberStatisticsService.cs`

- [ ] Read the units digit from the last character.
- [ ] Count how many earlier digits are greater than the units digit.
- [ ] Count how many digits are divisible by 4 as individual digits.
- [ ] Find the largest and smallest digit, then multiply them.
- [ ] Count distinct digits without arrays or collections.
- [ ] Use nested loops or repeated string scanning to detect first appearances.
- [ ] Commit.

### Task 4: Format The Output Cleanly

**Files:**
- Modify: `Ex01_05/NumberStatisticsRunner.cs`

- [ ] Print all 4 required answers clearly and consistently.
- [ ] Keep the formatting clean and easy to compare against the mandatory samples.
- [ ] Avoid extra blank lines or unclear labels.
- [ ] Commit.

### Task 5: Manual Verification And Screenshots

**Files:**
- No new files

- [ ] Run the mandatory example `314159265` and confirm:
  - units digit is `5`
  - digits greater than it: `2`
  - digits divisible by 4: `1`
  - largest times smallest: `9`
  - distinct digits: `7`
- [ ] Run the mandatory example `008040080` and confirm:
  - units digit is `0`
  - digits greater than it: `3`
  - digits divisible by 4: `9`
  - largest times smallest: `0`
  - distinct digits: `3`
- [ ] Add 2 more examples of your choice to cover additional edge cases.
- [ ] Capture all 4 runs and paste them into `Ex01_ScreenShots.doc`.
- [ ] Commit.

## Done Criteria

- `Ex01_05` exists and builds.
- Leading zeros are preserved.
- No arrays or collections were used.
- The 2 mandatory runs match the lecturer results.
- Four screenshots exist in `Ex01_ScreenShots.doc`.
