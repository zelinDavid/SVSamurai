using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Game.Service {
    public interface IInputService {
        void Input(InputButton button, InputState state);
    }

    /// <summary>
    /// 与Entitas交互的输入服务
    /// </summary>
    public class EntitasInputService : IInputService, IInitService {
        private Contexts _contexts;
        public void Init(Contexts contexts) {
            _contexts = contexts;

            _contexts.service.SetGameServiceEntitasInputService(this);
            _contexts.input.SetGameInputButton(InputButton.NULL, InputState.NULL);
        }

        public int GetPriority() {
            return 0;
        }

        public void Input(InputButton button, InputState state) {
            _contexts.input.ReplaceGameInputButton(button, state);
        }
    }

    public class UnityInputService : IInitService, IExcuteService, IPlayerBehaviour {
        public bool IsRun { get; set; }
        public bool IsCollideWall { get; set; }
        public bool IsAttack { get; }

        bool _isPress = false;

        IInputService _entitaInputService;
        InputButtonComponent _inputButton;
        Contexts _contexts;

        public void Init(Contexts contexts) {
            _contexts = contexts;

            _inputButton = contexts.input.gameInputButton;
            _entitaInputService = contexts.service.gameServiceEntitasInputService.EntitasInputService;
        }

        public void Attack(int skillCode) {
            InputDown(KeyCode.K, InputButton.ATTACK_O);
            InputDown(KeyCode.L, InputButton.ATTACK_X);
        }

        public void Idle() {
            if (!_isPress && _inputButton.InputButton != InputButton.NULL && _inputButton.InputState != InputState.NULL)
            {
                _entitaInputService.Input(_inputButton.InputButton, _inputButton.InputState);
            }
        }

        public void Move() {
             
        }

        public void TrunRight() {
            if (!InputDown(KeyCode.D, InputButton.RIGHT))
                InputPress(KeyCode.D, InputButton.RIGHT);
        }

        public void TurnBack() {
            if(!InputDown(KeyCode.S, InputButton.BACK))
                InputPress(KeyCode.S, InputButton.BACK);
        }

        public void TurnForward() {
             if(!InputDown(KeyCode.W, InputButton.FORWARD))
                InputPress(KeyCode.W, InputButton.FORWARD);
        }

        public void TurnLeft() {
            if (!InputDown(KeyCode.A, InputButton.LEFT))
                InputPress(KeyCode.A, InputButton.LEFT);
        }

        public int GetPriority() {
            return 1;
        }

        public bool InputDown(KeyCode code, InputButton button){
            if(UnityEngine.Input.GetKeyDown(code)){
                Input(button, InputState.DOWN);
                _isPress = true;
                return true;
            }else{
                return false;
            }
        }


        public bool InputPress(KeyCode code, InputButton button)
        {
            if (UnityEngine.Input.GetKey(code))
            {
                Input(button, InputState.PREE);
                _isPress = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InputUp(KeyCode code, InputButton button)
        {
            if (UnityEngine.Input.GetKeyUp(code))
            {
                Input(button, InputState.UP);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void Input(InputButton button, InputState state){
            _entitaInputService.Input(button, state);
        }
        
        //暂时没看懂这块逻辑
        public void Execute() {

            TurnForward();

            TurnBack();

            TurnLeft();

            TrunRight();

            Attack(0);

            Idle();
        }
    }

}