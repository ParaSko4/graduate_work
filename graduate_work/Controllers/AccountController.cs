using graduate_work.Common;
using graduate_work.Interfaces;
using graduate_work.Interfaces.Services;
using graduate_work.Models.Api;
using graduate_work.Models.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace graduate_work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork dbUnit;
        private readonly IJwtService jwtService;
        private readonly IEmailService emailService;
        private readonly IImgService imgService;

        private ActionResult ar;

        public AccountController(IUnitOfWork dbUnit, IJwtService jwtService, IEmailService emailService, IImgService imgService)
        {
            this.dbUnit = dbUnit;
            this.jwtService = jwtService;
            this.emailService = emailService;
            this.imgService = imgService;
        }

        [Authorize]
        [HttpGet("AuthorizeCheck")]
        public ActionResult AuthorizeCheck()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public ActionResult SignInApp([FromBody] SignInUser signInUser)
        {
            UserAccount user = dbUnit.UserAccountRepository.FindByCredential(signInUser.Login, signInUser.Password);

            if (user == null)
            {
                return BadRequest(HttpResponseMessages.SignInFailed);
            }

            int schoolId = user.Role == ApiConfig.ROLE_ADMIN ? dbUnit.SchoolRepository.FindByUserId(user.Id).Id : dbUnit.PersonalDataRepository.FindByUserId(user.Id).SchoolId;
            Request.HttpContext.SignInAsync(ApiConfig.COOKIE, jwtService.GetClaimsForCookies(user.Id, schoolId, user.Role, user.Email));

            return Ok(HttpResponseMessages.SignInSuccess);
        }

        [Authorize]
        [HttpDelete("SignOut")]
        public ActionResult SignOutApp()
        {
            HttpContext.SignOutAsync();

            return Ok(HttpResponseMessages.SignOutSuccess);
        }

        [AllowAnonymous]
        [HttpPost("SchoolRegistration")]
        public ActionResult SchoolRegistration(SchoolRegistrationInfo schoolRegistrationInfo)
        {
            if (schoolRegistrationInfo.Password.Length < 8 || schoolRegistrationInfo.Password.Length > 32)
            {
                return BadRequest(HttpResponseMessages.BadPassword);
            }
            if (dbUnit.UserAccountRepository.isExistByLogin(schoolRegistrationInfo.Login))
            {
                return BadRequest(HttpResponseMessages.RegistrationUserExistByLogin);
            }
            if (dbUnit.UserAccountRepository.isExistByEmail(schoolRegistrationInfo.Email))
            {
                return BadRequest(HttpResponseMessages.RegistrationUserExistByEmail);
            }
            if (!emailService.IsEmailValid(schoolRegistrationInfo.Email))
            {
                return BadRequest(HttpResponseMessages.RegistrationUserBadEmail);
            }
            if (dbUnit.SchoolRepository.isExistByName(schoolRegistrationInfo.SchoolName))
            {
                return BadRequest(HttpResponseMessages.RegistrationSchoolExistByName);
            }

            emailService.SendMessage(ApiConfig.Options.SchoolRegistration, schoolRegistrationInfo.Email, schoolRegistrationInfo);

            return Ok(HttpResponseMessages.RegistrationSuccess);
        }

        [AllowAnonymous]
        [HttpGet("SchoolRegistrationConfirmation")]
        public ActionResult SchoolRegistrationConfirmation(string jwt)
        {
            ar = IsJwtValid(jwt);

            if (ar != null)
            {
                return ar;
            }

            SchoolRegistrationInfo registrationInfo = jwtService.GetDataFromJwt(ApiConfig.Options.SchoolRegistration, jwt) as SchoolRegistrationInfo;

            dbUnit.UserAccountRepository.Add(registrationInfo.Login, registrationInfo.Password, registrationInfo.Email, ApiConfig.ROLE_ADMIN);
            dbUnit.Complete();

            UserAccount userAccount = dbUnit.UserAccountRepository.FindByCredential(registrationInfo.Login, registrationInfo.Password);
            dbUnit.SchoolRepository.Add(registrationInfo.SchoolName, registrationInfo.SchoolLocation, registrationInfo.Email, registrationInfo.SchoolNumber, userAccount.Id);
            dbUnit.Complete();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Restore")]
        public ActionResult Restore(string email)
        {
            if (!dbUnit.UserAccountRepository.isExistByEmail(email))
            {
                return BadRequest(HttpResponseMessages.EmailNotExist);
            }
            emailService.SendMessage(ApiConfig.Options.Restore, email);

            return Ok(HttpResponseMessages.RestoreCheckEmail);
        }

        [AllowAnonymous]
        [HttpPost("RestoreConfirming")]
        public ActionResult RestoreConfirming([FromBody] RestoreData restoreData)
        {
            ar = IsJwtValid(restoreData.Jwt);

            if (ar != null)
            {
                return ar;
            }
            if (restoreData.NewPassword != restoreData.RepeatedNewPassword)
            {
                return BadRequest(HttpResponseMessages.PasswordNotMatch);
            }
            if (restoreData.NewPassword.Length < 8 || restoreData.NewPassword.Length > 32)
            {
                return BadRequest(HttpResponseMessages.BadPassword);
            }

            UserAccount userAccount = dbUnit.UserAccountRepository.FindByEmail(jwtService.GetDataFromJwt(ApiConfig.Options.Restore, restoreData.Jwt) as string);
            userAccount.Password = restoreData.NewPassword;

            dbUnit.UserAccountRepository.Update(userAccount);
            dbUnit.Complete();

            emailService.SendMessage(ApiConfig.Options.RestoreSuccess, userAccount.Email);

            return Ok(HttpResponseMessages.RestoredSuccess);
        }


        private ActionResult IsJwtValid(string jwt)
        {
            if (jwt == null || jwt.Length == 0)
            {
                return BadRequest(HttpResponseMessages.BadToken);
            }
            if (!jwtService.CheckExpiryTime(jwt))
            {
                return BadRequest(HttpResponseMessages.ExpiredToken);
            }

            return null;
        }
    }
}
