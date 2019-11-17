using System;
using System.Threading.Tasks;
using System.Web;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDB.Controllers
{
    [ApiController]
    [Route("url")]
    public class ShortUrlController : ControllerBase
    {
        private static readonly Random Random = new Random();
        private readonly Table _shortUrlsTable;

        public ShortUrlController(IAmazonDynamoDB dynamoDb)
        {
            _shortUrlsTable = Table.LoadTable(dynamoDb, "short_urls");
        }
        
        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToUrl(string shortCode)
        {
            var document = await _shortUrlsTable.GetItemAsync(shortCode);
            if (document == null)
            {
                return NotFound();
            }
            return Redirect(document["url"].AsString());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLinkRequest request)
        {
            var shortCode = GenerateNewShortCode();
            await _shortUrlsTable.PutItemAsync(new Document
            {
                {"short_code", shortCode},
                {"url", request.Url}
            });
            return CreatedAtAction(nameof(RedirectToUrl), new {shortCode}, null);
        }

        private static string GenerateNewShortCode()
        {
            var bytes = new byte[6];
            Random.NextBytes(bytes);
            return Convert.ToBase64String(bytes)
                .Replace('/', '_')
                .Replace('+', '.')
                .Replace('=', '-');
        }
        
        public class CreateLinkRequest
        {
            public string Url { get; set; }
        }
    }
}