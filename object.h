#ifndef _OBJECT_H
#define _OBJECT_H
#include <string>
#include <memory>
#include <exception>

class Object {
public:
	Object() = delete;
	
	Object& operator=(const Object& src);
	Object(const std::string& name);
	Object(const Object& src);
	virtual ~Object() {};

	unsigned int getID() const { return _ID; }
	std::string getName() const { return _name; }

	virtual void update() = 0;

private:
	static unsigned int s_next_id;
	
	unsigned int _ID;
	std::string _name;
};

typedef std::shared_ptr<Object> ObjectPtr;

#endif