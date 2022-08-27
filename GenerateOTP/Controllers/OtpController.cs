using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Verify.V2.Service;

namespace GenerateOTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        public OtpController(ITwilioRestClient client)
        {
            _client = client;
        }
        [HttpPost("send")]
        public IActionResult randam(string number)
        {
           
                Random random = new Random();
                const string accountSid = "ACf0581a32f146ebc6c57e4bb054daccfd";
                const string authToken = "f1a9b3261d2a71c235a3fbdd98dd214d";
                const string verifysid = "VA5f5cee0b58e4a7a8a7f5917393782bc8";
                TwilioClient.Init(accountSid, authToken);
                CreateVerificationOptions v = new CreateVerificationOptions(verifysid, number, "sms");
                var verification = VerificationResource.Create(v);
                return Ok("success");
            
           
        }
        [HttpPost]
        public IActionResult VerifyOTP(string number, string OTP)
        {
            try
            {
                string accountSid = "AC0d2e5aa5a5b29117b395779116567dce";
                string authToken = "f1a9b3261d2a71c235a3fbdd98dd214d";
                string serviceSid = "VA3f32df1a43881bc0ce4bd352ced1ab59";
                TwilioClient.Init(accountSid, authToken);

                var verificationCheck = VerificationCheckResource.Create(
                    to: number,
                    code: OTP,
                    pathServiceSid: serviceSid
                );
                return Ok("successs");
            }
            catch (Exception ex)
            {
                return StatusCode(5307, "You have to match OTP or Phone Number..");
            }


        }
        [HttpPost("otp")]
        public IActionResult EmailRandomOTP(string EMAIL)
        {

            Random random = new Random();
            const string accountSid = "ACf0581a32f146ebc6c57e4bb054daccfd";
            const string authToken = "f1a9b3261d2a71c235a3fbdd98dd214d";
            const string verifysid = "VA94419990b4bb86e702478061d74b4dbf";
            TwilioClient.Init(accountSid, authToken);
            CreateVerificationOptions v = new CreateVerificationOptions(verifysid, EMAIL, "email");
            var verification = VerificationResource.Create(v);
            return Ok("success");


        }
    }
}
    
