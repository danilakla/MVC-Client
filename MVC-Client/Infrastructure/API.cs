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
    public static class Profile
    {
        public static string GetSkill(string baseUri,int id) => $"{baseUri}/get-skill/{id}";
        public static string AddSkill(string baseUri) => $"{baseUri}/create-skill";
        public static string DeleteSkill(string baseUri, int id) => $"{baseUri}/delete-skill/{id}";
        public static string UpdateSkill(string baseUri) => $"{baseUri}/update-skill";

        public static string GetProfile(string baseUri) => $"{baseUri}/GetProfile";
        public static string UpdateProfile(string baseUri) => $"{baseUri}/UpdateProfile";

        public static string UpdateIconProfile(string baseUri) => $"{baseUri}/UpdatePhotoProfile";
        public static string UpdateBgProfile(string baseUri) => $"{baseUri}/UpdateProfileBackPhoto";

        public static string GetProject(string baseUri, int id) => $"{baseUri}/get-project/{id}";
        public static string AddProject(string baseUri) => $"{baseUri}/create-project";
        public static string DeleteProject(string baseUri, int id) => $"{baseUri}/delete-project/{id}";
        public static string UpdateProject(string baseUri) => $"{baseUri}/update-project";



    }



}
