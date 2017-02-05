using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlanetEditor {
	static GameObject planet;

	[MenuItem("Examples/Create new planet")]
	static void CreatePlanet() {
		// Create a new game object.
		planet = new GameObject("New planet");
		// Planet.
		planet.AddComponent<Planet>();
	}
}