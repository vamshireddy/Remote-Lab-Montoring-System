Remote-Lab-Montoring-System
===========================

Making the lab maintenence easy!

##Features

* Help the faculty to know the current state of any system in any Lab
* Provide the details of processes running in that particular system.
* Provide the screenshot's of the Desktop to the admin.
* Provision to switch off the system remotely
* CPU usage statistics
* Provide Network connection details ( IP, MAC,DNS, Gateway, Subnet Mask )

## Architecture

* Server will be listening for the request from the Faculty.
* Faculty can open the website which will be built on ASP.NET and can browse the labs and computer's list.
* On clicking a computer, the query is sent to the server, which will be processed and the reply is sent back which contains the details opted.
* When a request hits the server, it processes in the background, making a connection with the desired Lab Computer ( which has daemon running ) and gets the stats,pics etc.
* These obtained stats on the server are sent back to the Faculty member on the same HTTP connection.
* During this processing time, the website should make the user know that its processing and he/she should wait untill its done.

## Benefits

* HOD can browse what students are currently working on.
* Faculty can see the progress of a student in a lab.
* Can remotely shutdown PC's if they are on.
