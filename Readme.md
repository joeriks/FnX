####Helpers around Func for encapsulation, creation with inferred types, currying and recursion. Makes it easier to create, use and pass around funcs in C#.

*(any object).Select(func map)* maps any object to a new object (just like Linq Select).

*Fn.Func(func)* creates a new Func. With types inferred.

*Fn.Select(func)* invokes a new Func immediately and returns any object - with the type, even if its anonymous.

*(any object).SelectIf(condition, func)* invokes a func and returns its result - if the condition is true.

*(any object).SelectIfNull(func)* invokes a func - if the object is null.

*(any object).SelectIfEmpty(func)* invokes a func - if the enumerable is null or empty.

*(any object).FuncFromAnonymous(func)* creates a new Func. With types inferred. Use a default object to figure out the type.

*(func).Func(T param...)* creates a new Func based on an existing, with reduced parameters(s), also known as currying.

*Fn.NewList(func)* creates an empty list of the out type of the Func.

*Fn.Y(this => param => {something...; this(param);})* recursive call within a func

####Installation:

	Install-Package FnX.Fn

	using FnX;


####Example 1:

Specify intent and encapsulate functionality without spreading it cross separate ordinary functions:
Note that the encapsulated code here are only supposed to be two or three lines each, 

    bool SomeFunction(var incomingData:Foo) {
    
	    var customActionOnIncomingData = incomingData.Select(self=> 
	    {
	    	... some functionality ...
	    	return ...
	    });
	    
	    var storeInDatabase = customActionOnIncomingData.Select(self=>
	    {
	    	... some functionality ...
	    	return ...;
	    });
	    
	    var sendEmail = storeInDatabase.Select(self=>
	    {
	    	... some functionality ...
	    	return ...;
	    });
	    
	    return sendEmail.Success;
    }
    
####Example 2:

Use ExtensionMethod Select: (any object).Select to map any object to an anonymous object:

    var fakeRequestObject = new Dictionary<string, object> { { "id", 12 }, { "foo", null } };

    var request = fakeRequestObject.Select(self => new
    {
        id = self["id"] ?? 0,
        foo = self["foo"] ?? ""
    });

    Assert.AreEqual(12, request.id);
    Assert.AreEqual("", request.foo);

####Example 3:

On the fly mapper:

    var mapFooToBar = Fn.Func((Foo self) => new Bar { Id = self.Id, Name = self.Name });
    var bar = foo.Select(mapFooToBar);

or

    var bar = foo.Select(self => new Bar { Id = self.Id, Name = self.Name });
    
    
or use the mapper on a reqular LINQ Select on a list

    var listOfBars = foos.Select(mapFooToBar);

On the fly mapper with dictionary:

    var bar = dict.Select(self =>
        {
            var dictMapper = Fn.Func((string name) => self[name] ?? "");
            return new
            {
                Id = dictMapper("Id"),
                Foo = dictMapper("Foo")
            };
        });

####Example 4:

Use Fn.Func to create a Func with type inferred from the actual lambda:

	var queryByCategoryAndColor = Fn.Func((string cateogory, string color)=>{
		return SomeDb.ProductsQuery.Where(p=>p.Color==color && p.Category==category).Select(p=> new {p.Id, p.Name});
	});
	
... which in this caase returns an anoymous type which you can not declare with a Func<...>

But even if you use non-anonymous types you are helped by this method as you do not need to write

	Func<string> some = ()=>"foo";
	
Instead, just write:

	var some = Fn.Func(()=>"foo");

####Example 5:

Use Fn.Select to enclose code inside a Func and return an anonymous object (or any type):

	var request = Fn.Select(()=>{
		var category = Request["category"];
		var color = Request["color"];
		if (category=="" && color=="") throw new Exception("Not allowed");
		return new {category, color};
	});

####Example 6:

Use Fn.Func to create an "anonymous typecreator":

	var newPerson = Fn.Func((string name, string address)=>new{name,address});
	var p = newPerson("Foo","Bar");

####Example 7:

Use Fn.NewList together with a anonymous typecreator to create a list for anonymous objects of that type.

	var newPerson = Fn.Func((string name, string address)=>new{name,address});
	var list = Fn.NewList(newPerson);
	list.Add(newPerson("one", "two"));
	list.Add(newPerson("three", "four"));

The NewList returns an empty list with the anonymous object signature. Which is not possible otherwise as new List, just like new Func, needs the type argument to be specified.
"Using the generic type 'System.Collections.Generic.List<T>' requires 1 type arguments"

####Example 8:

Use the anonymous typecreator together with Linq Select:

	var listOfPersons = Db.SomeQuery.Select(r=>newPerson(r.Name,r.Address));

####Example 9:

Reduce the number of parameters of an existing Func ("currying") with Func extension method:

	var function = Fn.Func((int a, int b) => a + b);
    var reduced = function.Func(1);

    var result = reduced(1);
    Assert.AreEqual(2,result);

####Example 10:

Currying supports up to 9 parameters, reduced to any number below that:

    var functionWithNineParameters = Fn.Func((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
    var reducedToFiveParameters = functionWithNineParameters.Func(1, 1, 1, 1);
    var result = reducedToFiveParameters(1, 1, 1, 1, 1);
    Assert.AreEqual(9, result);


####Example 11:

Recursion on Funcs - using Y Combinator: flatten node tree to a string

    var rootNode = //some node hierarchy (see tests for example)
    var result = new StringBuilder();
    Fn.Y<Node>(recursiveAction => 
        param => { 
            result.Append(param.Name); 
            foreach (var c in param.Children) recursiveAction(c); 
            })(rootNode);
            
Ref for the Y Combinator code : Wes Dyer http://blogs.msdn.com/b/wesdyer/archive/2007/02/02/anonymous-recursion-in-c.aspx            

####Notes

The Func and Select is simply using generic factory pattern Func creators, which gives us type inferrence for our new Funcs.

In C# we cannot use var f = new Func(()=>) without explicitly write the types as C# constructors cannot infer types http://stackoverflow.com/questions/3570167/why-cant-the-c-sharp-constructor-infer-type we need this factory pattern to make it nice and easy to create Func's without declaring the type explicitly. 

The helpers are simply wrappers:

	public static Func<TOut> Func<TOut>(Func<TOut> func)
	{
		return func
	}

and 

    public static TOut Select<TOut>(Func<TOut> func)
    {
        return func();
    }

with overloads for 0-9 parameters.

The curry looks like this

	public static Func<T2, T3, TOut> Func<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1)
    {
        return (t2, t3) => func(t1, t2, t3);
    }

To save me from a lot of manual coding I'm using T4's to create all necessary overloads. So if anyone needs to support a lot more parameters it's easy to just change the T4 code to do so.
