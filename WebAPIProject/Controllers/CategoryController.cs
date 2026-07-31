using Microsoft.AspNetCore.Mvc;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers;

// Marks this class as an API Controller.
[ApiController]

// Sets the route to: /api/category
[Route("api/[controller]")] public class CategoryController : ControllerBase
{
    // Returns all categories from the database.
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Categories.ToList());
    }
   
    // Dependency injection to access the database.
    private readonly ProjectContext _context;

// Constructor receives the database context.
    public CategoryController(ProjectContext context)
    {
        _context = context;
    }
    // Creates a new category in the database.
    [HttpPost]
    public IActionResult Create(Category category)
    {
        // Adds the new category to the database context.
        _context.Categories.Add(category);

        // Saves the changes to the database.
        _context.SaveChanges();

        // Returns the created category.
        return Ok(category);
    }
    // Updates an existing category in the database.
    [HttpPut("{id}")]
    public IActionResult Update(int id, Category updatedCategory)
    {
        // Searches for the category using its id.
        Category? category = _context.Categories
            .FirstOrDefault(c => c.CategoryId == id);

        // Returns 404 Not Found if the category does not exist.
        if (category == null)
        {
            return NotFound("Category not found.");
        }

        // Updates the category name with the new value.
        category.Name = updatedCategory.Name;

        // Saves the updated data in the database.
        _context.SaveChanges();

        // Returns the updated category with status 200 OK.
        return Ok(category);
    }
    // Deletes a category from the database.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Searches for the category by its id.
        Category? category = _context.Categories
            .FirstOrDefault(c => c.CategoryId == id);

        // Returns 404 if the category does not exist.
        if (category == null)
        {
            return NotFound("Category not found.");
        }

        // Removes the category from the database.
        _context.Categories.Remove(category);

        // Saves the changes.
        _context.SaveChanges();

        // Returns a success message.
        return Ok("Category deleted successfully.");
    }
}

