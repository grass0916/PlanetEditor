using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Planet : MonoBehaviour {
	// Constants.
	public const float MIN_RAD = 0.1f;
	public const int   MIN_RES = 1;

	// Public values can be modified.
	public float currentRadius;
	public int   currentResolution;

	// [MonoBehaviour] Awake is called when the script instance is being loaded.
	public void Awake() {
		// Default value.
		this.currentRadius = 1f;
		this.currentResolution = 1;
	}

	// [MonoBehaviour] Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	public void Start() {
		// Default values.
		this.lstRad = this.currentRadius;
		this.lstRes = this.currentResolution;
		this.oriLon = 24 / this.lstRes;
		this.oriLat = 16 / this.lstRes;
		// Start to draw.
		this.illustratePlanet(this.lstRad, this.oriLon / this.lstRes, this.oriLat / this.lstRes);
	}

	// [MonoBehaviour] Update is called every frame, if the MonoBehaviour is enabled.
	public void Update() {
		if (this.lstRad != this.currentRadius || this.lstRes != this.currentResolution) {
			// Update parameters.
			this.lstRad = (this.currentRadius     >= MIN_RAD) ? this.currentRadius : MIN_RAD;
			this.lstRes = (this.currentResolution >= MIN_RES) ? this.currentResolution : MIN_RES;
			// Start to draw.
			this.illustratePlanet(this.lstRad, this.oriLon / this.lstRes, this.oriLat / this.lstRes);
		}
	}

	// [MonoBehaviour] This function is called when the MonoBehaviour will be destroyed.
	public void OnDestroy() {

	}

	/* Private members */
	private float lstRad;
	private int   lstRes, oriLon, oriLat;

	private void illustratePlanet(float nRad, int nLon, int nLat) {
		// Mesh filter.
		gameObject.AddComponent<MeshFilter>();
		// Mesh renderer.
		gameObject.AddComponent<MeshRenderer>();
		gameObject.GetComponent<MeshFilter>().mesh = new Mesh();

		/* Below code is based on web. */
		/* http://wiki.unity3d.com/index.php/ProceduralPrimitives */

		MeshFilter filter = gameObject.GetComponent<MeshFilter>();
		Mesh mesh = filter.sharedMesh;
		mesh.Clear();

		#region Vertices
		Vector3[] vertices = new Vector3[(nLon+1) * nLat + 2];
		float _pi = Mathf.PI;
		float _2pi = _pi * 2f;
		 
		vertices[0] = Vector3.up * nRad;
		for( int lat = 0; lat < nLat; lat++ )
		{
			float a1 = _pi * (float)(lat+1) / (nLat+1);
			float sin1 = Mathf.Sin(a1);
			float cos1 = Mathf.Cos(a1);
		 
			for( int lon = 0; lon <= nLon; lon++ )
			{
				float a2 = _2pi * (float)(lon == nLon ? 0 : lon) / nLon;
				float sin2 = Mathf.Sin(a2);
				float cos2 = Mathf.Cos(a2);
		 
				vertices[ lon + lat * (nLon + 1) + 1] = new Vector3( sin1 * cos2, cos1, sin1 * sin2 ) * nRad;
			}
		}
		vertices[vertices.Length-1] = Vector3.up * -nRad;
		#endregion
		 
		#region Normales		
		Vector3[] normales = new Vector3[vertices.Length];
		for( int n = 0; n < vertices.Length; n++ )
			normales[n] = vertices[n].normalized;
		#endregion
		 
		#region UVs
		Vector2[] uvs = new Vector2[vertices.Length];
		uvs[0] = Vector2.up;
		uvs[uvs.Length-1] = Vector2.zero;
		for( int lat = 0; lat < nLat; lat++ )
			for( int lon = 0; lon <= nLon; lon++ )
				uvs[lon + lat * (nLon + 1) + 1] = new Vector2( (float)lon / nLon, 1f - (float)(lat+1) / (nLat+1) );
		#endregion
		 
		#region Triangles
		int nbFaces = vertices.Length;
		int nbTriangles = nbFaces * 2;
		int nbIndexes = nbTriangles * 3;
		int[] triangles = new int[ nbIndexes ];
		 
		//Top Cap
		int i = 0;
		for( int lon = 0; lon < nLon; lon++ )
		{
			triangles[i++] = lon+2;
			triangles[i++] = lon+1;
			triangles[i++] = 0;
		}
		 
		//Middle
		for( int lat = 0; lat < nLat - 1; lat++ )
		{
			for( int lon = 0; lon < nLon; lon++ )
			{
				int current = lon + lat * (nLon + 1) + 1;
				int next = current + nLon + 1;
		 
				triangles[i++] = current;
				triangles[i++] = current + 1;
				triangles[i++] = next + 1;
		 
				triangles[i++] = current;
				triangles[i++] = next + 1;
				triangles[i++] = next;
			}
		}
		 
		//Bottom Cap
		for( int lon = 0; lon < nLon; lon++ )
		{
			triangles[i++] = vertices.Length - 1;
			triangles[i++] = vertices.Length - (lon+2) - 1;
			triangles[i++] = vertices.Length - (lon+1) - 1;
		}
		#endregion
		 
		mesh.vertices = vertices;
		mesh.normals = normales;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		 
		mesh.RecalculateBounds();
		mesh.Optimize();
	}
}
