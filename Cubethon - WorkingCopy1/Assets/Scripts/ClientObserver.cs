using UnityEngine;

namespace Chapter.Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        void Start()
        {
            _playerMovement =
                (PlayerMovement)
                FindObjectOfType(typeof(PlayerMovement));
        }

        void OnGUI()
        {
            if (GUILayout.Button("SuperSpeed"))
            {
                Debug.Log("SuperSpeed button clicked.");

                if (_playerMovement) 
                _playerMovement.ToggleTurbo();
            }

        }
    }
}