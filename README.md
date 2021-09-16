# WebIntegration-SCPSL
A Integrated Web Plugin For SCPSL Servers

Pre Requisites
==============
- Website With PHP And FTP Access or XAMPP running Apache
- MySQL / MariaDB Database e.g XAMPP running MySql



Web Integration Players
=======================

MySql With The Following Columns
================================
- userid - INT - Length Should Be Set To The Server Max Players + 2 ex. a 32 player server would be 34
- username - VARCHAR - 50
- userrank - VARCHAR - 50

Config
======
- IsEnabled - Enable / Disable Plugin
- Database Configuration

Database Configuration (skip to 5th if you are hosting locally and have not added a password to the root account)
======================
- Web Address - The IP / Domain For The Server Hosting The scp-server folder (only the domain no "/" e.g example.com/scp-server is where the folder should be located but put only example.com or a public ip address also do not need to specify www or http / https)
- Host IP - The Public IP For The Machine Hosting The Database
- Host Port - The Database Port (default is 3306)
- Username - The Login Username
- Password - The Login Password
- Database Name - The Name Of The Database
- Table Name - The Name Of The Table
- User ID Col Name - The Name Of The Column Holding The User ID
- Username Col Name - The Name Of The Column Holding The Username
- User Rank Col Name - The Name Of The Column Holding The User Rank

Or Follow This Guide: 
