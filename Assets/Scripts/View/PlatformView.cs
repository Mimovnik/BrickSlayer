using UnityEngine;

public class PlatformView : Part
{
    public void Update(){
        transform.position = root.model.platformModel.transform.position;
    }
}
