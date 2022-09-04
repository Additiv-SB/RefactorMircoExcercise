TirePressureMonitoringSystem

S - Single responsibility
Class should have only one purpose - So, Alarm class has purpose for checking tire pressure boundaries and Sensor class has purpose for readind and giving tire pressure

O - Open closed principle
Classes should be open for extension, closed for modification 
We do not have to implement complex if statements and we could simple add new objects for example checcking visibility that could depends on ISensor interface so, that means this is open for new logic additions

L- Liskov substitution
This means that every subclass or derived class should be substituable for their base or parent class.

I - Inteface segregation
Interface should not force classes to implement large number of functions with multiple purposes or what they can't do.

D- Dependency inversion - Components should depend on abstractions not on concretions.
It states that the high-level module must not depend on the low-level module, but they should depend on abstractions.

 I've made interfaces IAlarm and ISensor where those interfaces help us to have separate functions in the file, and every class depends on they abstractions.


 Turn Ticket Dispenser

S - Single responsibility
Class should have only one purpose - So, Turn Ticket dispenser excercise has turn ticket, turnnumber sequence class have single responsibility

UnicodeFileToHtmlConverter

S - Class before refactoring has a multiple purpose to read html, convert it so I split it into 3 classes for single responsibilitz principle. 

L- IStreamReader is based on stream reader class implemented deeply.
DI - components depeneds on abstractions


TelemetrySystem

S, I and D - one class TelemtryClient and TelemetryDyagnosticControls have multiple purposes and dont depends on the apstractions so I Implement interfaces and split functions purposes
now classes depends on the apstractions
