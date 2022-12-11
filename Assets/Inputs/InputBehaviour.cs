using UnityEngine;

namespace Inputs
{
    public class InputBehaviour : MonoBehaviour
    {
        private readonly InputsCatcher _catcher = new InputsCatcher();

        void Update()
        {
            _catcher.Update();

            
        }
    }

    public class InputsCatcher
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Debug.Log(KeyCode.UpArrow);
        }
    }
}
