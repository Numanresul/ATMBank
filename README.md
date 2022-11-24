# ATMBank
NET6,WebApi,EfCore,Linq,Nlayer,JWT Auth
# Requeriments
VS2022, NET6 FRAMEWORK, POSTGRE10
# Description

When this project is launched with visual studio 2022, if Postgre10 is installed on the machine and the correct database information is entered in the DbContext, it will automatically create all tables and default data.

First of all, jwt should be obtained with the SignIn method. The default user information for this is as follows.</br>
{
   "pin": 1234,
   "identityNumber": 111222333444
}</br>

The equivalents of the "AccountType" value that will be sent to the endpoints to withdraw and deposit money are as follows.</br>
  "AccountType":1  ==> TRY</br>
  "AccountType":2  ==> EUR</br>
  "AccountType":3  ==> USD</br>
  
  In addition, the postman collection that creates requests to all endpoints has been added to the project directory. All urls of the project and data to be posted are available in this postman collection.</br>
  
  Again, there is a visual showing the diagram of the database created in the project directory.</br>

