
using demo.web.Data;
using demo.web.Data.Entities;
using demo.web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.web.Controllers
{
    public class AppController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AppController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Index(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();
            return View();
        }

        public IActionResult ShowUsers()
        {
            //LINQ Query
            var results = from u in _userRepository.GetAllUsers()
                          select u;
            return View(results.ToList());
        }

    }
}
