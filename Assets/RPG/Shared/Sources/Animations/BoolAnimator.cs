using UnityEngine;

namespace RPG.Shared.Animations
{
    [RequireComponent(typeof(Animator))]
    public class BoolAnimator : MonoBehaviour
    {
        [SerializeField] private string _boolParameter = "Visible";
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Show()
        {
            _animator.SetBool(_boolParameter, true);
        }
        
        public void Hide()
        {
            _animator.SetBool(_boolParameter, false);
        }
    }
}

