# Coding Standards

This document turns the lecturer coding standards into direct working rules.

## Variables And Class Members

### Local variables

- Use meaningful names, even if they are long.
- Use `camelCase`.
- Indices with no special meaning may be named `i`, `j`, and similar when that is the natural choice.
- Avoid meaningless short names unless they are the natural loop / index variables with no special meaning.

Examples:

- Good: `numOfItems`
- Bad: `NumOfItems`
- Bad: `numOfItems_`
- Bad: `NUMOFITEMS`

### Local const booleans

- Name them with the prefix `v_`.
- Use CamelCase after the prefix.
- Prefer a positive boolean meaning.
- When you need the negative meaning, pass `!variable` instead of creating a negative boolean literal.
- Prefer named boolean constants over raw `true` / `false` when passing boolean parameters.

### Class and struct members

- Regular data members: `m_SomeName`
- Const members and local consts: `k_SomeName`
- Static members: `s_SomeName`
- Readonly members: `r_SomeName`
- Static readonly members: `sr_SomeName`

## Statements

- Always wrap `if`, `else`, `for`, and similar bodies with curly braces.
- Do not rely on single-line statement bodies without braces.

## Properties, Methods, And Indexers

### Naming

- Use meaningful names.
- Do not add underscores to method names.
- Use PascalCase for public and protected methods.
- Private methods should start with a lower-case first letter.

Examples:

- Good: `GetNumOfItems`
- Good: `getNumOfItems` for a private method
- Bad: `get_num_of_items`
- Bad: `Getnumofitems`
- Bad: `GETNUMOFITEMS`

### Method declaration

- Use spaces between parameter declarations, not tabs.
- Keep the method declaration on one line when reasonable.
- If there are many parameters, split the parameter list across several lines.

### Parameters

- Use meaningful parameter names.
- Prefix parameters by direction:
- `i_` = input only
- `o_` = output only
- `io_` = input and output

Examples:

- `string i_Name`
- `int i_Age`
- `ref string io_PhoneNumber`
- `out string o_Age`

## Classes And Structs

- Use meaningful names.
- Use PascalCase.

## Enums

- Use meaningful names.
- Use PascalCase.
- Prefix enum type names with `e`.
- For flagged enums, use a plural name ending with `s`.
- Do not use C++-style enum naming.
- Do not use unnecessary underscores.

Examples:

- Good: `eFuelType`
- Good: `eFuelTypes` for `[Flags]`
- Bad: `Fuel_Type`

## Delegates And Events

### Delegates

- Use meaningful names.
- Delegate names follow class naming style.
- End regular delegate names with `Delegate`.
- If the delegate is an event handler, use the suffix `EventHandler`, not `Delegate`.

### Events

- Event names should be PascalCase.
- Event names should describe the event clearly, usually as an action or event state.

Examples:

- `Closed`
- `Closing`
- `AfterEdit`
- `BeforeEdit`

### Event handler methods in subscribers

- Name them as `<senderName>_<EventName>`.

Example:

- `buttonOK_Click(object sender, EventArgs e)`

### Event raiser methods

- The internal method that raises an event should be named `OnXXX`.

Example:

- `OnClick(EventArgs e)`

## Style

### Conditions

- Prefer direct boolean assignment.

Good:

```csharp
isOldMan = age > 50;
```

Bad:

```csharp
if (age > 50)
{
	isOldMan = true;
}
else
{
	isOldMan = false;
}
```

### Duplicated code

- Do not duplicate shared code inside both `if` and `else`.
- Move the shared code outside the branch when possible.

### Layout

- Use tabs, not spaces, for indentation.
- Each nested block should be indented one tab deeper than its parent block.

### Spaces

- Do not use double blank lines.
- Do not leave redundant blank lines.
- Use spaces around operators.
- Use spaces after commas in parameter lists and argument lists.
- Do not put a space before method parentheses or method-call parentheses.
- The source slide examples are inconsistent about control-statement parentheses:
  - one slide shows `if (boolVar)` and `for (int j = 0; ...)`
  - another slide shows `if(x == 5)` as the good example
- Because of that inconsistency, treat the non-negotiable part as:
  - keep spaces around operators
  - keep spaces after commas
  - do not add a space before method-call parentheses
  - preserve one consistent control-statement style within the file / repository instead of reformatting back and forth

Good:

- `x = t + 5;`
- `if(x == 5)`
- `Console.WriteLine("Hello {0} and {1}", name1, name2);`
- `DoSomeThing(5, 4);`

Bad:

- `x=t+5;`
- `if(x==5)`
- `Console.WriteLine("Hello {0} and {1}",name1,name2);`
- `DoSomeThing (5, 4);`

### Blank lines

- Add a blank line after the local variable declarations section.
- Add a blank line after a closing brace, unless another closing brace or `else` follows immediately.
- Add a blank line before the single return statement.

## Method Implementations

- Use only one `return` statement per method.
- Prefer methods that implement a flow by calling other methods instead of one long monolithic implementation.

## Safe Working Summary

When in doubt, prefer:

- meaningful names
- explicit braces
- clear method flow
- one return
- no duplication
- tabs for indentation
- exact naming conventions
