using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClickerRoot.Scripts.Presenter
{
    public class PlusValuePresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _plusValueText;
        [SerializeField] private float _showingTime = 1f;
        [SerializeField] private float _spawnRadius = 2f;

        private float _onShownDelay = 0.01f;

        private void Awake()
        {
            _plusValueText.gameObject.SetActive(false);
        }


        public void SetPlusValue(int plusValue)
        {
       
            _plusValueText.gameObject.SetActive(true);

            _plusValueText.text = $"+{plusValue}";

            _plusValueText.transform.position = Random.insideUnitCircle * _spawnRadius;
            
            StopAllCoroutines();
            StartCoroutine(FlyText());
        }

        private IEnumerator FlyText()
        {
            for(int i =0; i < (_showingTime / _onShownDelay); i++)
            {
                yield return new WaitForSeconds(_onShownDelay);
                _plusValueText.transform.position = new Vector2(_plusValueText.transform.position.x, _plusValueText.transform.position.y + 1 * Time.deltaTime);
            }
            _plusValueText.gameObject.SetActive(false);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        }
    }
}
