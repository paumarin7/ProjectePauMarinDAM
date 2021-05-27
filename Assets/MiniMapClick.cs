using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniMapClick : MonoBehaviour, IPointerClickHandler
{
    public Camera miniMapCam;
    GameObject player;

    public void OnPointerClick(PointerEventData eventData)
    {

        Vector2 localCursor = new Vector2(0, 0);

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RawImage>().rectTransform, eventData.pressPosition, eventData.pressEventCamera, out localCursor))
        {

            Texture tex = GetComponent<RawImage>().texture;
            Rect r = GetComponent<RawImage>().rectTransform.rect;

            //Using the size of the texture and the local cursor, clamp the X,Y coords between 0 and width - height of texture
            float coordX = Mathf.Clamp(0, (((localCursor.x - r.x) * tex.width) / r.width), tex.width);
            float coordY = Mathf.Clamp(0, (((localCursor.y - r.y) * tex.height) / r.height), tex.height);

            //Convert coordX and coordY to % (0.0-1.0) with respect to texture width and height
            float recalcX = coordX / tex.width;
            float recalcY = coordY / tex.height;

            localCursor = new Vector2(recalcX, recalcY);

            CastMiniMapRayToWorld(localCursor);

        }

    }

    private void CastMiniMapRayToWorld(Vector2 localCursor)
    {
        Ray miniMapRay = miniMapCam.ScreenPointToRay(new Vector2(localCursor.x * miniMapCam.pixelWidth, localCursor.y * miniMapCam.pixelHeight));

        RaycastHit miniMapHit;

        if (Physics.Raycast(miniMapRay, out miniMapHit, Mathf.Infinity))
        {

            if (miniMapHit.transform.gameObject.CompareTag("Teleport"))
            {

               if (miniMapHit.transform.gameObject.GetComponent<Teleport>().walked == true)
                {
                    player.GetComponent<CharacterController>().enabled = false;
                    player.transform.position = new Vector3(miniMapHit.transform.position.x, 0, miniMapHit.transform.position.z);
                    Debug.Log("miniMapHit: " + miniMapHit.collider.gameObject);
                    player.GetComponent<CharacterController>().enabled = true;
                }
                else
                {
                    Debug.Log("Alo");
                }

            }
            else
            {
                Debug.Log("miniMapHit: " + miniMapHit.collider.gameObject);
            }
       
        }

    }


    public void Start()
    {


        StartCoroutine(searchMinimapCamera());

        
    }

    public IEnumerator searchMinimapCamera()
    {
        yield return new WaitForSeconds(1);
        player = GameManager.player;
        miniMapCam = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();

    }
}
