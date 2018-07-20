using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRunner
{
    public class Player : MonoBehaviour
    {

        public int hitPoints = 100;
        public GameObject landingArea;

        private bool spotSelected = false;
        private Text healthText;
        private AudioSource innerVoiceAS;
        private Vector3 landingSpot;
        private Quaternion landingRotation;
        private GameManager gameManager;
        private Spawner spawner;

        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            spawner = FindObjectOfType<Spawner>();
            healthText = GameObject.Find("HealthText").GetComponent<Text>();
            healthText.text += hitPoints.ToString();
        }

        void Update()
        {
            if (Input.GetButton("CallHeli") && spotSelected == true)
            {
                Instantiate(landingArea, landingSpot, landingRotation);
                SendMessageUpwards("OnMakeInitialHeliCall");
                spotSelected = false;
                gameManager.StartText(spotSelected);
            }
        }

        public void SelectSpot()
        {
            landingSpot = transform.position;
            landingRotation = transform.rotation;
            spotSelected = true;
            gameManager.StartText(spotSelected);
        }

        public void TakeDamage(int damageTaken)
        {
            hitPoints -= damageTaken;
            healthText.text = hitPoints.ToString();
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                spawner.ReSpawn();
            }
        }

        public Vector3 GetLandingSpot() {
            return landingSpot;
        }
    }
}
