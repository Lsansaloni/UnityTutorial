﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManage : MonoBehaviour
{

    public LayerMask clickableLayer;

    public Texture2D pointer; //Normal pointer
    public Texture2D target; //Cursos¡r for clickable objes like the world
    public Texture2D doorway;//cursor for doorways
    public Texture2D combat;//cursor combat action

    public EventVector3 OnclickEnviroment;



    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            bool item = false;

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }           
            else if(hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;

                    OnclickEnviroment.Invoke(doorway.position);
                    Debug.Log("DOOOR");
                }
                else if(item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;

                    OnclickEnviroment.Invoke(itemPos.position);
                    Debug.Log("ITEM");
                }
                else
                {
                    OnclickEnviroment.Invoke(hit.point);
                }
            }
        }
        else
        {

            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>
{

}