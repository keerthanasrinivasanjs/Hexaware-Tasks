namespace ExceptionHandlling
{
    public class User
    {
        public bool IsAuthenticated { get; set; }

        // Example: Stored permissions for demonstration  
        private List<string> permissions;

        public User(bool isAuthenticated, List<string> permissions)
        {
            IsAuthenticated = isAuthenticated;
            this.permissions = permissions ?? new List<string>();
        }

        public bool IsAuthorized(string permission)
        {
            return permissions.Contains(permission);
        }
    }
}
