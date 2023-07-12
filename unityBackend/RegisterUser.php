<?php


$servername = "localhost";
$username = "root";
$password = "";
$dbname = "player_details";

//variable submited by user

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) 
{
  die("Connection failed: " . $conn->connect_error);
}
echo "connected successfully, now will show the users.<br><br>";

$sql = "SELECT player_name FROM player WHERE player_name = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  //tell user that "that name is already taken"
  echo "Player name is already taken.";
 
} else {
  echo "Creating user...";
  //insert the user and the password into the database
  $sql_2 = "INSERT INTO player (player_name, player_password, player_score)
VALUES ('". $loginUser ."','".$loginPass ."' ,0)";
}
if ($conn->query($sql_2) === TRUE) {
  echo "New record created successfully";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>