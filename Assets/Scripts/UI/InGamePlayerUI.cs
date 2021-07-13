using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGamePlayerUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI lifes;
    [SerializeField] TextMeshProUGUI distanceToExplosion;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] TextMeshProUGUI enemyDestroyedCount;
    [SerializeField] TextMeshProUGUI gamePointsCount;
    Player player;
    GameManager gameManager;

    void Start(){
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update(){
        lifes.text = "lifes: " + player.lifes;
        distanceToExplosion.text = "explosion distance: " + player.distanceToExplosionBomb;
        bombs.text = "bombs: " + player.bombCount;
        enemyDestroyedCount.text = "enemy destroyed: " + gameManager.enemyDestroyed;
        gamePointsCount.text = "points: " + gameManager.gamePoints;
    }
}
