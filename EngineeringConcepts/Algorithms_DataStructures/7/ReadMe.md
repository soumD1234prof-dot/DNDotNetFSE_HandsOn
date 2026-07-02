# Financial Forecasting — Recursive Future Value
 
## Recursion
 
A recursive function solves a problem by calling itself on a smaller
version of the same problem, until it hits a **base case** simple enough
to answer directly. Compound growth is a natural fit: *"this year's value
depends on last year's value"* is a recursive definition —
`FV(year) = FV(year - 1) * (1 + rate)`, with `FV(0) = presentValue` as
the base case. Recursion lets the code mirror that definition almost
exactly, instead of manually tracking a running total in a loop.
 
## Implementation
 
- `calculateFutureValue()` — simple recursive compounding over a single
  historical growth rate per year.
- `naiveBestFutureValue()` — given **multiple possible growth-rate
  scenarios per year** (e.g. optimistic/pessimistic), recursively
  explores every combination to find the path with the highest final
  value. Written the straightforward way, with no reuse of work.
- `optimizedBestFutureValue()` — the same logic, but **memoized**: results
  for a given year are cached the first time they're computed and reused
  instead of recomputed.
- `main.cpp` — runs all three and times the naive vs. memoized versions
  against each other.
## Build & Run
 
```bash
g++ -O2 FinancialForecast.cpp main.cpp -o forecast_demo
./forecast_demo
```
 
## Time Complexity
 
| Function                     | Complexity | Reason |
|------------------------------|------------|--------|
| `calculateFutureValue`       | O(n)       | One recursive call per year, no branching |
| `naiveBestFutureValue`       | O(k^n)     | k choices per year, branches into k new recursive calls at every level |
| `optimizedBestFutureValue`   | O(n·k)     | Each year's result computed once and cached; k choices evaluated per year |
 
n = number of years, k = number of scenarios per year.
 
Measured with n = 24, k = 2: naive recursion took **~93 ms**, memoized
took **~0.01 ms** — and the gap widens exponentially with each additional
year (at n = 34 the naive version would take on the order of minutes).
 
## Why the naive version blows up
 
At year 0, trying scenario A recurses into the *entire remaining
subtree* for years 1..n. Trying scenario B at year 0 recurses into the
**identical** subtree again — the choice made at year 0 doesn't change
what the best outcome from year 1 onward looks like. This is a classic
case of **overlapping subproblems**: the same `(year)` state gets
recomputed from scratch by every branch that reaches it.
 
## Optimization: memoization
 
Since `bestMultiplier(year)` only depends on `year` (not on the path
taken to reach it), its result can be cached in an array the first time
it's computed. Every later call for that same year becomes an O(1)
lookup instead of a fresh recursive exploration. This is **top-down
dynamic programming** — same recursive structure, but each distinct
subproblem is solved exactly once.
 
A further optimization would be converting this into a **bottom-up
(iterative) DP**, filling the array from year `n` down to `0` in a loop
instead of recursively. This avoids call-stack overhead entirely and
sidesteps stack-depth limits for very large `n` — worth doing if the
forecasting horizon could realistically grow very large (e.g. daily
compounding over decades).