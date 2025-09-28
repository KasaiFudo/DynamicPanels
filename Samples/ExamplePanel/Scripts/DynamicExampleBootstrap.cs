using UnityEngine;
using UnityEngine.UI;

namespace KasaiFudo.DynamicPanels
{
    public class DynamicExampleBootstrap : MonoBehaviour
    {
        [SerializeField] private ExamplePanel _panel;
        
        private void Awake()
        {
            _panel.Initialize(new ExampleData());
            _panel.Show();
        }
    }
}
