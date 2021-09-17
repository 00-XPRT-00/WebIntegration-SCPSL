<?php
$dbhost = $_POST['dbhost'];
if ($_POST['dbhost'] == "127.0.0.1") {
  $dbhost = "localhost";
}
$dbhostname=$dbhost;
$dbhostport=$_POST['dbport'];
$dbusername=$_POST['dbuser'];
$dbpassword=$_POST['dbpass'];
$dbdatabase=$_POST['dbname'];
$dbdatatable=$_POST['dbtable'];

$sql = mysqli_connect($dbhostname.':'.$dbhostport,$dbusername,$dbpassword,$dbdatabase);
$option = $_POST['o'];
if ($option == "del" || $option == "ins") {
  $playerevent=true;
  $idcol = $_POST['idcol'];
  $uncol = $_POST['usercol'];
  $urcol = $_POST['rankcol'];
  $username = $_POST['username'];
  if ($option == "del"){
      $query = "DELETE FROM `$dbdatatable` WHERE `$uncol`='$username'";
      if (mysqli_query($sql, $query)){
        header('location: player-list'); // change player-list to the name of your php file if you changed it or 
      }
      else {
        echo mysqli_error($sql);
      }
  }
  else if ($option == "ins"){
    $id = $_POST['id'];
    $rank = $_POST['rank'];
    $query = "INSERT INTO `$dbdatatable` (`$idcol`, `$uncol`, `$urcol`) VALUES ('$id','$username','$rank')";
    if (mysqli_query($sql, $query)){
      header('location: player-list'); // change player-list to the name of your php file if you changed it

      // Write To The Config
      $posts[] = array('dbhost'=>$dbhostname, 'dbport'=>$dbhostport, 'dbuser'=>$dbusername, 'dbpass'=>$dbpassword, 'dbname'=>$dbdatabase, 'dbtable'=>$_POST['maindbtbl'], 'idcol'=>$idcol, 'uncol'=>$uncol, 'urcol'=>$urcol);
      $response['posts'] = $posts;

      $fp = fopen('auto-config.json', 'w');
      fwrite($fp, json_encode($response));
      fclose($fp);
    }
    else {
      echo mysqli_error($sql);
    }
  }
}
?>
