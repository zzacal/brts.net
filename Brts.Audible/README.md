# Audible

Audibles types allow you to listen for changes to a value. For example, when a value changes, the UI should reflect that change.

```csharp
var myVal = new Audible<int>(value: 0);

test.OnChange((newVal) => Console.WriteLine(newVal));

myVal.Value = 12
myVal.Value = 13

// Console Output
// > 12
// > 13
```
