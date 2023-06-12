using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;
using ClickerRoot.Scripts.Utils.ServiceLocator;
using ClickerRoot.Scripts.Interfaces;
using System;
using ClickerRoot.Scripts.Utils;

namespace ClickerRoot.Scripts.Presenter
{
    public class UpgradeButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TMP_Text _labelText;
        [SerializeField] private TMP_Text _costText;

        [Space(10)]
        [Header("Value Settings")]
        [SerializeField] private int _upgradeValue = 2;
        [SerializeField] private int _initialCost = 5;
        [SerializeField] private ulong _maxValue = 3 * Const.Billion;

        private ulong _currentUpgradeCost;

        private void Start()
        {
            _upgradeButton.onClick.AddListener(OnUpgradeClick);
            _labelText.text = "Upgrade Click!";

            _currentUpgradeCost = (ulong)_initialCost;

            UpdateCostTextValue();

            EventBus.Instance.Subscrive<ScoreChangeSignal>(CheckButtonOnEnable);

            _upgradeButton.interactable = false;
        }


        private void OnUpgradeClick()
        {
            var score = ServiceLocator.Current.Get<IScore>();

            if((long)(score.CurrentScore - _currentUpgradeCost) >= 0) 
            {
                EventBus.Instance?.Invoke(new UpgradeClickValueSignal((ulong)_upgradeValue));
                EventBus.Instance?.Invoke(new ChangeLevelSignal(ItemType.ClickLevel));

                score.DecreaseScore(_currentUpgradeCost);

                _currentUpgradeCost = _currentUpgradeCost * (ulong)Mathf.Exp(2);

                if (_currentUpgradeCost >= _maxValue)
                {
                    EventBus.Instance.Unsubscribe<ScoreChangeSignal>(CheckButtonOnEnable);
                    _upgradeButton.interactable = false;
                    _costText.text = "MAX";
                }
                else
                {
                    UpdateCostTextValue();
                } 
            }        
        }

        private void UpdateCostTextValue()
        {
            _costText.text = TextFormat(_currentUpgradeCost);
        }

        private void CheckButtonOnEnable(ScoreChangeSignal signal)
        {
            var score = ServiceLocator.Current.Get<IScore>();
            _upgradeButton.interactable = (long)(score.CurrentScore - _currentUpgradeCost) >= 0;
        }


        private string TextFormat(ulong score)
        {
            if (score < 0) return "0";
            if (score >= Const.Quadrillion) return "1P";

            if (score < 10 * Const.Thousand) return score.ToString();
            if (score >= 10 * Const.Thousand && score < Const.Million) return $"{(int)(score / Const.Thousand)}K";
            if (score >= Const.Million && score < Const.Billion) return $"{(int)(score / Const.Million)}M";
            if (score >= Const.Billion && score < Const.Trillion) return $"{(int)(score / Const.Billion)}G";
            if (score >= Const.Trillion && score < Const.Quadrillion) return $"{(int)(score / Const.Trillion)}T";

            throw new ArgumentOutOfRangeException(nameof(score));
        }
    }
}
