# Ex01_02 Basic Letter Tree Implementation Plan

> **For agentic workers:** REQUIRED: Use `.agent/skills/executing-plans/SKILL.md` to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build `Ex01_02` so it prints the fixed beginner letter tree exactly as shown in the PDF.

**Architecture:** Create a reusable public tree builder in `Ex01_02` even though this section only needs the fixed shape. That keeps `Ex01_03` simple, because it can reference the compiled `Ex01_02` assembly instead of copying the tree logic.

**Tech Stack:** C#, .NET Framework 4.7.2, Console app, Visual Studio for Windows

---

## File Structure

- Create: `Ex01_02/Ex01_02.csproj`
- Create: `Ex01_02/Program.cs`
- Create: `Ex01_02/LetterTreeBuilder.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

## Spec Notes To Honor

- The output is a fixed tree, no user input.
- The left side includes printed row numbers.
- The canopy rows widen by letters in sequence.
- The trunk prints `|Z|` twice for the fixed example.
- Spacing matters, so compare against the PDF visually.
- Recursion is suggested only as an advanced bonus, not a hard requirement.

### Task 1: Create The Project

**Files:**
- Create: `Ex01_02/Ex01_02.csproj`
- Create: `Ex01_02/Program.cs`
- Modify: `Ex01 Ela 318481066 Shahar 207108846.slnx`

- [ ] Add a new project named `Ex01_02` to the solution.
- [ ] Keep `Program.Main()` minimal and delegate the output work.
- [ ] Confirm the project builds before adding real logic.
- [ ] Commit.

### Task 2: Build A Reusable Tree Generator

**Files:**
- Create: `Ex01_02/LetterTreeBuilder.cs`

- [ ] Add a public builder method such as `BuildTree(int i_Height)` that returns the full output text.
- [ ] Use `StringBuilder` to assemble the output text.
- [ ] Treat the tree height as total printed rows, including the two trunk lines.
- [ ] Make the canopy rows consume letters sequentially from `A` onward and continue cyclically after `Z`.
- [ ] Make the trunk use the last canopy letter wrapped as `|X|`.
- [ ] Keep the API public so `Ex01_03` can reuse it through a project reference.
- [ ] Commit.

### Task 3: Print The Fixed Section-2 Tree

**Files:**
- Modify: `Ex01_02/Program.cs`
- Modify: `Ex01_02/LetterTreeBuilder.cs`

- [ ] Call the builder with the fixed section-2 height.
- [ ] Match the exact tree shown in the PDF:
  - numbered rows
  - centered canopy
  - two trunk rows
  - no extra blank lines
- [ ] Compare visually with `page6.png`.
- [ ] Commit.

### Task 4: Final Manual Verification

**Files:**
- No new files

- [ ] Run the project with `Ex01_02` as startup project.
- [ ] Compare the entire console output against the PDF tree.
- [ ] Capture a screenshot and add it to `Ex01_ScreenShots.doc`.
- [ ] Commit.

## Done Criteria

- `Ex01_02` exists in the solution.
- The fixed beginner tree matches the PDF shape.
- The implementation exposes a reusable public builder for `Ex01_03`.
- A screenshot is saved in `Ex01_ScreenShots.doc`.
