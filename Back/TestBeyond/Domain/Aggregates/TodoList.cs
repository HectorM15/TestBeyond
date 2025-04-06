using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Aggregates;

public class TodoList : ITodoList
{
    private readonly ITodoListRepository _repository;
    private readonly List<TodoItem> _items = new();

    public TodoList(ITodoListRepository repository)
    {
        _repository = repository;
    }

    public void AddItem(string title, string description, string category)
    {
        if (!_repository.IsValidCategory(category))
            throw new InvalidOperationException("Categoría inválida.");
        var id = _repository.GetNextId();
        _items.Add(new TodoItem(id, title, description, category));
    }

    public void UpdateItem(int id, string title, string description, string category)
    {
        var item = GetItem(id);
        if (item.TotalProgress() > 50)
            throw new InvalidOperationException("No se puede modificar un item con más del 50% completado.");
        if (!_repository.IsValidCategory(category))
            throw new InvalidOperationException("Categoría inválida.");
        item.Update(title, description, category);
    }

    public void RemoveItem(int id)
    {
        var item = GetItem(id);
        if (item.TotalProgress() > 50)
            throw new InvalidOperationException("No se puede eliminar un item con más del 50% completado.");
        _items.Remove(item);
    }

    public void RegisterProgression(int id, DateTime dateTime, int percent)
    {
        var item = GetItem(id);
        item.AddProgression(dateTime, percent);
    }

    public void PrintItems()
    {
        foreach (var item in _items.OrderBy(i => i.Id))
        {
            Console.WriteLine($"{item.Id}) {item.Title} - {item.Description} ({item.Category}) Completed:{item.IsCompleted}");
            int cumulative = 0;
            foreach (var prog in item.Progressions)
            {
                cumulative += prog.Percent;
                int blocks = cumulative / 2;
                string bar = new string('O', blocks).PadRight(50);
                Console.WriteLine($"{prog.Date.ToShortDateString()} - {cumulative}% |{bar}|");
            }
            Console.WriteLine();
        }
    }

    private TodoItem GetItem(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id)
            ?? throw new InvalidOperationException($"No existe un TodoItem con Id {id}");
    }
    public IReadOnlyCollection<TodoItem> GetAllItems()
    {
        return _items.OrderBy(x => x.Id).ToList();
    }
}
