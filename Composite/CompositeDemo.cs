namespace StructuralPatternsDemo.Composite;

// Intent: Compose objects into tree structures and treat individual objects and groups uniformly.

public interface IFileSystemItem
{
    string Name { get; }
    int GetSize();
    void Display(string indent = "");
}

public sealed class FileItem : IFileSystemItem
{
    private readonly int _size;

    public FileItem(string name, int size)
    {
        Name = name;
        _size = size;
    }

    public string Name { get; }

    public int GetSize() => _size;

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}- File: {Name}, Size: {_size} KB");
    }
}

public sealed class FolderItem : IFileSystemItem
{
    private readonly List<IFileSystemItem> _items = [];

    public FolderItem(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Add(IFileSystemItem item)
    {
        _items.Add(item);
    }

    public int GetSize()
    {
        return _items.Sum(item => item.GetSize());
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}+ Folder: {Name}, Total Size: {GetSize()} KB");

        foreach (IFileSystemItem item in _items)
        {
            item.Display(indent + "  ");
        }
    }
}

public static class CompositeDemo
{
    public static void Run()
    {
        var root = new FolderItem("Root");

        var documents = new FolderItem("Documents");
        documents.Add(new FileItem("Resume.pdf", 500));
        documents.Add(new FileItem("DesignPatterns.docx", 800));

        var pictures = new FolderItem("Pictures");
        pictures.Add(new FileItem("photo1.png", 1200));
        pictures.Add(new FileItem("photo2.png", 1500));

        root.Add(documents);
        root.Add(pictures);

        root.Display();
    }
}