#include "object.h"

unsigned int Object::s_next_id = 0;

Object& Object::operator=(const Object & src) {
	_name = src._name;
	return *this;
}

Object::Object(const std::string& name) : 
	_ID(s_next_id++), 
	_name(name) {

}

Object::Object(const Object & src) : 
	_name(src._name), 
	_ID(s_next_id++) {

}
