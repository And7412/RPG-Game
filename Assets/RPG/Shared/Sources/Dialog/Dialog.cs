using System.Threading.Tasks;
using RPG.Shared.Animations;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public abstract class Dialog<V,T> : MonoBehaviour where V:DialogArgs where T : DialogResult
    {
        [SerializeField] private BoolAnimator _animator;
        
        private TaskCompletionSource<T> _dialogCompletionSource;

        private void Awake()
        {
            OnAwake();
        }

        private void Open()
        {
            _animator.Show();
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
            _animator.Hide();
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

