using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRunner;

public class Zombie : MonoBehaviour {

    public int zombieHealthPoints = 100;
    public int zombieDamage = 10;

    private Player player;

    private void Update()
    {
        if (player == null) {
            player = FindObjectOfType<Player>();
        }
    }

    public void LoseHealthPoints(int damage) {
        zombieHealthPoints -= damage;
        if (zombieHealthPoints <= 0) {
            Destroy(gameObject);
        }
    }

    public void DealDamage() {
        player.TakeDamage(zombieDamage);
    }
}
