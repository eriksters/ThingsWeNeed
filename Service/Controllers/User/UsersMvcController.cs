using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.User
{
    public class UsersMvcController : Controller
    {
        [Route]
        [Route("Users")]
        [Route("Users/All")]
        [HttpGet]
        public ActionResult All()
        {
            throw new NotImplementedException();
        }

        [Route("Users/{id}")]
        [HttpGet]
        public ActionResult Details([Bind(Include = "id")] int id) {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                UserDto User;
                using (var db = new UserDaLogic())
                {
                    User = db.GetById(id);
                }

                UserDetailsViewModel viewModel = new UserDetailsViewModel() {
                    User = User
                };

                return View("Details", viewModel);
            }
        }

        [Route("Users/Create")]
        [HttpGet]
        public ActionResult Create([Bind(Include = "dto")] UserDto dto) {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                UserDto User;
                using (var db = new UserDaLogic())
                {
                    User = db.Create(dto.FName, dto.LName, dto.PhoneNumber, dto.Username, dto.Email);
                }

                UserDetailsViewModel viewModel = new UserDetailsViewModel()
                {
                    User = User
                };

                return View("Details", viewModel);
            }
        }

        [Route("Users/{id}/Edit")]
        [HttpGet]
        public ActionResult Update(int id) {
            throw new NotImplementedException();
        }

    }
}