# Ex01 Agent Instructions

This repository contains a course assignment with strict lecturer rules. Tiny formatting mistakes, naming mistakes, and output mismatches can cost points. Work carefully and conservatively.

## Mandatory Read Order Before Any Implementation

Before writing code, editing code, suggesting architecture changes, or claiming something is ready, read these files in this exact order:

1. `Ex01_Insructions/00_Ex01_Course_Guardrails.md`
2. `Ex01_Insructions/DN_2026B_Ex01.pdf`
3. `Professor_Rulebook/Coding_Standards.md`
4. `Ex01_Insructions/01_Coding_Standards_Source_Notes.md`
5. `Professor_Rulebook/Submission_Rules.md`
6. `Professor_Rulebook/Visual_Studio_Workflow.md`
7. The relevant section plan file in `Ex01_Insructions/PLAN_Ex01_0X_*.md`

If any guidance conflicts, the PDF in `Ex01_Insructions/DN_2026B_Ex01.pdf` wins.

## Project Context

- Course: Object-Oriented Programming in C# / .NET
- Exercise: `Ex01`
- Environment: `Visual Studio for Windows`
- Framework: `.NET Framework 4.7.2`
- Solution structure: one solution, one project per section
- Project names must be:
  - `Ex01_01`
  - `Ex01_02`
  - `Ex01_03`
  - `Ex01_04`
  - `Ex01_05`

## Hard Rules

- Do not invent formats, labels, or output wording.
- Do not change required solution, project, or submission naming conventions.
- Use meaningful names everywhere.
- Keep a declarations section at the top of methods and start executable statements only after that section.
- Use tabs for indentation.
- Always use braces for control-flow bodies.
- Avoid redundant blank lines and redundant spaces.
- Prefer direct boolean assignment when a condition only decides `true` or `false`.
- Prefer one `return` statement per method when practical.
- Avoid duplicated logic.
- Validate user input and re-prompt on invalid input.
- Keep output formatting exactly aligned with the lecturer examples.
- Follow `Ex01_Insructions/01_Coding_Standards_Source_Notes.md` for the exact coding-style interpretation used in this repository.
- Use the lecturer EXE as a UX/style clue only. If the EXE and the PDF disagree, the PDF wins.
- For repeated same-type input, prefer one clear batch prompt instead of repeating the same prompt before every value, unless the PDF explicitly requires repeated prompting.

## Section-Specific Non-Negotiables

- `Ex01_01`
  - Read 4 valid 7-bit binary numbers.
  - Convert binary to decimal manually. Do not use a built-in binary conversion helper.
  - Match the English output format exactly.
  - In transition-count ties, choose the smallest decimal number.

- `Ex01_02`
  - Print the fixed beginner letter tree exactly as shown.
  - Preserve row numbering and spacing carefully.

- `Ex01_03`
  - Read a tree height from `4` to `15`.
  - Reuse `Ex01_02` via project reference. Do not duplicate the tree logic.

- `Ex01_04`
  - Input length is exactly 8 characters.
  - Palindrome check must be recursive.
  - Palindrome check must be case-insensitive.

- `Ex01_05`
  - Input length is exactly 9 digits.
  - Preserve leading zeros by treating input as a string.
  - Do not use arrays or data structures.

## Required Libraries / APIs Mentioned By The Exercise

Use these where relevant:

- `StringBuilder`
- `string.Format`
- `int.TryParse`
- `Math`
- `Char`
- helpful `string` methods

## Before Marking Work As Done

Verify all of the following:

- The relevant project builds in Visual Studio.
- Output matches the PDF examples exactly where examples exist.
- No extra spaces or extra blank lines were introduced.
- Naming follows lecturer conventions.
- Required screenshots were captured into `Ex01_ScreenShots.doc`.
- The final submission folder will not include `bin`, `obj`, `.git`, or `packages`.

## When To Stop And Ask

Stop and ask the user before proceeding if:

- the PDF wording is ambiguous
- the sample output and the written text seem inconsistent
- a proposed refactor would change the required public structure
- there is a conflict between lecturer rules and convenience

When unsure, choose the most conservative interpretation and point to the PDF.
