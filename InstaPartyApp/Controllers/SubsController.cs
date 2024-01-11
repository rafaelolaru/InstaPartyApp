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

    [HttpDelete("deleteFromMyParties/{partyId}")]
    public IActionResult DeleteFromMyParties(int partyId)
    {
      var userId = GetCurrentUserId();
      if (userId == null)
      {
        return Unauthorized("User is not authenticated.");
      }

      var subscription = _context.Subscriptions
                                 .FirstOrDefault(s => s.UserId == userId && s.PartyId == partyId);

      if (subscription == null)
      {
        return NotFound("Subscription not found.");
      }

      _context.Subscriptions.Remove(subscription);
      _context.SaveChanges();
      return Ok($"Unsubscribed from party with ID: {partyId}");
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
    [HttpGet("GetPartyDetails/{partyId}")]
    public IActionResult GetPartyDetails(int partyId)
    {
      var party = _context.Parties.FirstOrDefault(p => p.PartyId == partyId);

      if (party == null)
      {
        return NotFound("Party not found.");
      }

      return Ok(party);
    }
    private int? GetCurrentUserId()
    {
      // Use the custom claim type "userid"
      var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("userid");

      if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
      {
        return userId;
      }

      return null;
    }
  }

}
