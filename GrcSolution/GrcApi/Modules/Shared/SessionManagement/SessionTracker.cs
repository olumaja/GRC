using Arm.GrcApi.Modules.Shared;

namespace GrcApi.Modules.Shared.SessionManagement
{
    public class SessionTracker : BaseEntity
    {
        public string Email { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastLogin { get; private set; }
        public string? Token { get; private set; }
        public int NumberOfTry { get; private set; } = 0;
        public bool IsLock { get; private set; } = false;
        public DateTime? LockDuration { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryDate { get; set; }
        public DateTime? LastLogOut { get; set; }

        public static SessionTracker Create(string name, string email, DateTime dateCreated, DateTime lastLogin)
        {
            return new SessionTracker
            {
                Name = name,
                Email = email,
                DateCreated = dateCreated,
                LastLogin = lastLogin
            };
        }

        public void UpdateToken(string? token = null)
        {
            Token = token;
        }

        public void UpdateRefreshToken(string? refreshToken = null, DateTime? expiryDate = null)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpiryDate = expiryDate;
        }

        public void UpdateNumberOfTry(int retry = 0)
        {
            NumberOfTry = retry;
        }

        public void UpdateLock(bool isLock)
        {
            if (isLock)
            {
                NumberOfTry = 0;
                LockDuration = DateTime.Now.AddMinutes(5);
            }

            IsLock = isLock;
        }

        public void UpdateLastLogin(DateTime lastLogin)
        {
            LastLogin = lastLogin;
        }

        public void UpdateLastLogOut(DateTime lastLogOut)
        {
            LastLogOut = lastLogOut;
        }
    }
}
