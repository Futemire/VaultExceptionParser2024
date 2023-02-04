# Summary
The Vault Exception Parser helps to parse Vault Errors and Restrictions from generic numbers to the actual message found in the Server Errors and Restrictions tables listed in the API documentation. To ensure the correct errors are returned you must use the VaultExceptionParser assembly that matches the year version of Vault Server returning the errors. This version of the VaultExceptionParser is intended for all flavors of Autodesk Vault 2023.

## Setup
To make the library available for use in your application add the VaultExceptionParser2023.dll as a reference to your project.
Make sure the VaultExceptionParser2023.dll is deployed with your library/application to aviod file not found exceptions when parsing an exception. 

## Use
The Vault Exception Parser contains all static methods and properties and is initialized upon first use, therefor you do not need to instantiate any objects on your own.
Simply call the code below from any Exception object.

```C#
try{
      /* Some code containing Vault API calls */
}
catch(Exception ex)
{
   /* 
      If the exception is a valid Vault Exception then the full error or restriction message is returned with 
      the original exception added as the InnerException, otherwise the original exception is returned. 
   */
   throw ex.ParseVaultException();
}
```
    
### Additional Versions
-	VaultExceptionParser2020
-	VaultExceptionParser2021
-	VaultExceptionParser2022
-	VaultExceptionParser2023


