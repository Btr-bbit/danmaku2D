using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostShadow : MonoBehaviour
{
    public GameObject spiritPlayerShadow;

    public float duration = 2f;

    public float interval = 0.03f;

    void Start()
    {
    }

    private float lastTime = 0;

    private Vector3 lastPos = Vector3.zero;

    void Update()
    {
        if (lastPos == this.transform.position)
        {
            return;
        }
        lastPos = this.transform.position;
        /*if (Time.time - lastTime < interval)
        {
            return;
        }
        lastTime = Time.time;*/
        GameObject ghostitem = Instantiate(spiritPlayerShadow, transform.position, transform.rotation);
        ghostitem.GetComponent<GhostItem>().duration = duration;
        ghostitem.GetComponent<GhostItem>().deleteTime = Time.time + duration;

        /*for (int i = 0; i < meshRender.Length; i++)
        {
            Mesh mesh = new Mesh();
            meshRender[i].BakeMesh(mesh);

            GameObject go = new GameObject();
            go.hideFlags = HideFlags.HideAndDontSave;

            GhostItem item = go.AddComponent<GhostItem>();//控制残影消失
            item.duration = duration;
            item.deleteTime = Time.time + duration;

            MeshFilter filter = go.AddComponent<MeshFilter>();
            filter.mesh = mesh;

            MeshRenderer meshRen = go.AddComponent<MeshRenderer>();

            meshRen.material = meshRender[i].material;
            meshRen.material.shader = ghostShader;//设置xray效果
            meshRen.material.SetFloat("_Intension", Intension);//颜色强度传入shader中

            go.transform.localScale = meshRender[i].transform.localScale;
            go.transform.position = meshRender[i].transform.position;
            go.transform.rotation = meshRender[i].transform.rotation;

            item.meshRenderer = meshRen;
        }*/
    }
}