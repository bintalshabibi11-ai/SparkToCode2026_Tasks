using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPIProject;

// Creates the Web API application builder.
// The builder is used to register services before the app starts.
var builder = WebApplication.CreateBuilder(args);

// Registers ProjectContext inside the dependency injection container.
// It connects Entity Framework Core to SQL Server using the connection
// string named "DefaultConnection" from appsettings.json.
builder.Services.AddDbContext<ProjectContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Registers controller support in the Web API project.
// This allows ASP.NET Core to discover and run controller classes.
builder.Services.AddControllers();

// Allows Swagger to discover the API endpoints.
builder.Services.AddEndpointsApiExplorer();

// Generates the Swagger documentation and interface.
builder.Services.AddSwaggerGen(c =>
{
    // Adds the JWT Bearer authentication option to Swagger.
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // The header name that carries the token.
        Name = "Authorization",

        // Specifies that Bearer authentication uses HTTP.
        Type = SecuritySchemeType.Http,

        // Sets the authentication scheme to Bearer.
        Scheme = "bearer",

        // Explains that the token format is JWT.
        BearerFormat = "JWT",

        // Sends the token inside the request header.
        In = ParameterLocation.Header,

        // Instructions displayed in the Swagger Authorize box.
        Description = "Enter your JWT token in the box below"
    });

    // Applies the Bearer authentication definition to API requests.
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                // Connects this requirement to the Bearer definition above.
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },

            // No specific scopes are required for this authentication.
            new List<string>()
        }
    });
});

// Builds the application after all services have been registered.
var app = builder.Build();

// Enables Swagger to generate the API documentation.
app.UseSwagger();

// Enables the Swagger user interface in the browser.
app.UseSwaggerUI();

// Redirects HTTP requests to HTTPS when HTTPS is available.
app.UseHttpsRedirection();

// Maps requests to the actions inside the controller classes.
app.MapControllers();

// Starts the Web API application.
app.Run();
