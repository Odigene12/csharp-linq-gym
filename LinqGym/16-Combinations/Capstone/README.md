# Capstone

| | |
|---|---|
| Module | 16 - Combinations |
| Exercises | 18, in two files |

Everything together. `ReportsExercises.cs` asks for the kind of summaries a real application produces
(per-cohort statistics, instructor workload, grade distributions, leaderboards). `ChallengesExercises.cs`
is algorithmic: longest runs, anagram groups, pivots, pairs summing to a target, running averages,
transposition, medians.

There is no single right answer. A capstone may take one long chain or a few named intermediate
queries; method syntax or query syntax; `GroupBy` or `AggregateBy`. Aim for the version you could
explain line by line to a colleague.

When you finish, try each one again from a blank `TODO` a week later. If the shape of the solution
comes to you before you start typing, you are done with this repo.

```bash
dotnet test --filter "FullyQualifiedName~ReportsExercises|FullyQualifiedName~ChallengesExercises"
```

<!-- exercises:start -->
**ChallengesExercises.cs**

| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Capstone | `Challenge_01_LongestIncreasingRun` | the length of the longest run of strictly increasing consecutive values in Data.Numbers (5 \| 3 8 \| 1 9 \| 2 8 \| 7 \| 3 10 -> 2). Hint: Aggregate with a (Best, Current, Previous) tuple. |
| 2 | Capstone | `Challenge_02_AnagramGroups` | group `words` into anagram groups (same letters, any order) and return the groups that have more than one word. |
| 3 | Capstone | `Challenge_03_TopTwoWordsIgnoringCase` | the two most frequent words in Data.Words ignoring case, as (lowercase word, count), most frequent first. |
| 4 | Capstone | `Challenge_04_Pivot` | a nested dictionary City -> (Active -> count), e.g. result["Nashville"][true] == 6. |
| 5 | Capstone | `Challenge_05_PairsThatSumToTen` | every pair of DISTINCT values from Data.Numbers (each pair once, in first-seen order) whose sum is 10. Hint: Distinct, then SelectMany with the index overload so the inner sequence starts after the outer element. |
| 6 | Capstone | `Challenge_06_RunningAverage` | the running average of Data.Temperatures (average of the first 1, first 2, first 3, ... readings). |
| 7 | Capstone | `Challenge_07_TransposeAMatrix` | transpose a 2x3 matrix into a 3x2 one: [[1,2,3],[4,5,6]] -> [[1,4],[2,5],[3,6]]. |
| 8 | Capstone | `Challenge_08_ValuesThatAppearMoreThanOnce` | the values that occur more than once in Data.Numbers, ascending. |
| 9 | Capstone | `Challenge_09_FormatAHierarchy` | for cohort 1 the string "Primary: Jurnell Cockhren; Juniors: Kate Williams, Blaise Gratton". |
| 10 | Capstone | `Challenge_10_MedianGrade` | the median of all non-null grades (29 values -> the 15th smallest). |

**ReportsExercises.cs**

| # | Level | Exercise | Task |
|---|-------|----------|------|
| 1 | Capstone | `Report_01_CohortSummary` | for each cohort: (Name, ActiveStudents, AverageAge). |
| 2 | Capstone | `Report_02_CourseSummary` | for each course, a CourseStats(Code, EnrollmentCount, AverageGrade) where AverageGrade is over graded enrollments only and 0 when there are none. Keep course order. |
| 3 | Capstone | `Report_03_InstructorWorkload` | for each instructor: (FullName, CourseCount, DistinctStudentCount across their courses), ordered by DistinctStudentCount descending, then FullName ascending. |
| 4 | Capstone | `Report_04_CityLeaderboard` | (City, StudentCount, ActiveRate) per city, ordered by ActiveRate descending then City ascending. ActiveRate = active students / all students in that city, as a double. |
| 5 | Capstone | `Report_05_TopThreeStudentsByAverageGrade` | the first names of the three students with the highest average Grade, counting only students with at least TWO graded enrollments. |
| 6 | Capstone | `Report_06_StudentsWhoTookEveryBackendCourse` | first names of students enrolled in ALL courses of the "Backend" category. |
| 7 | Capstone | `Report_07_GradeDistribution` | how many graded enrollments fall in each band: "A" (90+), "B" (80-89), "C" (70-79), "F" (below 70), ordered by band. |
| 8 | Capstone | `Report_08_BirthdayCalendar` | (Month, number of students born that month) for every month that has at least one student, ordered by month. |
<!-- exercises:end -->
