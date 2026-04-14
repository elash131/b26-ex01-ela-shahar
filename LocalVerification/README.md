# Local Verification

This folder is for local verification only. It is not part of the course solution structure.

## Ex01_01

Run:

```powershell
powershell -ExecutionPolicy Bypass -File .\LocalVerification\Run-Ex01_01-Verification.ps1
```

What it checks:

- full output matching for the 4 lecturer sample runs
- input validation for:
  - empty input
  - invalid length
  - invalid characters

If all tests pass, the script prints a pass summary and exits successfully.
