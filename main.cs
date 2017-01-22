/*

 ____        _                        _            
/ ___|  __ _| |_ __ ___   ___  _ __  | |___      __
\___ \ / _` | | '_ ` _ \ / _ \| '_ \ | __\ \ /\ / /
 ___) | (_| | | | | | | | (_) | | | || |_ \ V  V / 
|____/ \__,_|_|_| |_| |_|\___/|_| |_(_)__| \_/\_/  

	Author: Ze-Hao Wang (Salmon)
	GitHub: http://github.com/grass0916
	Site:   http://salmon.tw

	Copyright 2017 Salmon

*/

using Planets;   // planets.cs
using Creatures; // creatures.cs

using Console   = System.Console;
using Exception = System.Exception;
using Regex     = System.Text.RegularExpressions.Regex;
using Match     = System.Text.RegularExpressions.Match;
using Int32     = System.Int32;
using UInt32    = System.UInt32;
using Convert   = System.Convert;

class PlanetEditor {
	public Planet planet = null;

	public static void CommandProtocal(string str) {
		// Parse the string, e.g. (<command> <param1> <param2> ...).
		Match m = Regex.Match(str, "(\\w|\"([^\"]+)\")+");

		// Search the command to do.
		switch (m.Value) {
			// 'CP' means that creating planet.
			case "cp":
				Coordinate pos;
				string planetName;
				int r;

				if (m.Length != 5) { throw new Exception("ERR_CP_PARAMS_NUMBER"); }

				// Normalize the parameters.
				m.NextMatch(); planetName = m.Value; // Name.
				m.NextMatch(); pos.x = Convert.ToDouble(m.Value); // x of position.
				m.NextMatch(); pos.y = Convert.ToDouble(m.Value); // y of position.
				m.NextMatch(); pos.z = Convert.ToDouble(m.Value); // z of position.
				m.NextMatch(); r = Int32.Parse(m.Value); // Radius.

				// Create a new planet.
				// TODO - Got some problems, Planet isn't a static member.
				planet = new Planet(planetName, pos, r);
				Console.WriteLine("Created a planet ({0}).", planetName);

				break;

			// 'AC' means that adding creature.
			case "ac":
				// The object (creature).
				// Object creature = null;
				// Type and name of creature.
				string creatureType, creatureName;

				if (m.Length != 2) { throw new Exception("ERR_AC_PARAMS_NUMBER"); }

				// Normalize the parameters.
				m.NextMatch(); creatureType = m.Value; // Type.
				m.NextMatch(); creatureName = m.Value; // Name.

				// Add a new creature.
				if (planet == null) {
					Console.WriteLine("Please create a planet first.");
				} else {
					switch (creatureType) {
						case "Lion":
							// TODO - new a Lion.
							// creature = new Creature<Lion>(creatureName);
							Console.WriteLine("Created a creature ({0}-{1}).", creatureType, creatureName);
							break;

						case "Plant":
							// TODO - new a Plant.
							// creature = new Creature<Plant>(creatureName);
							Console.WriteLine("Created a creature ({0})-{1}.", creatureType, creatureName);
							break;
					}
				}

				break;

			// 'RO' means that removing object.
			case "ro":
				// ID of pbject.
				uint objectID;

				if (m.Length != 1) { throw new Exception("ERR_RO_PARAMS_NUMBER"); }

				// Normalize the parameters.
				m.NextMatch(); objectID = System.UInt32.Parse(m.Value); // ID.

				// Remove the object in the planet.
				if (planet == null) {
					Console.WriteLine("Please create a planet first.");
				} else {
					planet.removeObject(objectID);
					Console.WriteLine("Remove an object ({0}).", objectID);
				}

				break;

			// 'UP' means that updating.
			case "up":
				if (m.Length != 0) { throw new Exception("ERR_UP_PARAMS_NUMBER"); }

				// Update the planet.
				if (planet == null) {
					Console.WriteLine("Please create a planet first.");
				} else {
					planet.update();
					Console.WriteLine("Update the planet.");
				}

				break;

			// Other cases.
			default:
				break;
		}

		return;
	}

	static void Main() {
		try {
			for (string line = Console.ReadLine(); line != "exit";) {
				// Message.
				Console.WriteLine("Your entered: " + line);
				// Command protocal.
				PlanetEditor.CommandProtocal(line);
				// Get next line (next command).
				line = Console.ReadLine();
			}

			return;
		} catch (Exception e) {
			Console.WriteLine(e.Message);

			return;
		}
	}
}
