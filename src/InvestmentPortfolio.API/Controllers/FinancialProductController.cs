using InvestmentPortfolio.Application.Interfaces;
using InvestmentPortfolio.Application.Validators;
using InvestmentPortfolio.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]   
    public class FinancialProductController : ControllerBase
    {
        private readonly IFinancialProductAppService _financialProductAppService;

        public FinancialProductController(IFinancialProductAppService financialProductAppService)
        {
            _financialProductAppService = financialProductAppService;
        }

        [HttpGet]
        public IActionResult GetAllFinancialProducts()
        {
            var products = _financialProductAppService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
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
            var validator = new FinancialProductValidator();
            var validationResult = validator.Validate(financialProductViewModel);

            if (!ModelState.IsValid)
                return BadRequest();

            _financialProductAppService.Add(financialProductViewModel);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFinancialProduct([FromBody] FinancialProductViewModel financialProductViewModel)
        {
            // Validar o modelo usando FluentValidation
            var validator = new FinancialProductValidator(); // Supondo que você tenha um validador definido
            var validationResult = validator.Validate(financialProductViewModel);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _financialProductAppService.Update(financialProductViewModel);
            return Ok();
        }        
    }

}