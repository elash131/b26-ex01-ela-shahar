# Coding Standards Source Notes

This file is a source-checked summary of `RulePages/CodingStandards_NoSC/page3.png` through `page8.png`.

Use it when you want the lecturer coding standards exactly as they appear in the original slides, including places where the markdown transcription needed clarification.

## Variables And Class Members

- Use meaningful names, even if they become long.
- Indices with no special meaning may be named `i`, `j`, and similar.
- Local variables should be `camelCase`.
- The first letter is lower-case.
- The first letter of each following word is upper-case.
- The source slide explicitly shows `v_` for local const booleans.
- In this repository, use `v_` for local booleans too as a conservative convention.
- Phrase boolean names as positive assertions.
- Good: `v_IsValidInput`, `v_HasCharacters`, `containsOnlyBinaryDigits`
- Avoid negative boolean names such as `v_IsInvalidInput`, `v_IsEmpty`, `hasNoCharacters`
- When a new local boolean control variable is needed, initialize it to `true`.
- Good: `bool v_ShouldReadAnotherBinaryNumber = true;`
- Avoid initializing such a control variable to `false` and then flipping the flow around it.
- When passing a boolean parameter, prefer a named boolean variable over raw `true` / `false`.
- If you need the negative meaning, prefer `!variable` instead of a negatively named boolean.
- Class and struct member prefixes:
  - regular member: `m_`
  - const member and local const: `k_`
  - static member: `s_`
  - readonly member: `r_`
  - static readonly member: `sr_`

## Statements

- Every statement body should be wrapped with block wrappers / curly braces.
- Do not rely on one-line bodies without braces for `if`, `else`, `for`, and similar statements.

## Properties, Methods, And Indexers

- Use meaningful names.
- Do not add underscores to method names.
- Public and protected methods should use PascalCase.
- Private methods should start lower-cased.
- In method declarations, separate parameters with spaces, not tabs.
- Keep the method declaration on one line when reasonable.
- If there are many parameters, split the declaration across several lines.

## Parameters

- Use meaningful names.
- Prefix by direction:
  - `i_` for input only
  - `o_` for output only
  - `io_` for input and output

## Classes, Structs, Enums, Delegates, And Events

- Classes and structs should use meaningful PascalCase names.
- Enums should use meaningful PascalCase names.
- Enum types should be prefixed with `e`.
- Flag enums should use a plural name.
- Do not use unnecessary underscores in enum names.
- Delegate names follow class naming style and should end with `Delegate`.
- Event-handler delegate types should end with `EventHandler`, not `Delegate`.
- Event names should be PascalCase and describe the event clearly.
- Subscriber handler methods should be named like `<senderName>_<EventName>`.
- Event raiser methods should be named `OnXXX`.

## Style

- Prefer direct boolean assignment:
  - good: `isOldMan = age > 50;`
  - avoid `if / else` that only assign `true` / `false`
- Prefer positive boolean flow:
  - good: `if(!v_HasCharacters)`
  - avoid `if(v_IsEmpty)`
- Prefer positive boolean initialization:
  - good: `bool v_ShouldContinue = true;`
  - avoid `bool v_IsDone = false;`
- Avoid duplicated code inside both `if` and `else`.
- Move shared logic outside the branch when possible.

## Layout

- Use tabs, not spaces, for indentation.
- Each nested block should be indented one tab deeper than its parent block.

## Spaces

- Do not leave double blank lines.
- Do not leave redundant blank lines.
- Use spaces around operators and operands.
- Use spaces after commas in parameter declarations and argument lists.
- Do not put a space before method or method-call parentheses.

## Blank Lines

- Add a blank line after the local variable declarations section.
- Add a blank line after a closing brace, unless the next token is another closing brace or `else`.
- Add a blank line before the single `return` statement.

## Method Implementations

- Use only one `return` statement per method.
- Prefer methods that implement a flow by calling other methods.

## Important Source Ambiguity

The original slides are inconsistent about control-statement parentheses:

- `page7.png` shows `if (boolVar)` and `for (int j = 0; ...)`
- `page8.png` shows `if(x == 5)` as the good example

Because of that inconsistency, use this repository rule:

- Always keep spaces around operators.
- Never churn code solely to switch between `if(` and `if (`.
- Preserve one consistent control-statement style within the file / repository.
- For this repository, prefer the current no-space control-statement style:
  - `if(x == 5)`
  - `for(index = 0; index < count; index++)`
