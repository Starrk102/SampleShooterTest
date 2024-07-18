using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    //player
    public float speedPlayer;
    public float fireRatePlayer;
    public float fireRangePlayer;
    public int healthPlayer;
    public GameObject bullet;
    
    //enemy
    public float speedEnemy;
    public int healthEnemy;
}