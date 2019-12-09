using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public TMPro.TMP_InputField username;
    public TMPro.TMP_InputField email;
    public TMPro.TMP_InputField password;
    public GameObject createerrortextpanel;
    public TextMeshProUGUI notification;
    //public TextMeshProUGUI text;
    IEnumerator CreateUser(string username, string email, string password)
    {
        string createUserURL = "http://localhost/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);
        if (username != null || email != null || password != null)
        {
            createerrortextpanel.gameObject.SetActive(true);
        }

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);
        notification.text = webRequest.downloadHandler.text;
    }
    public void CreateNewUser()
    {
        StartCoroutine(CreateUser(username.text, email.text, password.text));
    }
    public void LoginGame()
    {

    }
}
