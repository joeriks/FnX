FnX.Fn is a helper to make a little more use of anonymous objects. 

The helper is a simple static class that has some functions that uses generics to make it possible to create anonymous object returning Funcs as well as invoked objects from such Funcs.

Example 1:

Use Fn.Create to create a Func that returns a list of anonymous objects:

	var queryByCategoryAndColor = Fn.Create((string cateogory, string color)=>{
		return SomeDb.ProductsQuery.Where(p=>p.Color==color && p.Category==category).Select(p=> new {p.Id, p.Name});
	});

(You cannot create a func that returns anonymoys types otherwise, as you need to explicitly define the type var f = new Func<?>)

Example 2:

Use Fn.Invoke to enclose code inside a Func and return an anonymous object:

	var request = Fn.Invoke(()=>{
		var category = Request["category"];
		var color = Request["color"];
		if (category=="" && color=="") throw new Exception("Not allowed");
		return new {category, color};
	});

