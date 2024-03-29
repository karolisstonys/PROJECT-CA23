﻿using Microsoft.IdentityModel.Tokens;
using PROJECT_CA23.Models;
using PROJECT_CA23.Models.Dto.UserMediaDtos;
using PROJECT_CA23.Models.Enums;
using PROJECT_CA23.Repositories.IRepositories;
using PROJECT_CA23.Repositories.RepositoryServices.IRepositoryServices;

namespace PROJECT_CA23.Repositories.RepositoryServices
{
    public class ReviewRepoService : IReviewRepoService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewRepoService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<UserMedia> AddReviewIfNeeded(UserMedia userMedia, UpdateUserMediaRequest req)
        {
            var hasNoReviewButHasReviewDataToAdd = userMedia.Review == null && (!req.UserRating.IsNullOrEmpty() || !req.ReviewText.IsNullOrEmpty());
            if (hasNoReviewButHasReviewDataToAdd) 
            {
                Review review = new Review();
                review.UserId = userMedia.UserId;
                review.User = userMedia.User;
                review.UserMediaId = userMedia.UserMediaId;
                review.UserMedia = userMedia;
                review.MediaId = userMedia.MediaId;
                review.Media = userMedia.Media;
                await _reviewRepo.CreateAsync(review);

                userMedia.Review = review;
                userMedia.ReviewId = review.ReviewId;
            }

            userMedia.Review.UserRating = Enum.Parse<EUserRating>(req.UserRating);
            userMedia.Review.ReviewText = req.ReviewText;
            return userMedia;
        }
    }
}
