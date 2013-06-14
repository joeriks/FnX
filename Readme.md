####FnX.Fn is a helper to make a little more use of anonymous objects. 

The helper is a simple static class with functions that uses generics to make it possible to create anonymous object returning Funcs as well as invoked objects from such Funcs.

While doing this we isolate code and create and pass around strongly typed anonymous objects in ways that are not otherwise possible. A nice detail is that anonymous objects are immutable.

I found this suits script like coding very well, as WebPages Razor and ScriptCs.

The strongly typed anonymous objects makes us get complete intellisense (for the objects as well as the lists) in Visual Studio. Unfortunately WebMatrix intellisense does not work with anonymous objects (version 3).

####Installation:

	Install-Package FnX.Fn

####Example 1:

Use Fn.Create to create a Func that returns a list of anonymous objects:

	using FnX;
	var queryByCategoryAndColor = Fn.Create((string cateogory, string color)=>{
		return SomeDb.ProductsQuery.Where(p=>p.Color==color && p.Category==category).Select(p=> new {p.Id, p.Name});
	});

(You cannot create a func that returns anonymoys types otherwise, as you need to explicitly define the type var f = new Func<?>)

####Example 2:

Use Fn.Invoke to enclose code inside a Func and return an anonymous object:

	var request = Fn.Invoke(()=>{
		var category = Request["category"];
		var color = Request["color"];
		if (category=="" && color=="") throw new Exception("Not allowed");
		return new {category, color};
	});

####Example 3:

Use Fn.Create to create an "anonymous typecreator":

	var newPerson = Fn.Create((string name, string address)=>new{name,address});
	var p = newPerson("Foo","Bar");

####Example 4:

Use Fn.NewList together with a anonymous typecreator to create a list for anonymous objects of that type.

	var newPerson = Fn.Create((string name, string address)=>new{name,address});
    var list = Fn.NewList(newPerson);
    list.Add(newPerson("one", "two"));
    list.Add(newPerson("three", "four"));

The NewList returns an empty list with the anonymous object signature. Which is not possible otherwise as new List, just like new Func, needs the type argument to be specified.
"Using the generic type 'System.Collections.Generic.List<T>' requires 1 type arguments"

####Example 5:

Use the anonymous typecreator together with Linq Select:

	var listOfPersons = Db.SomeQuery.Select(r=>newPerson(r.Name,r.Address));

####Notes

The code behind the scenes looks simply like this:

	public static Func<TOut> Create<TOut>(Func<TOut> constructor)
	{
		return constructor;
	}

and 

    public static TOut Invoke<TOut>(Func<TOut> func)
    {
        return func();
    }

with overloads for 0-9 parameters.

