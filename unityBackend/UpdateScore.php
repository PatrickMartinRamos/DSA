<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "player_details";

$playerScore = $_POST["playerScore"];
$loginUser = $_POST["loginUser"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "UPDATE player SET player_score = '". $playerScore ."' WHERE player_name = '". $loginUser ."'";

if ($conn->query($sql) === TRUE) {
  echo "Record updated successfully";
} else {
  echo "Error updating record: " . $conn->error;
}

$conn->close();
?>
