using ClickerRoot.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerRoot.Scripts.Presenter
{
    public class ButtonClickPresenter : MonoBehaviour
    {
        [SerializeField] private Button _clickButton;
        [SerializeField] private int _initialClickValue = 1;

        private int _currentClickValue;

        private void Awake()
        {
            _clickButton.onClick.AddListener(OnButtonClick);
            _currentClickValue = _initialClickValue;
        }

        private void Start()
        {
            EventBus.Instance.Subscrive<UpgradeClickValueSignal>(UpgradeClickValue);
        }


        private void OnButtonClick()
        {
            EventBus.Instance?.Invoke(new ScoreChangeSignal(_currentClickValue));
        }

        private void UpgradeClickValue(UpgradeClickValueSignal upgrade)
        {
            _currentClickValue += upgrade.Value;
        }

    }
}


