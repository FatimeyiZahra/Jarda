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
    [Route("V1/NewsPage")]
    [ApiController]
    public class NewsPageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsPageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Route("AllNews")]
        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            var news = await _unitOfWork.News.GetAllNewWithCategories();

            //var newss = await _unitOfWork.News.GetNews();
            var newsResources = _mapper.Map<IEnumerable<News>, IEnumerable<NewsResource>>(news);


            return Ok(newsResources);

        }
        [Route("news")]
        [HttpGet]
        public async Task<IActionResult> GetNewsByCategory([FromQuery] int categoryId,
                                                            [FromQuery] int page = 1)
        {

            var category = await _unitOfWork.Category.GetByIdAsync(categoryId);

            if (category == null) return NotFound();

            var totalNews = await _unitOfWork.News.GetNewsCountByCategoryId(categoryId);

            var news = await _unitOfWork.News.GetNewsByCategoryId(categoryId, page);

            var newsResources = _mapper.Map<IEnumerable<News>, IEnumerable<NewsResource>>(news);
            return Ok(new
            {
                news = newsResources,
                pagination = new
                {
                    current = page,
                    totalPage = Convert.ToInt32(Math.Ceiling(totalNews / 12.0))
                }
            });

        }
    }
}
