using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class createlogin : MonoBehaviour
{
    public InputField username;
    public InputField email;
    public InputField password;
    public InputField UsernameLogin;
    public InputField PassLogin;
    public GameObject Fail;

    IEnumerator CreateUser(string username, string email, string password)
    {
        string createUserURL = "http://localhost/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.error);
    }

    public void settext()
    {
        
    }

    public void CreateNewUser()
    {
        StartCoroutine(CreateUser(username.text, email.text, password.text));

    }


       IEnumerator Loginuser(string username, string password)
    {
        string LoginUrl = "http://localhost/nsirpg/Login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        
        form.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(LoginUrl, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);
        if (webRequest.downloadHandler.text == "0")
        {
            SceneManager.LoadScene(1);
            Fail.SetActive(false); 
        }
        else;
        {
            Debug.Log("passwrong");
            Fail.SetActive(true);
        }

    }

    public void Logininin()
    {
        StartCoroutine(Loginuser(UsernameLogin.text, PassLogin.text));

    }
}










////php 

 

//<?php 

//$server_name = "localhost"; 
//$server_username = "root"; 
//$server_password = ""; 
//$database_name = "NsiRpg";
////user variables 
//$username = $_POST["username"];
//$password = $_POST["password"]; 

////check connection 
//$conn = new mysqli($server_name, $server_username, $server_password, $database_name); 

//if(!$conn) 
//{
// die("Connection failed.".mysqli_connect_error());

//} 
////check users exsist  
////http://localhost/nsirpg/insertuser.php
//$namecheckquery = "SELECT username, salt, hash FROM users WHERE username = '".$username."';";
//$namecheck = mysqli_query($conn, $namecheckquery);
//if(mysqli_num_rows($namecheck) != 1)
//{
//echo "user error"; 
//exit();
//}	

////get login from query 
//$existinginfo = mysqli_fetch_assoc($namecheck); 
//$salt = $existinginfo["salt"];
//$hash = $existinginfo["hash"]; 

//$loginhash = crypt($password,  $salt ); 
//if($hash != $loginhash) 
//{
// echo "0";
// exit ();
//}
//else 
//{
//echo "1";	
//exit ();
//}

//?> 
//// 