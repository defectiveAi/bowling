**Project Summary**

* The project was scaffolded using Aspire, providing the **AppHost**, **Web**, **ServiceDefaults** and **ApiService** projects as a starting point. These were not made by me.
* Based on Clean Architecture layers, I added three new projects: **Application**, **Domain**, and **Infrastructure**.
  * The **Application** layer has handlers following CQS, with two queries and two commands currently implemented.
  * The **Domain** project is designed with DDD. The aggregate root is the `BowlingGame`, which consists of `Players`. Each player has a `Scorecard` to track their progress, with individual `Frames` representing a set of `Rolls`.
  * A domain service is implemented to interpret a `Scorecard`'s rolls into a player's score.
  * The **Repository** pattern is used, with a basic in-memory implementation in Infrastructure.
  * I have never used Blazor before, so there code there "just good enough".

**How to Run:**
1) Install .net 9 SDK.
2) Run:

```
cd BowlingConcept.AppHost
dotnet run
```

3) The console should print a URL that can be navigated to, e.g. `https://localhost:17177`.
4) On the Resources page, find `webfrontend` and navigate to URL, e.g. `https://localhost:7104`

<img width="697" alt="image" src="https://github.com/user-attachments/assets/c55b9ab0-8543-4b8f-be08-9e58f4df6d9d" />
