using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _messageContext = context;
            _mapper = mapper;
        }

        public async Task CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createUserMessageDto);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteUserMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            if (value != null)
            {
                _messageContext.UserMessages.Remove(value);
                await _messageContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"{id} sine sahip Kullanıcı mesajı bulunamadı");
            }
        }

        public async Task<List<ResultUserMessageDto>> GetAllUserMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultUserMessageDto>>(values);
        }

        public async Task<GetByIdUserMessageDto> GetByIdUserMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdUserMessageDto>(value);
        }

        public async Task<List<ResultInBoxUserMessageDto>> GetInboxUserMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).ToListAsync();
            return _mapper.Map<List<ResultInBoxUserMessageDto>>(values);
        }

        public async Task<List<ResultSendBoxUserMessageDto>> GetSendBoxUserMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderID == id).ToListAsync();
            return _mapper.Map<List<ResultSendBoxUserMessageDto>>(values);
        }

        public async Task<int> GetTotalMessageCount()
        {
            int value = await _messageContext.UserMessages.CountAsync();
            return value;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).CountAsync();
            return value;
        }

        public async Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateUserMessageDto);
            _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
    }
}
