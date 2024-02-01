using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SSO_Google_.Models;
using SSO_Google_.Data;
namespace SSO_Google_.Controllers;
using Microsoft.AspNetCore.Identity;

public class LoginController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<HomeController> _logger;
    [ActivatorUtilitiesConstructor]

    public LoginController(ILogger<HomeController> logger,ApplicationDbContext dbContext,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _dbContext = dbContext;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Logins(Login login)
    {
        return View();
    }
    private string GetPassword(string userEmail)
    {
        return _dbContext.Credentials?
            .Where(c => c.userEmail == userEmail)
            .Select(c => c.userPassword)
            .FirstOrDefault() ?? string.Empty;
    }

    [HttpPost]
    public async Task<IActionResult> Logins(Login login,int a)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var dbpassword = GetPassword(login.userEmail);
                if (!string.IsNullOrEmpty(dbpassword) && dbpassword.Equals(login.userPassword))
                {
                    return RedirectToAction("Content", "Login");

                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid credentials.");
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(String.Empty, $"Something Went Wrong: {exception.Message}");
            }
        }

        return View(login);
    }
    [HttpGet]
    public IActionResult Content(Login login)
    {
        return View();
    }
    [HttpGet]
    [HttpPost]
    public IActionResult ExternalLogin(string provider)
    {
        var redirectUrl = Url.Action("ExternalLoginCallback", "Login");
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }
    public async Task<IActionResult> ExternalLoginCallback(string remoteError = null)
    {
        try
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return RedirectToAction("Logins", "Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                // Handle the error
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return RedirectToAction("Logins", "Login");
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("External login callback succeeded.");
                return RedirectToAction("Content", "Login");
            }
            else
            {                
                    // The user doesn't exist, create a new user
                    var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
                    var user = new IdentityUser { UserName = userEmail, Email = userEmail };
                    var createResult = await _userManager.CreateAsync(user);

                    if (createResult.Succeeded)
                    {
                        // Add external login to the user
                        var addLoginResult = await _userManager.AddLoginAsync(user, info);

                        if (addLoginResult.Succeeded)
                        {
                            // Sign in the user with the external login
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            _logger.LogInformation("User created and signed in with external login.");
                            return RedirectToAction("Content", "Login");
                        }
                    }
                    _logger.LogError($"External login failed: {createResult.Errors}");
                    ModelState.AddModelError(string.Empty, "External login failed. Please try again.");
                    return RedirectToAction("Logins", "Login");
            }
        }
      
        catch (Exception ex)
        {
            _logger.LogError($"Exception in ExternalLoginCallback: {ex}");
            return RedirectToAction("Error", "Home");
        }
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
