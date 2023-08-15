using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Variables for current hit points and maximum damage that target can receive
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    Enemy enemy;
    
    // Reset enemy health On Enable instead of start 
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // On collision call of the Process hit routine
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    // Upon hit hit points are reduced + once hit point are smaller or equal to 0 = destruction of enemy
    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold(); // Reward with gold when enemy is destroyed
        }
    }

}
