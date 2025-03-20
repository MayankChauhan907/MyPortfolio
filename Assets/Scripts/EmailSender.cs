using System;
using UnityEngine;

public class EmailSender : MonoBehaviour
{
    public void SendEmail()
    {
        string email = "mayankdarbar907@gmail.com"; // Your email
        string subject = Uri.EscapeDataString("Interested in Your Work"); // Default subject
        string body = Uri.EscapeDataString("Hi Mayank, \n\nI’d love to connect with you!"); // Default body text

        string mailto = $"mailto:{email}?subject={subject}&body={body}";
        Application.OpenURL(mailto);
    }
}

