using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Conffig/Spawner")]
public class ConffigSpawner : ScriptableObject
{
    [SerializeField] private int _lencghPool;
    [SerializeField] private float _cooldownSpawn;

    public int LencghPool => _lencghPool;
    public float CooldownSpawn => _cooldownSpawn;
}