namespace MVC_Client.Infrastructure;

public static class API
{

    public static class Identity
    {
        public static string RegistrationUniversity(string baseUri) => $"{baseUri}/registr-manager/temp-saving";
        public static string RegistrationUser(string baseUri) => $"{baseUri}/registr-user/temp-saving";
        public static string RegistrationStudent(string baseUri) => $"{baseUri}/registr-student";
        public static string AuthUser(string baseUri) => $"{baseUri}/api/Authentication/Login-user";


    }
}
