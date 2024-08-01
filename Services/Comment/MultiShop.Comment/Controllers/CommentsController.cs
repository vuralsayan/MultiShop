using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;
        private readonly IMapper _mapper;

        public CommentsController(CommentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _context.UserComments.ToListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateUserCommentDto createUserCommentDto)
        {
            var values = _mapper.Map<UserComment>(createUserCommentDto);
            await _context.UserComments.AddAsync(values);
            await _context.SaveChangesAsync();
            return Ok("Yorum başarılı bir şekilde eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateUserCommentDto updateUserCommentDto)
        {
            var values = _mapper.Map<UserComment>(updateUserCommentDto);    
            _context.UserComments.Update(values);
            await _context.SaveChangesAsync();
            return Ok("Yorum başarılı bir şekilde güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var values = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(values);
            await _context.SaveChangesAsync();
            return Ok($"{id} li yorum başarılı bir şekilde silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCommentListByProductId")]
        public async Task<IActionResult> GetCommentListByProductId(string productID)
        {
            var values = await _context.UserComments.Where(x => x.ProductID == productID).ToListAsync();
            return Ok(values);
        }

        [HttpGet("GetActiveCommentCount")]
        public async Task<IActionResult> GetActiveCommentCount()
        {
            int values = await _context.UserComments.Where(x => x.Status == true).CountAsync();
            return Ok(values);
        }

        [HttpGet("GetPassiveCommentCount")]
        public async Task<IActionResult> GetPassiveCommentCount()
        {
            int values = await _context.UserComments.Where(x => x.Status == false).CountAsync();
            return Ok(values);
        }

        [HttpGet("GetTotalCommentCount")]
        public async Task<IActionResult> GetTotalCommentCount()
        {
            int values = await _context.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
