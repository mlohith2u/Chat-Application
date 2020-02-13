using System;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
public class SignXML
{
    public SignXML()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public byte[] Encryptpid(string toEncrypt, bool useHashing, byte[] keyArray)
    {
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        // Get the key from config file

        //  string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        //System.Windows.Forms.MessageBox.Show(key);
        //If hashing use get hashcode regards to your key
        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(keyArray);
            //Always release the resources and flush data
            //of the Cryptographic service provide. Best Practice

            hashmd5.Clear();
        }


        //  TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        RijndaelManaged tdes = new RijndaelManaged();
        //set the secret key for the tripleDES algorithm
        tdes.Key = keyArray;
        //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
        tdes.Mode = CipherMode.ECB;
        //padding mode(if any extra byte added)
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        //transform the specified region of bytes array to resultArray
        byte[] resultArray = cTransform.TransformFinalBlock
                (toEncryptArray, 0, toEncryptArray.Length);
        //Release resources held by TripleDes Encryptor
        tdes.Clear();
        //Return the encrypted data into unreadable string format
        return resultArray;
    }


    public void SignFilefrompath(string filename)
    {
        try
        {
            X509Certificate2 newcertificate = new X509Certificate2(@"E:\AGMTEAM\HMS\Application.Web\Application.Helpers\AadhaarauthHelpers\Certificates\Staging_Signature_PrivateKey.p12", "public");

            // Create a new RSA signing key and save it in the container. 
            RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)newcertificate.PrivateKey;

            // Create a new XML document.
            XmlDocument xmlDoc = new XmlDocument();

            // Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(@"E:\1.xml");

            // Sign the XML document. 
            SignXml(xmlDoc, rsaKey);

            Console.WriteLine("XML file signed.");

            // Save the document.
            xmlDoc.Save(@"E:\test.xml");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    // Sign an XML file.  
    // This document cannot be verified unless the verifying  
    // code has the key with which it was signed. 
    public static void SignXml(XmlDocument xmlDoc, RSA Key)
    {
        // Check arguments. 
        if (xmlDoc == null)
            throw new ArgumentException("xmlDoc");
        if (Key == null)
            throw new ArgumentException("Key");

        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(xmlDoc);

        // Add the key to the SignedXml document.
        signedXml.SigningKey = Key;


        Signature XMLSignature = signedXml.Signature;

        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";

        // Add an enveloped transformation to the reference.
        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);

        KeyInfo keyInfo = new KeyInfo();

        // Load the X509 certificate.
        X509Certificate MSCert = X509Certificate.CreateFromCertFile(@"E:\AGMTEAM\HMS\Application.Web\Application.Helpers\AadhaarauthHelpers\Certificates\uidai_auth_stage.cer");


        // Load the certificate into a KeyInfoX509Data object 
        // and add it to the KeyInfo object.

        KeyInfoX509Data keyInfoData = new KeyInfoX509Data(MSCert);
        keyInfoData.AddIssuerSerial(MSCert.Issuer, MSCert.GetSerialNumberString());
        keyInfoData.AddSubjectName(MSCert.Subject);
        keyInfo.AddClause(keyInfoData);

        // Add the KeyInfo object to the Reference object.
        XMLSignature.KeyInfo = keyInfo;

        // Add the reference to the SignedXml object.


        signedXml.AddReference(reference);

        // Compute the signature.
        signedXml.ComputeSignature();

        // Get the XML representation of the signature and save 
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();

        // Append the element to the XML document.
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

    }
}