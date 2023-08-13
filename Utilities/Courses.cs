namespace JituCourses.Utilities
{
    public static class Courses
    {
        static string rdx_FILE_PATH = @"Data\Courses.txt";

        static Dictionary<int, string> rdx_AVAILABLE_COURSES = new Dictionary<int, string>();

        /************************* 
          ADMIN DISPLAY OPTIONS
        *************************/
        public static void rax_DISPLAY_ADMIN_OPTIONS()
        {
            string[] rdx_COURSES = File.ReadAllLines(rdx_FILE_PATH);

            // COUNTER
            int rdx_KEY_COUNTER = 1;

            foreach (string course in rdx_COURSES)
            {
                // TRIM LEADING AND TRAILING SPACES
                string SANITIZED_DATA = course.Trim();

                // ADD THE COURSE TO THE DICTIONARY
                rdx_AVAILABLE_COURSES.Add(rdx_KEY_COUNTER, SANITIZED_DATA);

                // INCREMENT COUNTER
                rdx_KEY_COUNTER++;
            }

            Console.WriteLine($"{Environment.NewLine}****** Available Courses ******");

            // DISPLAY ALL COURSES
            foreach (var course in rdx_AVAILABLE_COURSES)
            {
                Console.WriteLine($"{course.Key}. {course.Value}");
            }

            // ADMIN OPTIONS
            Console.WriteLine($"{Environment.NewLine}Admin Options:");
            Console.WriteLine("1. Update course");
            Console.WriteLine("2. Delete course");


            Console.WriteLine($"{Environment.NewLine}Select Option:");

            int SELECTED_OPTION = int.Parse(Console.ReadLine());

            // Handle admin actions
            switch (SELECTED_OPTION)
            {
                case 1:
                    rax_UPDATE_COURSE();
                    break;
                case 2:
                    rax_DELETE_COURSE();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            // Continue with regular course selection
            // rax_SELECT_COURSE();
        }

        ///////////////////////////////////
        ///// CRUD OPERATIONS | Start ////
        //////////////////////////////////

        /***********
         ADD COURSE
        ************/
        public static void rax_ADD_COURSE(string COURSE)
        {
            if (!File.Exists(rdx_FILE_PATH))
            {
                // CREATE FILE IF IT DOESN'T EXIST
                using (FileStream fileStream = File.Create(rdx_FILE_PATH))
                {
                    Console.WriteLine($"{Environment.NewLine}****Running file create participants****");
                }
            }

            File.AppendAllText(rdx_FILE_PATH, $"{COURSE}\n");

            // REGISTRATION RESPONSE
            Console.WriteLine($"{COURSE} has been added!");
        }

        /**************
         UPDATE COURSE
        ***************/
        public static void rax_UPDATE_COURSE()
        {
            Console.WriteLine("Select Course to update by id i.e 1, 2 or 3 etc... >");
            int rdx_COURSE_ID = int.Parse(Console.ReadLine());

            if (rdx_AVAILABLE_COURSES.ContainsKey(rdx_COURSE_ID))
            {
                Console.WriteLine($"Update the course '{rdx_AVAILABLE_COURSES[rdx_COURSE_ID]}':");

                string rdx_UPDATED_COURSE_INFO = Console.ReadLine();

                // UPDATE COURSE INFO IN DICTIONARY
                rdx_AVAILABLE_COURSES[rdx_COURSE_ID] = rdx_UPDATED_COURSE_INFO;

                // UPDATE FILE CONTENTS
                rax_UPDATE_COURSE_IN_FILE(rdx_COURSE_ID, rdx_UPDATED_COURSE_INFO);

                Console.WriteLine("Course updated!");
            }
            else
            {
                Console.WriteLine("Invalid course id!");
            }
        }


        /*********************
         UPDATE FILE CONTENTS
        *********************/
        private static void rax_UPDATE_COURSE_IN_FILE(int rdx_COURSE_ID, string rdx_UPDATED_COURSE_INFO)
        {
            string[] rdx_COURSES = File.ReadAllLines(rdx_FILE_PATH);

            if (rdx_COURSE_ID >= 1 && rdx_COURSE_ID <= rdx_COURSES.Length)
            {
                // Update the course in the array
                rdx_COURSES[rdx_COURSE_ID - 1] = rdx_UPDATED_COURSE_INFO;

                // Write the updated courses back to the file
                File.WriteAllLines(rdx_FILE_PATH, rdx_COURSES);
            }
        }

        /**************
         DELETE COURSE
        ***************/
        public static void rax_DELETE_COURSE()
        {
            Console.WriteLine("Enter the number of the course to delete:");
            int rdx_COURSE_ID = int.Parse(Console.ReadLine());

            if (rdx_AVAILABLE_COURSES.ContainsKey(rdx_COURSE_ID))
            {
                // Remove the course from the dictionary
                rdx_AVAILABLE_COURSES.Remove(rdx_COURSE_ID);

                Console.WriteLine("Course deleted!");
            }
            else
            {
                Console.WriteLine("Invalid course number!");
            }
        }

        ////////////////////////////////
        ///// CRUD OPERATIONS | End ////
        ////////////////////////////////

        /****************
         DISPLAY COURSES
        *****************/
        public static void rax_DISPLAY_COURSES()
        {
            string[] rdx_COURSES = File.ReadAllLines(rdx_FILE_PATH);

            // COUNTER
            int rdx_KEY_COUNTER = 1;

            foreach (string course in rdx_COURSES)
            {
                // TRIM LEADING AND TRAILING SPACES
                string SANITIZED_DATA = course.Trim();

                // ADD THE COURSE TO THE DICTIONARY
                rdx_AVAILABLE_COURSES.Add(rdx_KEY_COUNTER, SANITIZED_DATA);

                // INCREMENT COUNTER
                rdx_KEY_COUNTER++;
            }

            Console.WriteLine($"{Environment.NewLine}****** Available Courses ******");

            rax_SELECT_COURSE();
        }

        /**************
         SELECT COURSE
        ***************/
        public static void rax_SELECT_COURSE()
        {
            // DISPLAY COURSES
            foreach (var key in rdx_AVAILABLE_COURSES)
            {
                Console.WriteLine($"{key.Key}. {key.Value}");
            }

            int _SELECTED_OPTION = Int32.Parse(Console.ReadLine());

            // CHECK IF SELECTED OPTION EXISTS
            if (rdx_AVAILABLE_COURSES.ContainsKey(_SELECTED_OPTION))
            {
                string SELECTED_COURSE = rdx_AVAILABLE_COURSES[_SELECTED_OPTION];

                Console.WriteLine($"You've selected the course: {SELECTED_COURSE}");

                // CONFIRM PURCHASE
                Console.WriteLine($"{Environment.NewLine}Confirm purchase?");
                int rdx_PURCHASE_OPTION = Int32.Parse(Console.ReadLine());


            }

        }
    }
}