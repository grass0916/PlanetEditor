#include "planet.h"

Planet::Planet(const Planet & src) : 
	Object(src.getName()), 
	_object_ptrs() {
	for (const auto& sop : src._object_ptrs) {
		_object_ptrs.push_back(sop);
	}
}

void Planet::removeObject(uint32_t id) {
	for (auto it = _object_ptrs.begin(); it != _object_ptrs.end();  ++it) {
		if (id == (*it)->getID()) {
			_object_ptrs.remove(*it);
			return;
		}
	}
}
