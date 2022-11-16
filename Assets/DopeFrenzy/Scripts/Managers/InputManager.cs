using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;
        public InputPlayer inputPlayer;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            inputPlayer = new InputPlayer();
            inputPlayer.Enable();
        }


    }

}

