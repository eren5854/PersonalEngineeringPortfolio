using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonalEngineeringPortfolio.Controllers;

[Authorize]
public sealed class AdminPanelController : Controller
{
    [HttpGet("/admin-panel")]
    public IActionResult Index() => View();
}