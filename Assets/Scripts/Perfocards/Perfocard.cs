using UnityEngine;

namespace Scripts
{
    public abstract class Perfocard : MonoBehaviour
    {
        [SerializeField] public abstract string InteractionName { get; }
    }
}
