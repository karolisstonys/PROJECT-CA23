﻿using PROJECT_CA23.Models;
using PROJECT_CA23.Models.Dto.UserMediaDtos;

namespace PROJECT_CA23.Repositories.IRepositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<UserMedia> AddReviewIfNeeded(UserMedia userMedia, UpdateUserMediaRequest req);
    }
}
