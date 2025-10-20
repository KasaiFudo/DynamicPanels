namespace KasaiFudo.DynamicPanels
{
    public interface IDataContext
    {
        object GetValue(string id);
        void SetValue(string id, object value);
    }
}
