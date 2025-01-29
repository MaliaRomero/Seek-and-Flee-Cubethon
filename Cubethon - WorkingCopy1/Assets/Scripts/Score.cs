using UnityEngine;
using TMPro;

namespace Chapter.Observer
{
public class Score : Subject
{
        public Transform player;
        public TextMeshProUGUI scoreText;
        private ScoreObserver _scoreObserver;
        public bool ScoreReached;
        public bool Target;

        public bool ColorChangeTriggered;


        //public TextMeshProUGUI message;

        void Start()
        {
            _scoreObserver = FindObjectOfType<ScoreObserver>();
            if (_scoreObserver != null)
            {
                Attach(_scoreObserver);
            }
        }

        void Update()
        {
            scoreText.text = player.position.z.ToString("0");
            if (player.position.z >= 300)
            {
                Debug.Log("AHHHHHH");
                ScoreReached = true;
                NotifyObservers();
            }
            else if (player.position.z >= 200)
            {
                Target = true;
                NotifyObservers();
            }

            if (player.position.y <= -1) // Trigger event when y position <= -5
            {
                ColorChangeTriggered = true;
                NotifyObservers();
            }
        }
    }
}