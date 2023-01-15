﻿namespace PROJECT_CA23.Models.Dto.UserMediaDtos
{
    public class GetUserMediaRequest
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Optional filter: "Wishlisth", "Watching" or "Finished"
        /// </summary>
        public string? Filter { get; set; }
    }
}
