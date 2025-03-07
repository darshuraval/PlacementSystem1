using Microsoft.AspNetCore.Mvc;
using PlacementSystem.Data;
using PlacementSystem.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;

namespace PlacementSystem.Controllers
{
	public class AuthController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AuthController(ApplicationDbContext context)
		{
			_context = context;
		}

		// ====================== [ INDEX ] ============================
		public IActionResult Index()
		{
			return View();
		}

		// ====================== [ REGISTER ] ============================
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Register(User user)
		{
			if (ModelState.IsValid)
			{
				// Check if the email is already registered
				var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
				if (existingUser != null)
				{
					ModelState.AddModelError(string.Empty, "Email already exists.");
					return View();
				}

				// Hash the password before storing
				user.PasswordHash = HashPassword(user.PasswordHash);
				_context.Users.Add(user);
				_context.SaveChanges();
				return RedirectToAction("Login");
			}
			return View();
		}

		// ====================== [ LOGIN ] ============================
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(string email, string password)
		{
			if (ModelState.IsValid)
			{
				var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);

				if (existingUser != null && VerifyPassword(password, existingUser.PasswordHash))
				{
					// Store user session
					HttpContext.Session.SetString("UserId", existingUser.Id.ToString());
					HttpContext.Session.SetString("UserRole", existingUser.Role);
					HttpContext.Session.SetString("FullName", existingUser.FullName ?? "");

					return RedirectToAction("Dashboard", existingUser.Role);
				}

				ModelState.AddModelError(string.Empty, "Invalid email or password.");
			}
			return View();
		}

		// ====================== [ LOGOUT ] ============================
		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear(); // Clears all session values
			return RedirectToAction("Index", "Home");
		}

		// ====================== [ FORGET PASSWORD ] ============================
		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ForgetPassword(string email)
		{
			var user = _context.Users.FirstOrDefault(u => u.Email == email);
			if (user != null)
			{
				// Generate a reset token (this should be sent via email)
				string resetToken = Guid.NewGuid().ToString();
				// You need to store the reset token in your database and implement an email system.

				// TODO: Implement email sending logic
			}
			return View();
		}

		// ====================== [ PASSWORD HASHING METHODS ] ============================
		private string HashPassword(string password)
		{
			byte[] salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			return $"{Convert.ToBase64String(salt)}.{hashed}";
		}

		private bool VerifyPassword(string enteredPassword, string storedPassword)
		{
			var parts = storedPassword.Split('.');
			if (parts.Length != 2) return false;

			byte[] salt = Convert.FromBase64String(parts[0]);
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: enteredPassword,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			return hashed == parts[1];
		}
	}
}
