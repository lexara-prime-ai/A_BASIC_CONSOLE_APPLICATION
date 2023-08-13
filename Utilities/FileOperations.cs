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
        public static void rax_WRITE_FILE(string USER_NAME, string USER_PASSWORD)
        {
            // HASH PASSWORD
            string rdx_HASHED_PASSWORD = BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD);

            if (!File.Exists(rdx_FILE_PATH))
            {
                // CREATE FILE IF IT DOESN'T EXIST
                using (FileStream fileStream = File.Create(rdx_FILE_PATH))
                {
                    Console.WriteLine($"{Environment.NewLine}****Running file create participants****");
                }
            }

            File.AppendAllText(rdx_FILE_PATH, $"{USER_NAME},{rdx_HASHED_PASSWORD}\n");

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

            if (rdx_REGISTERED_USERS.ContainsKey(_USER_NAME))
            {
                string rdx_STORED_PASSWORD = rdx_REGISTERED_USERS[_USER_NAME];

                var isPasswordValid = BCrypt.Net.BCrypt.Verify(_USER_PASSWORD, rdx_STORED_PASSWORD);

                if (isPasswordValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("User Not Found!");
                return false;
            }
        }
    }
}