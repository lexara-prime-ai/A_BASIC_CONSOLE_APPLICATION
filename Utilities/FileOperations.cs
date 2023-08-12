using BCrypt.Net;

namespace JituCourses.Utilities
{
    public static class FileOperations
    {
        // FILE NAME
        static string rdx_FILE_PATH = @"Data\Data.txt";

        /***************
       REGISTERED USERS
       ****************/
        static Dictionary<string, string> rdx_REGISTERED_USERS = new Dictionary<string, string>();

        /**********
        WRITE FILE
        ***********/
        public static void rax_WRITE_FILE(string? USER_NAME, string? USER_PASSWORD)
        {
            // HASH PASSWORD
            string rdx_HASHED_PASSWORD = BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            if (!File.Exists(rdx_FILE_PATH))
            {
                // CREATE FILE IF IT DOESN'T EXIST
                using (FileStream fileStream = File.Create(rdx_FILE_PATH))
                {
                    Console.WriteLine($"{Environment.NewLine}****Running file create participants****");
                }
            }

            File.AppendAllText(rdx_FILE_PATH, $"{USER_NAME},${rdx_HASHED_PASSWORD}\n");

            // REGISTRATION RESPONSE
            Console.WriteLine($"{USER_NAME} has been added!");
        }

        /*********
        READ FILE
        *********/
        public static Dictionary<string, string> rax_READ_FILE()
        {
            string[] rdx_USERS = File.ReadAllLines(rdx_FILE_PATH);

            foreach (string DATA in rdx_USERS)
            {
                string[] rdx_DATA = DATA.Split(',');

                if (rdx_DATA.Length == 2)
                {
                    string USER_NAME = rdx_DATA[0];
                    string USER_PASSWORD = rdx_DATA[1];

                    rdx_REGISTERED_USERS.Add(USER_NAME, USER_PASSWORD);
                }
                else
                {
                    Console.WriteLine("User not found...");
                }
            }
            return rdx_REGISTERED_USERS;
        }

        /*******************************
        CHECK FOR IF USER IS REGISTERED
        ******************************/
        public static bool rax_VALIDATE_USER(string _USER_NAME, string _USER_PASSWORD)
        {
            rax_READ_FILE();

            string rdx_STORED_PASSWORD;
            // CHECK IF USER EXISTS IN DICTIONARY
            if (rdx_REGISTERED_USERS.TryGetValue(_USER_NAME, out rdx_STORED_PASSWORD))
            {
                // CHECK IF STORED PASSWORD IS EQUAL TO PASSWORD INPUT
                if (BCrypt.Net.BCrypt.Verify(_USER_PASSWORD, rdx_STORED_PASSWORD))
                {
                    Console.WriteLine("Login successful!");
                    Console.WriteLine($"Welcome, {_USER_NAME}!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect password!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"User '{_USER_NAME}' not found.");
                return false;
            }
        }
    }
}