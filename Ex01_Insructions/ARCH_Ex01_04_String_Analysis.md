# Ex01_04 String Analysis Architecture

**Purpose:** define the planned folder layout, class structure, and responsibility boundaries for `Ex01_04` before any implementation begins.

**Scope:** this document is architecture only. It does not contain implementation code.

## Design Goals

- Match the lecturer rules for `Ex01_04` exactly.
- Keep the project structure simple and consistent with `Ex01_01`.
- Separate input, analysis, and formatting responsibilities.
- Make the recursive palindrome requirement impossible to miss.
- Avoid unnecessary files or abstractions.

## Section 4 Rules That Drive The Design

- The input length must be exactly `8` characters.
- If the input contains only digits, report whether the represented number is divisible by `4`.
- If the input contains only English letters, report:
  - the number of uppercase letters
  - whether the letters are ordered in descending alphabetical order
- In all cases, report whether the string is a palindrome.
- The palindrome check must be recursive.
- The palindrome check must be case-insensitive.
- The user must be re-prompted for invalid input.

## Mandatory Coding Standards For The Future Implementation

These rules are architecture constraints for every planned file in this section:

- Use meaningful names everywhere.
- Use `PascalCase` for classes and for public methods.
- Use a lower-case first letter for private methods.
- Do not use underscores in method names.
- Use `camelCase` for local variables.
- Generic loop indices may be named `i`, `j`, and similar only when they have no special meaning.
- Prefix parameters by direction when relevant:
  - `i_` for input only
  - `o_` for output only
  - `io_` for input and output
- Use member prefixes exactly when members are introduced:
  - `m_` regular members
  - `k_` constants
  - `s_` static members
  - `r_` readonly members
  - `sr_` static readonly members
- Keep Boolean names positive.
- When a local Boolean control variable is introduced, initialize it to `true`.
- Use `!` for the negative case instead of negative Boolean names.
- Always use braces for `if`, `else`, `for`, and similar statements.
- Use tabs for indentation.
- Use spaces around operators and after commas.
- Preserve the repository control-statement style consistently:
  - `if(condition)`
  - `for(index = 0; index < count; index++)`
- Keep a declarations section at the top of each method.
- Leave one blank line after the declarations section before the first executable statement.
- Leave one blank line before the single `return` statement.
- Leave one blank line after a closing brace unless another closing brace or `else` follows immediately.
- Prefer one `return` statement per method when practical.
- Avoid duplicated logic.
- Prefer direct Boolean assignment when a condition only decides `true` or `false`.
- Add comments inside methods only when a programming decision truly requires explanation.
- Prefer small focused methods that implement flow by calling helper methods.

## Folder Structure Decision

Keep `Ex01_04` as a flat project folder, just like `Ex01_01`.

Planned structure:

- `Ex01_04/Ex01_04.csproj`
- `Ex01_04/App.config`
- `Ex01_04/Program.cs`
- `Ex01_04/StringAnalysisRunner.cs`
- `Ex01_04/StringAnalysisInputReader.cs`
- `Ex01_04/StringAnalysisAnalyzer.cs`
- `Ex01_04/StringAnalysisFormatter.cs`
- `Ex01_04/StringAnalysisReport.cs`

No subfolders are planned inside `Ex01_04`, because the project is small and the existing repository style keeps section files at project root level.

## Class Responsibilities

### `Program`

- Single entry point only.
- Creates the runner and starts the flow.
- Contains no business logic.

### `StringAnalysisRunner`

- Owns the top-level use-case flow.
- Reads valid input from the user.
- Sends the input to the analyzer.
- Sends the analysis result to the formatter.
- Prints the final formatted output.

This class exists so `Program` stays minimal and the project follows the same structure already used in `Ex01_01`.

### `StringAnalysisInputReader`

- Reads the input string from the console.
- Validates that the length is exactly `8`.
- Prints the invalid-input message when needed.
- Re-prompts until a valid 8-character string is entered.

This class should validate only the input contract, not the analysis rules. Mixed content is not invalid by itself, so content classification does not belong here.

### `StringAnalysisAnalyzer`

- Determines whether the input is:
  - digits only
  - English letters only
  - mixed / other valid 8-character content
- Computes the numeric-only result when the input is digits only.
- Computes the letter-only results when the input is English letters only.
- Computes the palindrome result in all cases.
- Holds the recursive palindrome helper as a private method.

This is the main decision-making class of the section.

### `StringAnalysisFormatter`

- Converts the analysis result into the final console text.
- Uses predictable output ordering.
- Keeps formatting logic out of the analyzer.

This class should build the text in one place so formatting changes do not leak into the logic layer.

### `StringAnalysisReport`

- Lightweight data holder for the final analysis results.
- Carries only the values needed by the formatter.
- Avoids repeated recomputation during output creation.

Planned result fields:

- original input
- whether the input is digits only
- whether the input is English letters only
- whether the number is divisible by `4`
- uppercase letters count
- whether letters are in descending alphabetical order
- whether the input is a palindrome

## Planned Responsibility Boundaries

### What `StringAnalysisInputReader` should not do

- It should not count uppercase letters.
- It should not check descending order.
- It should not check palindrome.
- It should not decide which result lines should be printed.

### What `StringAnalysisAnalyzer` should not do

- It should not print anything directly.
- It should not read from `Console`.
- It should not contain the final output wording.

### What `StringAnalysisFormatter` should not do

- It should not classify the input again.
- It should not recalculate analysis values.
- It should not read input.

## Data Flow

1. `Program` starts the runner.
2. `StringAnalysisRunner` asks `StringAnalysisInputReader` for one valid 8-character string.
3. `StringAnalysisRunner` sends the valid input to `StringAnalysisAnalyzer`.
4. `StringAnalysisAnalyzer` returns a `StringAnalysisReport`.
5. `StringAnalysisRunner` sends the report to `StringAnalysisFormatter`.
6. `StringAnalysisRunner` prints the formatted result.

## Planned Lecturer-Requested API Usage In This Section

The lecturer mentioned several APIs that should be used in the assignment. For `Ex01_04`, the planned usage is:

- `Char`
  - input classification
  - uppercase counting
  - English-letter validation
- `string.Format`
  - output lines in the formatter
- `StringBuilder`
  - building the final output block in the formatter
- `int.TryParse`
  - safe numeric conversion for the digits-only case
- helpful `string` methods
  - input length check
  - case normalization for palindrome and alphabetical-order checks

`Math` is not planned for `Ex01_04`, because this section does not naturally need it. It is already relevant in other sections of the assignment.

## Important Architecture Decisions

- Keep the palindrome logic inside `StringAnalysisAnalyzer`, not in a separate class, because it is one requirement inside the analysis domain, not a reusable subsystem.
- Keep the project flat, because adding folders would create structure overhead without clarity benefits.
- Use a result object instead of returning many separate values, because the formatter needs a clear, stable contract.
- Treat mixed 8-character input as valid input. In that case, only the palindrome result should always be available, while the digits-only and letters-only outputs stay conditional.

## Output-Format Caution

Implementation must use the exact lecturer wording and ordering from the official exercise material.

This architecture document does not invent final output labels. It only defines where that wording should live: `StringAnalysisFormatter`.
