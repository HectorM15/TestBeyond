using Microsoft.AspNetCore.Mvc;
using TestBeyond.API.DTOs;
using Domain.Interfaces;
using AutoMapper;

namespace TestBeyond.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoListController : ControllerBase
{
    private readonly ITodoList _todoList;
    private readonly IMapper _mapper;

    public TodoListController(ITodoList todoList, IMapper mapper)
    {
        _todoList = todoList;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddItem([FromBody] TodoItemDto dto)
    {
        try
        {
            _todoList.AddItem(dto.Title, dto.Description, dto.Category);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/progression")]
    public IActionResult RegisterProgression(int id, [FromBody] ProgressionDto dto)
    {
        try
        {
            _todoList.RegisterProgression(id, dto.Date, dto.Percent);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, [FromBody] TodoItemDto dto)
    {
        try
        {
            _todoList.UpdateItem(id, dto.Title, dto.Description, dto.Category);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveItem(int id)
    {
        try
        {
            _todoList.RemoveItem(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _todoList.GetAllItems();
        var result = items.Select(_mapper.Map<TodoItemReadDto>);
        return Ok(result);
    }
}
