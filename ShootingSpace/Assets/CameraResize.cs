using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour {

    public const float DESIGN_W = 600f;
    public const float DESIGN_H = 900f;

    public float runtimeH;

    public DestroyByBoundary boundary;

    private void Awake()
    {
        float runtimeWdivH = Screen.width * 1.0f / Screen.height;

        //Debug.LogError(">>>>" + Screen.width);
        //Debug.LogError(">>>>" + Screen.height);
        //Debug.LogError(">>>>"+ runtimeWdivH);

        float w = Camera.main.orthographicSize * DESIGN_W / DESIGN_H;

        runtimeH = w / runtimeWdivH;

        Camera.main.orthographicSize = runtimeH;

        Camera.main.transform.position = new Vector3(
            0, Camera.main.transform.position.y, 0
            );

        boundary.SetSize(w*2, runtimeH*2);
        boundary.transform.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);
    }


}
