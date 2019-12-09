using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;

public class ForgotUsernamePassword : MonoBehaviour
{
    private string characters = "0123456789abcdefghijklmnopqrstuvwxyz";
    private string code = "";
    public GameObject emailerrortextpanel;
    public TextMeshProUGUI notification;
    private string _username;
    public GameObject codesub;
    public TMP_InputField inputCode;
    public GameObject changepasswordpanel;

    public GameObject upPass;

    void CreateCode() // Creates a random code using the above characters to a length of 10
    {
        for (int i = 0; i < 10; i++)
        {
            int a = UnityEngine.Random.Range(0, characters.Length);
            code = code + characters[a];
        }
        Debug.Log(code);
    }

    public void SendEmail(TMP_InputField _email)
    {
        CreateCode();
        MailMessage mail = new MailMessage();
        //Email that the Receiver sees
        mail.From = new MailAddress("DontRespond@BlahBlah.com");
        //Email we send to that the user inputs
        mail.To.Add(_email.text);
        //subject of email
        mail.Subject = "NSIRPG Password Reset";
        //body of email ( the email will address you by saying hello then username) followed by a code
        mail.Body = "Hello " + _username + "\nReset using this code: " + code;

        // Connect to google
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        // Be able to send through ports
        smtpServer.Port = 25;
        // Login to google
        smtpServer.Credentials = new NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        { return true; };
        // Send message
        smtpServer.Send(mail);
        Debug.Log("Sending Email");
        codesub.SetActive(true);
    }

    IEnumerator ForgotPassword(TMP_InputField _email)
    {
        string forgottonPasswordURL = "http://localhost/nsirpg/CheckEmail.php";
        WWWForm form = new WWWForm();
        form.AddField("email_POST", _email.text);
        if (_email.text != null)
        {
            emailerrortextpanel.gameObject.SetActive(true);
        }

        UnityWebRequest webRequest = UnityWebRequest.Post(forgottonPasswordURL, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);
        if (webRequest.downloadHandler.text == "User Not Found")
        {
            //ERROR
            notification.text = webRequest.downloadHandler.text;
        }
        else
        {
            // If it all works the result will be the username
            _username = webRequest.downloadHandler.text;
            SendEmail(_email);
        }
    }
    public void ResetPassword(TMP_InputField _email)
    {
        Debug.Log(_email.text);
        StartCoroutine(ForgotPassword(_email));
    }
    public void CheckCode()
    {
        if (inputCode.text == code)
        {
            codesub.SetActive(false);
            upPass.SetActive(true);
        }
    }


    IEnumerator UpdatePassword(TMP_InputField _password)
    {
        string passwordURL = "http://localhost/nsirpg/UpdatePassword.php";
        WWWForm form = new WWWForm();
        form.AddField("password_POST", _password.text);
        form.AddField("username_POST", _username);
        UnityWebRequest webRequest = UnityWebRequest.Post(passwordURL, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);

    }
    public void SetPassword(TMP_InputField _password)
    {
        StartCoroutine(UpdatePassword(_password));
    }
}
