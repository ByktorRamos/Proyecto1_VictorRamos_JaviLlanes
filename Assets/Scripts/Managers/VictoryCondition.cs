using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    public static VictoryCondition instance;
    private List<EnemyLife> enemies = new List<EnemyLife>();
    public GameObject victoryPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
        if (victoryPoint != null)
        {
            victoryPoint.SetActive(false);
        }
    }

    public void RegisterEnemy(EnemyLife enemy)
    {
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(EnemyLife enemy)
    {
        enemies.Remove(enemy);
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        if (enemies.Count == 0 && victoryPoint != null)
        {
            victoryPoint.SetActive(true);
        }
    }
}
