using System.Configuration;
using System.Web.Http;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.WebApi;

namespace TwilioExample.Controllers
{
    public class ConversationController : ApiController
    {
        private string Username = ConfigurationManager.AppSettings["Twilio:Username"];
        private string Password = ConfigurationManager.AppSettings["Twilio:Password"];

        public ConversationController()
        {
        }

        [Route("api/conversation/helloWorld")]
        public IHttpActionResult HelloWorld()
        {
            TwilioClient.Init(Username, Password);

            var message = MessageResource.Create(
                to: new Twilio.Types.PhoneNumber("+19092247557"),
                from: new Twilio.Types.PhoneNumber("+16192028377"),
                body: "Hello World"
            );

            return Ok(message.Sid);
        }

        [Route("api/conversation/createJob")]
        public IHttpActionResult ReceiveMessage(SmsRequest request)
        {
            TwilioClient.Init(Username, Password);

            var message = MessageResource.Create(
                to: new Twilio.Types.PhoneNumber("+19092247557"),
                from: new Twilio.Types.PhoneNumber("+16192028377"),
                body: $"You said: {request.Body}"
            );

            return Ok(message.Sid);
        }
    }
}
