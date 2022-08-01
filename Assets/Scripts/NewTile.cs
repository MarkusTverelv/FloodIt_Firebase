using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTile : ICreate
{
    int colorID;

    bool isConquered;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ICreate.SetState(bool isConquered)
    {
        this.isConquered = isConquered;
    }

    void ICreate.SetPosition(float x, float y)
    {
        position = new Vector3(x, y, 0);
    }

    void ICreate.ChangeColorID(int index)
    {
        colorID = index;
    }
}
