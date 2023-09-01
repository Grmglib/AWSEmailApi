using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Accounts;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public SendController(
            IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        //Endpoints

        [HttpPost("EmailLink")]
        public IActionResult EmailLink(EmailLinkRequest model)
        {
            _accountService.EmailLink(model);
            return Ok(new { message = "Email link sent" });
        }

        [HttpPost("EmailLinkError")]
        public IActionResult EmailLinkError(EmailLinkErrorRequest model) 
        {
            _accountService.EmailLinkError(model);
            return Ok(new { message = "Email link error sent" });
        }
        [HttpPost("CustomMessage")]
        public IActionResult Custom(CustomEmailRequest model)
        {
            _accountService.CustomEmail(model);
            return Ok(new { message = "Email sent" });
        }

        [HttpPost("test")]
        public IActionResult Test(TestEmailRequest model)
        {
            _accountService.Test(model);
            return Ok(new { message = "Test email sent" });
        }
    }
}