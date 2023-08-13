using JituCourses.Models;

namespace JituCourses.Utilities
{
    public static class Authentication
    {
        /*********************
        AUTHENTICATION OPTIONS 
        **********************/
        static Dictionary<int, string> rdx_AUTHENTICATION_OPTIONS = new Dictionary<int, string>()
        {
            { 1, "Register" },
            { 2, "Login" }
        };

        // USER INPUT
        static string? rdx_USER_NAME;
        static string? rdx_USER_PASSWORD;

        /*****************************
        DISPLAY AUTHENTICATION OPTIONS 
        ******************************/
        public static void rax_DISPLAY_AUTHENTICATION_OPTIONS()
        {
            // LOOP THROUGH OPTIONS
            foreach (KeyValuePair<int, string> option in rdx_AUTHENTICATION_OPTIONS)
            {
                Console.WriteLine($"{option.Key}. {option.Value}");
            }
            // MEHOD CALL : Receive User Input
            rax_AUTHENTICATE_USER();
        }

        /*****************
        RECEIVE USER INPUT 
        ******************/
        public static void rax_AUTHENTICATE_USER()
        {
            // READ USER INPUT
            int rdx_SELECTED_OPTION = Int32.Parse(Console.ReadLine());

            // HANDLE USER REGISTRATION : Select Option 1
            if (rdx_SELECTED_OPTION == 1)
            {
                string rdx_Username_AlertBox = AlertBox.rax_DISPLAY_ALERT_BOX("Create a username >");

                Console.WriteLine(rdx_Username_AlertBox);
                rdx_USER_NAME = Console.ReadLine();

                // VALIDATE INPUT
                if (string.IsNullOrWhiteSpace(rdx_USER_NAME))
                {
                    Console.WriteLine("Please provide valid username");

                    // RETURN TO LOGIN SECTION
                    rax_DISPLAY_AUTHENTICATION_OPTIONS();
                }
                else
                {
                    // PROCEED IF USER INPUT IS VALID
                    string rdx_Password_AlertBox = AlertBox.rax_DISPLAY_ALERT_BOX("Create a password >");
                    Console.WriteLine(rdx_Password_AlertBox);

                    rdx_USER_PASSWORD = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(rdx_USER_PASSWORD))
                    {
                        Console.WriteLine("Invalid input....");

                        // RETURN TO LOGIN SECTION
                        rax_DISPLAY_AUTHENTICATION_OPTIONS();
                    }
                    else
                    {
                        // REGISTER USER
                        Console.WriteLine($"{Environment.NewLine}Registration in progress....");
                    }
                }

                // KEEP TERMINAL OPEN AND RECEIVE USER INPUT
                FileOperations.rax_WRITE_FILE(rdx_USER_NAME, rdx_USER_PASSWORD);

                // DISPLAY ADDITIONAL INSTRUCTIONS
                Console.WriteLine($"{Environment.NewLine}Please Login | Register to continue...");

                // RETURN TO LOGIN SECTION
                rax_DISPLAY_AUTHENTICATION_OPTIONS();

            }
            else if (rdx_SELECTED_OPTION == 2)
            {
                Console.WriteLine($"Switching to Login...{Environment.NewLine}");
                rax_LOGIN_USER();
            }
            else
            {
                Console.WriteLine("Invalid option...");
                // RETURN TO LOGIN SECTION
                rax_DISPLAY_AUTHENTICATION_OPTIONS();
            }
        }

        /**********
        LOGIN USER  
        ***********/
        public static void rax_LOGIN_USER()
        {
            Console.WriteLine("Enter username >");
            rdx_USER_NAME = Console.ReadLine();
            // VERIFY INPUT
            if (string.IsNullOrWhiteSpace(rdx_USER_NAME))
            {
                Console.WriteLine("Invalid input!");
                rax_LOGIN_USER();
            }
            else
            {

                Console.WriteLine("Enter password >");
                rdx_USER_PASSWORD = Console.ReadLine();

                bool rdx_IS_VALID_USER = FileOperations.rax_VALIDATE_USER(rdx_USER_NAME, rdx_USER_PASSWORD);

                // VALIDATE USER
                if (rdx_IS_VALID_USER)
                {
                    // HANDLE SUCCESSFUL LOGIN
                    Console.WriteLine($"{Environment.NewLine}Logining in...");
                    Courses.rax_DISPLAY_COURSES();
                }
                else
                {
                    Console.WriteLine("Incorrect password!");
                }
            }



        }


    }

}