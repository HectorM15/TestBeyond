namespace Domain.Entities;

public class TodoItem
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    private List<Progression> _progressions = new();
    public IReadOnlyCollection<Progression> Progressions => _progressions.AsReadOnly();
    public bool IsCompleted => TotalProgress() == 100;

    public TodoItem(int id, string title, string description, string category)
    {
        Id = id;
        Title = title;
        Description = description;
        Category = category;
    }

    public int TotalProgress() => _progressions.Sum(p => p.Percent);

    public void AddProgression(DateTime date, int percent)
    {
        if (_progressions.Count > 0 && date <= _progressions.Last().Date)
            throw new InvalidOperationException("La fecha debe ser mayor a la última registrada.");
        if (percent <= 0 || percent >= 100)
            throw new InvalidOperationException("El porcentaje debe estar entre 1 y 99.");
        if (TotalProgress() + percent > 100)
            throw new InvalidOperationException("El progreso total no puede superar 100%.");

        _progressions.Add(new Progression(date, percent));
    }

    public void Update(string title, string description, string category)
    {
        Title = title;
        Description = description;
        Category = category;
    }
}
