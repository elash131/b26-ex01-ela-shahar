# Ex01_04 String Analysis Implementation Plan

> **For agentic workers:** REQUIRED: Use `.agent/skills/executing-plans/SKILL.md` to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build `Ex01_04` so it reads one valid 8-character string and reports the required numeric-only result, letter-only results, and the recursive case-insensitive palindrome result.

**Architecture:** Keep the project flat and consistent with `Ex01_01`. Separate the flow into input reading, analysis, result transport, and formatting, with the recursive palindrome logic kept inside the analyzer so the lecturer requirement is explicit and local.

**Tech Stack:** C#, .NET Framework 4.7.2, Console app, Visual Studio for Windows

**Planning Note:** This document intentionally contains no code snippets yet, by explicit user request.

---

## File Structure

- Keep: `Ex01_04/Ex01_04.csproj`
- Keep: `Ex01_04/App.config`
- Create: `Ex01_04/Program.cs`
- Create: `Ex01_04/StringAnalysisRunner.cs`
- Create: `Ex01_04/StringAnalysisInputReader.cs`
- Create: `Ex01_04/StringAnalysisAnalyzer.cs`
- Create: `Ex01_04/StringAnalysisFormatter.cs`
- Create: `Ex01_04/StringAnalysisReport.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

## Mandatory Coding Standards During Implementation

Every implementation task in this section must follow these lecturer rules:

- Use meaningful names everywhere.
- Use `PascalCase` for classes and for public methods.
- Use a lower-case first letter for private methods.
- Do not put underscores in method names.
- Use `camelCase` for local variables.
- Use `i_`, `o_`, and `io_` parameter prefixes when relevant.
- Use member prefixes exactly when members are needed:
  - `m_`
  - `k_`
  - `s_`
  - `r_`
  - `sr_`
- Keep Boolean names positive.
- When introducing a local Boolean control variable, initialize it to `true`.
- Use `!` for the negative case instead of negative Boolean naming.
- Prefer direct Boolean assignment when a condition only decides `true` or `false`.
- Always wrap control-flow bodies with braces.
- Use tabs for indentation.
- Use spaces around operators and after commas.
- Preserve one consistent control-statement style and follow the repository style:
  - `if(condition)`
  - `for(index = 0; index < count; index++)`
- Keep a declarations section at the top of each method.
- Add one blank line after the declarations section before the first executable statement.
- Add one blank line before the single `return` statement.
- Add one blank line after a closing brace unless another closing brace or `else` follows immediately.
- Prefer one `return` statement per method when practical.
- Avoid duplicated logic.
- Keep methods small and focused.
- Add in-method comments only when a programming decision requires explanation.

## Spec Notes To Honor

- Input length must be exactly `8` characters.
- If the input is digits only:
  - report whether the represented number is divisible by `4`
- If the input is English letters only:
  - report how many uppercase letters appear in the input
  - report whether the letters are ordered in descending alphabetical order
- In all cases:
  - report whether the input is a palindrome
  - the palindrome check must be recursive
  - the palindrome check must be case-insensitive
- Input validation must re-prompt on invalid input.
- Required lecturer examples to verify:
  - `HgFeDcBa`
  - `12481632`
  - `AbCddCbA`
- Add `2` additional examples of your own.

## Lecturer-Mentioned Libraries And APIs To Use In This Section

- `Char`
  - digit detection
  - English-letter detection
  - uppercase counting
- helpful `string` methods
  - exact length validation
  - case normalization
  - character access
- `string.Format`
  - final output line formatting
- `StringBuilder`
  - final multi-line output assembly
- `int.TryParse`
  - safe numeric conversion for the digits-only case

`Math` is not planned for this section because it adds no natural value here. That is acceptable because the assignment-wide API list is used where relevant, not artificially forced into every section.

## Output Planning Rules

- Do not invent output wording.
- Keep the final labels and line order aligned with the lecturer material.
- Keep the console text simple and functional.
- If the official material leaves wording ambiguous, implementation should use the most conservative lecturer-style phrasing.

### Task 1: Confirm The Project Shell

**Files:**
- Keep: `Ex01_04/Ex01_04.csproj`
- Keep: `Ex01_04/App.config`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`
- Create: `Ex01_04/Program.cs`

- [ ] Ensure `Ex01_04` is included in the solution.
- [ ] Keep `Program.Main()` minimal and delegate immediately to a runner class.
- [ ] Confirm the project targets `.NET Framework 4.7.2`.
- [ ] Confirm the project builds before adding section logic.
- [ ] Commit.

### Task 2: Build The Top-Level Flow

