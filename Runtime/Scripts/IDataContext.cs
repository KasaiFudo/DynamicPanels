namespace DynamicPanels.Scripts
{
    public interface IDataContext
    {
        object GetValue(string id);
        void SetValue(string id, object value);
    }
}
