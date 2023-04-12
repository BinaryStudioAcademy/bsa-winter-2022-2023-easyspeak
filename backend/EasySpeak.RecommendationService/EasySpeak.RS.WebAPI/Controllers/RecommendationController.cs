using EasySpeak.Core.Common.DTO.User;
using EasySpeak.RS.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.RS.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RecommendationController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;

    public RecommendationController(IRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpPost]
    public async Task<Dictionary<long, long>> GetRecommendedUsers(NewRecommendationDto recommendationDto)
    {
        return await _recommendationService.GetRecommendedUsers(recommendationDto.ToDictionary());
    }
    
}   