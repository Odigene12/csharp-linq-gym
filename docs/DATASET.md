# The dataset

Every test gets a fresh `SchoolData` (see `LinqGym/Data/SchoolData.cs`). Nothing you do in one exercise
leaks into another. This page is the printable reference; the class itself has the same values.

## Primitive collections

| Property | Type | Values | Handy facts |
|----------|------|--------|-------------|
| `Numbers` | `List<int>` | 5, 3, 8, 1, 9, 2, 8, 7, 3, 10 | sum 56, 8 distinct, evens 8 2 8 10, odds 5 3 1 9 7 3 |
| `Words` | `List<string>` | apple, Banana, cherry, apple, date, banana, Elderberry, fig, APPLE, grape | 9 distinct, 7 ignoring case, 55 chars |
| `Prices` | `List<decimal>` | 19.99, 5.49, 120.00, 42.50, 5.49, 0.99 | sum 194.46, avg 32.41 |
| `Temperatures` | `List<double>` | 72.5, 68.0, 75.2, 80.1, 66.4, 71.9, 78.3 | sum 512.4, avg 73.2 |
| `NullableScores` | `List<int?>` | 90, null, 85, null, 70, 100 | sum 345, avg 86.25 |
| `MixedBag` | `object?[]` | 1, "one", 2.5, null, 3, "three", 4L, true, 5, "five" | ints 1 3 5, strings one three five |
| `Matrix` | `List<int[]>` | [1,2,3], [4,5], [6,7,8,9] | 9 cells, sum 45 |
| `SetA` / `SetB` | `List<int>` | 1 2 3 4 5 5 / 4 5 6 7 7 | union 1..7, intersect 4 5 |
| `TagsA` / `TagsB` | `List<string>` | csharp LINQ dotnet / linq Dotnet azure | only match ignoring case |
| `Empty` | `List<int>` | (none) | |

## Students (20)

`Id, FirstName, LastName, Birthday, Active, City, Email, CohortId`. `Age` is computed against a fixed
`Clock.Today` of **2026-01-01**. First and last names are alphabetical A..T, so sorting by name gives Id order.

| Id | Name | Birthday | Age | Active | City | Email | Cohort |
|----|------|----------|-----|--------|------|-------|--------|
| 1 | Anne Appleton | 1978-02-04 | 47 | yes | Nashville | yes | 1 |
| 2 | Bobbie Bradshaw | 1988-07-14 | 37 | **no** | Nashville | null | 1 |
| 3 | Carrie Cooper | 1996-02-04 | 29 | yes | Memphis | yes | 1 |
| 4 | Derek Dickinson | 1984-09-29 | 41 | yes | Nashville | yes | 1 |
| 5 | Ethel Erikson | 1971-11-24 | 54 | yes | Knoxville | yes | 1 |
| 6 | Francis Foster | 1983-04-18 | 42 | yes | Memphis | yes | 2 |
| 7 | Gary Gaines | 1968-07-14 | 57 | yes | Chattanooga | null | 2 |
| 8 | Howard Harrison | 1973-08-24 | 52 | yes | Nashville | yes | 2 |
| 9 | Ingrid Ibanez | 1991-01-08 | 34 | yes | Knoxville | yes | 2 |
| 10 | Jacob Jiminez | 1984-05-26 | 41 | yes | Nashville | yes | 2 |
| 11 | Kate Kristov | 1987-08-13 | 38 | **no** | Memphis | yes | 3 |
| 12 | Louis Lancaster | 1978-03-24 | 47 | **no** | Nashville | null | 3 |
| 13 | Matt Michaelson | 1972-11-14 | 53 | yes | Chattanooga | yes | 3 |
| 14 | Nancy Newton | 1976-07-31 | 49 | yes | Nashville | yes | 3 |
| 15 | Ophelia Otterson | 1984-12-24 | 41 | yes | Knoxville | yes | 3 |
| 16 | Paul Pritchard | 1989-01-28 | 36 | yes | Memphis | yes | 4 |
| 17 | Quincy Queensland | 1958-08-03 | 67 | **no** | Nashville | null | 4 |
| 18 | Richard Ridley | 1948-10-31 | 77 | yes | Chattanooga | yes | 4 |
| 19 | Steve Southard | 1965-07-08 | 60 | yes | Nashville | yes | 4 |
| 20 | Terrence Thompson | 1989-10-19 | 36 | yes | Knoxville | yes | 4 |

