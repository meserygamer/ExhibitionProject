using UnityEngine;

namespace Scripts
{
    public class ClickerOpenner : MonoBehaviour
    {
        [SerializeField] protected Animator _UpTeethClickerAnimator;
        [SerializeField] protected Animator _DownTeethClickerAnimator;


        public void OpenTeeths()
        {
            _UpTeethClickerAnimator.SetTrigger("TeethOpen");
            _DownTeethClickerAnimator.SetTrigger("TeethOpen");
        }

        public void CloseTeeths()
        {
            _UpTeethClickerAnimator.SetTrigger("TeethClose");
            _DownTeethClickerAnimator.SetTrigger("TeethClose");
        }
    }
}
