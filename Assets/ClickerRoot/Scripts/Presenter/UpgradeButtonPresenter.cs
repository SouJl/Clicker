using ClickerRoot.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerRoot.Scripts.Presenter
{
    public class UpgradeButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TMP_Text _labelText;
        [SerializeField] private TMP_Text _costText;
        [SerializeField] private int _initialCost = 5;

        private int _currentUpgradeValue;


        private void Awake()
        {
            _upgradeButton.onClick.AddListener(OnUpgradeClick);
            _labelText.text = "Upgrade Click!";
            UpdateCostValue(_initialCost);
        }

        private void OnUpgradeClick()
        {
            EventBus.Instance?.Invoke(new UpgradeClickValueSignal(_currentUpgradeValue));
            EventBus.Instance?.Invoke(new ScoreChangeSignal(-_currentUpgradeValue));

            UpdateCostValue(_currentUpgradeValue * 2);
        }

        private void UpdateCostValue(int newCost)
        {
            _costText.text = newCost.ToString();
            _currentUpgradeValue = newCost;
        }
    }
}
