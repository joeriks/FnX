####Helpers around Func for encapsulation, creation with inferred types, currying and recursion. Makes it easier to create, use and pass around funcs in C#.
[![Gitter](https://badges.gitter.im/Join Chat.svg)](https://gitter.im/joeriks/FnX?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

*(any object).Map(func map)* maps any object to a new object (just like Linq Select).
*(any object).Select(func map)* maps any object to a new object (just like Linq Select).

*Fn.Func(func)* creates a new Func. With types inferred.

*Fn.Map(func)* invokes a new Func immediately and returns any object - with the type, even if its anonymous.

*(any object).MapIf(condition, func)* invokes a func and returns its result - if the condition is true.

*(any object).MapIfNull(func)* invokes a func - if the object is null.

*(any object).MapIfEmpty(func)* invokes a func - if the enumerable is null or empty.

*(any object).Action(action) invokes an action on the object.

*(any object).FuncFromAnonymous(func)* creates a new Func. With types inferred. Use a default object to figure out the type.

*(func).Func(T param...)* creates a new Func based on an existing, with reduced parameters(s), also known as currying.

*Fn.NewList(func)* creates an empty list of the out type of the Func.

*Fn.Y(this => param => {something...; this(param);})* recursive call within a func

####Installation:

	Install-Package FnX.Fn

	using FnX;


####Example Map (or Select):

Specify intent and encapsulate functionality without spreading it cross separate ordinary functions:
Note that the encapsulated code here are only supposed to be two or three lines each, 

    bool SomeFunction(var incomingData:Foo) {
    
	    var customActionOnIncomingData = incomingData.Map(self=> 
	    {
	    	... some functionality ...
	    	return ...
	    });
	    
	    var storeInDatabase = customActionOnIncomingData.Map(self=>
	    {
	    	... some functionality ...
	    	return ...;
	    });
	    
	    var sendEmail = storeInDatabase.Map(self=>
	    {
	    	... some functionality ...
	    	return ...;
	    });
	    
	    return sendEmail.Success;
    }
    
####Example Map (or Select):

Use ExtensionMethod Map: (any object).Map to map any object to an anonymous object:

    var fakeRequestObject = new Dictionary<string, object> { { "id", 12 }, { "foo", null } };

    var request = fakeRequestObject.Map(self => new
    {
        id = self["id"] ?? 0,
        foo = self["foo"] ?? ""
    });

    Assert.AreEqual(12, request.id);
    Assert.AreEqual("", request.foo);

###Example Action

Use Extensionmethod Action: (any object).Action to perform action on any object:

	Table.AddRow().Action(row=>{
		row.AddCell().Action(cell=>{
			cell.Text = "Sample";
			cell.Font.Bold = true;
		});
		row.AddCell().Action(cell=>{
			cell.Text = "Lorem ipsum";
		});
	})

####Example On the fly mapper

On the fly mapper:

    var mapFooToBar = Fn.Func((Foo self) => new Bar { Id = self.Id, Name = self.Name });
    var bar = foo.Map(mapFooToBar);

or

    var bar = foo.Map(self => new Bar { Id = self.Id, Name = self.Name });
    
    
or use the mapper on a reqular LINQ Select on a list

    var listOfBars = foos.Map(mapFooToBar);

On the fly mapper with dictionary:

    var bar = dict.Map(self =>
        {
            var dictMapper = Fn.Func((string name) => self[name] ?? "");
            return new
            {
                Id = dictMapper("Id"),
                Foo = dictMapper("Foo")
            };
        });

####Example Fn.Func

Use Fn.Func to create a Func with type inferred from the actual lambda:

	var queryByCategoryAndColor = Fn.Func((string cateogory, string color)=>{
		return SomeDb.ProductsQuery.Where(p=>p.Color==color && p.Category==category).Select(p=> new {p.Id, p.Name});
	});
	
... which in this caase returns an anoymous type which you can not declare with a Func<...>

But even if you use non-anonymous types you are helped by this method as you do not need to write

	Func<string> some = ()=>"foo";
	
Instead, just write:

	var some = Fn.Func(()=>"foo");

####Example Fn.Select

Use Fn.Map to enclose code inside a Func and return an anonymous object (or any type):

	var request = Fn.Map(()=>{
		var category = Request["category"];
		var color = Request["color"];
		if (category=="" && color=="") throw new Exception("Not allowed");
		return new {category, color};
	});

####Example Anonymous typecreator

Use Fn.Func to create an "anonymous typecreator":

	var newPerson = Fn.Func((string name, string address)=>new{name,address});
	var p = newPerson("Foo","Bar");

####Example Create list with anonymous type

Use Fn.NewList together with a anonymous typecreator to create a list for anonymous objects of that type.

	var newPerson = Fn.Func((string name, string address)=>new{name,address});
	var list = Fn.NewList(newPerson);
	list.Add(newPerson("one", "two"));
	list.Add(newPerson("three", "four"));

The NewList returns an empty list with the anonymous object signature. Which is not possible otherwise as new List, just like new Func, needs the type argument to be specified.
"Using the generic type 'System.Collections.Generic.List<T>' requires 1 type arguments"

####Example 

Use the anonymous typecreator together with Linq Select:

	var listOfPersons = Db.SomeQuery.Select(r=>newPerson(r.Name,r.Address));

####Example Currying 1

Reduce the number of parameters of an existing Func ("currying") with Func extension method:

	var function = Fn.Func((int a, int b) => a + b);
    var reduced = function.Func(1);

    var result = reduced(1);
    Assert.AreEqual(2,result);

####Example Currying 2

Currying supports up to 9 parameters, reduced to any number below that:

    var functionWithNineParameters = Fn.Func((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
    var reducedToFiveParameters = functionWithNineParameters.Func(1, 1, 1, 1);
    var result = reducedToFiveParameters(1, 1, 1, 1, 1);
    Assert.AreEqual(9, result);


####Example Recursion of funcs 

Recursion on Funcs - using Y Combinator: flatten node tree to a string

    var rootNode = //some node hierarchy (see tests for example)
    var result = new StringBuilder();
    Fn.Y<Node>(recursiveAction => 
        param => { 
            result.Append(param.Name); 
            foreach (var c in param.Children) recursiveAction(c); 
            })(rootNode);
            
Ref for the Y Combinator code : Wes Dyer http://blogs.msdn.com/b/wesdyer/archive/2007/02/02/anonymous-recursion-in-c.aspx            


####Example 12:

Continue to next if no hits.

            public static IEnumerable<MyModel> Search(int id, string fromDate, string toDate, string search)
            {

                var selectById = Fn.Func(() => Querying.Fetch<MyModel>(
                        "SELECT TOP 1 * FROM MyTable Where Id=@0",
                        id));

                var selectBetweenDates = Fn.Func(() => Querying.Fetch<MyModel>(
                        "SELECT TOP 50 * FROM MyTable Where RegDate BETWEEN @0 AND @1",
                        fromDate,
                        toDate);

                var selectFreeSearch = Fn.Func(() => Querying.Fetch<MyModel>(
                        "SELECT TOP 50 * FROM MyTable Where Name Like @0",
                        "%" + search ? "%"));

                return selectById()
                        .MapIfEmpty(selectBetweenDates)
                        .MapIfEmpty(selectFreeSearch);

            }


####Notes

The Func and Map is simply using generic factory pattern Func creators, which gives us type inferrence for our new Funcs.

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
