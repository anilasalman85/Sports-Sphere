namespace SportsSphere.User.Data
{
    // UserStateService.cs
    public class UserStateService
    {
        public int UserId { get; private set; }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }

}
