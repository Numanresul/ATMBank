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
}
