namespace lab3.Interfaces
{
    public interface ISerializeble
    {
        object FromText(string text);
        string ToText();
        string ClassName();
    }
}
