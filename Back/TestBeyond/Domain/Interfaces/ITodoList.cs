using Domain.Entities;

namespace Domain.Interfaces;

public interface ITodoList
{
    void AddItem(string title, string description, string category);
    void UpdateItem(int id, string title, string description, string category);
    void RemoveItem(int id);
    void RegisterProgression(int id, DateTime dateTime, int percent);
    void PrintItems();
    public IReadOnlyCollection<TodoItem> GetAllItems();
    
}
