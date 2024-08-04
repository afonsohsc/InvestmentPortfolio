using FluentValidation;
using InvestmentPortfolio.Application.Interfaces;
using InvestmentPortfolio.Application.Validators;
using InvestmentPortfolio.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.API.Controllers
{
    [ApiController]
    [Route("transaction")]   
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionAppService _transactionAppService;

        public TransactionController(ITransactionAppService transactionAppService)
        {
            _transactionAppService = transactionAppService;
        }

        [HttpGet("{clientId:int}")]
        public IActionResult GetAll(int clientId)
        {
            var products = _transactionAppService.GetAll(clientId);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TransactionViewModel transactionViewModel)
        {
            var validationResult = new TransactionValidator().Validate(transactionViewModel);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            _transactionAppService.Add(transactionViewModel);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] TransactionViewModel transactionViewModel)
        {
            var validationResult = new TransactionValidator().Validate(transactionViewModel);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            _transactionAppService.Update(transactionViewModel);
            return Ok();
        }        
    }

}