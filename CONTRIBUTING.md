# Contributing

Thanks for helping make the gym better. The most useful contributions are new exercises, sharper
explanations in a README, and corrections to anything that is wrong.

If you use Claude Code or another coding agent in this repo, `CLAUDE.md` states the same rules in the
form an agent needs; keep the two in step when the workflow changes.

## Branch model

- **`main`** holds the exercises with `TODO` placeholders. Every test on `main` fails by design.
- **`solutions`** holds the same files with a reference answer in every `TODO` slot. Every test on `solutions` passes.

`main` is *generated* from `solutions`. Never edit an `*Exercises.cs` file directly on `main`.

## Adding or changing an exercise

1. Check out `solutions`.
2. Edit the `*Exercises.cs` file. Write the answer inline, marked so the generator can strip it:

   ```csharp
   IEnumerable<int> result = Data.Numbers.Where(n => n > 2); //!      // single line
   
   IEnumerable<int> result = //!{                                       // multi-line
       Data.Numbers
           .Where(n => n > 2);
   //!}
   ```

   Keep the `// Task:` comment right after the method signature - the README table is built from it.
3. Run `dotnet test` - everything must pass.
4. Run `powershell -File tools/Update-ReadmeTables.ps1` to refresh the exercise tables in the READMEs.
5. Commit to `solutions`.
6. Regenerate `main`:

   ```bash
   git checkout main
   git checkout solutions -- .
   powershell -File tools/Make-StudentVersion.ps1
   dotnet build
   git commit -am "Sync from solutions"
   ```

   `git checkout solutions -- .` copies every tracked file, so a change to `tools/`, `docs/` or the
   workflow cannot be left behind; the generator then strips the answers back out. It does not propagate
   *deletions*, so if you removed a file on `solutions`, delete it on `main` by hand. CI on `main` fails
   if any `//!` marker survives or if a test does something other than throw `NotImplementedException`.

## Conventions

- One folder per method: `README.md` + `<Method>Exercises.cs`, namespace `LinqGym.<Category>`.
- Test names: `Easy_01_...`, `Medium_04_...`, `Hard_08_...` - the number continues across levels so the test explorer sorts them.
- 7 exercises for a method (3 easy / 2 medium / 2 hard) or 10 for a heavily used one (3 / 4 / 3).
- Every exercise: a `// Task:` comment, one or more `TODO` slots with an explicit result type, then assertions.
- Prefer assertions on Ids, names or small literal arrays over assertions that re-derive the answer with LINQ.
- Data lives in `LinqGym/Data/SchoolData.cs`; changing it affects hundreds of expected values, so add to it rather than altering it.
- ASCII only in source files.

## Reporting a wrong expected value

Open an issue with the test name and what you believe the correct value is. The `solutions` branch is
the source of truth: if its test passes, the expected value matches the reference solution, and the
discussion is about whether the *task description* is clear.
