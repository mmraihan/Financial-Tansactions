using AutoMapper;
using FinTransact.TransactionAPI.Dtos.Transaction;
using FinTransact.TransactionAPI.Entities;
using FinTransact.TransactionAPI.ExceptionHandler.Model;
using FinTransact.TransactionAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTransact.TransactionAPI.Controllers
{
    public class TransactionController : BaseApiController
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionController(IGenericRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnTransactionDto>>> GetTransactions()
        {
            var transactions = await _transactionRepository.ListAllAsync();
            var transactionDtos = _mapper.Map<IEnumerable<ReturnTransactionDto>>(transactions);
            return Ok(transactionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTransactionDto>> GetTransaction(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var transactionDto = _mapper.Map<ReturnTransactionDto>(transaction);
            return Ok(transactionDto);
        }

        [HttpPost]
        public async Task<ActionResult<ReturnTransactionDto>> PostTransaction(AddTransactionDto addTransactionDto)
        {
            var transaction = _mapper.Map<Transaction>(addTransactionDto);
            var result = await _transactionRepository.AddAsync(transaction);

            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Unable to add the transaction."));
            }

            var returnTransactionDto = _mapper.Map<ReturnTransactionDto>(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = returnTransactionDto.Id }, returnTransactionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, UpdateTransactionDto updateTransactionDto)
        {
            if (id != updateTransactionDto.Id)
            {
                return BadRequest(new ApiResponse(400, "ID mismatch."));
            }

            var transaction = _mapper.Map<Transaction>(updateTransactionDto);
            var result = await _transactionRepository.UpdateAsync(transaction);

            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Unable to update the transaction."));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await _transactionRepository.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new ApiResponse(404, "Transaction not found."));
            }

            return NoContent();
        }
    }
}
