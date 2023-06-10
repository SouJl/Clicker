using ClickerRoot.Scripts.Interfaces;
using ClickerRoot.Scripts.Model;
using UnityEngine;

namespace ClickerRoot.Scripts.Utils.ServiceLocator
{
    public class InGameServiceLocator : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Initialize();

            ServiceLocator.Current.Register<IScore>(new ScoreModel());
        }
    }
}
