# WebIntegration-SCPSL
A series of simple plugins that allow you to integrate a webserver with SCPSL
Works With 4 Servers (NAME MUST BE SAME ex. 'Garrys Server 1' and 'Garrys Modded Server 2' wouldnt work has to be: 'Garrys Server 1' and 'Garrys Server 2' so on)


# WebIntegration Players

After Installing And Configuring
================================
Players Will Be Logged To {web_address}/scp-server/player-list if you have more than one server others are accessible from {web_address}/scp-server/player-list-{server_num}

Pre Requisites
==============
- Website With PHP And FTP Access or XAMPP running Apache
- MySql Database e.g XAMPP running MySql (for each server make 1 table but at the end add _servernum ex. {tablename}, {tablename}_2, {tablename}_3, {tablename}_4 is for 4 servers - {tablename} is the name of your mysql table)

MySql Server With The Following Columns (names can be changed but need to update in the plugin config file)
================================
- userid - INT - Length Should Be Set To The Server Max Players + 2 ex. a 32 player server would be 34
- username - VARCHAR - 50
- userrank - VARCHAR - 50

Config
======
- Is Enabled - Enable / Disable Plugin
- Main Server Name - Where The Server Number Is Put {server_num} instead ex. MyServer [1] would be MyServer [{server_num}] - Not Needed If Only 1 Server
- Waiting For Players Message
- Player Join Message
- Player Leave Message
- Default Rank - The Rank That Will Show On The Database In Logged In Console By WebIntegrationPlayers For People With No Ranks
- Webserver Url - The IP / Domain For The Server Hosting The scp-server folder (only the domain no "/" e.g example.com/scp-server is where the folder should be located but put only example.com or a public ip address also do not need to specify www or http / https)
- Database Configuration

Database Configuration (skip to 5th if you are hosting locally and have not added a password to the root account)
======================
- Host IP - The Public IP For The Machine Hosting The Database
- Host Port - The Database Port (default is 3306)
- Username - The Login Username
- Password - The Login Password
- Database Name - The Name Of The Database
- Table Name - The Name Of The Table
- User ID Col Name - The Name Of The Column Holding The User ID
- Username Col Name - The Name Of The Column Holding The Username
- User Rank Col Name - The Name Of The Column Holding The User Rank
