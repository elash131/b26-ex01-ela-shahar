# Ex01_03 Dynamic Letter Tree Implementation Plan

> **For agentic workers:** REQUIRED: Use `.agent/skills/executing-plans/SKILL.md` to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build `Ex01_03` so it asks the user for a valid tree height from 4 to 15, then prints the dynamic tree by reusing the tree-building logic from `Ex01_02`.

**Architecture:** `Ex01_03` should not duplicate the tree algorithm. Instead, add a project reference to `Ex01_02`, validate the height in `Ex01_03`, and call the public tree builder already implemented there.

**Tech Stack:** C#, .NET Framework 4.7.2, Console app, Visual Studio for Windows

---

## File Structure

- Create: `Ex01_03/Ex01_03.csproj`
- Create: `Ex01_03/Program.cs`
- Create: `Ex01_03/DynamicTreeRunner.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`
- Modify: `Ex01_03/Ex01_03.csproj`

## Spec Notes To Honor

- Prompt the user for tree height.
- Valid range is `4` through `15`, inclusive.
- Invalid input must show an error and re-prompt.
- This project must reuse section 2 through a project reference.
- Mandatory screenshot examples are required for heights `4`, `8`, and `9`.

### Task 1: Create The Project And Reference

**Files:**
- Create: `Ex01_03/Ex01_03.csproj`
- Modify: `Ex01_03/Ex01_03.csproj`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

- [ ] Add project `Ex01_03` to the solution.
- [ ] Add a project reference from `Ex01_03` to `Ex01_02`.
- [ ] Confirm `Ex01_03` can build against the public builder from `Ex01_02`.
- [ ] Commit.

### Task 2: Implement Height Input Validation

**Files:**
- Create: `Ex01_03/DynamicTreeRunner.cs`
- Modify: `Ex01_03/Program.cs`

- [ ] Use `int.TryParse` for parsing the height.
- [ ] Reject non-numeric input.
- [ ] Reject values smaller than `4` or larger than `15`.
- [ ] Use a clear English validation message and re-prompt until valid.
- [ ] Keep `Program.Main()` minimal and delegate to the runner.
- [ ] Commit.

### Task 3: Reuse Ex01_02 Instead Of Copying

**Files:**
- Modify: `Ex01_03/DynamicTreeRunner.cs`

- [ ] Call the public tree builder from `Ex01_02` with the validated height.
- [ ] Print the returned tree exactly once.
- [ ] Do not copy the tree-generation code into `Ex01_03`.
- [ ] Confirm that heights `4`, `5`, `8`, and `9` match the PDF examples and the section-2 shape rules.
- [ ] Commit.

### Task 4: Manual Verification And Screenshots

**Files:**
- No new files

- [ ] Run the project with input `4` and capture a screenshot.
- [ ] Run the project with input `8` and capture a screenshot.
- [ ] Run the project with input `9` and capture a screenshot.
- [ ] Add all screenshots to `Ex01_ScreenShots.doc`.
- [ ] Commit.

## Done Criteria

- `Ex01_03` exists and builds.
- Input validation works for bad text and out-of-range values.
- The implementation reuses `Ex01_02` through a project reference.
- Required screenshots for `4`, `8`, and `9` exist in `Ex01_ScreenShots.doc`.
