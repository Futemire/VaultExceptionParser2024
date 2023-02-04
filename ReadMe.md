# Instructions for Updating

<hr/>
The Vault Error Parser must be updated for every new Vault version released to match its most current API and Error Codes.

## Updating the API

The two .dlls that are used in this library and will need to be replaced yearly are:

- *Autodesk.Connectivity.WebServices.dll*
- *Autodesk.Connectivity.WebServices.dll.WCF*

You can find these files in one of two locations:

- C:\Program Files\Autodesk\Vault Client \<YEAR\>\Explorer\
- C:\Program Files\Autodesk\Autodesk Vault \<YEAR\> SDK\bin\x64

### Vault Api Versions
-	Vault 2020 = 25
-	Vault 2021 = 26
-	Vault 2022 = 27
-	Vault 2023 = 28

<hr/>
## Updating Error Codes

The error codes for Vault are hidden in the Vault SDK documentation:<br/>
![Vault S D K Contents](Resources/VaultSDKContents.png)

The Vault SDK must be installed before the document will be available.<br/>
To install the SDK navigate to...<br/>
C:\Program Files\Autodesk\Vault Client 2022\SDK\ and run **Setup.exe**.<br/>  

Then the **VaultSDK.chm** will be at... <br/>
C:\Program Files\Autodesk\Autodesk Vault 2022 SDK\docs\VaultSDK.chm

Open the *VaultSDK.chm* file and select Server Error Codes.<br/>
In the table starting in the top left cell "Code" select and hold the left mouse button down while using your mouse wheel to scroll all the way to the bottom right cell of the table.<br/>
Once selected copy the contents into a file named **ErroCodes.txt** (naming is important).<br/>
Save the file to the Resources folder of this project overwriting the previous file.<br/>
Error Codes will now reflect the newest version.
<hr/>