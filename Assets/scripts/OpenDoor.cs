using UnityEngine;
using DG.Tweening;
public class OpenDoor : MonoBehaviour
{
    public Transform Door;

    private void OnTriggerEnter(Collider other)
    {
        Door.DOLocalMoveY(3f, 2f);
    }

    private void OnTriggerExit(Collider other)
    {
        Door.DOLocalMoveY(-1.4f, 2f);
    }
}
