namespace SportsSphere.Admin.Data
{
    // AuthenticationService.cs
    public class AuthenticationService
    {
        public int UserId { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public void Authenticate(int userId)
        {
            UserId = userId;
            IsAuthenticated = true;
        }

        public void Logout()
        {
            UserId = 0;
            IsAuthenticated = false;
        }
    }

}
