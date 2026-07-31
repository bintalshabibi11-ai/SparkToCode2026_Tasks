namespace WebAPIProject.Models;

// This class represents the Category table in the database.
public class Category
{
    // This is the primary key for the Category table.
    public int CategoryId { get; set; }

    // This stores the category name.
    public string Name { get; set; } = string.Empty;
}