**Files:**
- Create: `Ex01_04/StringAnalysisRunner.cs`
- Modify: `Ex01_04/Program.cs`

- [ ] Create a runner class responsible only for the top-level execution flow.
- [ ] Make the runner read valid input, analyze it, format the result, and print it.
- [ ] Keep `Program` and `Runner` free of analysis details.
- [ ] Commit.

### Task 3: Implement Input Validation

**Files:**
- Create: `Ex01_04/StringAnalysisInputReader.cs`

- [ ] Read one string from the user.
- [ ] Reject any input whose length is not exactly `8`.
- [ ] Print a clear invalid-input message and re-prompt until the input length is valid.
- [ ] Treat mixed valid 8-character input as valid input, not as invalid input.
- [ ] Keep this class focused only on the input contract, not on analysis decisions.
- [ ] Commit.

### Task 4: Create The Analysis Result Contract

**Files:**
- Create: `Ex01_04/StringAnalysisReport.cs`

- [ ] Define a result object that carries all values the formatter needs.
- [ ] Include enough data to decide which lines should be printed.
- [ ] Keep the data contract simple and section-specific.
- [ ] Commit.

### Task 5: Implement Input Classification

**Files:**
- Create: `Ex01_04/StringAnalysisAnalyzer.cs`

- [ ] Add the main analysis method that receives the original string and returns the report object.
- [ ] Classify the input as:
  - digits only
  - English letters only
  - mixed / other valid 8-character input
- [ ] Use `Char` and English-letter range checks rather than broad Unicode assumptions.
- [ ] Keep classification logic in the analyzer, not in the reader or formatter.
- [ ] Commit.

### Task 6: Implement The Digits-Only Rule

**Files:**
- Modify: `Ex01_04/StringAnalysisAnalyzer.cs`

- [ ] Add the digits-only helper for divisibility by `4`.
- [ ] Use `int.TryParse` for a safe numeric conversion flow.
- [ ] Only expose the divisibility result when the input is digits only.
- [ ] Verify the lecturer example `12481632`.
- [ ] Commit.

### Task 7: Implement The Letters-Only Rules

**Files:**
- Modify: `Ex01_04/StringAnalysisAnalyzer.cs`

- [ ] Add a helper that counts uppercase English letters.
- [ ] Add a helper that checks descending alphabetical order.
- [ ] Normalize case before comparing letters for alphabetical order.
- [ ] Only expose these two results when the input is English letters only.
- [ ] Verify the lecturer examples `HgFeDcBa` and `AbCddCbA`.
- [ ] Commit.

### Task 8: Implement The Recursive Palindrome Rule

**Files:**
- Modify: `Ex01_04/StringAnalysisAnalyzer.cs`

- [ ] Add a recursive helper for palindrome detection.
- [ ] Make the palindrome check case-insensitive.
- [ ] Run the palindrome check for every valid input type.
- [ ] Keep the recursion local and explicit so the lecturer requirement is easy to review.
- [ ] Commit.

### Task 9: Implement Output Formatting

**Files:**
- Create: `Ex01_04/StringAnalysisFormatter.cs`

- [ ] Build the final output in one place.
- [ ] Use `StringBuilder` to assemble the multi-line result cleanly.
- [ ] Use `string.Format` for the final line wording.
- [ ] Print only the lines relevant to the input type, while always printing the palindrome result.
- [ ] Keep the output order stable and sample-driven.
- [ ] Commit.

### Task 10: Manual Verification And Screenshots

**Files:**
- No new source files

- [ ] Run the lecturer examples:
  - `HgFeDcBa`
  - `12481632`
  - `AbCddCbA`
- [ ] Add `2` extra examples that cover missing edges, such as:
  - mixed valid 8-character input
  - letter-only input that is not in descending order
- [ ] Compare the output text carefully against the lecturer material.
- [ ] Capture all `5` runs in `Ex01_ScreenShots.doc`.
- [ ] Commit.

## Risks To Watch During Implementation

- Confusing "English letters only" with any Unicode letters.
- Forgetting that mixed 8-character input is still valid input.
- Using a non-recursive palindrome check by accident.
- Applying the digits-only or letters-only outputs when the input does not belong to that category.
- Drifting from the lecturer output wording or line order.

## Done Criteria

- `Ex01_04` exists in the solution and builds.
- Input validation accepts only length `8`.
- Digits-only input prints the digits rule plus palindrome.
- Letters-only input prints uppercase count, descending-order result, and palindrome.
- Mixed valid input still prints the palindrome result.
- The palindrome check is recursive and case-insensitive.
- The lecturer examples and two additional examples were captured.
