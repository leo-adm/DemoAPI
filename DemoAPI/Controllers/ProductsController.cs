using AutoMapper;
using DemoAPI.Data;
using DemoAPI.DTOs;
using DemoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepo _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDTO>> GetAllProducts()
        {
            var products = _repository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDTO>>(products));
        }

        [HttpGet("{id}", Name="GetProductById")]
        public ActionResult<ProductReadDTO> GetProductById(int id)
        {
            var product = _repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductReadDTO>(product));
        }

        [HttpPost]
        public ActionResult<ProductReadDTO> CreateProduct(ProductCreateDTO product)
        {
            var productModel = _mapper.Map<Product>(product);
            _repository.CreateProduct(productModel);
            _repository.SaveChanges();

            var productReadDTO = _mapper.Map<ProductReadDTO>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new { productReadDTO.Id }, productReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDTO productUpdateDTO)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
                return NotFound();

            _mapper.Map(productUpdateDTO, productModelFromRepo);

            _repository.UpdateProduct(productModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductUpdateDTO> patchDoc)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }

            var productToPatch = _mapper.Map<ProductUpdateDTO>(productModelFromRepo);
            patchDoc.ApplyTo(productToPatch, ModelState);
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(productToPatch, productModelFromRepo);

            _repository.UpdateProduct(productModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(productModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
