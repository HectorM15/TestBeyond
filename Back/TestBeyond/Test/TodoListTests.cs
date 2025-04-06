
using Domain.Aggregates;
using System;
using TestBeyond.Infrastructure;
using Xunit;

namespace TestBeyond.Tests;

public class TodoListTests
{
    [Fact]
    public void CanAddItemAndPrint()
    {
        var repo = new InMemoryTodoListRepository();
        var todoList = new TodoList(repo);

        todoList.AddItem("Task 1", "Description 1", "Work");

        var ex = Record.Exception(() => todoList.PrintItems());

        Assert.Null(ex); 
    }

    [Fact]
    public void CanRegisterValidProgression()
    {
        var repo = new InMemoryTodoListRepository();
        var todoList = new TodoList(repo);

        todoList.AddItem("Task 2", "Description 2", "Work");
        todoList.RegisterProgression(1, DateTime.Today, 30);

        var ex = Record.Exception(() => todoList.RegisterProgression(1, DateTime.Today.AddDays(1), 50));
        Assert.Null(ex); 
    }

    [Fact]
    public void ThrowsWhenProgressionDateIsNotIncreasing()
    {
        var repo = new InMemoryTodoListRepository();
        var todoList = new TodoList(repo);

        todoList.AddItem("Task 3", "Description 3", "Work");
        todoList.RegisterProgression(1, DateTime.Today, 30);

        var ex = Assert.Throws<InvalidOperationException>(() =>
            todoList.RegisterProgression(1, DateTime.Today, 10));

        Assert.Contains("fecha debe ser mayor", ex.Message);
    }

    [Fact]
    public void ThrowsWhenProgressionExceeds100Percent()
    {
        var repo = new InMemoryTodoListRepository();
        var todoList = new TodoList(repo);

        todoList.AddItem("Task 4", "Description 4", "Work");
        todoList.RegisterProgression(1, DateTime.Today, 90);

        var ex = Assert.Throws<InvalidOperationException>(() =>
            todoList.RegisterProgression(1, DateTime.Today.AddDays(1), 20));

        Assert.Contains("no puede superar", ex.Message);
    }

    [Fact]
    public void CannotUpdateItemWithMoreThan50Percent()
    {
        var repo = new InMemoryTodoListRepository();
        var todoList = new TodoList(repo);

        todoList.AddItem("Task 5", "Description 5", "Work");
        todoList.RegisterProgression(1, DateTime.Today, 60);

        var ex = Assert.Throws<InvalidOperationException>(() =>
            todoList.UpdateItem(1, "New Title", "New Description", "Work"));

        Assert.Contains("No se puede modificar", ex.Message);
    }

    [Fact]
    public void CannotRemoveItemWithMoreThan50Percent()
    {
        var repo = new InMemoryTodoListRepository();
        var todoList = new TodoList(repo);

        todoList.AddItem("Task 6", "Description 6", "Work");
        todoList.RegisterProgression(1, DateTime.Today, 60);

        var ex = Assert.Throws<InvalidOperationException>(() => todoList.RemoveItem(1));

        Assert.Contains("No se puede eliminar", ex.Message);
    }
}
