using UnityEngine;

namespace Chapter.Observer
{
    public class EndTrigger : MonoBehaviour
    {
        public GameManager gameManager;

        void OnTriggerEnter ()
        {
            gameManager.CompleteLevel();
        }
    }
}