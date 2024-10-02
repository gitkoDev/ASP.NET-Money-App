using System.Transactions;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IUserTransactionRepository _repository;
    public TransactionsController(IUserTransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        var transactions = await _repository.GetAllAsync(pageNumber, pageSize);
        var userTransactionDto = transactions.Select(s => s.ToUserTransactionDto());
        return Ok(userTransactionDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var transaction = await _repository.GetByIdAsync(id);
        if (transaction == null) 
        {
            return NotFound();
        }
        var userTransactionDto = new UserTransactionDto(){SenderId = transaction.SenderId, ReceiverId = transaction.ReceiverId, Amount = transaction.Amount};
        return Ok(userTransactionDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserTransactionDto addTransactionDto)
    {
        var receiver = await _repository.GetReceiverByIdAsync(addTransactionDto.ReceiverId);
        var sender = await _repository.GetSenderByIdAsync(addTransactionDto.SenderId);
        if (receiver is null || sender is null)
        {
            return BadRequest("Transaction sender and receiver have to be valid users");
        }

        if (receiver == sender)
        {
            return BadRequest("Transaction sender and receiver cannot be the same user");
        }

        if (sender.Salary - addTransactionDto.Amount < 0)
        {
            return BadRequest("Sender does not have enough funds for the transaction");
        }


        var transactionDto = new UserTransaction()
        {
            Sender = sender,
            Receiver = receiver,
            Amount = addTransactionDto.Amount
        };

        var result = await _repository.AddAsync(transactionDto);
        return CreatedAtAction(nameof(Add), new { id = transactionDto.Id}, result);
    }

}