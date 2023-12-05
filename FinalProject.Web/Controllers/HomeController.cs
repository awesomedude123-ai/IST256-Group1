﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

using FinalProject.Web.ViewModels;
using FinalProject.Web.Services;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Linq;
using FinalProject.DAL.Repositories;

namespace FinalProject.Web.Controllers
{
	/// <summary>
	/// home page controller
	/// </summary>
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> logger;
		private readonly IMailService mailService;
		private readonly IConfiguration config;
private readonly AdventureWorksRepository repo;
		/// <summary>
		/// controller for home page
		/// </summary>
		/// <param name="mailService">email service for sending mail</param>
		/// <param name="config">Configuration for the a[[;ocatopm</param>
		/// <param name="logger">Logger to log errors and such</param>
		public HomeController(IMailService mailService,
			IConfiguration config,
			ILogger<HomeController> logger, AdventureWorksRepository repo)
		{
			this.mailService = mailService;
			this.logger = logger;
			this.config = config;
			this.repo = repo;
		}

		/// <summary>
		/// Main landing page -- lists all functions.  Requires at minimum tmaint role
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Index()
		{
			List<string> Items = new()
			{
				"Mens",
				"Womens",
				"Accessories"
			};
			List<string> Images = new()
			{
				"/images/beverage.png",
				"/images/condiments.png",
				"/images/confections.png"
			};
ViewBag.Images = Images;
ViewBag.Items = Items;

var model = repo.GetAllCategories().ToList();
			return View(model);
		}

		/// <summary>
		/// Privacy page end point
		/// </summary>
		/// <returns></returns>

		/// 

		public IActionResult About()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}

		/// <summary>
		/// Display the group contract.
		/// </summary>
		/// <returns>The contract view.</returns>
		public IActionResult Contract()
		{
			return View();
		}
		public IActionResult Womens()
		{
			
			return View();
			
		}
		public IActionResult Mens()
		{
			return View();
		}
		public IActionResult Accessories()
		{
			return View();
		}
		public IActionResult Shoppingcart()
		{
			return View();
		}
		


		/// <summary>
		/// Error page to show to the user
		/// </summary>
		/// <param name="id">ID of the error</param>
		/// <returns>View telling user there has been an error.  Also emails the error out</returns>
		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(string id)
		{
			var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
			var unhandledException = feature?.Error;
			logger.LogError(unhandledException, "error {IISerror} occurred in final project", id);
			MailRequest mail = new()
			{
				ToAddress = config.GetValue<string>("ErrorEmailAddress"),
				Subject = $"Project ERROR: {id}",
				Body = $"an eror has occured {unhandledException?.Message}"
			};
			mailService.SendEmailAsync(mail);
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, HrResult = unhandledException?.HResult.ToString(), IisError = id });
		}
	}
}