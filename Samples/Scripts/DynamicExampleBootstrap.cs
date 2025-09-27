using UnityEngine;
using UnityEngine.UI;

namespace DynamicPanels.Samples.Scripts
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
