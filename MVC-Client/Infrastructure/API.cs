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
    public static class Chat
    {
        public static string GetContacts(string baseUri, string name = "", string lastname = "") => $"{baseUri}/get-contacts?name={name}&lastName={lastname}";

        public static string GetFriends(string baseUri) => $"{baseUri}/get-friends";
        public static string AddFriend(string baseUri) => $"{baseUri}/add-friends";
        public static string GetNotification(string baseUri) => $"{baseUri}/get-notifications";
        public static string SendNotification(string baseUri) => $"{baseUri}/send-notification";
        public static string DeleteNotification(string baseUri, int id) => $"{baseUri}/delete-notification/{id}";
        public static string GetNotification(string baseUri,int id) => $"{baseUri}/get-notification/{id}";

        public static string GetMessages(string baseUri, string roomName) => $"{baseUri}/get-messages/{roomName}";

        public static string DeleteFriend(string baseUri, string room) => $"{baseUri}/delete-friend/{room}";


        public static string AcceptInviteGroup(string baseUri, string roomname = "", string emailForRomm= "") => $"{baseUri}/acceptInvete-group?roomName={roomname}&emailForRoom={emailForRomm}";
        public static string CreateGroup(string baseUri) => $"{baseUri}/create-group";
        public static string GetGroups(string baseUri) => $"{baseUri}/get-groups";


    }


}
