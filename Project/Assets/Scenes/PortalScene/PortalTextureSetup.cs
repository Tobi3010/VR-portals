using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraA;
    public Material cameraMatA;

    public Camera cameraB;
    public Material cameraMatB;

    void Start()
    {
        if(cameraA.targetTexture != null){
            cameraA.targetTexture.Release();  
        }    
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;

        if(cameraB.targetTexture != null){
            cameraB.targetTexture.Release();  
        }    
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }
}
