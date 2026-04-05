# Submission Rules

This document captures the lecturer submission rules in plain English.

## Submission Channels

- Main submission channel: the course Google Form
- Course email for issues and exercise-related communication: `DN.COURSE.MTA@gmail.com`

## Teaming Rule

- Follow the course submission mode exactly as instructed.
- The submission rules document states that exercises are submitted in pairs unless staff explicitly approves otherwise.
- Do not assume solo work, triple work, or any other team size is allowed without explicit approval.

## Core Submission Expectations

- Follow the coding standards document.
- Keep names, formatting, folder names, and code organization clean and consistent.
- Do not leave unused code in the submission.
- Before submitting, verify the solution opens properly in `Visual Studio for Windows`.
- The lecturer and TAs do not support other IDEs/editors as the official submission environment.

## Generated Folders You Must Remove Before Submission

Delete these folders before creating the final zip:

- `bin`
- `obj`
- `.git`
- `packages`

The final zip should not contain generated binaries or unnecessary build artifacts.

## Exact Naming Rules

### Solution name

Use this exact format:

```text
Ex0X FirstStudentFirstName <StudentID> SecondStudentFirstName <StudentID>.sln
```

Example:

```text
Ex01 Yoav 011112222 Adi 033334444.sln
```

Rules:

- Use spaces
- Do not use hyphens, underscores, commas, or other separators

### Project name

Use this exact format:

```text
B26 Ex0X FirstStudentFullName <StudentID> SecondStudentFullName <StudentID>
```

Example:

```text
B26 Ex01 YoavBenGal 011112222 AdiCohen 033334444
```

Rules:

- Use spaces
- Do not use hyphens, underscores, commas, or other separators

### Zip file

- Compress the solution as a `.zip`
- The zip name should match the required top-level submission name
- The zip should contain a top-level folder with the same base name

## Expected Zip Structure

The zip should contain:

1. A top-level folder named exactly like the submission
2. The `.sln` file
3. The screenshot/document file if required by the exercise
4. All exercise project folders

Example structure:

```text
B26 Ex01 GuyRonen 012345678 AvivLevi 987654321.zip
└── B26 Ex01 GuyRonen 012345678 AvivLevi 987654321/
    ├── Ex01_Screenshots.docx
    ├── Ex01 Guy 012345678 Aviv 987654321.sln
    ├── Ex01_01/
    ├── Ex01_02/
    ├── Ex01_03/
    ├── Ex01_04/
    └── Ex01_05/
```

## Google Form And Email Workflow

- Submit through the Google Form by the submission deadline.
- If the form cannot be used, send the zip by email.
- If you do not receive the form confirmation email, contact the course email.

## Email Subject Formats

Use the exact subject prefix:

### Regular submission

```text
SUBMIT DN MTA B26 Ex01 YoavBenGal 011112222 AdiCohen 033334444
```

### Question about an exercise

```text
QUESTION DN MTA B26 Ex01 YoavBenGal 011112222 AdiCohen 033334444
```

### Recheck request

```text
RECHECK DN MTA B26 Ex01 YoavBenGal 011112222 AdiCohen 033334444
```

## Required Email Body For Manual Submission

When emailing a submission, include an exercise checking report with fields like:

- Exercise No
- First Student Details
- Second Student Details
- Delivery Date
- Delivered In Delay: `Yes (X days)` or `No`
- Delay Reason
- Visual Studio Version
- Comments

## Late Submission

- The submission instructions mention late-submission handling and penalties.
- The document indicates a default penalty of `2 points per late day` unless the exercise states otherwise.
- Do not rely on late submission being accepted automatically.

## After The Exercise Is Checked

- The checked work may include reviewer comments inside the code files.
- Search for the marker `$G$` to find the reviewer comments quickly.
- Those comments explain deductions and the relevant checked section.
- Use the exact `QUESTION DN MTA ...` or `RECHECK DN MTA ...` subject format for follow-up mail.

## Final Pre-Submission Checklist

- Solution opens in `Visual Studio for Windows`
- Naming format is exact
- Only spaces used in names where required
- No `bin`, `obj`, `.git`, or `packages`
- No unnecessary binaries in the zip
- Zip structure is correct
- Correct Google Form submission or email fallback
- Correct email subject if emailing
