using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllUserMessageAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateUserMessageDto createUserMessageDto)
        {
            await _userMessageService.CreateUserMessageAsync(createUserMessageDto);
            return Ok("Mesaj başarılı bir şekilde eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteUserMessageAsync(id);
            return Ok("Mesaj başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateUserMessageDto updateUserMessageDto)
        {
            await _userMessageService.UpdateUserMessageAsync(updateUserMessageDto);
            return Ok("Mesaj başarılı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessageById(int id)
        {
            var value = await _userMessageService.GetByIdUserMessageAsync(id);
            return Ok(value);
        }

        [HttpGet("GetInboxUserMessage")]
        public async Task<IActionResult> GetInboxUserMessage(string id)
        {
            var values = await _userMessageService.GetInboxUserMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetSendboxUserMessage")]
        public async Task<IActionResult> GetSendboxUserMessage(string id)
        {
            var values = await _userMessageService.GetSendBoxUserMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var value = await _userMessageService.GetTotalMessageCount();
            return Ok(value);
        }

        [HttpGet("GetTotalMessageCountByReceiverId")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _userMessageService.GetTotalMessageCountByReceiverId(id);
            return Ok(value);
        }
    }
}
