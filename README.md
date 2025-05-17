# Bee.DateTime
Virtual data and time for clients

## Help, Feedback, Contribute
If you have any issues or feedback, please file an issue here in Github. We'd love to have you help by contributing code for new features, optimization to the existing codebase, ideas for future releases, or fixes!

## Example

```csharp
using System;

static void Main(string[] args)
{
	//Timestamp from server
	long? timestamp = 1747481774;
    
	//The given value will be incremented every second until the process is complete.
	var v = Bee.DateTime.DateTime.start(timestamp);
	
	if(v == false)
		return
		
	DateTime? dt = Bee.DateTime.DateTime.getDateTime();
	
	string dts = Bee.DateTime.DateTime.getDateTimeString("yyyy-MM-dd HH:mm:ss);
	
	long? ts = Bee.DateTime.DateTime.getTimestamp();
}
