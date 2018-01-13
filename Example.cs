using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : Monobehaviour{
    List<Finger> fList;
    FingerManager fManager;
    void Update () {
            fList = fManager.updateList(Input.touches);
        if (Input.touchCount == 0)
        fList = fManager.ClearFingers();
            foreach (Finger f in fList) {
                //DO STUFF
            }
    }
}