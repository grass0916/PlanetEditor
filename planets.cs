/*
    This file, we record the basic planet.
*/

using Objects; // objects.cs

using Console = System.Console;
using Exception    = System.Exception;
using System.Collections.Generic;
// using List    = System.Collections.Generic.List;

namespace Planets {

	public struct Coordinate {
		public double x;
		public double y;
		public double z;
	};

	public class Planet : Object {
		// Remoeve- Constructor that takes no arguments.
		// TODO - ??? public Planet() = delete;

		// Remoeve- Operator overloading.
		// TODO - ??? public operator=(const Planet & src) = delete;

		public Planet(Planet src) {

		}

		public Planet(string name, float r) {
			// TODO - ??? Object(name);
			this._radius = r;

			if (!this.radiusCheck()) { throw new Exception("ERR_WRONG_RADIUS"); }
		}

		public Planet(string name, Coordinate pos, float r) {
			// TODO - ??? Object(name);
			this._position = pos;
			this._radius   = r;

			if (!this.radiusCheck()) { throw new Exception("ERR_WRONG_RADIUS"); }
		}

		public void setPosition(Coordinate pos) {
			this._position = pos;
			return;
		}
		
		public void setRadius(float r) {
			this._radius = r;
			return;
		}
		
		public void addObject(Object obj) {
			this._objects.Add(obj);
			return;
		}
		
		public void removeObject(uint id) {
			foreach (Object obj in this._objects) {
				if (obj.getID() == id) {
					this._objects.Remove(obj);
					Console.Write("Remove object:{0}", obj.getID());
				}
			}
			return;
		}

		public override void update() {
			foreach (Object obj in this._objects) {
				obj.update();
				Console.Write("Object:{0} - {1}.", obj.getID(), obj.getName());
			}
			return;
		}

		/* Private memebers start from here */

		private bool radiusCheck() => (this._radius > 0.0);

		private Coordinate _position;
		private float _radius;
		private List<Object> _objects = new List<Object>();
	}
}