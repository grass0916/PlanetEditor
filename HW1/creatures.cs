/*
    This file, we record the basic creatutes. Include the naive, lions and plants.
*/

using Objects; // objects.cs

using Console = System.Console;

namespace Creatures {
	public class CreatureType {
		// Values.
		protected enum CREATURE_STATUS     { DEAD = 0, ALIVE };
		protected enum CREATURE_MOVEMENT   { NONE = 0, RUN };
		protected enum CREATURE_ABSORPTION { NONE = 0, EAT, GROWTH };

		// Fields.
		protected int  status;
		protected int  movement;
		protected int  absorption;
		protected bool isAlive;

		// Constructor that takes no arguments.
		public CreatureType() {
			this.status     = (int)CREATURE_STATUS.ALIVE;
			this.movement   = (int)CREATURE_MOVEMENT.NONE;
			this.absorption = (int)CREATURE_ABSORPTION.NONE;
			this.isAlive    = true;
		}

		// Destructor that takes no arguments.
		~CreatureType() {
			this.status  = (int)CREATURE_STATUS.DEAD;
			this.isAlive = false;
		}

		// Define the movement of creature.
		public virtual void move() {
			// Nothing to do.
		}

		// Define the creature that how to absorb the nutrient.
		public virtual void absorb() {
			// Nothing to do.
		}

		// Get the status of the creature.
		public virtual int deadOrAlive() {
			Console.WriteLine((this.status == (int)CREATURE_STATUS.ALIVE) ? "Alive" : "Dead");
			return this.status;
		}

		// Define the creature that how to absorb the nutrient.
		public virtual bool alive() {
			return this.isAlive;
		}

		// 
		public virtual int birth() {
			// Nothing to do.
			return 0;
		}
	}

	// Extended creature: Lion.
	public class Lion : CreatureType {
		// Constructor that tasks no arguments.
		public Lion() {
			this.status     = (int)CREATURE_STATUS.ALIVE;
			this.movement   = (int)CREATURE_MOVEMENT.RUN;
			this.absorption = (int)CREATURE_ABSORPTION.EAT;
			this.isAlive    = true;
		}

		// Destructor that takes no arguments.
		~Lion() {
			this.status  = (int)CREATURE_STATUS.DEAD;
			this.isAlive = false;
		}

		// Define the movement of creature.
		public override void move() {
			Console.WriteLine("Run Run Run");
			return;
		}

		// Define the creature that how to absorb the nutrient.
		public override void absorb() {
			Console.WriteLine("Eat Eat Eat");
			return;
		}
	}

	// Extended creatures: Plant.
	public class Plant : CreatureType {
		// Constructor that tasks no arguments.
		public Plant() {
			this.status     = (int)CREATURE_STATUS.ALIVE;
			this.movement   = (int)CREATURE_MOVEMENT.NONE;
			this.absorption = (int)CREATURE_ABSORPTION.GROWTH;
			this.isAlive    = true;
		}

		// Destructor that takes no arguments.
		~Plant() {
			this.status  = (int)CREATURE_STATUS.DEAD;
			this.isAlive = false;
		}

		// Define the movement of creature.
		public override void move() {
			Console.WriteLine("Cannot move");
			return;
		}

		// Define the creature that how to absorb the nutrient.
		public override void absorb() {
			Console.WriteLine("Growth");
			return;
		}

		// 
		public override int birth() {
			Console.WriteLine("Spread seed");
			return 0;
		}
	}

	// TODO - Class Creature.
	/*
	class Creature<T> : Object where T : CreatureType, new() {

		// Destructor that takes no arguments.
		~Creature() {

		}

		private int _amount = 0;
		private T _p_implement = null;
	}
	*/
}