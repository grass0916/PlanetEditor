#ifndef _PLANET_H
#define _PLANET_H
#include <iostream>
#include <string>
#include <list>
#include <memory>
#include <exception>
#include "coordinate.h"
#include "object.h"

class Planet : public Object {
public:
	Planet() = delete;
	Planet& operator=(const Planet& src) = delete;

	Planet(const Planet& src);

	Planet(const std::string& name, const float radius) throw(...) :
		Object(name),
		_position({}), 
		_radius(radius) {
		if (!radiusCheck())
			throw std::exception("Radius should be greater than 0.0f.");
	}

	Planet(const std::string& name, const Coordinate& position, const float radius) throw(...) :
		Object(name),
		_position(position),
		_radius(radius) {
		if (!radiusCheck())
			throw std::exception("Radius should be greater than 0.0f.");
	}

	void setPosition(const Coordinate& position) {
		_position = position;
	}

	void setRadius(const float radius) {
		_radius = radius;
	}

	void addObject(const ObjectPtr& ptr) {
		_object_ptrs.push_back(ptr);
	}

	void removeObject(uint32_t id);

	virtual void update() {
		for (auto& p : _object_ptrs) {
			std::cout << p->getID() << ' ' << p->getName() << std::endl;
			p->update();
			std::cout << std::endl;
		}
	}

private:
	bool radiusCheck() { return _radius > 0.0f; }

	Coordinate _position;
	float _radius;
	std::list<ObjectPtr> _object_ptrs;
};

#endif