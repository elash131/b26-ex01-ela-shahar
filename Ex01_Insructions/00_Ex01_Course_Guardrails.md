# Ex01 Course Guardrails

This file summarizes the binding rules that must guide every Ex01 implementation decision.

## Source Of Truth

- The official source of truth is `Ex01_Insructions/DN_2026B_Ex01.pdf`.
- The translated files in `Professor_Rulebook/` are useful, but if they ever conflict with the PDF, the PDF wins.
- The lecturer example executable in `Professor_Exe_Example/Ex01.exe` is also a behavior reference.

## Global Exercise Structure

- Build the work in `Visual Studio for Windows`.
- Use one blank solution first, then add one project per section.
- Project names must be `Ex01_01`, `Ex01_02`, `Ex01_03`, `Ex01_04`, `Ex01_05`.
- Keep all projects inside the same solution.
- Before submitting, make sure the final deliverable includes the required `.sln` file with the exact lecturer naming format.

## Naming And Style Rules

- Use meaningful names everywhere.
- Local variables: `camelCase`.
- Types, public methods, events: `PascalCase`.
- Private methods: lower-case first letter.
- Parameters must use direction prefixes when relevant: `i_`, `o_`, `io_`.
- Member prefixes matter: `m_`, `k_`, `s_`, `r_`, `sr_`.
- Always use braces for `if`, `else`, loops, and similar statements.
- Use tabs for indentation, not spaces.
- Do not leave redundant blank lines.
- Add spaces around operators and after commas.
- Use one `return` statement per method when practical.
- Avoid duplicated logic.

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
- `Ex01_02`: match the printed tree shape exactly, including the numbered rows and the centered trunk.
- `Ex01_03`: valid tree height range is `4` to `15`, inclusive.
- `Ex01_04`: palindrome check must be recursive and case-insensitive.
- `Ex01_05`: preserve leading zeros by treating the input as a 9-character digit string, not as an `int`.

## Required Run Examples

- `Ex01_01`: 4 mandatory examples appear in the PDF.
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
