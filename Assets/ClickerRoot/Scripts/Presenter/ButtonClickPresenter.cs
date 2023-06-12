using ClickerRoot.Scripts.Interfaces;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.ServiceLocator;
using ClickerRoot.Scripts.Utils.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerRoot.Scripts.Presenter
{
    public class ButtonClickPresenter : MonoBehaviour
    {
        [SerializeField] private Button _clickButton;
        [SerializeField] private int _clickPower = 1;

        [SerializeField] private PlusValuePresenter _plusValue;

        private ulong _currentClickPower;

        private void Awake()
        {
            _clickButton.onClick.AddListener(OnButtonClick);
            _currentClickPower = (ulong)_clickPower;
        }

        private void Start()
        {
            EventBus.Instance.Subscrive<UpgradeClickValueSignal>(UpgradeClickValue);
        }


        private void OnButtonClick()
        {
            var score = ServiceLocator.Current.Get<IScore>();
            
            score.IncreaseScore(_currentClickPower);

            _plusValue.SetPlusValue((int)_currentClickPower);
        }

        private void UpgradeClickValue(UpgradeClickValueSignal upgrade)
        {
            _currentClickPower += upgrade.Value;
        }

    }
}


