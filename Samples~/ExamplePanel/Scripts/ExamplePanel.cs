using DynamicPanels.Scripts;
using TMPro;
using UnityEngine;

namespace DynamicPanels.Samples.Scripts
{
    public class ExamplePanel : DynamicPanel
    {
        [SerializeField] private GameObject _holder;
        [SerializeField] private GameObject _resultsHolder;
        [SerializeField] private TMP_Text _resultText;
        
        private ExampleData _data; //This is your data to read or write as you wish.
        private IDataContext _context; //This is the context that will be used to bind your data to the UI.

        public void Show()
        {
            _holder.SetActive(true);
            OnShow();
        }

        public void Initialize(ExampleData data) //This is called by the Bootstrap to simulate DI
        {
            _data = data;
            _context = new DynamicDataContext<ExampleData>(_data);
        }

        protected virtual void OnShow()
        {
            Build(_context);
        }

        protected override void OnValueChanged() //This is not necessary, but it's a calls every time when some render is changed.
        {
            UpdateReadValues();
            Build(_context);
        }
        
        private void UpdateReadValues()
        {
            //This is just an example of how to use the data. You can edit your save data or runtime data like debug or something
            _resultsHolder.SetActive(ExampleData.IsOn); 
            _resultText.text = ExampleData.ReadData;
        }
        
    }

    public class ExampleData
    {
        public enum SomePanels
        {
            MainMenu,
            Settings,
            Stats,
            Debug,
        }
        
        public static bool IsOn {get; private set;}
        public static SomePanels WriteData {get; private set;}
        public static string ReadData => WriteData.ToString();
    }
}
