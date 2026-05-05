namespace StructuralPatternsDemo.Flyweight;

// Intent: Share common object data to reduce memory usage when many similar objects are created.

public sealed class ProductCategory
{
    public ProductCategory(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }

    public void DisplayProduct(string productName, decimal price)
    {
        Console.WriteLine($"{productName} | Category: {Name} | Price: ${price}");
    }
}

public sealed class ProductCategoryFactory
{
    private readonly Dictionary<string, ProductCategory> _categories = [];

    public ProductCategory GetCategory(string name, string description)
    {
        if (!_categories.TryGetValue(name, out ProductCategory? category))
        {
            category = new ProductCategory(name, description);
            _categories[name] = category;

            Console.WriteLine($"Created new shared category: {name}");
        }

        return category;
    }

    public int TotalCategoriesCreated => _categories.Count;
}

public sealed class Product
{
    private readonly ProductCategory _category;

    public Product(string name, decimal price, ProductCategory category)
    {
        Name = name;
        Price = price;
        _category = category;
    }

    public string Name { get; }
    public decimal Price { get; }

    public void Display()
    {
        _category.DisplayProduct(Name, Price);
    }
}

public static class FlyweightDemo
{
    public static void Run()
    {
        var factory = new ProductCategoryFactory();

        var laptopCategory = factory.GetCategory("Electronics", "Electronic devices");
        var phoneCategory = factory.GetCategory("Electronics", "Electronic devices");
        var bookCategory = factory.GetCategory("Books", "Printed and digital books");

        var products = new List<Product>
        {
            new("Laptop", 1200, laptopCategory),
            new("Phone", 800, phoneCategory),
            new("C# Design Patterns Book", 45, bookCategory)
        };

        foreach (Product product in products)
        {
            product.Display();
        }

        Console.WriteLine($"Total shared categories created: {factory.TotalCategoriesCreated}");
    }
}