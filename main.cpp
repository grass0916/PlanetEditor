#include <iostream>
#include "creature.h"
#include "planet.h"
using std::cin;
using std::cout;
using std::endl;

class Lion : public CreatureType {
public:
	Lion() {}
	virtual ~Lion() {}
	virtual void move() { cout << "Run Run Run" << endl; }
	virtual void absorb() { cout << "Eat Eat Eat" << endl;}
	virtual int deadOrAlive() { cout << "Alive" << endl; return 0; }
	virtual bool alive() { return true; }
	virtual int birth() { return 0; }
};

class Plant : public CreatureType {
public:
	Plant() {}
	virtual ~Plant() {}
	virtual void move() { cout << "Plant cannot move :(" << endl; }
	virtual void absorb() { cout << "Growth" << endl; }
	virtual int deadOrAlive() { cout << "Alive" << endl;  return 0; }
	virtual bool alive() { return true; }
	virtual int birth() { cout << "Spread seeds" << endl;  return 0; }
};

int main() {
	std::string command;
	Planet* p_planet = nullptr;
	while (cin >> command, command != "exit") {
		if (command == "cp") {
			float r;
			Coordinate pos;
			std::string name;
			cin >> name >> pos.x >> pos.y >> pos.z >> r;
			try {
				p_planet = new(std::nothrow) Planet(name, pos, r);
				cout << p_planet->getName() << " created!" << endl;
			}
			catch (std::exception& e) {
				cout << e.what() << endl;
				cout << "you shall not pass!!" << endl;
				if (p_planet != nullptr)
					delete p_planet;
			}
		}
		else if(command == "ac") {
			std::string c_type;
			std::string name;
			cin >> c_type >> name;
			ObjectPtr op;
			if (c_type == "Lion") {
				op = std::make_shared<Creature<Lion>>(name);
			}
			else if (c_type == "Plant") {
				op = std::make_shared<Creature<Plant>>(name);
			}
			else {
				cout << "You shall not pass!!" << endl;
				continue;
			}
			if (p_planet == nullptr) {
				cout << "Please create planet first." << endl;
				continue;
			}
			else {
				p_planet->addObject(op);
				cout << op->getName() << " added!" << endl;
			}
		}
		else if (command == "ro") {
			unsigned int id;
			cin >> id;
			if (p_planet == nullptr) {
				cout << "Please create planet first." << endl;
			}
			else {
				p_planet->removeObject(id);
				cout << id << " removed!" << endl;
			}
		}
		else if (command == "up") {
			if (p_planet == nullptr) {
				cout << "Please create planet first." << endl;
			}
			else
				p_planet->update();
		}
	}
	return 0;
}