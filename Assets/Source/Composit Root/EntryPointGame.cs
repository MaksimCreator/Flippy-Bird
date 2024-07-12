using System.Collections.Generic;
using UnityEngine;

public class EntryPointGame : MonoBehaviour
{
    [SerializeField] private List<CompositRoot> _composits;

    private void Awake()
    {
        foreach (var item in _composits)
        {
            item.Init();
            item.enabled = true;
        }
    }
}