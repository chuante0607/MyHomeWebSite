﻿using Microsoft.AspNetCore.Mvc;
using MyHomeWebSite.Methos;
using MyHomeWebSite.Models;

namespace MyHomeWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly UserMethod _userMethod;


        public HomeController(UserMethod userMethod)
        {
            _userMethod = userMethod;
        }


        [HttpGet]
        async public Task<IActionResult> Index([FromQuery] Login login)
        {
            Aemployee employee = await _userMethod.GetUser(login);
            return Ok(new { Url = "/WebPages/Index.Html", Employee = employee });
        }
    }
}