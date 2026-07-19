# Learning ASP.NET Web API — Concepts & First Exercise
 
A study log covering the fundamentals of RESTful web services, Web APIs, and
Microservices, plus a hands-on walkthrough of the first Web API project.
 
---
 
## 1. RESTful Web Service, Web API & Microservice
 
### What is REST?
**REST (Representational State Transfer)** is an architectural style for
designing networked applications — not a protocol or a standard. It defines
a set of constraints:
 
- **Stateless** — each request from client to server must contain all the
  information needed to understand it. The server does not store client
  session state between requests.
- **Resource-based** — everything is a "resource" (e.g. a user, a product)
  identified by a URL, and you act on it using standard HTTP verbs rather
  than encoding the action in the URL itself.
- **Representational** — the client and server exchange *representations*
  of a resource (JSON, XML, plain text, etc.), not the resource itself.
- **Messages** — communication happens via self-descriptive HTTP messages
  (request/response pairs) that carry headers, a verb, and optionally a body.
### Web Service vs. Web API
| | Web Service | Web API |
|---|---|---|
| Protocol | Typically SOAP over HTTP | Any style — REST, or plain HTTP |
| Data format | Restricted to XML | **Not restricted to XML** — can return JSON, XML, plain text, etc. |
| Contract | Strict WSDL contract | Flexible, often self-documented via routes |
 
The key theoretical distinction from the syllabus: a **Web Service** is
traditionally SOAP-based and XML-only, while a **Web API** is a broader term
for any HTTP-based API and is *not restricted to sending XML as a response*.
 
### What is a Microservice?
A **microservice** is a small, independently deployable application that
handles one specific piece of business functionality. Microservices are
typically exposed to the outside world through a Web API — the API is the
*interface*, the microservice is the *application* behind it. A single
system may be composed of many microservices, each with its own Web API.
 
---
 
## 2. HttpRequest & HttpResponse
 
- **HttpRequest** — sent from client to server. Contains:
  - An HTTP verb (GET, POST, PUT, DELETE, etc.)
  - A URL / resource path
  - Headers (metadata like content type, authorization)
  - An optional body (payload, typically JSON)
- **HttpResponse** — sent from server back to client. Contains:
  - A status code (e.g. 200, 404, 500)
  - Headers
  - An optional body (the resource representation or error details)
---
 
## 3. Action Verbs
 
Web API relies on standard HTTP methods to indicate the *intent* of a request:
 
| Verb | Meaning | Typical Use |
|---|---|---|
| `HttpGet` | Retrieve a resource | Read data, no side effects |
| `HttpPost` | Create a new resource | Insert new data |
| `HttpPut` | Replace/update a resource | Full update of an existing resource |
| `HttpDelete` | Remove a resource | Delete existing data |
 
In a controller, these are declared either via **naming convention**
(a method named `Get...`, `Post...`, etc. is auto-mapped) or explicitly via
**attributes**, e.g.:
 
```csharp
[HttpGet]
public IEnumerable<string> GetAll() { ... }
 
[HttpPost]
public void Create([FromBody] string value) { ... }
```
 
Attributes are especially needed when a method name doesn't follow the verb
convention, or when you want to be explicit about intent.
 
---
 
## 4. HttpStatusCodes used in Web API
 
Status codes communicate the *result* of an action back to the client:
 
| Code | Name | Meaning |
|---|---|---|
| `200` | OK | Request succeeded |
| `400` | BadRequest | Client sent invalid data |
| `401` | Unauthorized | Client isn't authenticated |
| `500` | InternalServerError | Something failed on the server side |
 
In controller code, these map to helper methods:
 
```csharp
return Ok(data);              // 200
return BadRequest("Invalid"); // 400
return Unauthorized();        // 401
return InternalServerError(); // 500
```
 
---
 
## 5. Structure of a Web API
 
- A **Controller** class inherits from `ApiController` (classic .NET
  Framework) or `ControllerBase` (.NET Core).
- Each public method on the controller is an **Action**, mapped to a route
  and an HTTP verb.
- Routing determines which URL pattern maps to which controller + action.
```
Client Request
   ↓
Route (URL pattern) 
   ↓
Controller (inherits ApiController)
   ↓
Action Method (Get/Post/Put/Delete)
   ↓
HttpResponse (status code + body)
```
 
---
 
## 6. Configuration Files
 
### .NET Core (used in this project)
Modern ASP.NET Core uses the **minimal hosting model** — there is no
`Startup.cs` by default; everything lives in a single `Program.cs`.
 
| File | Purpose |
|---|---|
| `Program.cs` | Combines what used to be `Startup.cs`'s two methods into one file: **service registration** (dependency injection — e.g. `builder.Services.AddControllers()`) and the **middleware pipeline** (e.g. `app.UseHttpsRedirection()`, `app.MapControllers()`) |
| `appsettings.json` | Application-level configuration (connection strings, custom settings) — environment-independent defaults |
| `launchSettings.json` (under `Properties/`) | Local development launch profiles (URLs, ports, environment variables) — **not deployed to production** |
 
