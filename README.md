# Parcel Distribution
<p>
<img src="https://dev.azure.com/alireza-es/ParcelDist/_apis/build/status/ParcelDist%20on%20GitHub-CI?branchName=master"/>
 </p>
 <p>
 <img src="[![Build Status](https://dev.azure.com/alireza-es/ParcelDist/_apis/build/status/ParcelDist%20on%20GitHub-CI?branchName=master)](https://dev.azure.com/alireza-es/ParcelDist/_build/latest?definitionId=4&branchName=master)"/>
 </p>
This is a hypothetical problem to practice SOLID design principles and show some agile practices like Automatic Build, Automatic Test, Continuous Integration (CI) and Continuous Delivery (CD).

## Problem
<p>
You work at a parcel delivery company and you are asked to design a system to automate the internal handling of parcels coming in.  
The parcels are coming in at the distribution center and need to be handled by different departments based on their weight and value.
</p>
<p>
Currently management is making plans that could lead to the adding or removal of departments in the future.  
</p>
<p>
The current business rules are as follows:
-   Parcels with a weight up to 1 kg are handled by the "Mail" departement.
-   Parcels with a weight up to 10 kg are handled by the "Regular" department.
-   Parcels with a weight over 10 kg are handled by the "Heavy" department.
-   Parcels with a value of over € 1000,- need to be signed off by the "Insurance" department, before being processed by Mail, Regular or Heavy department.
 </p>
 <p>

 
 ## Solution

 </p>
<p>
  <img src="https://raw.githubusercontent.com/fadamedia/ParcelDist/master/etc/design.jpg"/>
</p>
<p>
In this project, there are two types of department: IParcelProcessor, IParcelSigner. If management has a plan to remove a department, you should just remove it from organization structure.
</p>
<p>
If management wants to add a new department, you should add a new class and derive it from department and implement IParcelProcessor or IParcelSigner based on its type. Then you should add it to your organization structure. Organization structure is just a list of departments.
</p>
<p>
 
### Example of using Open/Close Principle(OCP) in solustion
 
 </p>
<p> 
It is “Open” to extend because you can easily create your type of department (IParcelProcessor or IParcelSigner) and implement its behaviors (Process or SignOff).  
 </p>
<p> 
It is “Close” for modification because ParcelDistributationService is working with interfaces, not concrete classes. Encapsulation occurs here.

 </p>
 <p>
 
### Example of using Interface Segration Principle(ISP) in solustion
 
 </p>
<p> 
Two multiple behaviors of the department (Processing or Signing Off) are put into two different interfaces (IParcelProcessor, IParcelSigner) instead of just one interface. 
  </p>
 <p>
So, the insurance department does not have to implement the Process method, because it does not know how to implement it.
 </p>

