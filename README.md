# Checker
The minimum code to demo how to use expression tree/lambda, extension methods to implements fluent api.

# What's Fluent API
[This article](http://rrpblog.azurewebsites.net/?p=33) explains it much better than I ever could.

> there are two sides to interfaces, the implementation and the usage. There's more work to be done on the creation side, I agree with that, 
however the main benefits can be found on the usage side of things. 
Indeed, for me the main advantage of fluent interfaces is a more natural, easier to remember and use and why not, more aesthetically pleasing API. 
And just maybe, the effort of having to squeeze an API in a fluent form may lead to better thought out API?

As Martin Fowler says [in the original article about fluent interfaces](https://martinfowler.com/bliki/FluentInterface.html):

> Probably the most important thing to notice about this style is that the intent is to do something along the lines of an internal DomainSpecificLanguage. 
Indeed this is why we chose the term 'fluent' to describe it, in many ways the two terms are synonyms. The API is primarily designed to be readable and to flow. 
The price of this fluency is more effort, both in thinking and in the API construction itself. The simple API of constructor, setter, and addition methods is 
much easier to write. Coming up with a nice fluent API requires a good bit of thought.

As in most cases API's are created once and used over and over again, the extra effort may be worth it.