namespace Apacs.SDK.Web {
    class ApacsExample {
        static string userLogin="user";
        static string userPassword="password";
        static string apacsApiUrl="http://localhost:7110/v1/";

        static ApacsStub apacsStub;
        
        static void Main() {
            apacsStub = new ApacsStub(userLogin, userPassword, apacsApiUrl);

            apacsStub.GetRoot();
        }
    }
}