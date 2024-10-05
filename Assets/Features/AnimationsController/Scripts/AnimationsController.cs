using UnityEngine;

public class AnimationsController : MonoBehaviour, IAnimationController {
    [SerializeField] private Animator _animator;

    public void PlayAnimation(string animationType) => _animator.SetTrigger(animationType);

    public void ResetAllTriggers() {
        foreach(string trigger in GolemAnimationTriggersMapper.Triggers) 
            _animator.ResetTrigger(trigger);
    }
}

    
