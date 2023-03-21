using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public abstract class Dialog<V,T> : MonoBehaviour where V:DialogArgs where T : DialogResult
    {
        [SerializeField] private Canvas _canvas;
        
        private TaskCompletionSource<T> _dialogCompletionSource;

        private void Awake()
        {
            OnAwake();
        }

        private void Open()
        {
            //TODO animation
            _canvas.enabled = true;
        }

        public async Task<T> Run(V args)
        {
            Open();
            OnOpen(args);

            _dialogCompletionSource = new TaskCompletionSource<T>();
            var result = await _dialogCompletionSource.Task;
            
            Close();
            OnClose(result);
            
            return result;
        }

        private void Close()
        {
            //TODO animation
            _canvas.enabled = false;
        }

        protected virtual void OnOpen(V args) {}
        protected virtual void OnClose(T args) {}
        protected virtual void OnAwake() {}

        protected void SetResult(T arg)
        {
            _dialogCompletionSource.SetResult(arg);
            OnClose(arg);
        }
    }

    public class DialogArgs { }
    public class DialogResult { }
}

