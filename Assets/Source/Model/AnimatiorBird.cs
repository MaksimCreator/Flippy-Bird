using UnityEngine;

public class AnimatiorBird : MonoBehaviour
{
    private readonly Animator _animationBird;

    public AnimatiorBird(Animator animationBird)
    {
        _animationBird = animationBird;
    }

    public void ExitAnimator()
    => _animationBird.enabled = false;
}
