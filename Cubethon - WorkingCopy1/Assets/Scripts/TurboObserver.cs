using UnityEngine;

namespace Chapter.Observer
{
    public class TurboObserver : Observer
    {
        [SerializeField] private GameObject car; // Reference to the hat object set in the editor

        void Start()
        {
            if (car != null)
            {
                car.SetActive(false); // Ensure the hat is initially hidden in the editor
            }
            else
            {
                Debug.LogError("car object not assigned in the editor!");
            }
        }

        public override void Notify(Subject subject)
        {
            Debug.Log("Turbo mode activated!");
            if (car != null)
            {
                car.SetActive(true); // Show the hat when turbo is activated
                Debug.Log("car given to the player!");
            }
        }
    }
}