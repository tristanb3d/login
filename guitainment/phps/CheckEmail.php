<?php
	$servername = "localhost";
	$server_username = "root";
	$dbname = "sqlsystem";
	$server_password = "";
	
	$email = $_POST["email_Post"];
	
	// make connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	//check connection
	if(!$conn)
	{
		die("Connection Failed.".mysql_connect_error());
	}
	
	$checkemail = "SELECT username FROM users where email = '".$email."'";
	$checkemailresult = mysqli_query($conn, $checkemail);
	
	if(mysqli_num_rows($checkemailresult) > 0)
	{
		while ($row = mysqli_fetch_assoc($checkemailresult))
		{
				echo $row["username"];
							
		}
	}
	
	else
	{
		echo "There is no account associated with this email";
	}
	
?>