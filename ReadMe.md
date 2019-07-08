 # AssertHelper

Library to apply assert on function. 
Personnal implementation of code contracts, compatible with actual VS version : 
https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/code-contracts


### Prerequisites

If you use `AssertHelper.CastleInterceptors` thinks to add reference to `castleCore` https://github.com/castleproject/Core
If you use `AssertHelper.ReflectionProxies` thinks to add reference to `System.Reflection.DispatchProxy` https://www.nuget.org/packages/system.reflection.dispatchproxy/

### Sample

##### Simplify If condition / throw

The **sample case** :
```
private void AssertFunc(object parameter)
{
    Assert.NotNull(parameter);

    Console.WriteLine("function logic");
}

[...]

AssertFunc("not null value");
AssertFunc(null);
```

1 : return : function logic    
2 : throw  NullAssertException => "parameter  : must be null but was not"
\
\
\
We can add **custom parameter name** :
```
private void AssertFunc(object specificName)
{
    Assert.NotNull(specificName, nameof(specificName));

    Console.WriteLine("function logic");
}

[...]

AssertFunc("not null value");
AssertFunc(null);
```
1 : return : function logic   
2 : throw  NullAssertException => "parameter **specificName** : must be null but was not"
\
\
\
We can add **custom message** :
```
private void AssertFunc(object specificName)
{
    Assert.NotNull(specificName, nameof(specificName), "specific message");

    Console.WriteLine("function logic");
}

[...]

AssertFunc("not null value");
AssertFunc(null);
```
1 : return : function logic    
2 : throw  NullAssertException => "parameter **specificName** : **specific message**"
\
\
\
Or use **custom exception** :
```
private void AssertFunc(object specificName)
{
    Assert.NotNull(specificName, new SpecificException("specific arguments"));
    Console.WriteLine("function logic");
}

[...]

AssertFunc("not null value");
AssertFunc(null);
```

1 : return : function logic    
2 : throw **SpecificException**


## Authors

* **Thibaut PILLON** - 

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

