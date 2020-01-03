using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using MailKit.Net.Smtp;


public class ContactModel : PageModel
{
    public string MessageSent { get; set; } = "";

    [BindProperty]
    public string name { get; set; }

    [BindProperty]
    public string email { get; set; }

    [BindProperty]
    public string message { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        SendMail(name, email, message);
        return Redirect("/Contact/?sendSuccess");
    }

    public void OnGet(int id)
    {
        if (Request.QueryString.HasValue && Request.QueryString.Value.Contains("sendSuccess"))
        {
            MessageSent = "Thanks for contacting us!";
        }
    }

    private void SendMail(string name, string email, string messageBody)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(name, email));
        message.To.Add(new MailboxAddress("Bucks Animal Shelter", "bucksanimalshelter@gmail.com"));
        message.Subject = "";
        message.Body = new TextPart("plain")
        {
            Text = messageBody
        };
        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("bucksanimalshelter", "WeloveJon!");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}