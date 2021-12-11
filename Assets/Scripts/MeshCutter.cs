using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCutter : MonoBehaviour
{
    public GameObject TargetObject;

    public GameObject In;  // TODO: 動作確認用
    public GameObject Out;  // TODO: 動作確認用

    // 切断用オブジェクトの切断面メッシュ情報
    private MeshFilter cutterMeshFilter;
    private Mesh cutterMesh;

    // 切断対象オブジェクトのメッシュ情報
    private MeshFilter targetMeshFilter;
    private Mesh targetMesh;

    private Plane cutPlane;  // TODO: 動作確認用

    void Start()
    {
        // 切断用meshの取得
        cutterMeshFilter = GetComponent<MeshFilter>();
        cutterMesh = cutterMeshFilter.mesh;

        // 切断対象objectのmesh取得
        targetMeshFilter = TargetObject.GetComponent<MeshFilter>();
        targetMesh = targetMeshFilter.mesh;


        // TODO: 動作確認用に切断平面を作成
        cutPlane = new Plane(new Vector3(0, 1, 0), Vector3.zero);


        Test();
    }

    //void Update()  TODO: 動作確認のためコメントアウト
    void Test()
    {
        DVector3 p1, p2, p3;
        bool p1Bool, p2Bool, p3Bool;

        // カットしたいオブジェクトのメッシュをトライアングルごとに処理
        for (int i = 0; i < targetMesh.triangles.Length; i += 3)
        {
            // メッシュの3つの頂点を取得
            p1 = new DVector3(transform.TransformPoint(targetMesh.vertices[targetMesh.triangles[i]]));
            p2 = new DVector3(transform.TransformPoint(targetMesh.vertices[targetMesh.triangles[i + 1]]));
            p3 = new DVector3(transform.TransformPoint(targetMesh.vertices[targetMesh.triangles[i + 2]]));

            // 頂点が切断面のどちら側にあるか(true: 内側、false: 外側)
            p1Bool = DVector3.Dot(new DVector3(cutPlane.normal), p1) + (double)cutPlane.distance < 0 ? true : false;
            p2Bool = DVector3.Dot(new DVector3(cutPlane.normal), p2) + (double)cutPlane.distance < 0 ? true : false;
            p3Bool = DVector3.Dot(new DVector3(cutPlane.normal), p3) + (double)cutPlane.distance < 0 ? true : false;

            // 3つの頂点が全て内側にある場合はそのままメッシュ登録
            if (p1Bool && p2Bool && p3Bool)
            {
                // TODO
                Instantiate(In, new Vector3((float)p1.x, (float)p1.y, (float)p1.z), Quaternion.identity);  // 動作確認用
            }
            // 3つの頂点が全て外側にある場合は表示する必要がないためスキップ
            else if (!p1Bool && !p2Bool && !p3Bool)
            {
                // TODO
                Instantiate(Out, new Vector3((float)p1.x, (float)p1.y, (float)p1.z), Quaternion.identity);  // 動作確認用
            }
            else
            {
                // TODO
            }
        }
    }
}