### .NET Framework 4.5 (older / classic style)
| File | Purpose |
|---|---|
| `WebApiConfig.cs` (under `App_Start`) | Registers Web API routes — the classic equivalent of a `WebAPI.config` |
| `RouteConfig.cs` (under `App_Start`) | Registers MVC-style routes |
| `Web.config` | Application-wide XML configuration (connection strings, app settings, system.web settings) |
 
> **Note:** This project uses .NET Core, since recent Visual Studio versions
> no longer offer .NET Framework 4.5 as a new-project target by default. The
> underlying REST/Web API concepts are identical — only the configuration
> plumbing differs (JSON + `Program.cs` instead of XML + `App_Start`).
 
---
 
## 7. Exercise 1 — First Web API using Visual Studio (.NET Core)
 
**Goal:** Create a .NET Core Web API project, inspect the scaffolded
controller, and confirm the default `GET` action returns the expected result.
 
### Steps
1. **File → New → Project → ASP.NET Core Web API**.
2. Keep **"Use controllers"** checked (so the project scaffolds a real
   `ApiController`-style class rather than Minimal APIs) and select the
   latest .NET target.
3. Visual Studio scaffolds:
   - `Controllers/WeatherForecastController.cs` — the API controller
   - `WeatherForecast.cs` — the data model returned by the controller
   - `Program.cs` — service + middleware configuration
   - `appsettings.json`, `Properties/launchSettings.json`
4. Press **F5** (or Ctrl+F5) to build and run.
5. Navigate directly to the GET endpoint in the browser:
```
   https://localhost:<port>/WeatherForecast
```
   (Port number is shown in the console output, e.g. `Now listening on:
   https://localhost:7174`.)

6. **Expected result:** a JSON array of 5 weather objects is returned,
   confirming the `GET` action executed correctly end-to-end (route →
   controller → action → response).
 
### Project Structure
```
FirstWebAPI/
├── Controllers/
│   └── WeatherForecastController.cs   → the API controller (inherits ControllerBase)
├── Properties/
│   └── launchSettings.json            → local dev launch profiles
├── appsettings.json                   → app configuration
├── Program.cs                         → DI + middleware pipeline setup
├── WeatherForecast.cs                 → data model (DTO)
└── FirstWebAPI.http                   → sample HTTP requests for testing
```
 
### Controller Code (`WeatherForecastController.cs`)
```csharp
using Microsoft.AspNetCore.Mvc;
 
namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];
 
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
```
 
Notice how this maps to the classic concepts:
- `[ApiController]` — marks this as a Web API controller
- `ControllerBase` — the Core equivalent of `ApiController` (inheritance
  mentioned in the objectives)
- `[HttpGet]` — the action verb attribute
- `Get()` — the action method
- `[Route("[controller]")]` — sets the route to the controller's name
  (`WeatherForecast`), so the endpoint becomes `/WeatherForecast`
### Data Model (`WeatherForecast.cs`)
```csharp
namespace FirstWebAPI
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}
```
This is just the DTO (Data Transfer Object) — the "shape" of what gets
serialized to JSON in the response. Not an action itself.
 
### `Program.cs` (minimal hosting model)
```csharp
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
 
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
 
app.Run();
```
- `AddControllers()` — registers controller support (dependency injection)
- `MapOpenApi()` — exposes the OpenAPI/Swagger JSON document in dev
  environments only
- `MapControllers()` — wires up the routes defined by `[Route]` /
  `[HttpGet]` attributes in controllers
- `app.Run()` — starts the app and begins listening for requests
### Actual Result
Hitting `https://localhost:7174/WeatherForecast` returned:
```json
[
  { "date": "2026-07-18", "temperatureC": 49, "temperatureF": 120, "summary": "Mild" },
  { "date": "2026-07-19", "temperatureC": -3, "temperatureF": 27, "summary": "Balmy" },
  { "date": "2026-07-20", "temperatureC": 37, "temperatureF": 98, "summary": "Sweltering" },
  { "date": "2026-07-21", "temperatureC": 49, "temperatureF": 120, "summary": "Bracing" },
  { "date": "2026-07-22", "temperatureC": -17, "temperatureF": 2, "summary": "Mild" }
]
```
This confirms the full REST request/response cycle worked end-to-end:
```
Client Request (GET /WeatherForecast)
   ↓
Routing → WeatherForecastController
   ↓
Get() action executes
   ↓
Returns 5 WeatherForecast objects
   ↓
Serialized to JSON → HttpResponse (200 OK)
```
 
> **Note on Swagger:** this template did not include Swagger/OpenAPI UI
> wiring by default (only the raw `AddOpenApi()`/`MapOpenApi()` JSON
> endpoint), so testing was done by hitting the controller route directly
> in the browser rather than through a Swagger UI page.