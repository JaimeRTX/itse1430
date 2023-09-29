namespace MovieLibrary
{
    public class ValidatableObject 
    {
        public bool IsValid 
        {
            get { return TryValidate(out var _); }
        }
        public virtual bool TryValidate(out string message)
        {
            message = "";
            return true;
        }
        public string Validate ()
        {
            if (!TryValidate(out var message))
            {
                return message;
            }

            return "";
        }
    }
}