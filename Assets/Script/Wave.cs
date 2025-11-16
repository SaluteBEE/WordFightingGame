using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Wave : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float damage = 10f;
    [SerializeField] public int currentRow = 0;
    [SerializeField] public string WaveText;
    [SerializeField] TextMeshPro WaveTextMesh;
    [SerializeField] MeshRenderer TextMesh;
    [SerializeField] BoxCollider2D col;

    void Start()
    {
        WaveTextMesh.text = WaveText;
        StartCoroutine(destroyWave());

        SpriteRenderer CharacterSR = GameObject.FindGameObjectWithTag("Character").GetComponent<SpriteRenderer>();
        
        TextMesh.sortingLayerID = CharacterSR.sortingLayerID;
        TextMesh.sortingOrder = CharacterSR.sortingOrder-1;
        
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    void LateUpdate()
    {

        WaveTextMesh.ForceMeshUpdate();
        var bounds = WaveTextMesh.textBounds;  
        col.size = new Vector2(bounds.size.x, bounds.size.y);
        col.offset = new Vector2(bounds.size.x/2,0);
    }
    IEnumerator destroyWave()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
    
}
