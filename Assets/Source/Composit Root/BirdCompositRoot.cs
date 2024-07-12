using UnityEngine;

public class BirdCompositRoot : CompositRoot
{
    [SerializeField] private PhysicsCompositRoot _physicsCompositRoot;
    [SerializeField] private Rigidbody2D _rigidbodeBird;
    [SerializeField] private Camera _camera;
    [SerializeField] private ConffigBird _conffigBird;
    [SerializeField] private Animator _birdAnimator;
    [SerializeField] private AudioSource _audioSourceEffects, _audiSourcePoints;

    private Bird _bird;
    private InputRouter _inputRouter;
    private AnimatiorBird _animator;

    public Bird Model => _bird;

    public override void Init()
    {
        AllMusicGame.Singleton.InitAudioSource(_audioSourceEffects,_audiSourcePoints);

        _animator = new AnimatiorBird(_birdAnimator);
        _bird = new Bird(_rigidbodeBird, _conffigBird.TapForce, _conffigBird.MaxRotation, _conffigBird.MinRotation, _conffigBird.SpeedRotation);

        BirdMove moveming = new BirdMove(_bird, _conffigBird.Speed);
        CameraController cameraController = new CameraController(_camera, _bird, _conffigBird.XOffset);

        _inputRouter = new InputRouter(moveming, cameraController);
    }
    
    public void OnDisableBird()
    {
        enabled = false;
        _animator.ExitAnimator();
        _rigidbodeBird.velocity = new Vector2(0, _rigidbodeBird.velocity.y);
    }

    private void OnEnable()
        => _inputRouter.OnEnable();
        
    private void OnDisable()
        => _inputRouter.OnDisable();

    private void Update()
        => _inputRouter.Update(Time.deltaTime);
}
