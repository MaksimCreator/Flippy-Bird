using UnityEngine;

public class PhysicsEventBroadcaster : MonoBehaviour
{
    private object _model;
    private PhysicsRouter _router;

    public void Init(PhysicsRouter router,object model)
    {
        _router = router;
        _model = model;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PhysicsEventBroadcaster broadcaster))
            _router.TryAddCollision(_model,broadcaster._model);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PhysicsEventBroadcaster broadcaster))
            _router.TryAddCollision(_model,broadcaster._model);
    }
}