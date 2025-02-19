using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using Xenhey.BPM.Core.Net8.Implementation;
using Xenhey.BPM.Core.Net8;
using Microsoft.Azure.Functions.Worker;


namespace ChatService
{
    public class DirectMessages
    {
        private readonly ILogger _logger;

        public DirectMessages(ILogger<DirectMessages> logger)
        {
            _logger = logger;
        }

        private HttpRequest _req;
        private NameValueCollection nvc = new NameValueCollection();
        [Function("directmessages")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest req)
        {
            _req = req;

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(_req.Body).ReadToEndAsync();
            _req.Headers.ToList().ForEach(item => { nvc.Add(item.Key, item.Value.FirstOrDefault()); });
            var results = orchrestatorService.Run(requestBody);
            return resultSet(results);

        }

        private ActionResult resultSet(string reponsePayload)
        {
            var returnContent = new ContentResult();
            var mediaSelectedtype = nvc.Get("Content-Type");
            returnContent.Content = reponsePayload;
            returnContent.ContentType = mediaSelectedtype;
            return returnContent;
        }
        private IOrchestrationService orchrestatorService
        {
            get
            {
                return new RemoteOrchrestratorService(nvc);
            }
        }

    }
}
