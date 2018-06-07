namespace ByteDev.PwnedPasswords
{
    public class PwnedPasswordResponse
    {
        public bool IsPwned { get; set; }
        public long Count { get; set; }

        public static PwnedPasswordResponse CreateNotPwned()
        {
            return new PwnedPasswordResponse
            {
                IsPwned = false,
                Count = 0
            };
        }

        public static PwnedPasswordResponse CreatePwned(long numberOfTimes)
        {
            if (numberOfTimes < 1)
                return CreateNotPwned();

            return new PwnedPasswordResponse
            {
                IsPwned = true,
                Count = numberOfTimes
            };
        }
    }
}