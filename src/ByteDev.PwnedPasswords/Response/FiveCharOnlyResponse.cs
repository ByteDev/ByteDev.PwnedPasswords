using System;

namespace ByteDev.PwnedPasswords.Response
{
    internal class FiveCharOnlyResponse
    {
        private string[] _rawContentLines;

        public string RawContent { get; }

        public string[] RawContentLines
        {
            get { return _rawContentLines ?? (_rawContentLines = RawContent.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)); }
        }

        public FiveCharOnlyResponse(string rawContent)
        {
            if(string.IsNullOrEmpty(rawContent))
                throw new ArgumentException(nameof(rawContent));

            RawContent = rawContent;
        }

        public long GetCount(HashedPassword hashedPassword)
        {
            foreach (var line in RawContentLines)
            {
                if (line.StartsWith(hashedPassword.HashSuffix))
                {
                    var value = line.Substring(hashedPassword.HashSuffix.Length + 1);
                    return Convert.ToInt64(value);
                }
            }

            return 0;
        }
    }
}