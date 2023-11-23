using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InstaPartyApp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SubsController : ControllerBase
  {
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SubsController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
      _context = context;
      _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("CreateNewParty")]
    public IActionResult CreateNewParty([FromBody] Party party)
    {

      var newParty = new Party
      {
        Name = party.Name,
        Date = DateTime.Now,
        Description = party.Description,
      };
      _context.Parties.Add(newParty);
      _context.SaveChanges();
      return Ok(party);
    }

    [HttpPost("SubToParty/{partyId}")]
    public IActionResult SubToParty(int partyId)
    {
      var userId = GetCurrentUserId();
      if (userId == null)
      {
        return Unauthorized("User is not authenticated.");
      }

      var subscription = new Subscription
      {
        UserId = userId.Value,
        PartyId = partyId
      };

      _context.Subscriptions.Add(subscription);
      _context.SaveChanges();
      return Ok(subscription);
    }

    [HttpGet("GetAllParties")]
    public IActionResult GetAllParties()
    {
      var parties = _context.Parties.ToList();
      return Ok(parties);
    }

    [HttpGet("GetMyParties")]
    public IActionResult GetMyParties()
    {
      var userId = GetCurrentUserId();
      if (userId == null)
      {
        return Unauthorized("User is not authenticated.");
      }

      var myParties = _context.Subscriptions
                               .Where(s => s.UserId == userId)
                               .Select(s => s.PartyId)
                               .ToList();
      return Ok(myParties);
    }

    private int? GetCurrentUserId()
    {
      var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
      if (userIdClaim != null)
      {
        return int.Parse(userIdClaim.Value);
      }
      return null;
    }
  }

}
