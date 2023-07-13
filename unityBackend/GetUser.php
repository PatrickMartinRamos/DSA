<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "player_details";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT player_name, player_score, player_id FROM player ORDER BY player_score DESC LIMIT 5";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "Player: " . $row["player_name"]. " - Score: " . $row["player_score"]."<br>";
  }
} else {
  echo "0 results";
}

$conn->close();
?>
