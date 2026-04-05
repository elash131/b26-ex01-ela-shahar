# Visual Studio Workflow

This is the lecturer-approved setup flow for course exercises.

## Approved Environment

- Use `Visual Studio for Windows`
- Build a blank solution first
- Then add the exercise projects into that solution

## Step 1: Create A Blank Solution

1. Open `Visual Studio`
2. Click `Create a new project`
3. Search for `solution`
4. Choose `Blank Solution`
5. Name the solution according to the submission instructions

The result should be an empty solution with no projects yet.

## Step 2: Add A Project To The Solution

1. Right-click the solution
2. Choose `Add`
3. Choose `New Project`
4. Choose the empty desktop C# project template shown in the lecturer guide
5. Use the .NET Framework version required by the exercise guide
6. Name the project according to the assignment instructions

## Step 3: Add The Main Class

- Add a class named `Program`
- This creates `Program.cs`
- Put the project code in the correct project folder

## Step 4: Repeat For All Exercise Parts

- Create one project per exercise part, according to the assignment structure
- Keep all projects inside the same solution

## Step 5: Set The Startup Project

To run a specific exercise part with `F5`:

1. Right-click the relevant project
2. Choose `Set as Startup Project`

## Expected Structure

The lecturer example shows a single solution containing multiple project folders, such as:

```text
Ex01_01/
Ex01_02/
Ex01_03/
Ex01_04/
Ex01_05/
```

## Working Rule

Before submission, confirm that:

- the solution opens correctly
- all expected projects exist
- each project is inside the solution
- the correct startup project can be selected

If Visual Studio for Windows cannot open the solution cleanly, the submission is not ready.
