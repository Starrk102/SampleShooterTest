using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameManagerPresenter : IStartable
{
    private readonly GameManager gameManager;
    private IObjectResolver iObjectResolver;

    public GameManagerPresenter(GameManager gameManager, IObjectResolver iObjectResolver)
    {
        this.gameManager = gameManager;
        this.iObjectResolver = iObjectResolver;
    }
    
    public void Start()
    {
        gameManager.Init();
    }
}