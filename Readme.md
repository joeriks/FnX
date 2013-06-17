####Helpers to easily create functions (func's) on the fly, as well as such which returns a value immediately. Especially well suited for functions that returns anonymous types.

*Fn.New(func)* creates a new Func. With types inferred.

*Fn.Get(func)* invokes a new Func immediately and returns its value.

*(func).New(T param...)* creates a new Func based on an existing, with reduced parameters(s), also known as currying.

*Fn.NewList(func)* creates an empty list of the out type of the Func.

####Installation:

	Install-Package FnX.Fn

	using FnX;


####Example 1:

Use Fn.New to create a Func with type inferred from the actual lambda:

	var queryByCategoryAndColor = Fn.New((string cateogory, string color)=>{
		return SomeDb.ProductsQuery.Where(p=>p.Color==color && p.Category==category).Select(p=> new {p.Id, p.Name});
	});

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

Reduce the number of parameters of an existing Func (Curry) with New extension method:

	var function = Fn.New((int a, int b) => a + b);
    var reduced = function.New(1);

    var result = reduced(1);
    Assert.AreEqual(2,result);

####Example 7:

Currying supports up to 9 parameters, reduced to any number below that:

    var functionWithNineParameters = Fn.New((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
    var reducedToFiveParameters = function.New(1, 1, 1, 1);
    var result = reducedToFiveParameters(1, 1, 1, 1, 1);
    Assert.AreEqual(9, result);

####Notes

The New and Get is simply using generic factory pattern Func creators, which gives us type inferrence for our new Funcs.

In C# we cannot use var f = new Func(()=>) without explicitly write the types as C# constructors cannot infer types http://stackoverflow.com/questions/3570167/why-cant-the-c-sharp-constructor-infer-type we need this factory pattern to make it nice and easy to create Func's without declaring the type explicitly. 

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

To save me from a lot of manual coding I'm using T4's to create all necessary overloads. So if anyone needs to support a lot more parameters it's easy to just change the T4 code to do so.