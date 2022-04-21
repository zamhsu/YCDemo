using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base.IServices;
using WebApi.Models.Db;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDisplayDto>> Get(int id)
        {
            Product? product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductDisplayDto productDisplayDto = _mapper.Map<ProductDisplayDto>(product);

            return productDisplayDto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDisplayDto>>> GetAll()
        {
            IEnumerable<Product> products = await _productService.GetAllAsync();

            List<ProductDisplayDto> productDisplayDtos = _mapper.Map<List<ProductDisplayDto>>(products.ToList());

            return productDisplayDtos;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDisplayDto>> Create([FromBody] ProductCreateDto productCreateDto)
        {
            Product product = _mapper.Map<Product>(productCreateDto);

            await _productService.CreateAsync(product);

            ProductDisplayDto productDisplayDto = _mapper.Map<ProductDisplayDto>(product);

            return productDisplayDto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductEditDto productEditDto)
        {
            if (id != productEditDto.Id)
            {
                return BadRequest();
            }

            Product product = _mapper.Map<Product>(productEditDto);

            await _productService.UpdateAsync(id, product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }
    }
}
