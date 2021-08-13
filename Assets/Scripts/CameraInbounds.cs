using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInbounds : MonoBehaviour
{
    [SerializeField] private Transform map;
    [SerializeField] private Camera camera;

    private float MapX;
    private float MapY;

    private BoxCollider2D collider;
    private float SizeWidth;
    private float SizeHeight;

    private float LeftBound;
    private float RightBound;
    private float BottomBound;
    private float UpperBound;

    private Vector2 ScreenBounds;
    private Vector2 camerpos;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        SizeWidth = collider.bounds.size.x;
        SizeHeight = collider.bounds.size.y;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    // Update is called once per frame
    void LateUpdate()
    {
        MapX = map.position.x;
        MapY = map.position.y;

        camerpos = camera.transform.position;

        LeftBound = MapX - SizeWidth / 2;
        RightBound = MapX + SizeWidth / 2;
        UpperBound = MapY + SizeHeight / 2;
        BottomBound = MapY - SizeHeight / 2;

        camerpos.x = Mathf.Clamp(camerpos.x, LeftBound, RightBound);
        camerpos.y = Mathf.Clamp(camerpos.y, BottomBound, UpperBound);

    }
}
