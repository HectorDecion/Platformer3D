using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public enum EnemyType
{
    Platform,
    Bobs,
    Boss01,
    Boss02,
    Boss03
}
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager sharedInstance;
    public EnemyType enemyType;
    
    //Lista de valores de daño
   public List<int> damageAmount = new List<int> {0, 10, 25, 35, 50};
    private void Awake()
    {
       if (sharedInstance == null)
            sharedInstance = this;
        else
            Destroy(gameObject);
    
    
    }
    void Start()
    {
        initializeEnemy();
    }

    public void initializeEnemy()
    {
        switch (enemyType)
        {
            case EnemyType.Platform:
                break;
            case EnemyType.Bobs:
                break;
            case EnemyType.Boss01:
                break;
            case EnemyType.Boss02:
                break;
            case EnemyType.Boss03:
                break;
        }
    }
    void Update()
    {
        
    }
}
