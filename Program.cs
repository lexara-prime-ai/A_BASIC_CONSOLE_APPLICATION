using JituCourses.Utilities;

namespace JituCourses;

class Program
{
    static void Main()
    {
        Console.WriteLine($"{Environment.NewLine}Welcome to The Jitu Online Courses...");
        Console.WriteLine($"{Environment.NewLine}Please Login | Register to continue...");
        
        // DISPLAY AUTHENTICATION OPTIONS
        Authentication.rax_DISPLAY_AUTHENTICATION_OPTIONS();

    }
}