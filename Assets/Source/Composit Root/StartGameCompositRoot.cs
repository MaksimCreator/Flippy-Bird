using UnityEngine;

public class StartGameCompositRoot : CompositRoot
{
    [SerializeField] private MenuGameView _UiView;

    public override void Init()
    {
        _UiView.Init();
    }
}
