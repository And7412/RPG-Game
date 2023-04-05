using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public class DialogsService : MonoBehaviour
    {
        [SerializeField] private YesNoDialog _yesNoDialog;
        [SerializeField] private ConfirmDialog _confirmDialog;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        public async Task<DialogConfirmResult> InvokeYesNoDialog(DialogConfirmArgs args)
        {
            return await _yesNoDialog.Run(args);
        }
        public async Task<DialogResult> InvokeConfirmDialog(DialogConfirmArgs args)
        {
            return await _confirmDialog.Run(args);
        }
    }
}
