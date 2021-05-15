using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebCommentsSection.Models;

namespace WebCommentsSection.Pages {
    public class IndexModel : PageModel {

        private readonly WebCommentsSection.Data.WebCommentsSectionContext _context;
        const string ServiceBusConnectionString = "Endpoint=sb://service-bus-aa-15052021.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=P9sILgyUFyGFiobVRE7EEKz0X68pWTM19q+M3LyV7Ko=";
        private const string QueueName = "opinions";
        private readonly IQueueClient _queueClient; 

        public IndexModel(WebCommentsSection.Data.WebCommentsSectionContext context) {
            _context = context;
            _queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

        }
        public IList<Comment> Comments { get; set; }
        
        [BindProperty]
        public Comment Comment { get; set; }
        
        
        public void OnGet() {
            var comments = from c in _context.Comment
                           orderby c.Timestamp descending
                           select c;

            Comments = comments.ToList();
        }

        public async Task<IActionResult> OnPost() { // moznaby tutaj dodac Comment jako parametr OnPost(Comment Comment)
            if (!ModelState.IsValid) {
                // may save that in session variable but it uses server memory too much 
                var comments = from c in _context.Comment
                               orderby c.Timestamp descending
                               select c;

                Comments = comments.ToList();
                
                //Request - instancja, która jest dostępna w obu metodach - OnGet i OnPost
                //Request.HttpContext.WebSockets - POBAWIC SIE TYM !!! 

                return Page(); // async - podanie tylko 1 części strony do przeładowania
            }

            Comment.Timestamp = DateTime.Now;
            _context.Comment.Add(Comment);
            _context.SaveChanges();

            // Azure Service Bus connection
            try
            {
                string message = JsonConvert.SerializeObject(Comment);
                var encodedMessage = new Message(Encoding.UTF8.GetBytes(message));
                Console.WriteLine($"Sending message: {message}");
                await _queueClient.SendAsync(encodedMessage);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
            await _queueClient.CloseAsync();
            // Azure end

            Comment.Name = null;
            Comment.Message = null;

            return RedirectToPage("./Index");
        }
    }
}
