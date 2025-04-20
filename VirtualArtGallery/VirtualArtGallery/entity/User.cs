namespace entity
{
    public class User
    {
        private int userID;
        private string username;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private DateTime? dateOfBirth;

        // Default Constructor
        public User() { }

        // Parameterized Constructor
        public User(int userID, string username, string password, string email, string firstName, string lastName, DateTime? dateOfBirth)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        // Getters and Setters
        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime? DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    }
}