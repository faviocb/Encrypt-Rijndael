<HTML>
<%
' This VBScript ASP file tests the accompanying rijndael.asp for
' encryption using the Rijndael AES block cipher algorithm
%>
<!--#include file="rijndael.asp"-->
<%
    Dim i
    Dim nb
    Dim nk
    Dim key(31)
    Dim block(31)
    Dim sTemp
    Dim sPlain
    Dim sPassword
    Dim bytIn()
    Dim bytPassword()
    Dim lCount
    

    sPlain = "woot woot - This is the original text 12345@67890"
    sPassword = "P@ssw0rd"

    Response.Write "Message=" & sPlain & "<BR>"
    Response.Write "Key=" & sPassword & "<BR>"

	
	
    lLength = Len(sPlain)
    ReDim bytIn(lLength-1)
    For lCount = 1 To lLength
        bytIn(lCount-1)=CByte(AscB(Mid(sPlain,lCount,1)))
    Next
	
	
	
    lLength = Len(sPassword)
    ReDim bytPassword(lLength-1)
    For lCount = 1 To lLength
        bytPassword(lCount-1)=CByte(AscB(Mid(sPassword,lCount,1)))
    Next
    
	
    bytOut = EncryptData(bytIn, bytPassword)
    
	
    sTemp = ""
    For lCount = 0 To UBound(bytOut)
        sTemp = sTemp & Right("0" & Hex(bytOut(lCount)), 2)
    Next
	
	
	
    Response.Write "Encrypted=" & sTemp & "<BR>"
    
    bytClear = DecryptData(bytOut, bytPassword)

	
	
	
    lLength = UBound(bytClear) + 1
    sTemp = ""
    For lCount = 0 To lLength - 1
        sTemp = sTemp & Chr(bytClear(lCount))
    Next
	
	
	
    Response.Write "Decrypted=" & sTemp & "<BR>"

%>
</HTML>
