using AutoMapper;
using FinTransact.TransactionAPI.Dtos.Transaction;
using FinTransact.TransactionAPI.Entities;
using FinTransact.TransactionAPI.ExceptionHandler.Model;
using FinTransact.TransactionAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinTransact.TransactionAPI.Controllers
{
    public class TransactionController : BaseApiController
    {
        private readonly IGenericRepository<Transaction> _genericTransactionRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionController(IGenericRepository<Transaction> genericTransactionRepository,  ITransactionRepository transactionRepository, IMapper mapper)
        {
            _genericTransactionRepository = genericTransactionRepository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        [HttpGet("get-all-transactions")]
        public async Task<ActionResult<IEnumerable<ReturnTransactionDto>>> GetTransactions()
        {
            var transactions = await _transactionRepository.GetTransactionListWithAssociteData();
            return Ok(transactions);
        }

        [HttpGet("get-transaction/{id}")]
        public async Task<ActionResult<ReturnTransactionDto>> GetTransactionById(int id)
        {
            var transaction = await _transactionRepository.GetTransactionByIdWithAssociateData(id);
            if (transaction == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(transaction);
        }

        [HttpPost("add-transaction")]
        public async Task<ActionResult<ReturnTransactionDto>> AddTransaction(AddTransactionDto addTransactionDto)
        {
            var transaction = _mapper.Map<Transaction>(addTransactionDto);
            var result = await _genericTransactionRepository.AddAsync(transaction);

            if (!result)
            {
                return BadRequest(new ApiResponse(400));
            }

            var returnTransactionDto = _mapper.Map<ReturnTransactionDto>(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = returnTransactionDto.Id }, returnTransactionDto);
        }

        [HttpPut("update-transaction/{id}")]
        public async Task<IActionResult> PutTransaction(int id, UpdateTransactionDto updateTransactionDto)
        {
            if (id != updateTransactionDto.Id)
            {
                return BadRequest(new ApiResponse(400));
            }

            var transaction = _mapper.Map<Transaction>(updateTransactionDto);
            var result = await _genericTransactionRepository.UpdateAsync(transaction);

            if (!result)
            {
                return BadRequest(new ApiResponse(400));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await _genericTransactionRepository.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new ApiResponse(404));
            }

            return NoContent();
        }
    }
}
