/*
- declare event action in class doing initial act
- define callback method in observer matching event signature (returns void)
- subscribe for event by adding pointer to callback in event invocation list
	- obj.event += observer.action
- notify subs after each act

- eventhandler<Teventargs>.invoke(object sender, Teventargs e)
	- only in base class
*/