using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            if (SceneView.lastActiveSceneView != null)
            {
                var sceneCam = SceneView.lastActiveSceneView.camera;
                if (sceneCam != null)
                {
                    transform.forward = sceneCam.transform.forward;
                }
            }
            return;
        }
#endif

        transform.forward = Camera.main.transform.forward;
    }
}