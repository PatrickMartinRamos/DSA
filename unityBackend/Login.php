<?php


$servername = "localhost";
$username = "root";
$password = "";
$dbname = "player_details";

//variable submited by user

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
$playerID = $_POST["playerID"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) 
{
  die("Connection failed: " . $conn->connect_error);
}
echo "connected successfully, now will show the users.<br><br>";

$sql = "SELECT player_password,player_id FROM player WHERE player_name = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  
  // output data of each row
  while($row = $result->fetch_assoc()) 
  {
   if($row["player_password"] == $loginPass)
   {
    echo "log in successfully";
    //get user's data here.

    //get player score

    //update player score
    
   }
   else{
    echo "wrong credentials";
   }
  }

} else {
  echo "user does not exist";
}

$conn->close();
?>