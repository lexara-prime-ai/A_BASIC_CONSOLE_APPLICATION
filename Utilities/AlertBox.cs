namespace JituCourses.Utilities
{
    public static class AlertBox
    {
        public static string message;
        public static string rdx_AlertBox
        {
            get
            {
                return $@"
 {message.ToUpper()} >     
        ";
            }
        }

        public static string rax_DISPLAY_ALERT_BOX(string _message)
        {
            message = _message;
            return rdx_AlertBox;
        }
    }
}