Cities: Nashville 9, Memphis 4, Knoxville 4, Chattanooga 3. Inactive: 2, 11, 12, 17. No email: 2, 7, 12, 17.

## Instructors (6)

| Id | Name | Birthday | Active | Specialty |
|----|------|----------|--------|-----------|
| 1 | Kate Williams | 1987-08-13 | yes | C# |
| 2 | Jurnell Cockhren | 1983-10-05 | yes | JavaScript |
| 3 | Blaise Gratton | 1989-03-02 | yes | C# |
| 4 | Terry TerribleInstructor | 1975-09-02 | **no** | Java |
| 5 | Jason JavaFanBoy | 1986-06-16 | yes | Java |
| 6 | Zachary Zohan | **2298-01-01** | yes | Quantum |

Yes, Zachary was born in the future. He is useful for "birthday after today" and "max birthday" exercises.

## Cohorts (4)

| Id | Name | Active | FullTime | Start | Students | Primary | Juniors |
|----|------|--------|----------|-------|----------|---------|---------|
| 1 | Evening Five | yes | no | 2025-01-13 | 1-5 | 2 | 1, 3 |
| 2 | Cohort of the Future | no | yes | 2024-06-03 | 6-10 | 6 | 5, 4 |
| 3 | Evening Ninja Warriors | yes | no | 2025-03-10 | 11-15 | 3 | 4, 6, 1 |
| 4 | Day Backgammon Geeks | no | yes | 2024-09-02 | 16-20 | 1 | 5, 3 |

`Cohort.Students` holds the same `Student` instances as `Data.Students` (reference equality works).

## Courses (8)

| Id | Code | Title | Credits | Category | Instructor |
|----|------|-------|---------|----------|------------|
| 1 | CS101 | Intro to C# | 3 | Backend | 1 |
| 2 | CS201 | Advanced C# | 4 | Backend | 3 |
| 3 | JS101 | JavaScript Basics | 3 | Frontend | 2 |
| 4 | JS201 | React Fundamentals | 5 | Frontend | 2 |
| 5 | DB101 | SQL & Databases | 3 | Data | 5 |
| 6 | DB201 | Entity Framework | 4 | Data | 1 |
| 7 | QC999 | Quantum Computing | 5 | Research | 6 |
| 8 | SE100 | Software Ethics | 2 | General | **null** |

Credits per category: Backend 7, Frontend 8, Data 7, Research 5, General 2 (total 29).

## Enrollments (32)

`Id, StudentId, CourseId, Grade (null = in progress), EnrolledOn`.

| Course | Students (grade) | Count | Avg |
|--------|------------------|-------|-----|
| 1 CS101 | 1 (92), 3 (88), 4 (74), 7 (59), 8 (83), 11 (65), 16 (96), 10 (80) | 8 | 79.625 |
| 2 CS201 | 1 (85), 4 (null), 13 (89), 16 (91) | 4 | 88.33 |
| 3 JS101 | 3 (95), 6 (67), 9 (91), 14 (70), 20 (79) | 5 | 80.4 |
| 4 JS201 | 6 (72), 9 (94), 14 (null), 20 (86) | 4 | 84 |
| 5 DB101 | 1 (78), 5 (81), 10 (77), 15 (84), 19 (62) | 5 | 76.4 |
| 6 DB201 | 5 (90), 8 (88), 13 (null), 19 (71) | 4 | 83 |
| 7 QC999 | (none) | 0 | - |
| 8 SE100 | 9 (100), 18 (88) | 2 | 94 |

Students with no enrollments: 2, 12, 17. Three in-progress enrollments (ids 7, 21, 23). 29 graded, sum 2375,
overall average 81.90, highest 100 (Ingrid, SE100), lowest 59 (Gary, CS101). 17 enrollments in 2024, 15 in 2025.

## Helpers

- `Data.Student(id)`, `Data.Instructor(id)`, `Data.Cohort(id)`, `Data.Course(id)` - plain indexers, allowed in answers.
- `Clock.Today` = 2026-01-01; `Person.Age` and `Person.FullName` are computed properties.
- `PersonIdComparer.Instance` - an `IEqualityComparer<Person>` that compares by Id.
- `LinqAssert.SameItems(expected, actual)` - order-insensitive equality used by a few tests.
- `StudentSummary` and `CourseStats` - records (value equality) used as projection targets.
