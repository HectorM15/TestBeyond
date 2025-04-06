namespace Domain.Interfaces;

public interface ITodoListRepository
{
    int GetNextId();
    bool IsValidCategory(string category);
}
