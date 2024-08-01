namespace MultiShop.Message.Dtos
{
    public class CreateUserMessageDto
    {
        public string? SenderID { get; set; }
        public string? ReceiverID { get; set; }
        public string? Subject { get; set; }
        public string? MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
