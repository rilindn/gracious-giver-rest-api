
using GraciousGiver_BackEnd.Data;
using GraciousGiver_BackEnd.Dtos;
using GraciousGiver_BackEnd.Helpers;
using GraciousGiver_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController:Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Firstname = dto.Firstname,
                    Lastname = dto.Lastname,
                    UserName = dto.UserName,
                    UserPassword = BCrypt.Net.BCrypt.HashPassword(dto.UserPassword),
                    UserState = dto.UserState,
                    UserCity = dto.UserCity,
                    UserPostcode = dto.UserPostcode,
                    UserRole = dto.UserRole,
                    UserEmail = dto.UserEmail,
                    UserGender = dto.UserGender,
                    UserDbo = dto.UserDbo
                };

                if (dto.UserPassword == dto.UserConfirmPassword && 
                    dto.UserEmail == dto.UserConfirmEmail)
                {
                    return Created("success", _repository.Create(user));
                }
            }
            return new JsonResult("Invalid user data!");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            try { 
            var user = _repository.GetByUsername(dto.UserName);
            var org = new Organization();

            if (user == null) 
            { 
                org = _repository.GetOrgByUsername(dto.UserName);
                if (org==null) return BadRequest(new { message = "Invalid credentials" });
            } 

               if (!BCrypt.Net.BCrypt.Verify(dto.UserPassword, user!=null?user.UserPassword:org.Password))
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            var jwt = _jwtService.Generate(user != null ? user.UserId:org.OrganizationId);


            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            options.HttpOnly = true;
            Response.Cookies.Append("jwt", jwt, options);

                return Ok(user != null ? user : org);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        [HttpGet("loggedUser")]
        public IActionResult Users()
        {
            var org = new Organization();
            try { 
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            int userId = int.Parse(token.Issuer);

            var user = _repository.GetById(userId);

            if(user==null) org = _repository.GetOrgById(userId);

            return Ok(user!=null?user:org);
            }catch(Exception e)
            {
                return Unauthorized();
            }
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (Request.Cookies["jwt"] != null)
            {
                string delCookie = "";
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("jwt", delCookie, options);
            }

            return Ok(new
            {
                message = "success"
            });
        }
        [HttpPost("changepsw")]
        public IActionResult Login(ChangePswDto dto)
        {
            try
            {
                var user = _repository.GetByUsername(dto.UserName);
                var org = new Organization();

                if (user == null)
                {
                    org = _repository.GetOrgByUsername(dto.UserName);
                    if (org == null) return BadRequest(new { message = "Invalid credentials" });
                }

                if (!BCrypt.Net.BCrypt.Verify(dto.OldPassword, user!=null?user.UserPassword:org.Password))
            {
                return BadRequest(new { message = "Invalid credentials" });
            }
                if (user != null)
                {
                    user.UserPassword = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                    _repository.ChangePsw(user);
                }
                else
                {
                    org.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                    _repository.ChangeOrgPsw(org);
                }

                return Ok(new
                {

                    message = "success"
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
