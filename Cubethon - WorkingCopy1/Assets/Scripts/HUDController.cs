using UnityEngine;

namespace Chapter.Observer {
    public class HUDController : Observer {

        private bool _isTurboOn;
        private PlayerMovement _playerMovement;

        void OnGUI() {
            /*
            GUILayout.BeginArea(new Rect(10, 10, 200, 200)); // Optional, for area definition
            if (GUILayout.Button("SuperSpeed")) {
                Debug.Log("SuperSpeed button clicked.");
                if (_playerMovement) 
                    _playerMovement.ToggleTurbo();
            }
            GUILayout.EndArea();*/
        }

        public override void Notify(Subject subject) {
            if (!_playerMovement)
                _playerMovement = 
                    subject.GetComponent<PlayerMovement>();

            if (_playerMovement){
                _isTurboOn = 
                    _playerMovement.IsTurboOn;
            }
        }
    }
}