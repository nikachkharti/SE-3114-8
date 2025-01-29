using Microsoft.AspNetCore.Mvc;
using MiniBank.UI.Web.Models;

namespace MiniBank.UI.Web.Controllers
{
    public class PeopleController : Controller
    {
        private static List<Person> _people = new()
        {
            new Person() {Name = "Nika"},
            new Person() {Name = "Daviti"},
            new Person() {Name = "Irakli"}
        };


        public IActionResult Index()
        {
            return View(_people);
        }
    }
}
