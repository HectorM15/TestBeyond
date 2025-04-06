
using Domain.Aggregates;
using Domain.Interfaces;
using TestBeyond.Infrastructure;

ITodoList todoList = new TodoList(new InMemoryTodoListRepository());

todoList.AddItem("Complete Project Report", "Finish the final report for the project", "Work");
todoList.RegisterProgression(1, new DateTime(2025, 3, 18), 30);
todoList.RegisterProgression(1, new DateTime(2025, 3, 19), 50);
todoList.RegisterProgression(1, new DateTime(2025, 3, 20), 20);

todoList.PrintItems();
