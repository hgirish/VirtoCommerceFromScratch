namespace CommerceClient.Globalization
{
    public class Element
    {
        private static Element _empty;

        public static Element Empty
        {
            get
            {
                return _empty ?? (_empty = new Element
                {
                    Name = "",
                    Value = "",
                    Category = "",
                    Culture = ""
                });
            }
            
        }

        public string Culture { get; set; }

        public string Category { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }
    }
}