using Plugin.Messaging;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
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
            if (IsValidFields())
            {
                //DisplayAlert("Aviso", "Selecione uma ferramenta de e-mail instalada neste dispositivo e apenas clique em enviar.", "OK");
                SendEmail();
            }

        }

        /// <summary>
        /// https://github.com/jstedfast/MailKit
        /// http://stackoverflow.com/questions/37791469/xamarin-forms-send-email-directly
        /// </summary>
        private void SendEmail()
        {
            var emailTask = MessagingPlugin.EmailMessenger;
            
            try
            {
                if (emailTask.CanSendEmail)
                {
                    emailTask.SendEmail("fernandesbartender@yahoo.com.br", "Novo Cliente - " + entryName.Text, "--------\n" + generateEmailBody(entryName.Text, entryEmail.Text, entryPhone.Text, entryMsg.Text, datepicker.Date.ToString("dd/MM/yyyy"), entryLocalEvento.Text));
                    DisplayAlert("Envio de Formulario - Instrução", "Ao selecionar seu aplicativo padrão de e-mail, apenas clique em enviar e entraremos em contato. Obrigado!", "OK");
                }
                else
                    DisplayAlert("Falha ao Enviar", "Falha ao enviar Email", "OK");
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", "Erro " + ex.Message, "OK");
            }

        }

        private bool IsValidFields()
        {
            if (entryName.Text == "" || entryPhone.Text == "" || entryEmail.Text == "" || entryLocalEvento.Text == "")
            {
                DisplayAlert("Erros no Formulário", "Todos os campos são obrigatorios!", "OK");
                return false;
            }
            if (!IsValidEmail(entryEmail.Text))
            {
                DisplayAlert("Erros no Formulário", "Email Invalido!", "OK");
                return false;
            }

            if(datepicker.Date <= DateTime.Today)
            {
                DisplayAlert("Erros no Formulário", "Data Invalida. Data selecionada precisa ser maior que a data de hoje!", "OK");
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string emailString)
        {
            if (emailString == "" || emailString == null) return false;

            return Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }



        private void btnSiteOficial_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.fernandesbartender.com.br"));
        }

        private String generateEmailBody(String nome, String email, String telefone, String mensagem, String dataEvento, String localEvento)
        {
            String body = "Nova solicitação de orçamento de " + nome + ".\n\n" +
                    "Email: " + email + "\nContato: " + telefone + "\nMensagem: " + mensagem + "\n" +
                    "Data do Evento: " + dataEvento + "\n" + "Local Evento: " + localEvento;

            return body;
        }
    }
}
