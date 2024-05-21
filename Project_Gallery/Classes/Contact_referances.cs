using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Gallery.Classes
{
    public class Contact_referances
    {
        public string image { get; set; }
        public string title { get; set; }

        public Contact_referances(string _image, string _title)
        {
            image = _image;
            title = _title;
        }

        public void Run()
        {
            if (title.StartsWith("http"))
            {

                Process.Start(new ProcessStartInfo
                {
                    FileName = title,
                    UseShellExecute = true

                });
            }
            if (title.Contains("@"))
            {
                string body = "Dear Tomer Chen \n We would like to contact you about a job offer \n Best Regards";
                string subject = "Job Offer";
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://mail.google.com/mail/u/0/?view=cm&fs=1&to=" + title + "&su=" + Uri.EscapeDataString(subject) + "&body=" + Uri.EscapeDataString(body),
                        UseShellExecute = true
                    });
                }
                catch
                {
                    Clipboard.SetText(title);
                    MessageBox.Show("An error occurred while opening Gmail My E-mail address has been added to your clipboard");
                }
            }
            if (title.StartsWith("+"))
            {
                string body = "Dear Tomer Chen \n We would like to contact you about a job offer \n Best Regards";
                try
                {
                    string whatsAppUri = $"https://web.whatsapp.com/send?phone={title}&text={Uri.EscapeDataString(body)}";

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = whatsAppUri,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Clipboard.SetText(title);
                    MessageBox.Show("An error occurred while opening WhatsApp My phone number has been added to your clipboard");
                }
            }

        }
    }
}
