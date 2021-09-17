<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Player List Viewer</title>
    <link rel="stylesheet" href="player-list.css">
</head>
<body>
    <table>
        Server 1
        <tr>
        <th>User ID</th>
        <th>NickName</th>
        <th>Rank</th>
        </tr>
        <?php
        sleep(5);
        $json = file_get_contents('auto-config.json');
        $arr = json_decode($json, true);
                            
        if (!$json) {die;} else {
            $dbjson = $arr["posts"][0];
            $dbhostname=$dbjson['dbhost'];
            $dbhostport=$dbjson['dbport'];
            $dbusername=$dbjson['dbuser'];
            $dbpassword=$dbjson['dbpass'];
            $dbdatabase=$dbjson['dbname'];
            $dbdatatable=$dbjson['dbtable'];

            $sql = mysqli_connect($dbhostname.':'.$dbhostport,$dbusername,$dbpassword,$dbdatabase);
            $con = $sql;
            $s = "SELECT * FROM `$dbdatatable`";
            $result = mysqli_query($con, $s);
            if (mysqli_num_rows($result) > 0) {
                while ($row = mysqli_fetch_assoc($result)){
                    echo "<tr><td>".$row[$dbjson['idcol']]."</td><td>".$row[$dbjson['uncol']]."</td><td>".$row[$dbjson['urcol']]."</td>";
                }
            }
        }
        ?>
    </table>
</body>
</html>