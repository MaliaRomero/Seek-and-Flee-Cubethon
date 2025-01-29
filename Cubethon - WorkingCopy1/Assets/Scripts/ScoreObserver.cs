using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Chapter.Observer 
{
    public class ScoreObserver : Observer
    {
        private Score score;

        [SerializeField]
        private TextMeshProUGUI wowText;

        private float messageTimer;
        private const float displayDuration = 3f;

        private bool Target;
        private bool First;

        public MeshRenderer playerMeshRenderer;

        void Start()
        {
            playerMeshRenderer = GameObject.Find("Player").GetComponent<MeshRenderer>();
            if (playerMeshRenderer == null)
            {
                Debug.LogError("MeshRenderer not found on the player!");
            }
        }

        void Update()
        {
            if (Target == true)
            {
                score.scoreText.text = "Second reached";
            }
            if (First == true)
            {
                score.scoreText.text = "First Reached";
            }
        }

        public override void Notify(Subject subject)
        {
            Debug.Log("Override");
            if (!score)
            {
                score = subject.GetComponent<Score>();
            }
            if (score)
            {
                Target = score.ScoreReached;
                First = score.Target;
            }

            if (score && score.ScoreReached)
            {
                Debug.Log("REACHED");
                wowText.text = "Wow!"; // Update the message text
                wowText.gameObject.SetActive(true);
            }


            if (score && score.ColorChangeTriggered)
            {
                ChangePlayerColor();
            }
        }
        void ChangePlayerColor()
        {
            if (playerMeshRenderer)
            {
                playerMeshRenderer.material.color = Color.red; // Change the color to red
                Debug.Log("Player color changed to red!");
            }
        }
    
    }
}