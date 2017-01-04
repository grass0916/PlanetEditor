#ifndef _ANIMAL_H
#define _ANIMAL_H
#include <string>
#include <vector>
#include <memory>
#include <exception>
#include "object.h"

class CreatureType {
public:
	CreatureType() {};
	virtual ~CreatureType() {};
	virtual void move() = 0;
	virtual void absorb() = 0;
	virtual int deadOrAlive() = 0;
	virtual bool alive() = 0;
	virtual int birth() = 0;
};

template<typename T>
class Creature : public Object {
public:
	Creature() = delete;
	Creature& operator=(const Creature& src) = delete;

	Creature(const Creature& src) : 
		Object(src.getName()), 
		_amount(src._amount) {
		_p_implement = new(std::nothrow) T(*src._p_implement);
	}

	Creature(const std::string& name) :
		Object(name) {
		_p_implement = new(std::nothrow) T();
	}

	virtual ~Creature() {
		if (_p_implement != nullptr)
			delete _p_implement;
	}

	virtual void update() {
		_p_implement->move();
		_p_implement->absorb();
		_amount -= _p_implement->deadOrAlive();
		if(_p_implement->alive())
			_amount += _p_implement->birth();
		_amount = _amount < 0 ? 0 : _amount;
	}

private:
	T* _p_implement = nullptr;
	int _amount = 0;
};

#endif