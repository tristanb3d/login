// start php script
<?php
	// variables have $
	$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbname = "sqlsystem";

	$username = $_POST["username_Post"]; // waiting for username to be sent
	$email = $_POST["email_Post"];
	$password = $_POST["password_Post"];
	
	// make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	//check connection
	if(!$conn)
	{
		die("Connection Failed.".mysql_connect_error());
	}
	// Make sure username is within database
	$checkuser =  "SELECT username FROM users";
	$checkuserresult = mysqli_query($conn, $checkuser);
	
	if(mysqli_num_rows($checkuserresult) > 0)
	{
		while($row = mysqli_fetch_assoc($checkuserresult))
		{
			if($row["username"] == $username)
			{
				print "User Already Exists";
			}
			else
			{
				$debug = "check email";
				print "check email";
			}				
		}
	}
	else if (mysqli_num_rows($checkuserresult) <=0)
	{
		$createuser = "INSERT INTO users(username, email, password) VALUES('".$username.";','".$email."', '".$password."')";
		$createuserresult = mysqli_query($conn, $createuser);
		if(!$createuserresult)
		{
			print "Error";
		}
		else
		{
			print "This is fine";
		}
	}
	if($debug == "check email")
	{
		$checkemail = "SELECT email FROM users"; // We need to check email... what do we say?
		$checkemailresult = mysqli_query($conn,$checkemail);
		if(mysqli_num_rows($checkemailresult) > 0)
		{
			 while($row = mysqli_fetch_assoc($checkemailresult))
            {
                if($row['email'] == $email)
                {
                    print "Email Already Exists";//echo and print are the same
                }
                else
                {
                    $createuser = "INSERT INTO users(username, email, password) VALUES('".$username."', '".$email."','".$password."')";
                    $createuserresult = mysqli_query($conn, $createuser);
                    if(!$createuserresult)
                    {
                        print "Error";
                    }
                    else
                    {
                        print "Create User";
                    }
                }
            }		
		}
	}
?>