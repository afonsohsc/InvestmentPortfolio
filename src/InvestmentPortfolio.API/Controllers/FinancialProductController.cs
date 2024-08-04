using FluentValidation;
using InvestmentPortfolio.Application.Interfaces;
using InvestmentPortfolio.Application.Validators;
using InvestmentPortfolio.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.API.Controllers
{
    [ApiController]
    [Route("financial-product")]   
    public class FinancialProductController : ControllerBase
    {
        private readonly IFinancialProductAppService _financialProductAppService;

        public FinancialProductController(IFinancialProductAppService financialProductAppService)
        {
            _financialProductAppService = financialProductAppService;
        }

        [HttpGet()]
        public IActionResult GetAllFinancialProducts()
        {
            var products = _financialProductAppService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetFinancialProductById(int id)
        {
            var product = _financialProductAppService.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddFinancialProduct([FromBody] FinancialProductViewModel financialProductViewModel)
        {
            var validationResult = new FinancialProductValidator().Validate(financialProductViewModel);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            _financialProductAppService.Add(financialProductViewModel);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFinancialProduct([FromBody] FinancialProductViewModel financialProductViewModel)
        {
            var validationResult = new FinancialProductValidator().Validate(financialProductViewModel);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            _financialProductAppService.Update(financialProductViewModel);
            return Ok();
        }        
    }

}