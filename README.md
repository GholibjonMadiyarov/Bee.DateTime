# Bee.DateTime
Virtual data and time for clients

## Help, Feedback, Contribute
If you have any issues or feedback, please file an issue here in Github. We'd love to have you help by contributing code for new features, optimization to the existing codebase, ideas for future releases, or fixes!

## Example

```csharp
using Bee.DateTime;

static void Main(string[] args)
{
	//Correct datetime from server
	var datetimeFromString = "2024-07-27 12:02:00";
    
	var dt = new Bee.DateTime.DateTime();
	
	dt.StartComplete += Dt_StartComplete;
	dt.StartError += Dt_StartError;

	dt.start(datetimeFromString);
	
	//var now = dt.getNow();
}

private void Dt_StartError(int code, string message, string data)
{
    //Error
}

private void Dt_StartComplete(int code, string message, string data)
{
    //Successfully
	
	//var now = dt.getNow();
}