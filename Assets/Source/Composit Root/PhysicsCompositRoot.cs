using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsCompositRoot : CompositRoot
{
    [SerializeField] private PhysicsEventBroadcaster _triggerDeadZone, _birdPhysicsEventBroadcaster;
    [SerializeField] private BirdUIView _birdUIView;
    [SerializeField] private BirdCompositRoot _birdCompositRoot;
    [SerializeField] private SpawnerObstacle _spawner;
    [SerializeField] private EndGameView _endGameView;
    [SerializeField] private GameObject _prefabGround;
    [SerializeField] private Animator _animatorGround;
    [SerializeField] private float _timeDelayAffterDeath;

    private PhysicsRouter _router;
    private PhysicsRecords _records;

    public PhysicsRouter Model => _router;

    public override void Init()
    {
        _records = new PhysicsRecords(_spawner);
        _router = new PhysicsRouter(_records.Values);
        InitPhysics();
        _spawner.Init();
        _birdUIView.Init(_records);

        StartCoroutine(GetRouterSeteper());
    }

    private void OnEnable()
    => _records.GameEnd += OnGameEnd;

    private void OnDisable()
    => _records.GameEnd -= OnGameEnd;

    private void InitPhysics()
    {
        PhysicsInitialized.InitObject(_prefabGround, _router, new Entity());
        PhysicsInitialized.InitObjectInChildren(_prefabGround, _router, new Entity());
        PhysicsInitialized.InitObject(_triggerDeadZone.gameObject, _router, new DeadZone());
        _birdPhysicsEventBroadcaster.Init(_router, _birdCompositRoot.Model);
    }

    private void OnGameEnd()
    {
        _animatorGround.enabled = false;
        _birdCompositRoot.OnDisableBird();

        StartCoroutine(InitGameEndView());
    }

    private IEnumerator GetRouterSeteper()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            _router.Step();
        }
    }

    private IEnumerator InitGameEndView()
    {
        yield return new WaitForSeconds(_timeDelayAffterDeath);

        _endGameView.Show(_records.Score, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex),() => SceneManager.LoadScene(0), Application.Quit);
    }
}
