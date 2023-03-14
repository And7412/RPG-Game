using Core.Patterns.ServiceLocator;
using RPG.Shared.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Shared
{
    public class GameQuit : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private YesNoDialog _yesNoDialog;
        [SerializeField] private string _textYesNoDialog;

        private void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private async void OnExitButtonClicked()
        {
            var x = await _yesNoDialog.Run(new DialogConfirmArgs(_textYesNoDialog));
            
            if (x.Confirm)
            {
                Application.Quit();
            }
        }
    }
}

