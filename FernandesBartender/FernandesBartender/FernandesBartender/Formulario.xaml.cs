
using Android.Content;
using System;
using Xamarin.Forms;

namespace FernandesBartender
{
    public partial class Formulario : ContentPage
    {
        public Formulario()
        {
            InitializeComponent();
        }
        private void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (DateTime.Now > e.NewDate)
            {
                DisplayAlert("Data Inválida", "Por favor selecione uma data valida!", "OK");
            }
        }

        private void entryMsg_Focused(object sender, FocusEventArgs e)
        {
            entryMsg.Text = "";
        }

        private void btnSend_Clicked(object sender, EventArgs e)
        {
            //TODO validar campos
            //TODO verificar se aparecelho tem conexao com internet

            SendEmail();

           /* if (IsValidFields())
            {
                SendEmail();
                DisplayAlert("Envio de Formulario", "Solicitação de Bartender Enviada. Aguarde e Entraremos em Contato!", "OK");
            }
            else
            {
                DisplayAlert("Erros no formulario", "Preencha os campos adequadamente", "OK");
            }*/

        }

        /// <summary>
        /// https://github.com/jstedfast/MailKit
        /// http://stackoverflow.com/questions/37791469/xamarin-forms-send-email-directly
        /// </summary>
        private void SendEmail()
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "person1@xamarin.com", "person2@xamrin.com" });

            email.PutExtra(Android.Content.Intent.ExtraCc,
            new string[] { "person3@xamarin.com" });

            email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");

            email.PutExtra(Android.Content.Intent.ExtraText,
            "Hello from Xamarin.Android");

            email.SetType("message/rfc822");
            //StartActivity(email);
            Context.StartActivity(Android.Content.Intent)
        }

        /*private bool IsValidFields()
        {
            throw new NotImplementedException();
        }*/

        private void btnSiteOficial_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.fernandesbartender.com.br"));
        }

        private String generateEmailBody(String nome, String email, String telefone, String mensagem, String dataEvento, String localEvento)
        {
            String body = "Olá Fernando, <br/> <t>Nova solicitação de orçamento de " + nome + ".<br/><br/><t>" +
                    "Email do cliente: " + email + "<br/><t> Telefone de contato: " + telefone + "<br><t> Mensagem: " + mensagem + "<br><t>" +
                    "Data do Evento: " + dataEvento + "<br><t>" + "Local Evento: " + localEvento;

            return body;
        }
    }
}
