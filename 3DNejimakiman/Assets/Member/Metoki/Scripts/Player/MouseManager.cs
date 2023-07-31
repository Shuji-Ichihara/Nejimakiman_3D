using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mouseParticle;
    GameObject _mouseEffects;
    private Vector3 mousePos;
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(_mouseParticle, mousePos,Quaternion.identity);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseEffects = GameObject.Find("MouseParticle(Clone)");
            Destroy(_mouseEffects);
        }
    }
}