namespace JituCourses.Utilities
{
    public static class Courses
    {
        static string rdx_FILE_PATH = @"Data\Courses.txt";

        static Dictionary<int, string> rdx_AVAILABLE_COURSES = new Dictionary<int, string>();

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