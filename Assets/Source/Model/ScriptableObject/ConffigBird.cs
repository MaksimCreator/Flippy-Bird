using UnityEngine;

[CreateAssetMenu(fileName = "Conffig Bird",menuName = "Conffig/Bird")]
public class ConffigBird : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _maxRotation;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _xOffset;

    public float Speed => _speed;
    public float TapForce => _tapForce;
    public float MaxRotation => _maxRotation;
    public float MinRotation => _minRotation;
    public float SpeedRotation => _speedRotation;
    public float XOffset => _xOffset;
}