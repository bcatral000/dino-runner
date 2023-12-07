using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   private MeshRenderer meshRenderer;

   private void Awake()
   {
        meshRenderer = GetComponent<MeshRenderer>();
   }

//moves ground sprite to the right at a set speed
   private void Update()
   {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
   }
}
