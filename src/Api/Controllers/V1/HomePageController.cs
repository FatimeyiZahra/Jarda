using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Resources;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [Route("V1/HomePage")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomePageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetAllOrderedAsync();

            var categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return Ok(categoryResources);

        }

        [Route("free-product")]
        [HttpGet]
        public async Task<IActionResult> GetFreeProduct()
        {
            var products = await _unitOfWork.Product.GetIsFreeProduct();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);

        }

        [Route("new-product")]
        [HttpGet]
        public async Task<IActionResult> GetNewProduct()
        {
            var products = await _unitOfWork.Product.GetIsNewProduct();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);
        }

        [Route("coming-product")]
        [HttpGet]
        public async Task<IActionResult> GetComingProduct()
        {
            var products = await _unitOfWork.Product.GetIsComingProduct();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productResources);

        }

        [Route("products")]
        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory([FromQuery] int categoryId,
                                                               [FromQuery] int page = 1)
        {

            var category = await _unitOfWork.Category.GetByIdAsync(categoryId);

            if (category == null) return NotFound();

            var totalProducts = await _unitOfWork.Product.GetProductsCountByCategoryId(categoryId);

            var products = await _unitOfWork.Product.GetProductsByCategoryId(categoryId, page);

            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return Ok(new
            {
                products = productResources,
                pagination = new
                {
                    current = page,
                    totalPage = Convert.ToInt32(Math.Ceiling(totalProducts / 12.0))
                }
            });
        }

        [Route("product/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Product.GetProductById(id);

            if (product == null) return NotFound();

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

       
    }
}
