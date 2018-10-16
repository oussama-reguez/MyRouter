using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace myRouter
{
   public  class  RouterEngine



    {


        public const string MODULATION="modulation";
        public const string STATUS = "status";
        public const string UPSTREAM = "upstream";
        public const string DOWNSTEAM = "downstream";
        public const string INTERNET = "internet";
        public Request authentication = null;
        public Parameter username = null;
        public Parameter password=null;
        public Boolean rebooting;
        public static Router router;
        private Boolean authenticated = false;

        


        public Router Router
        {
            get { return router; }
            set { router = value; }

        }



        private void getUserCredential()
        {

            
            foreach(Request request in router.Requests)
            {
                if (request.Name.Equals("authentication"))
                {
                    authentication = request;
                    foreach (Parameter parametre in request.Parameters)
                    {
                        if (parametre.Type.Equals("username"))
                        {
                           
                            username = parametre;
                        }
                        if (parametre.Type.Equals("password"))
                        {
                           
                            password = parametre;
                        }
                    }
                    return;
                }
            }
           
        }

        public RouterEngine (Router router)
        {
            RouterEngine.router = router;
            getUserCredential();
        }

    public  void authenticate()
        {
          

        }



        private static void encryptRouter(Router router)
        {

            XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));
            MemoryStream memo = new MemoryStream();
            SerializerObj.Serialize(memo, router);

            // Cleanup
            memo.Position = 0;
            MemoryStream ms;
            try
            {
                string theKey = @"mykeyismyroutercreatedbyoussamareguezliveinhammemzriba";
                byte[] salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(theKey, salt);



                RijndaelManaged RMCrypto = new RijndaelManaged();

                FileStream fileStream = new FileStream(WpfApplication4.MainWindow.appDirectory + "/router.mtlc", FileMode.Create);
                CryptoStream cs = new CryptoStream(fileStream,
                    RMCrypto.CreateEncryptor(pdb.GetBytes(32), pdb.GetBytes(16)),
                    CryptoStreamMode.Write);

                //

                int data;
                while ((data = memo.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);
                }





                memo.Close();
                cs.Close();




                //fsCrypt.Close();
            }
            catch
            {

            }












        }
        private static CryptoStream decryptRouter()
        {
            string theKey = @"mykeyismyroutercreatedbyoussamareguezliveinhammemzriba";
            byte[] salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(theKey, salt);

            FileStream fsCrypt = new FileStream(WpfApplication4.MainWindow.appDirectory+"/router.mtlc", FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(pdb.GetBytes(32), pdb.GetBytes(16)),
                CryptoStreamMode.Read);
            return cs;

        }
        private static Router createRouter(CryptoStream cs)

        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));


            // Load the object saved above by using the Deserialize function
            Router router = (Router)SerializerObj.Deserialize(cs);
            return router;
        }
        public string getInformation(string value, int lineNumber, int columnNumber, int length)
        {
            string line = GetLine(value, lineNumber);
            string result = line.Substring(columnNumber, length);




            return result;
        }
        

        public Request getRequestbyResult(String resultName)
        {


            return null;
        }


        public string getAdslState

        {
            get
            {
                if (router.DownStream == 0)
                {
                    return "on";
                }
                else
                {
                    return "false";
                }
            }
        }



        public string WhateverString

        {
            get
            {
                return "hello";
            }
        }



        public Boolean checkAlive()
        {

           

            Boolean alive = true;

            try
            {
                executeRequest(authentication);


            }

            
            catch (Exception ex)
            {
                alive = false;

             

                Console.WriteLine("exception we" + ex.Message);
              
            }
           

            finally
            {
                Console.WriteLine("alive ? " + alive);
               
            }
            return alive;


        }

        public void updateStatus()
        {
            if (rebooting == true)
            {
                return;
            }
            List<Request> resultRequest = new List<Request>();
            List<Result> results = new List<Result>();
            // searching all the requests where they have results
            foreach ( Request request in router.Requests)
            {
                if (request.Results != null && request.Results.Count!=0)
                {
                    resultRequest.Add(request);
                }


            }


            Console.WriteLine("count" + resultRequest.Count);


            foreach (Request req in resultRequest)
            {

              List<Result> resultss=  executeRequest(req);
                
                foreach(Result result in resultss)
                {
                    results.Add(result);
                }

               

            }
            foreach(Result result in results)
            {

                if (result.Name.Equals(STATUS))
                {
                    router.Status = result.Value;
                }

                if (result.Name.Equals(MODULATION))
                {
                    router.Modulation = result.Value;
                }

                if (result.Name.Equals(UPSTREAM))
                {
                    try
                    {
                        router.UpStream = Int32.Parse(result.Value);
                    }
                    catch(System.FormatException ex)
                    {
                        router.UpStream = 0;
                    }
                  
                }
                if (result.Name.Equals(DOWNSTEAM))
                {
                    try
                    {
                        router.DownStream= Int32.Parse(result.Value);
                    }
                    catch (System.FormatException ex)
                    {
                        router.DownStream = 0;

                    }
                }

                if (result.Name.Equals(INTERNET))
                {
                    Console.WriteLine("internet ip from router" + result.Value);
                    string input = result.Value.Trim();
                    

                    IPAddress address;
                    if (IPAddress.TryParse(input, out address))
                    {
                        switch (address.AddressFamily)
                        {
                            case System.Net.Sockets.AddressFamily.InterNetwork:
                                router.Internet = input;

                                break;
                            case System.Net.Sockets.AddressFamily.InterNetworkV6:
                                router.Internet = input;

                                break;
                            default:
                                // umm... yeah... I'm going to need to take your red packet and...
                                break;
                        }
                    }
                    else
                    {
                        router.Internet = "0.0.0.0";                    }
                  
                   
                }




            }

            







        }

        string GetLine(string text, int lineNo)
        {
            string[] lines = text.Replace("\r", "").Split('\n');





            return lines.Length >= lineNo ? lines[lineNo - 1] : null;



        }


       

        public Boolean checkAdsl()
        {

            return false;
            if (router.UpStream == 0)
            {
                return false;
            }
            return true;
        }

        public List<Result> executeRequest(string requestName)
        {
            int i = 0;

            Boolean requestFound = false;
            foreach(Request request in router.Requests)
            {
                

                if (request.Name.Equals(requestName))

                {
                    Console.WriteLine(request.Url);


                    List<Result> results = executeRequest(request);
                    Console.WriteLine("done executing");
                    return results;
                }
                i++;
            }

           
            return null;
        }

        public string sayHello()
        {
            return "hello ";
        }
        public   List<Result>  executeRequest(Request request)

           
        {
            List<Result> results = null;

            HttpWebRequest httpRequest=null ;

            String param = "";
            string url = "http://" + router.Ip + "/" + request.Url;


            if (!request.Type.Equals("GET"))
            {
                // post request

                httpRequest = (HttpWebRequest)WebRequest.Create(url);

                if (request.Name == "authentication")
                {
                    
                    param = username.Name + "=" + username + "&" + password.Name + "=" + password;
                        ;

                }
                else
                {
                    param = request.Parameters[0].Name + "=" + request.Parameters[0].Value;

                    for (int i = 1; i < request.Parameters.Count; i++)
                    {
                        param += "&" + request.Parameters[i].Name + "=" + request.Parameters[i].Value;
                    }
                }

                
                   

                    httpRequest.Method = "POST";
                    httpRequest.ContentType = "application/x-www-form-urlencoded";

               

                Console.WriteLine("hellosdfsdf sqsdfsqdfsqdfqsfqdsf");
                Console.WriteLine(param);
               
                var data = Encoding.ASCII.GetBytes(param);


                httpRequest.ContentLength = data.Length;
                using (var stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }



            /// get request 

            else


            {
                if (request.Parameters != null && request.Parameters.Count!=0)
                {

                    param = "?" + request.Parameters[0].Name + "=" + request.Parameters[0].Value;

                    for (int i = 1; i < request.Parameters.Count; i++)
                    {
                        param += "&" + request.Parameters[i].Name + "=" + request.Parameters[i].Value;
                    }

                }


                Console.WriteLine("starting to launch");

               
               
                    httpRequest = (HttpWebRequest)WebRequest.Create(url + param);
                     httpRequest.Timeout = 3000;
               
                
              
                

               





            }


            if (router.Authentication == "Header")
            {
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username.Value + ":" + password.Value));
                httpRequest.Headers.Add("Authorization", "Basic " + encoded);
            }
            else
            {
                if (authenticated==false)
                {
                    
                }


            }


            Console.WriteLine("starting to launch");
            HttpWebResponse response;



            using (response = (HttpWebResponse)httpRequest.GetResponse())
            {
                ;
                Console.WriteLine("done launching");

                if (request.Results != null && request.Results.Count != 0)


                {

                    string html = "";
                    string finalResult = "";
                    using (Stream stream = response.GetResponseStream())



                    using (StreamReader reader = new StreamReader(stream))
                    {

                        int i = 1;
                        int k = 1;

                        foreach (Result result in request.Results)
                        {


                            int s = result.LineNumber;


                            for (i = k; i <= s; i++)
                            {
                                html = reader.ReadLine();



                            }



                            k = s + 1;
                            if (result.Regex != null)
                            {
                                Regex regex = new Regex(result.Regex.Trim('"'));
                                var v = regex.Match(html);
                                finalResult = v.Groups[1].ToString();
                            }
                            else
                            {
                                finalResult = html.Substring(result.ColumnNumber, result.Length);
                            }

                            result.Value = finalResult;


                            Console.WriteLine(finalResult);

                        }

                        // html = reader.

                    }


                    response.Close();
                    httpRequest.Abort();

                    return request.Results;
                }
            }




            response.Close();
            httpRequest.Abort();
            return results;
        }


         

           // var request = (HttpWebRequest)WebRequest.Create("http://www.example.com/recepticle.aspx");

            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

    }

