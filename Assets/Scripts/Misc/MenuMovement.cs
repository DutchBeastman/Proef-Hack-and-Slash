//Created by: Fabian Verkuijlen
using UnityEngine;
using System.Collections;

public class MenuMovement : MonoBehaviour {

    private Quaternion buttonRot;
    private RectTransform localRect;
    private Vector2 mousePos;
    [SerializeField]private Camera uiCamera;
    [SerializeField][Range(0.001f, 0.03f)]private float moveSpeedX = 0.01f;
    [SerializeField][Range(0.001f, 0.03f)]private float moveSpeedY = 0.01f;
    [SerializeField]private Vector2 moveRange = new Vector2(50, 50);

    protected void Awake()
    {
        localRect = this.GetComponent<RectTransform>();
        if(uiCamera == null)
        {
            uiCamera = Camera.main;
            Debug.LogWarning("Camera was not set, Setting it to Main camera");
        }
        buttonRot = localRect.localRotation;
    }
    protected void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.x += Screen.width / 3;
        mousePos.y -= Screen.width / 2;
        RotateElement(mousePos);
    }

    private void RotateElement(Vector2 mousePos)
    {
        buttonRot = Quaternion.Euler(Mathf.Clamp((mousePos.y) * moveSpeedY, -moveRange.x, moveRange.y), Mathf.Clamp((mousePos.x)* moveSpeedX ,-moveRange.x,moveRange.y), 0);
        localRect.localRotation = buttonRot;
    }

}
