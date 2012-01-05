StringConvert.com
======================================================================
For a live demo, visit [www.stringconvert.com](http://www.stringconvert.com)

## What is it?

This is a simple demo that shows how use [knockoutJs](http://knockoutjs.com) and the [knockoutJs mapping plugin](http://knockoutjs.com/documentation/plugins-mapping.html). While I was at it I added [SignalR](http://github.com/SignalR/SignalR) as well. 
Oh, [stringConvert.com](http://www.stringConvert.com) is a service that converts strings into other strings.

## What's useful to look at?
Well, the cool thing with the knockoutJs mapping plugin is that you can take CLR types and serialize them to Json and load create a knockout view model from it. I'm doing a very simple version of that as you can see [here](https://github.com/MikeEast/StringConvert.com/blob/master/StringConvert.WebClient/MainModule.cs#L12) and [here](https://github.com/MikeEast/StringConvert.com/blob/master/StringConvert.WebClient/Views/index.cshtml#L57).  

The cool part about this is that I'm having StructureMap injecting all types that implement `IConvertStrings` into the `converterRepository`. When I implement a new converter it gets added automatically as usual using the injection, but it also gets added in my knockout view model since I load the serialized list.  

The mapping plugin also lets me focus on behavior. I define properties in the CLR type which the mapping plugin automatically adds to the knockoutJs view model as observables. I implement functionality on the client side on the very same view model since the mapping plugin allows me to specify a target view model when mapping.

## The SignalR part.
I wanted to have a go at the SignalR framework as well. The implementation here is not making use of all that it offers but some of it anyway. I use it to asynchronously execute the converters server side and when I get the response I update the result field. However, somewhat notable is that SignalR allows us to return a `Task<>` which makes the async [implementation](https://github.com/MikeEast/StringConvert.com/blob/master/StringConvert.WebClient/Hubs/ConverterHub.cs#L28) really easy. Still, this could have been done using jQuery or whatever and I wanted to make at least one example of the cooler features that SignalR offers.  
I came up with the very useful feature that shows the user the "Latests conversions", where I use the SignalR `Hub.Clients` property to call a client side function from my CLR code. Note that it is called Client**s** and the effect is that I call the client side function on ALL the connected clients and this is where things become interesting. 

## Nancy
Event though [Nancy](https://github.com/NancyFx/Nancy) is an awesome MVC framework, this time I only used Nancy to look cool. There's no interaction between SignalR and Nancy and they are running side by side rather that together. I do have a [feeling](https://twitter.com/#!/davidfowl/status/152349863969947649) this will be sorted out soon though.

## dotLess & Twitter Bootstrap
As a bonus I am happy to finally have got the Twitter Bootstrap less edition working with dotLess. I got a syntax error but it was just a qualifier that was weird and I guess it is a less dialect issue. I wrote a post about it on my [sad sad blog](http://devva.net/blog/post/dotLess-Twitter-Boostrap-Less-and-Syntax-Error.aspx).  

That's about it I think. Enjoy. Questions: [@mikaelOstberg](http://twitter.com/MikaelOstberg)

If you implement a converter, feel free to send a pull request. :)