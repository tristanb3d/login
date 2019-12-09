<?php

	$servername = "localhost";
	$server_username = "root";
	$dbname = "sqlsystem";
	$server_password = "";
	
	$email = $_POST["email_Post"];
	$password = $_POST["password_Post"];
	
	// make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	//check connection
	if(!$conn)
	{
		die("Connection Failed.".mysql_connect_error());
	}
	
	$resetPassword = "UPDATE users SET password = '".$password."' WHERE email = '".$email."'";
	$result = mysqli_query($conn, $resetPassword);
	
	if(!$result)
	{
		echo "Error";
	}
	else
	{
		echo "Password updated"
	}
?>