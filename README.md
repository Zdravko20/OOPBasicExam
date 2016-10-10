OOP Basics Exam – System Split
You have been given the task to gather statistics about The System. The System is a network of components, connected together to build something which functions logically, but you don’t need to know that. You need to build a program which processes statistics about The System.
Overview
The System consists, mainly, of two types of components – Hardware and Software components.
Hardware components have a name, a type, a maximum capacity and a maximum memory.
There are 2 types of Hardware components:
Power Hardware – decreases 75% of its given capacity, and increases its memory by 75%.
Heavy Hardware – decreases 25% of its given memory and doubles its given capacity.
Software components have a name, a type, capacity consumption and memory consumption.
Express Software – doubles its given memory consumption.
Light Software – increases its given capacity consumption by 50% and decreases its given memory consumption by 50%.
Example: If a Power Hardware has 150 given capacity, his capacity will be – 75% from 150 =
150 – 
((150 * 3) / 4)   =   
150 – (450 / 4)   =   
150 – 112 = 38
Note that you are working with INTEGERS.
Software components are stored on Hardware components. Each Software component takes up a specific amount of capacity and a specific amount of memory from the Hardware, in order to function properly. When registered, a Software component is stored on a specified Hardware Component.
There are several main commands you should configure in order for your program to function as needed.
Commands
RegisterPowerHardware(name, capacity, memory)
RegisterHeavyHardware(name, capacity, memory)
Registers a Hardware component of the specified type on The System with the given name, capacity, and memory.
RegisterExpressSoftware(hardwareComponentName, name, capacity, memory)
RegisterLightSoftware(hardwareComponentName, name, capacity, memory)
Registers a Software component of the specified type on the given Hardware component, with the
given name. The Software Component takes up from the hardware’s capacity and memory – the given capacity and memory.
If the given Hardware component does NOT exist in The System, the command should do nothing.
If the given Hardware component does NOT have enough capacity or memory to contain the Software component, the command should do nothing.
ReleaseSoftwareComponent(hardwareComponentName, softwareComponentName)
Destroys the Software Component with the given name, from the Hardware Component with the given name.
In case there is NO such Hardware Component, in The System, the command should do nothing.
In case there is NO such Software Component, on the given Hardware Component, the command should do nothing.
Analyze()
Shows statistics about the components currently in The System in the following format:
“System Analysis
  Hardware Components: {countOfHardwareComponents}
  Software Components: {countOfSoftwareComponents}
  Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}
  Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}”
The total operational memory in use and total capacity taken is calculated from all the Software components currently in The System. You must also print the maximum memory and capacity available from all the Hardware Components currently in The System.
System Split
This command finalizes the work of the program, and prints information about the whole System.
The System is split, and all of the Hardware components are to be printed one by one.
The format of printing is the following:
“Hardware Component – {componentName}
  Express Software Components: {countOfExpressSoftwareComponents}
  Light Software Components: {countOfLightSoftwareComponents}
  Memory Usage: {memoryUsed} / {maximumMemory}
  Capacity Usage: {capacityUsed} / {maximumCapacity}
  Type: {Power/Heavy}
  Software Components: {softwareComponent1, softwareComponent2…}”
Power Hardware Components must be printed before the Heavy Hardware Components.
When printing the Software Components, print only their names.
In case the Hardware component does not have any Software Components, print “None”. 
The general order of output for all of the components is – by order of entrance.
Input
The input will come in the form of commands, in the format – specified above.
The input will consist only of the commands specified above.
The input ends when you receive the command “System Split”.
Output
The only output you must print is the one specified for the Analyze command, and the final output.
All of the output must be exactly in the format specified above.
Constraints
The names of the components will be strings, and will consist of English alphabet letters and digits.
The names of the Hardware Components will always be unique.
The names of the Software Components will be unique for every Hardware Component.
The memory and capacity of each component will be integer numbers in range [0, 231 - 1].
The type of a Hardware Component can be “Power”or “Heavy”.
The type of a Software Component can be “Express” or “Light”.
There will be NO invalid input commands.
Allowed time/memory: 250ms / 32MB.
