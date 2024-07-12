﻿using AutoMapper;
using FinTransact.TransactionAPI.Dtos.BankAccount;
using FinTransact.TransactionAPI.Entities;
using FinTransact.TransactionAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinTransact.TransactionAPI.Controllers
{

    public class BankAccountController : BaseApiController
    {
        private readonly IGenericRepository<BankAccount> _bankAccountRepository;
        private readonly IMapper _mapper;

        public BankAccountController(IGenericRepository<BankAccount> bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnBankAccountDto>>> GetBankAccounts()
        {
            var accounts = await _bankAccountRepository.ListAllAsync();
            var accountDtos = _mapper.Map<IEnumerable<ReturnBankAccountDto>>(accounts);
            return Ok(accountDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnBankAccountDto>> GetBankAccount(int id)
        {
            var account = await _bankAccountRepository.GetByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            var accountDto = _mapper.Map<ReturnBankAccountDto>(account);
            return Ok(accountDto);
        }

        [HttpPost]
        public async Task<ActionResult<ReturnBankAccountDto>> PostBankAccount(AddBankAccountDto addBankAccountDto)
        {
            var bankAccount = _mapper.Map<BankAccount>(addBankAccountDto);
            var result = await _bankAccountRepository.AddAsync(bankAccount);

            if (!result)
            {
                return BadRequest("Unable to add the bank account.");
            }

            var returnBankAccountDto = _mapper.Map<ReturnBankAccountDto>(bankAccount);
            return CreatedAtAction(nameof(GetBankAccount), new { id = returnBankAccountDto.Id }, returnBankAccountDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankAccount(int id, UpdateBankAccountDto updateBankAccountDto)
        {
            if (id != updateBankAccountDto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var bankAccount = _mapper.Map<BankAccount>(updateBankAccountDto);
            var result = await _bankAccountRepository.UpdateAsync(bankAccount);

            if (!result)
            {
                return BadRequest("Unable to update the bank account.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            var result = await _bankAccountRepository.DeleteAsync(id);

            if (!result)
            {
                return BadRequest("Unable to delete the bank account.");
            }

            return NoContent();
        }
    }
}