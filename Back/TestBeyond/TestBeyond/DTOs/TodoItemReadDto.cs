namespace TestBeyond.API.DTOs;

public class TodoItemReadDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsCompleted { get; set; }
    public List<ProgressionDto> Progressions { get; set; }
}
