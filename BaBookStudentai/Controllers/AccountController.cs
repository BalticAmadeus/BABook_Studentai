using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;
using Microsoft.AspNet.Identity;

namespace BaBookStudentai.Controllers
{ }
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }
        public User GetById(string id)
        {
            var _db = new BaBookDbContext();
            var user = _db.Users.FirstOrDefault(x => x.Id.Equals(id));
            return user;
        }

        [Authorize]
        [Route("api/user")]
        public IHttpActionResult GetUser()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var usr = new UserDto
            {
                UserId = userId,
                Name = GetById(userId).UserName
    };
            return Ok();
        }

        // POST api/Register
        [AllowAnonymous]
        [Route("api/register")]
        public async Task<IHttpActionResult> Register(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }

