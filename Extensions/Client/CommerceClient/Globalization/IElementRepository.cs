namespace CommerceClient.Globalization
{
    public interface IElementRepository
    {
        Element Get(string key, string category, string name);
        bool Add(Element element);
    }
}