using UnityEngine;


namespace Chapter.Observer
{
   public class PlayerMovement : Subject
    {
        public bool IsTurboOn
        {
            get; private set;
        }

        private TurboObserver _turboObserver;


        public Rigidbody rb;
        public float forwardForce = 2000f;
        public float sidewaysForce = 500f;
        //For command pattern
        GameManager gameManager;
        PlayerCollision _playerCollision;
        HUDController _hudController;
        CameraController _cameraController;

        void Awake()
        {
            _hudController = FindObjectOfType<HUDController>();
            _cameraController = FindObjectOfType<CameraController>();
            Debug.Log("PM AKWAKE CameraController found: " + (_cameraController != null));

            _turboObserver = FindObjectOfType<TurboObserver>();
            if (_turboObserver != null)
            {
                Attach(_turboObserver);
            }
        }

        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            _playerCollision = FindObjectOfType<PlayerCollision>();
            //_cameraController = FindObjectOfType<CameraController>();
        }

        void OnEnable()
        {
            if (_hudController) 
                Attach(_hudController);

            if (_cameraController) {
                Attach(_cameraController);
                Debug.Log("Cam control attatched Player Movement On Enable");
            }    
            else
            {
                Debug.LogError("CameraController is null!");
            }
                
        }

        void OnDisable()
        {
            if (_hudController) 
                Detach(_hudController);

            if (_cameraController) 
                Detach(_cameraController);
        }

        //void Update()
        void FixedUpdate()
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey("d"))
            {
                // rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

                // instead of just calling addforce, we want to package this up as a command
                // and send to an invoker
                // we'll need a command class, some commands, and an invoker...
                Command moveRight = new MoveRight(rb, sidewaysForce);
                Invoker invoker = new Invoker();
                invoker.SetCommand(moveRight);
                invoker.ExecuteCommand();
            }

            if (Input.GetKey("a"))
            {
                //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                Command moveLeft = new MoveLeft(rb, sidewaysForce);
                Invoker invoker = new Invoker();
                invoker.SetCommand(moveLeft);
                invoker.ExecuteCommand();
            }

            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame(null);
                //FindObjectOfType<GameManager>().EndGame();
            }
        }
        
        public void ToggleTurbo() {
            IsTurboOn = !IsTurboOn;
            Debug.Log("Turbo toggled: " + IsTurboOn);
            if (IsTurboOn)
            {
                NotifyObservers();
            }
        }
    }
}