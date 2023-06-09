using ClickerRoot.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerRoot.Scripts 
{
    public class ButtonClickPresenter : MonoBehaviour
    {
        [SerializeField] private Button _clickButton;
        [SerializeField] private int _clickValue = 1;

        private void Awake()
        {
            _clickButton.onClick.AddListener(OnButtonClick);
        }


        private void OnButtonClick()
        {
            EventBus.Instance?.Invoke(new ScoreChangeEvent(_clickValue));
        }
    }
}


