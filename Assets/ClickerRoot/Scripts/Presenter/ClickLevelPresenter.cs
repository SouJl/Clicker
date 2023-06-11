using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;
using TMPro;
using UnityEngine;

namespace ClickerRoot.Scripts.Presenter
{
    public class ClickLevelPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _clickLevelText;
        [SerializeField] private string _description;
        private int _currentLevel = 1;

        private void Start()
        {
            EventBus.Instance.Subscrive<ChangeLevelSignal>(ChangeLevel);

            UpdateLevelText();
        }


        private void ChangeLevel(ChangeLevelSignal signal)
        {
            if (signal.Value == ItemType.ClickLevel)
            {
                _currentLevel++;
                UpdateLevelText();
            }
        }

        private void UpdateLevelText()
        {
            _clickLevelText.text = $"{_description} = {_currentLevel}";
        }
    }
}
