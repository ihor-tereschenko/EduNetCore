using BasicInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicInfo.Controllers
{
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository { get; }

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        [HttpGet("News/Index")]
        public IActionResult Index(/* int id*/)
        {
            // ViewData["name"] = name;
            // View();
            // return Ok(_newsRepository.GetNews().Single(x => x.Id == id));
            List<News> news = new List<News>();
            try
            {
                news = _newsRepository.GetNews();

             }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, news);
            }
            // return Ok(_newsRepository.GetNews());
            return Ok(news);
        }
        [HttpPost("News/Index")]
        public IActionResult AddNews([FromBody] News news)
        {
            if (_newsRepository.GetNews().FirstOrDefault(x => x.Id == news.Id) == null)
            {
                _newsRepository.AddNews(news);
                return Ok();
            }
            else return StatusCode(StatusCodes.Status406NotAcceptable);
        }
        [HttpDelete("News/{NewsId}")]
        public IActionResult DelNews([FromRoute]int NewsId)
        {
            try
            {
                _newsRepository.DelNews(NewsId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("News/{NewsId}")]
        public IActionResult UpdNews(int NewsId, [FromBody] News news)
        {
            // CheckNewsExists(NewsId);
            _newsRepository.UpdNews(NewsId, news);
            return Ok();
        }
        [HttpPatch("News/{NewsId}")]
        public IActionResult PatchNews(int NewsId, [FromBody] News news)
        {
            // CheckNewsExists(NewsId);
            _newsRepository.PatchNews(NewsId, news);
            return Ok();
        }
        /*
        public IActionResult Show(int id)
        {
            ViewData["news"] = _newsRepository.GetNews().Single(news => news.Id == id).Title;
            return View();
        }*/
    }
}