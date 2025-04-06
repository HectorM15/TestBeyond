using Domain.Interfaces;
namespace TestBeyond.Infrastructure;

public class InMemoryTodoListRepository : ITodoListRepository
{
    private int _nextId = 1;
    private readonly HashSet<string> _validCategories = new() { "Work", "Personal", "Urgent" };

    public int GetNextId() => _nextId++;

    public bool IsValidCategory(string category) => _validCategories.Contains(category);
}
