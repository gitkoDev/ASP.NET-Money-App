using System.Transactions;
using api.Data;
using api.Dtos;
using api.Interfaces;
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

    [HttpPost]
    public async Task<IActionResult> Add(AddUserTransactionDto addTransactionDto)
    {
        var receiver = await _repository.GetReceiverById(addTransactionDto.Receiver);
        var sender = await _repository.GetSenderById(addTransactionDto.Sender);
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