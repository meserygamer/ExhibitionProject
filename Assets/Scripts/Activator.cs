using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private GameObject _fire;


    public void EnableFire()
    {
        _fire.SetActive(true);
    }
}
