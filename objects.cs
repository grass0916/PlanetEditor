/*
    This file, we record the basic object.

	About the 'Member initialization list' in C#.
		> http://stackoverflow.com/questions/2435175/when-initializing-in-c-sharp-constructors-whats-better-initializer-lists-or-as

	About the 'Operator overloading (=)' in C#.
		> http://stackoverflow.com/questions/599367/why-can-not-be-overloaded-in-c

*/

using Console = System.Console;

namespace Objects {

	public class Object {
		// Constructor that takes no arguments.
		public Object() {
			// Delete this constructor.
		}

		// Constructor that takes one string.
		public Object(string name) {
			// Initial.
			this._ID   = s_next_id++;
			this._name = name;
		}

		// Constructor that takes one Object class.
		public Object(Object src) {
			// Initial.
			this._ID   = s_next_id++;
			this._name = src.getName();
		}

		// Destructor that takes no arguments.
		~Object() {
			// Nothing to do.
		}

		/*

		// Operator overloading.
		public static Object operator =(Object src) {
			this._name = src._name;
			return this;
		}

		*/

		public uint getID() => this._ID;
		public string getName() => this._name;

		public virtual void update() {
			// Nothing to do.
		}

		/* Private memebers start from here */

		private static uint s_next_id;
		private uint _ID;
		private string _name;
	}
}