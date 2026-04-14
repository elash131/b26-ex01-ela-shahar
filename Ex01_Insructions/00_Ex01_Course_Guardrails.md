# Ex01 Course Guardrails

This file summarizes the binding rules that must guide every Ex01 implementation decision.

## Source Of Truth

- The official source of truth is `Ex01_Insructions/DN_2026B_Ex01.pdf`.
- The translated files in `Professor_Rulebook/` are useful, but if they ever conflict with the PDF, the PDF wins.
- The lecturer example executable in `Professor_Exe_Example/Ex01.exe` is also a behavior reference.
- The lecturer EXE is a style and UX reference, not a spec override. If the EXE conflicts with the PDF, the PDF wins.

## Global Exercise Structure

- Build the work in `Visual Studio for Windows`.
- Use one blank solution first, then add one project per section.
- Project names must be `Ex01_01`, `Ex01_02`, `Ex01_03`, `Ex01_04`, `Ex01_05`.
- Keep all projects inside the same solution.
- Before submitting, make sure the final deliverable includes the required `.sln` file with the exact lecturer naming format.

## Naming And Style Rules

- Use meaningful names everywhere.
- Local variables: `camelCase`.
- Indices with no special meaning may use `i`, `j`, and similar if that is the clearest choice.
- Types, public methods, events: `PascalCase`.
- Private methods: lower-case first letter.
- Method names should not contain underscores.
- Parameters must use direction prefixes when relevant: `i_`, `o_`, `io_`.
- Member prefixes matter: `m_`, `k_`, `s_`, `r_`, `sr_`.
- Boolean names must be phrased positively, and negative usage should be written with `!`.
- Prefer `v_HasCharacters` and `!v_HasCharacters` over `v_IsEmpty`.
- Always use braces for `if`, `else`, loops, and similar statements.
- Prefer direct boolean assignment when the condition only decides `true` or `false`.
- Use tabs for indentation, not spaces.
- Do not leave redundant blank lines.
- Add spaces around operators and after commas.
- Keep a declarations section at the top of each method, then leave one blank line before the first executable statement.
- Add a blank line after a closing brace unless the next token is another closing brace or `else`.
- Add a blank line before the single `return` statement.
- Use one `return` statement per method when practical.
- Avoid duplicated logic.
- For the control-statement parenthesis ambiguity in the original slides, follow `Ex01_Insructions/01_Coding_Standards_Source_Notes.md`.

## Submission-Sensitive Rules

- Keep the folder clean before submission.
- Remove `bin`, `obj`, `.git`, and `packages` from the final zip.
- Keep the final zip structure exactly as the lecturer requires.
- Put `Ex01_ScreenShots.doc` in the same folder as the final `.sln`.
- Fill that document with the required console screenshots for the run examples.
- Do not rely on XML documentation for this submission.
- The PDF states a late penalty of `4 points per day`, so follow that number.

## Assignment-Wide Technical Rules

- Validate input in every section and re-prompt on invalid input.
- Use the following tools/classes somewhere in the assignment where relevant:
  - `StringBuilder`
  - `string.Format`
  - `int.TryParse`
  - `Math`
  - `Char`
  - helpful `string` methods
- For `Ex01_01`, convert binary to decimal manually. Do not use a built-in binary conversion helper.
- For `Ex01_03`, reuse `Ex01_02` by adding a project reference instead of duplicating the tree logic.
- For `Ex01_05`, do not use arrays or other data structures.

## Section-Specific Danger Points

- `Ex01_01`: the English output format must match the sample formatting exactly, including labels and decimal formatting.
- `Ex01_01`: if multiple numbers have the same maximum transition count, print the smallest decimal value among them.
- `Ex01_01`: the samples imply that if several numbers share the longest bit sequence, print all tied binary examples in the parentheses, not just one.
- `Ex01_01`: the divisible-by-4 binary list in the sample is ordered by ascending decimal value.
- `Ex01_02`: match the printed tree shape exactly, including the numbered rows and the centered trunk.
- `Ex01_03`: valid tree height range is `4` to `15`, inclusive.
- `Ex01_04`: palindrome check must be recursive and case-insensitive.
- `Ex01_05`: preserve leading zeros by treating the input as a 9-character digit string, not as an `int`.

## Lecturer EXE Behavior Notes

- For repeated homogeneous input, the lecturer EXE tends to print one batch prompt first, then accept several raw input lines without repeating the prompt before every value.
- Keep console text simple and functional. The EXE does not add decorative wording around the core task flow.
- In the lecturer EXE, invalid menu input silently redisplays the menu instead of printing a long extra explanation.
- In the lecturer EXE, the binary-series flow pauses with `Please press 'Enter' to exit...` before returning to the menu.
- In the lecturer EXE, the sand-clock flow returns directly to the menu without that extra pause.
- Do not copy the EXE blindly. Example: the lecturer EXE accepts a 3-line sand clock, but the real `Ex01_03` rule in the PDF is `4` to `15`.

## Required Run Examples

- `Ex01_01`: 4 mandatory examples appear in the PDF, plus at least 1 additional example of your own.
- `Ex01_02`: at least the fixed tree output must be shown.
- `Ex01_03`: mandatory screenshots for heights `4`, `8`, and `9`.
- `Ex01_04`: 3 mandatory examples plus 2 additional examples of your choice.
- `Ex01_05`: 2 mandatory examples plus 2 additional examples of your choice.

## Recommended Build Order

1. `Ex01_01`
2. `Ex01_02`
3. `Ex01_03`
4. `Ex01_04`
5. `Ex01_05`
6. Assemble screenshots into `Ex01_ScreenShots.doc`
7. Final naming and submission cleanup pass

## Final Sanity Checklist

- Output matches lecturer examples exactly where samples are given.
- No extra spaces, no extra blank lines, no unclear names.
- Every project builds in Visual Studio.
- Every required screenshot exists.
- No temporary helper files remain in the submission folder.
