using UnityEngine;

namespace Chapter.Observer
{
    public class CameraController : Observer
    {

        private bool _isTurboOn;
        public Vector3 _initialPosition;
        PlayerMovement _playerMovement;

        void Start() {
            //gameManager = FindObjectOfType<GameManager>();
            _playerMovement = FindObjectOfType<PlayerMovement>();

        }
        void OnEnable()
        {
            _initialPosition = 
                gameObject.transform.localPosition;
        }

        void Update()
        {
            if (_isTurboOn)
            {
                _playerMovement.forwardForce = 20000f;
                //Debug.Log("SuperSpeed On");
            }
            else
            {
                _playerMovement.forwardForce = 2000f;
                //Debug.Log("normal Speed");
            }
        }

        public override void Notify(Subject subject)
        {
            Debug.Log("Notify called in CameraController");
            if (!_playerMovement)
                _playerMovement = subject.GetComponent<PlayerMovement>();

            if (_playerMovement)
            {
                _isTurboOn = _playerMovement.IsTurboOn;
                Debug.Log("CameraController: Turbo is now " + _isTurboOn);
            }
        }
    }
}