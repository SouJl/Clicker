using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;
using ClickerRoot.Scripts.Utils.ServiceLocator;
using ClickerRoot.Scripts.Interfaces;
using System;

namespace ClickerRoot.Scripts.Presenter
{
    public class UpgradeButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TMP_Text _labelText;
        [SerializeField] private TMP_Text _costText;
        [SerializeField] private int _initialCost = 5;

        private ulong _currentUpgradeValue;

        private void Start()
        {
            _upgradeButton.onClick.AddListener(OnUpgradeClick);
            _labelText.text = "Upgrade Click!";
            UpdateCostValue((ulong)_initialCost);

            EventBus.Instance.Subscrive<ScoreChangeSignal>(_ =>
            {
                CheckButtonOnEnable();
            });
            CheckButtonOnEnable();
        }


        private void OnUpgradeClick()
        {
            var score = ServiceLocator.Current.Get<IScore>();

            if((long)(score.CurrentScore - _currentUpgradeValue) >= 0) 
            {
                EventBus.Instance?.Invoke(new UpgradeClickValueSignal(_currentUpgradeValue));
                EventBus.Instance?.Invoke(new ChangeLevelSignal(ItemType.ClickLevel));

                score.DecreaseScore(_currentUpgradeValue);

                UpdateCostValue(_currentUpgradeValue * 2);
            }        
        }

        private void UpdateCostValue(ulong newCost)
        {
            _costText.text = TextFormat(newCost);
            _currentUpgradeValue = newCost;

            CheckButtonOnEnable();
        }

        private void CheckButtonOnEnable()
        {
            var score = ServiceLocator.Current.Get<IScore>();
            _upgradeButton.interactable = (long)(score.CurrentScore - _currentUpgradeValue) >= 0;
        }


        private string TextFormat(ulong score)
        {
            if (score < 0) return "0";
            if (score >= 1000000000000000) return "1P";

            if (score < 10000) return score.ToString();
            if (score >= 10000 && score < 1000000) return $"{(int)(score / 1000)}K";
            if (score >= 1000000 && score < 1000000000) return $"{(int)(score / 1000000)}M";
            if (score >= 1000000000 && score < 1000000000000) return $"{(int)(score / 1000000000)}G";
            if (score >= 1000000000000 && score < 1000000000000000) return $"{(int)(score / 1000000000000)}T";

            throw new ArgumentOutOfRangeException(nameof(score));
        }
    }
}
