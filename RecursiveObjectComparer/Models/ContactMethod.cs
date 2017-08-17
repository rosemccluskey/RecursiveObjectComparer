namespace RecursiveObjectComparer.Models
{
    public class ContactMethod
    {
        public ContactMethods Method { get; set; }
        public string Info { get; set; }

    }

    public enum ContactMethods
    {
        Unknown,
        Landline,
        Mobile,
        Email,
        Fax,
        Facebook,
        Twitter,
        Instagram
    }
}
