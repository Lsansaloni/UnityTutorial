using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManage : MonoBehaviour
{

    public LayerMask clickableLayer;

    public Texture2D pointer; //Normal pointer
    public Texture2D target; //Cursos¡r for clickable objes like the world
    public Texture2D doorway;//cursor for doorways
    public Texture2D combat;//cursor combat action


  
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            if(hit.collider.gameObject.tag == "Doorway"){
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}
