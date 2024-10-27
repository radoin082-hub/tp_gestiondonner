namespace Model.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int _Id, string _Email, string _Password)
        {

            this.Id = _Id;
            this.Email = _Email;
            this.Password = _Password;
        }
    }
}
