####Helpers to create type inferred funcs and return object (of inferred type) from such funcs. Supports anonymous types. And also currying.

####Installation:

	Install-Package FnX.Fn

####Example 1:

Use Fn.New to create a Func with type inferred from the actual lambda:

	using FnX;
	var queryByCategoryAndColor = Fn.New((string cateogory, string color)=>{
		return SomeDb.ProductsQuery.Where(p=>p.Color==color && p.Category==category).Select(p=> new {p.Id, p.Name});
	});

(You cannot create a func that returns anonymoys types otherwise, as you need to explicitly define the type var f = new Func<?>)

####Example 2:

Use Fn.Get to enclose code inside a Func and return an anonymous object:

	var request = Fn.Get(()=>{
		var category = Request["category"];
		var color = Request["color"];
		if (category=="" && color=="") throw new Exception("Not allowed");
		return new {category, color};
	});

####Example 3:

Use Fn.New to create an "anonymous typecreator":

	var newPerson = Fn.New((string name, string address)=>new{name,address});
	var p = newPerson("Foo","Bar");

####Example 4:

Use Fn.NewList together with a anonymous typecreator to create a list for anonymous objects of that type.

	var newPerson = Fn.New((string name, string address)=>new{name,address});
    var list = Fn.NewList(newPerson);
    list.Add(newPerson("one", "two"));
    list.Add(newPerson("three", "four"));

The NewList returns an empty list with the anonymous object signature. Which is not possible otherwise as new List, just like new Func, needs the type argument to be specified.
"Using the generic type 'System.Collections.Generic.List<T>' requires 1 type arguments"

####Example 5:

Use the anonymous typecreator together with Linq Select:

	var listOfPersons = Db.SomeQuery.Select(r=>newPerson(r.Name,r.Address));

####Example 6:

Curry with New extension method (supports up to 9 parameters, and reduced to any number below that):

	var function = Fn.New((int a, int b) => a + b);
    var reduced = function.New(1);

    var result = reduced(1);
    Assert.AreEqual(2,result);


####Notes

The code behind the scenes looks simply like this:

	public static Func<TOut> New<TOut>(Func<TOut> constructor)
	{
		return constructor;
	}

and 

    public static TOut Get<TOut>(Func<TOut> func)
    {
        return func();
    }

with overloads for 0-9 parameters.

