<?php
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
	$checkaccount = "SELECT password FROM users WHERE username = '".$username."'";
	$result = mysqli_query($conn, $checkaccount);
	
	// If we have usernames which match the username
	if(mysql_num_rows($result > 0))
	{
		// check passwords match
		while($row = mysqli_fetch_assoc($result))
		{
			if($row['password'] == $password)
			{
				echo "Login is a go";
			}
			else
			{
				echo "Incorrect password";
			}
		}
	}
	else
	{
		echo "User is negative";
	}
?>