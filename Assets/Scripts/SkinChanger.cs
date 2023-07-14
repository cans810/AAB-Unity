 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SkinChanger : MonoBehaviour
{
    public SpriteLibraryAsset[] skins;
    private int skinNum = 0;

    public void setPlayerModelNext(){
        skinNum += 1;
        ChangeSkin(skins[skinNum]);
    }
    public void setPlayerModelPrev(){
        skinNum -= 1;
        ChangeSkin(skins[skinNum]);
    }

    public void ChangeSkin(SpriteLibraryAsset skin){
        GetComponent<SpriteLibrary>().spriteLibraryAsset = skin;
    }

    public SpriteLibraryAsset getCurrentSkin(){
        return GetComponent<SpriteLibrary>().spriteLibraryAsset;
    }
}
