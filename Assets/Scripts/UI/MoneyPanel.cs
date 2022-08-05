using TMPro;
using UnityEngine;

namespace IdleActionFarm.UI
{
    public class MoneyPanel : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _player.MoneyChanged += UpdateText;
        }

        private void OnDisable()
        {
            _player.MoneyChanged -= UpdateText;
        }

        private void UpdateText(int money)
        {
            _text.text = money.ToString();
        }
    }
}
