<img width="1920" height="1080" alt="Screenshot (226)" src="https://github.com/user-attachments/assets/d1541aa6-1bdb-4c0e-b5bc-d1ced9ad1d0a" />
</br>
<img width="1920" height="1080" alt="Screenshot (227)" src="https://github.com/user-attachments/assets/ec357858-3388-480b-9589-dbba6fb3c847" />
</br>

VersionControl.API Documentation
Project Overview

VersionControl.API is a C# ASP.NET Core Web API project that manages Region data.
It supports two API versions:

v190925 → /api/v190925/Regions

v210926 → /api/v210926/Regions

The project uses a shared repository to handle CRUD operations for both versions.

Project Structure
Versions/
│
├── Models/
│   └── Domain/
│       └── Region.cs                 # Shared model for all API versions
│
├── Repositories/
│   ├── Interfaces/
│   │   └── IRegionRepository.cs      # Repository interface
│   └── RegionRepository.cs           # Repository implementation
│
├── Version190925.API/
│   └── Controllers/
│       └── RegionsController.cs      # Version 190925 API controller
│
├── Version210926.API/
│   └── Controllers/
│       └── RegionsController.cs      # Version 210926 API controller
│
└── Program.cs                         # Application entry point & DI configuration

Models
Region
public class Region
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Code { get; set; }
    public required string Name { get; set; }
}


Id → Unique identifier for the region

Code → Region code (required)

Name → Region name (required)

Repository
IRegionRepository
public interface IRegionRepository
{
    IEnumerable<Region> GetAll();
    Region? GetById(Guid id);
    void Create(Region region);
    void Update(Guid id, Region region);
    void Delete(Guid id);
}


Defines the CRUD operations for Region.

RegionRepository

Implements IRegionRepository

Stores data in memory using List<Region>

Used by both API versions.

Controllers

Both versions have similar controllers:

Version 190925 → /api/v190925/Regions

Version 210926 → /api/v210926/Regions

Endpoints
Method	Route	Description
GET	/api/v{version}/Regions	Get all regions
GET	/api/v{version}/Regions/{id}	Get region by Id
POST	/api/v{version}/Regions	Create a new region
PUT	/api/v{version}/Regions/{id}	Update existing region
DELETE	/api/v{version}/Regions/{id}	Delete region

Replace {version} with v190925 or v210926.

Dependency Injection

Repository is registered as a singleton in Program.cs:

builder.Services.AddSingleton<IRegionRepository, RegionRepository>();


Controllers receive the repository via constructor injection:

public RegionsController(IRegionRepository repository)
{
    _repository = repository;
}

Program.cs Configuration
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IRegionRepository, RegionRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


Adds controllers, Swagger, HTTPS, and maps controllers.

Swagger can be accessed at: https://localhost:{port}/swagger

Git Workflow

Stage changes:

git add -A


Commit changes:

git commit -m "Descriptive message here"


Pull remote changes before pushing:

git pull origin main --rebase


Push commits:

git push origin main

Usage

Run the API:

dotnet run


Test API using Swagger:

v190925 → https://localhost:{port}/swagger

v210926 → https://localhost:{port}/swagger

Example Request (cURL)

# Get all regions (v210926)
curl https://localhost:{port}/api/v210926/Regions

Notes

Shared repository allows both API versions to work on the same data.

Guid is used for Id to ensure unique identification.

Build folders (bin/, obj/) should be ignored in Git using .gitignore.
