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
            _yesNoDialog.Closed += OnExit;
        }

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveListener(OnExitButtonClicked);
            _yesNoDialog.Closed -= OnExit;
        }

        private void OnExitButtonClicked()
        {
            _yesNoDialog.Open(new DialogConfirmArgs(_textYesNoDialog));
        }

        private void OnExit(DialogConfirmResult x)
        {
            if (x.Confirm)
            {
                Application.Quit();
            }
        }
    }
}

