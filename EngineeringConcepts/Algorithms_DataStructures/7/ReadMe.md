# Financial Forecasting — Recursive Future Value
 
Predicts future values from past growth rates using recursion, and
demonstrates why naive recursive branching can blow up in cost — and
how memoization fixes it.
 
## Recursion
 
A recursive method solves a problem by calling itself on a smaller
version of the same problem, until it hits a **base case** simple
enough to answer directly. Compound growth is a natural fit:
*"this year's value depends on last year's value"* is literally a
recursive definition — `FV(year) = FV(year - 1) * (1 + rate)`, with
`FV(0) = presentValue` as the base case.
 
## Features
 
- `CalculateFV()` — simple recursive compounding over a single
  historical growth rate per year.
- `NaiveBestFV()` — given **multiple possible growth-rate
  scenarios per year** (e.g. optimistic/pessimistic), recursively
  explores every combination to find the path with the highest final
  value. Written the straightforward way, with no reuse of work.
- `OptimizedBestFV()` — same logic, but **memoized**: each
  year's result is cached the first time it's computed and reused
  instead of recomputed.
- `Program.cs` — runs all three and times the naive vs. memoized
  versions against each other using `Stopwatch`.
## Build & Run
 
```bash
dotnet run
```
 
## Time Complexity
 
| Method                      | Complexity | Why |
|-------------------------------|------------|-----|
| `CalculateFV`        | O(n)       | One recursive call per year, no branching |
| `NaiveBestFV`        | O(k^n)     | k choices per year, branches into k new recursive calls at every level |
| `OptimizedBestFV`    | O(n·k)     | Each year's result computed once and cached; k choices evaluated per year |
 
n = number of years, k = number of scenarios per year.
 
## Why the naive version blows up
 
At year 0, trying scenario A recurses into the *entire remaining
subtree* for years 1..n. Trying scenario B at year 0 recurses into the
**identical** subtree again — the choice made at year 0 doesn't change
what the best outcome from year 1 onward looks like. This is a classic
case of **overlapping subproblems**: the same `year` state gets
recomputed from scratch by every branch that reaches it.
 
## Optimization: memoization
 
Since `MemoBestMultiplier(year)` only depends on `year` (not on the
path taken to reach it), its result is cached in an array the first
time it's computed. Every later call for that same year becomes an
O(1) lookup instead of a fresh recursive exploration. This is **top-down
dynamic programming** — same recursive structure, but each distinct
subproblem is solved exactly once.
 
A further step would be converting this into **bottom-up (iterative) DP**
— filling the array from year `n` down to `0` in a loop instead of
recursively. This avoids call-stack overhead and sidesteps C#'s
recursion depth limits for very large `n`.