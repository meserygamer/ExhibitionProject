using System.Collections.Generic;
using UnityEngine;


namespace Scripts
{
    public class PerfocardCounter : MonoBehaviour
    {
        [SerializeField] private PerfocardCounterTrigger _scorringTrigger;
        [SerializeField] private PerfocardSpawner _spawner;
        [SerializeField] private Animator _wallEAnimator;
        [SerializeField] private ColorSwitcher _colorSwitcher;
        [SerializeField] private GameOverScreen _gameOverScreen;

        private uint _counter = 0;

        private List<string> _rightAnswears = new List<string>() 
        {
            "MoveForward",
            "RotateRight",
            "MoveForward",
            "RotateLeft",
            "MoveForward",
            "RotateLeft",
            "MoveForward",
            "RotateRight",
            "MoveForward"
        };


        public void Start()
        {
            _scorringTrigger.ObjectEnteredInTrigger += OnObjectEnteredInTriggerHandler;
        }


        private void OnObjectEnteredInTriggerHandler(Collider collider)
        {
            collider.gameObject.TryGetComponent(out Perfocard perfocard);
            if(perfocard is null)
                return;
            _wallEAnimator.SetBool("MoveForward", false);
            _wallEAnimator.SetBool("RotateLeft", false);
            _wallEAnimator.SetBool("RotateRight", false);
            if (_rightAnswears[(int)_counter] == perfocard.InteractionName)
            {
                _colorSwitcher.SwitchToRightColor();
                _counter++;
            }
            else
            {
                _colorSwitcher.SwitchToErrorColor();
                _gameOverScreen.AddFail();
            }
            _wallEAnimator.SetBool(perfocard.InteractionName, true);
            _spawner.RespawnPerfocards();
        }
    }
}
