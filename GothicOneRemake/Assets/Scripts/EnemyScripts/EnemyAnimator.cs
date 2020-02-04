using UnityEngine;

public class EnemyAnimator : MonoBehaviour {
    
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk) {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Run(bool run) {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void Attack() {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }

    public void Dead() {
        anim.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }
}