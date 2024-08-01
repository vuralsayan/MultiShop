﻿namespace MultiShop.DtoLayer.CommentDtos
{
    public class GetByIdCommentDto
    {
        public int UserCommentID { get; set; }
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ProductID { get; set; }
    }
}
