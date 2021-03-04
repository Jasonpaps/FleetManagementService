Use the Navigation bar to access the three entities: Containers, Vessels, Fleets.

Container: The user has the ability to create a container by giving a name and assigning it to the corresponding vessel if there is one. At any point the user can Edit, Delete or review the Details of existing containers. 
The user is able to make load transfers between the vessels by editing the given container and assigning it to a different Vessel. The target Vessel must have free space in order to make the transfer. 
Each Container must have a unique name.

Vessel:The user has the ability to create a vessel by giving it a name, defining how many containers it fits and assigning it to a Fleet if there is one. At any point the user can Edit, Delete or review the Details of existing Vesels.
The user can assign the vessels into different fleets by editing the corresponding Vessel.  Each Vessel must have a unique name. The Vessel cannot be deleted if there are containers assigned to it.

Fleet: The user has the ability to create a fleet by giving it a name.At any point the user can Edit, Delete or review the Details of existing Fleets. 
Each fleet must have a unique name. The Fleet cannot be deleted if there are Vessels assigned to it.

The platform works on MSSQLLocalDB. Sample instances are initialized the first time the platform runs.
